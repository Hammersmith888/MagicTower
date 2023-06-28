
#define FB_LOG
#if UNITY_WSA && !UNITY_EDITOR
#define WSA_FACEBOOK
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_WSA
using MarkerMetro.Unity.WinIntegration;
#if WSA_FACEBOOK
using MarkerMetro.Unity.WinIntegration.Facebook;
#endif
#if UNITY_WP_8_1 && !UNITY_EDITOR
	using FB = MarkerMetro.Unity.WinIntegration.Facebook.FBNative;
#elif UNITY_WSA_10_0
	using FB = MarkerMetro.Unity.WinIntegration.Facebook.FBUWP;
#else
#if WSA_FACEBOOK
		using FB = MarkerMetro.Unity.WinIntegration.Facebook.FB;
#else
		using Facebook.Unity;
#endif
#endif
#else
using Facebook.Unity;
#endif

using CloudDBType = Native.FirebaseManager.EDBType;

namespace Social
{
    public enum WebConnectionState
    {
        NoInternet,
        Connect
    }

    [System.Flags]
    public enum EFacebookAccountLoginFlags
    {
        None = 0,
        FirstLogin = 1 << 0,
        AccountChanged = 1 << 1,
        SameAccount = 1 << 2
    }

    [System.Serializable]
    public class FacebookUser
    {
        public string name;
        public string id;
        public Sprite picture;
    }

    public class FacebookManager : MonoSingleton<FacebookManager>, IWaitInitializationFlagHolder, IPendingOperation
    {
        #region EVENTS
        public static UnityAction OnFacebookLogin = delegate { };
        public static UnityAction OnFacebookLogout = delegate { };
        #endregion

        #region CONSTANTS
        private const string REQUIRE_FACEBOOK_GRAPH = "https://graph.facebook.com/";
        private const string QUERY_USER_ME = "/me?fields=id,name,picture.width(120).height(120)";
#if WSA_FACEBOOK
		private const string APP_ID = "130208764223809";
		private const string QUERY_USER_APP_URL = "https://fb.me/130208764223809";
#else
        private const string APP_ID = "130208764223809";
        private const string QUERY_USER_APP_URL = "https://fb.me/130208764223809";
#endif
        private const string QUERY_USER_FRIENDS_IN = "/me/friends?fields=id,name,picture.width(120).height(120)";
        private const string QUERY_USER_APP_REQUESTS = "/me/apprequests";
        //private const string QUERY_USER_FRIENDS_INVITE = "/me/taggable_friends?fields=id,name,picture.width(120).height(120)";
        private const string OBJECT_LIFE_ID = "1284702278313102";
        private const string DATA_ASK = "Ask";
        private const string DATA_SEND = "Send";

        private const int TIMEOUT_LIMIT = 10;
        #endregion

        #region PROPERTY
        public bool isInitialized
        {
            get; private set;
        }

        public bool isLoggedIn
        {
            get
            {
                return FB.IsLoggedIn && currentUser != null;
            }
        }

        public bool isLoadingUserData
        {
            get
            {
                return currentLoadingUserData;
            }
        }

        public FacebookUser User
        {
            get
            {
                return currentUser;
            }
        }

        public List<FacebookUser> friendsOnline
        {
            get
            {
                return currentFriendsInGame;
            }
        }

        public List<FacebookUser> friendsInvite
        {
            get
            {
                return currentFriendsInvite;
            }
        }

        public List<MessagesData> friendsRequests
        {
            get
            {
                return currentFriendsRequests;
            }
        }

        public static string LastLoggedInFacebookID
        {
            get { return SPlayerPrefs.GetString("FacebookID", null); }
            set { SPlayerPrefs.SetString("FacebookID", value); }
        }
        #endregion

        private List<FacebookUser> currentFriendsInGame = new List<FacebookUser>();
        private List<FacebookUser> currentFriendsInvite = new List<FacebookUser>();
        private List<MessagesData> currentFriendsRequests = new List<MessagesData>();
        private FacebookUser currentUser = null;
        private bool currentLoadingUserData = false;
        private bool currentlyLoadingAppRequests = false;
        //If this flag is true then there is silent login operation running and we don't display message windows
        private bool currentAutoLogin = false;
        private int operationsStarted = 0;
        private bool initializing;
        private bool wasErrorOnLogin;

        protected override void Awake()
        {
            if (s_Instance != null && s_Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            s_Instance = this;
            DontDestroyOnLoad(gameObject);
#if WSA_FACEBOOK
			FB.Init( ( ) =>
			{
				if( FB.IsLoggedIn )
				{
					currentAutoLogin = true;
					StartCoroutine( CheckInternetConnection( OnInternetConnection ) );
				}
				else
				{
					//FirebaseSavesByDeviceController.Instance.Activate();
					isInitialized = true;
				}
			}, APP_ID, null );
#else
            Debug.Log("<b>FB INIT CALL</b>");
            FB.Init(() =>
           {
               if (FB.IsLoggedIn)
               {
                   currentAutoLogin = true;
                   StartCoroutine(CheckInternetConnection(OnInternetConnection));
               }
               else
               {
                   isInitialized = true;
               }
           });
#endif
        }

        [System.Diagnostics.Conditional("FB_LOG")]
        private void Log(string message, params object[] args)
        {
            if (args.Length > 0)
            {
                Debug.LogFormat(message, args);
            }
            else
            {
                Debug.Log(message);
            }
        }

        [System.Diagnostics.Conditional("FB_LOG")]
        private void LogError(string message, params object[] args)
        {
            if (args.Length > 0)
            {
                Debug.LogErrorFormat(message, args);
            }
            else
            {
                Debug.LogError(message);
            }
        }

        #region PENDING OPERATION RELATED
        private bool registeredAsPendingOperation;
        private bool pendingOperationAlreadyCompleted;
        private System.Action<bool> pendingOperationCompletionCallback;
        public void RegisterAsPendingOperation()
        {
            if (!registeredAsPendingOperation)
            {
                registeredAsPendingOperation = true;
                PendingOperationsManager.Instance.AddPendingOperation(this);
            }
        }

        public void StartOperation(System.Action<bool> operationResultCallback)
        {
            if (currentLoadingUserData || pendingOperationAlreadyCompleted || !FB.IsLoggedIn)
            {
                CompletePendingOperationWithResult(true);
                return;
            }

            pendingOperationCompletionCallback = operationResultCallback;
            StartCoroutine(CheckInternetConnection((WebConnectionState connectionState) =>
            {
                if (connectionState == WebConnectionState.Connect)
                {
                    currentAutoLogin = true;
                    OnInternetConnection(connectionState);
                }
                else
                {
                    pendingOperationCompletionCallback.InvokeSafely(false);
                    pendingOperationCompletionCallback = null;
                }
            }));
        }

        private void CompletePendingOperationWithResult(bool operationResult)
        {
            if (registeredAsPendingOperation)
            {
                registeredAsPendingOperation = !operationResult;
                pendingOperationAlreadyCompleted = operationResult;
                pendingOperationCompletionCallback.InvokeSafely(operationResult);
                pendingOperationCompletionCallback = null;
            }
        }
        #endregion

        #region EXTERNAL
        public void Login()
        {
            if (FB.IsInitialized)
            {
                FacebookUIController.ShowMessageWindow("", false);//Will be showed localized description
                StartCoroutine(CheckInternetConnection(OnInternetConnection)); 
            }
        }

        public void Logout()
        {
            if (FB.IsLoggedIn)
            {
#if WSA_FACEBOOK
				FB.Logout();
#else
                FB.LogOut();
#endif
                currentUser = null;
                currentAutoLogin = false;
                currentLoadingUserData = false;
                operationsStarted = 0;

                currentFriendsInGame.Clear();
                currentFriendsInvite.Clear();
                currentFriendsRequests.Clear();

                OnFacebookLogout();
            }
        }

        public void Invite(List<FacebookUser> users = null)
        {
#if WSA_FACEBOOK
				FB.AppRequest( message: "Come Play MagicSiege!", callback: ( result ) =>
				{
					Debug.Log( "AppRequest result: " + result.Text );
#if !UNITY_WSA_10_0
					if( result.Json != null )
						Debug.Log( "AppRequest Json: " + result.Json.ToString() );
#endif
#if UNITY_WP_8_1
		                }, title: "MagicSiege Invite");
#else
				} );
#endif

#else

#endif
        }

        public void RequestLife(List<FacebookUser> users)
        {
            if (users == null)
                return;

#if WSA_FACEBOOK
#else
            int length = Mathf.Max(users.Count, 50);
            string[] userIDs = new string[length];
            //Количество получателей, которых можно указать в поле to, ограничено. Если быть точнее — не более 50 друзей, а для Internet Explorer 8 и более ранних версий — не более 26.
            //https://developers.facebook.com/docs/games/services/gamerequests
            for (int i = 0; i < length; i++)
            {
                userIDs[i] = users[i].id;
            }

            if (userIDs.Length > 0)
            {
                FB.AppRequest("Help Me! Give me a life!", OGActionType.ASKFOR, OBJECT_LIFE_ID, userIDs, DATA_ASK, "Ask Life", (IAppRequestResult r) =>
               {
                   Debug.Log("Ask Object: " + r.RawResult);
               });
            }
            else
            {
                Debug.Log("[FacebookManager.cs] No selected friend id's");
            }
#endif
        }

        public void SendLife(string[] userIDs)
        {
            if (userIDs == null && userIDs.Length > 0)
                return;
#if WSA_FACEBOOK
#else

            FB.AppRequest("This is the Life for You!", OGActionType.SEND, OBJECT_LIFE_ID, userIDs, DATA_SEND, "Send Life", (IAppRequestResult r) =>
           {
               Debug.Log("Send Object: " + r.RawResult);
           });
#endif
        }

        public void DeleteRequest(string id)
        {
            if (string.IsNullOrEmpty(id))
                return;

            StartCoroutine(CheckInternetConnection((WebConnectionState state) =>
          {
              if (state == WebConnectionState.NoInternet)
              {
                  //UIPopupTextMessage.current.Show( "Check your internet connection...", "Internet" );

                  Logout();
                  return;
              }
          }));
#if WSA_FACEBOOK
#else

            FB.API(id, HttpMethod.DELETE, (IGraphResult r) =>
           {
               if (r.Error == null && !r.Cancelled)
               {
                   Debug.Log("[FacebookManager.cs] Delete Request: " + id);
               }
           });
#endif
        }
        //TODO
#if !WSA_FACEBOOK
        public void CreateGraphObject()
        {
            Dictionary<string, object> formData = new Dictionary<string, object>();
            formData["og:title"] = "Life fo my friends!";
            formData["og:type"] = "product";
            formData["fb:app_id"] = APP_ID;

            Dictionary<string, string> formDic = new Dictionary<string, string>();
            formDic["object"] = Facebook.MiniJSON.Json.Serialize(formData);

            FB.API("me/objects/object", HttpMethod.POST, (IGraphResult r) =>
           {
               Debug.Log(r.RawResult);

               if (!string.IsNullOrEmpty(r.Error))
                   return;


               string id;

               if (r.ResultDictionary.TryGetValue("id", out id))
               {
                   Debug.Log(id);

                   FB.AppRequest("Help, i need a life!", OGActionType.ASKFOR, id, null, "", "Ask For Life", (IAppRequestResult req) =>
                   {
                       Debug.Log(req.RawResult);
                   });
               }
           },
                formDic);
        }
#endif

        #endregion

        #region INTERNAL
        private void InitializeFacebook(System.Action onSucess)
        {
            initializing = true;

#if WSA_FACEBOOK
			FB.Init( ( ) =>
			{
				onSucess();
			}, "130208764223809", null );
#else
            FB.Init(() =>
           {
               initializing = false;
               onSucess();
           });
#endif
        }

        private void OnFacebookLoginError(bool tryLoginInBackgroundLater = true)
        {
#if UNITY_EDITOR || DEBUG_MODE
            Debug.LogFormat("OnFacebookLoginError: Is Logged In {0}", FB.IsLoggedIn);
#endif
            wasErrorOnLogin = true;
            FacebookUIController.ChangeStatusIcon(FacebookUIController.EConnectionState.NOT_CONNECTED);
            CompletePendingOperationWithResult(!tryLoginInBackgroundLater);
            //FirebaseSavesByDeviceController.Instance.Activate();
        }

        private void LoginInternal()
        {
            wasErrorOnLogin = false;
#if WSA_FACEBOOK
			FB.Login( "user_friends,email,public_profile,", ( FBResult r ) =>
			{
				if( r.Error != null )
				{
					isInitialized = true;
					OnFacebookLoginError();
					if( r.Error == "-1" )
					{
						FacebookUIController.ShowMessageWindow( "Login was cancelled" );
					}
					else
					{
						FacebookUIController.ShowMessageWindow( "Error on login" );
					}
					Debug.LogError( "[FacebookManager.cs] Error on login: " + r.Error );
					return;
				}
				//FacebookUIController.CloseMessageWindow();
				LoadUserData();
			} );
#else
            string[] userPermissions = new string[] {  "email", "public_profile" }; //"user_friends",
            FB.LogInWithReadPermissions(userPermissions, (ILoginResult r) =>
            {
                if (r.Error != null)
                {
                    isInitialized = true;
                    OnFacebookLoginError();
                    FacebookUIController.ShowMessageWindow("Error on login");
                    Debug.LogError("[FacebookManager.cs] Error on login: " + r.Error);
                    return;
                }

                if (r.Cancelled)
                {
                    isInitialized = true;
                    OnFacebookLoginError();
                    FacebookUIController.ShowMessageWindow("Login canceled");
                    Debug.Log("[FacebookManager.cs] Login process canceled");
                    return;
                }
                //FacebookUIController.CloseMessageWindow();
                FB.ActivateApp();
                LoadUserData();
            });
#endif
        }

        private void OnInternetConnection(WebConnectionState connectionState)
        {
            if (connectionState == WebConnectionState.Connect)
            {
                Debug.Log("[FacebookManager.cs] Connection to facebook...");

                if (!FB.IsLoggedIn)
                {
                    LoginInternal();
                }
                else
                {
                    LoadUserData();
                }
            }
            else
            {
                isInitialized = true;
                RegisterAsPendingOperation();
                FacebookUIController.ChangeStatusIcon(FacebookUIController.EConnectionState.NOT_CONNECTED);
                if (!currentAutoLogin)
                {
                    FacebookUIController.ShowMessageWindow("Connection error.\nCheck your internet connection...");
                }
                else
                {
                    FacebookUIController.CloseMessageWindow();
                }
            }
        }

        private void LoadUserData()
        {
            if (currentLoadingUserData)
            {
                FacebookUIController.ShowMessageWindow("You are already logged in!");
                return;
            }

            if (!currentAutoLogin)
            {
                FacebookUIController.ShowMessageWindow("", false);//Will be showed localized description 
            }
            currentLoadingUserData = true;
            operationsStarted++;
            wasErrorOnLogin = false;
            FB.API(QUERY_USER_ME, HttpMethod.GET,
#if WSA_FACEBOOK
		( FBResult fbResult ) =>	{
		IGraphResult r = new IGraphResult( fbResult );
#else
        (IGraphResult r) =>
        {
#endif
            try
            {
                if (r.Error != null)
                {
                    operationsStarted--;
                    currentLoadingUserData = false;
                    Debug.LogError("[FacebookManager.cs] Error on query user data: " + r.Error);
                    OnFacebookLoginError();
                    RegisterAsPendingOperation();
                    if (!currentAutoLogin)
                    {
                        FacebookUIController.ShowMessageWindow("Error on query user data.");
                    }
                    return;
                }

                if (r.Cancelled)
                {
                    operationsStarted--;
                    currentLoadingUserData = false;
                    OnFacebookLoginError();
                    RegisterAsPendingOperation();
                    if (!currentAutoLogin)
                    {
                        FacebookUIController.ShowMessageWindow("Facebook login process canceled.");
                    }
                    return;
                }
#if UNITY_EDITOR
                Debug.Log(r.RawResult);
#endif

                object username = "User", id;

                r.ResultDictionary.TryGetValue("name", out username);
                r.ResultDictionary.TryGetValue("id", out id);

                currentUser = new FacebookUser();
                currentUser.name = username as string;
                currentUser.id = id as string;//"1979473938731227";

#if UNITY_EDITOR
                Debug.Log(currentUser.id);
#endif

                operationsStarted++;
                StartCoroutine(DownloadImageByID(currentUser.id, () =>
              {
                  operationsStarted--;
              }));

                LoadStorageSave();
            }
            catch (System.Exception e)
            {
                operationsStarted--;
                currentLoadingUserData = false;
                OnFacebookLoginError();
                RegisterAsPendingOperation();
                if (!currentAutoLogin)
                {
                    FacebookUIController.ShowMessageWindow("Unknown Error");
                }
                Debug.LogError("Error1: " + e.Message);
            }
        });

            #region QUERY USER FRIENDS
            operationsStarted++;
            FB.API(QUERY_USER_FRIENDS_IN, HttpMethod.GET,
#if WSA_FACEBOOK
		( FBResult fbResult ) =>	{
		IGraphResult r = new IGraphResult( fbResult );
#else
        (IGraphResult r) =>
        {
#endif
            try
            {
                if (r.Error != null)
                {
                    operationsStarted--;
                    Debug.LogError("[FacebookManager.cs] Error on query user friends in game: " + r.Error);
                    return;
                }

                if (r.Cancelled)
                {
                    operationsStarted--;
                    return;
                }
                operationsStarted--;
#if UNITY_EDITOR || DEBUG_MODE
                Debug.Log(r.RawResult);
#endif

                object dataList = null;

                if (r.ResultDictionary.TryGetValue("data", out dataList))
                {
                    var friendsList = (List<object>)dataList;

                    foreach (object friend in friendsList)
                    {
#if WSA_FACEBOOK
						Facebook.JsonObject userData = friend as Facebook.JsonObject;
#else
                        Dictionary<string, object> userData = friend as Dictionary<string, object>;
#endif
                        FacebookUser user = new FacebookUser();
                        object name, id;

                        if (userData.TryGetValue("id", out id))
                        {
                            user.id = id.ToString();
                        }

                        if (userData.TryGetValue("name", out name))
                        {
                            user.name = name.ToString();
                        }

                        Debug.LogFormat("FB Friend: {0} {1}", name, id);

                        currentFriendsInGame.Add(user);

                        string url = DeserializePictureURL(friend);

                        if (!string.IsNullOrEmpty(url))
                        {
                            operationsStarted++;
                            StartCoroutine(DownloadImageByURL(url, user, () =>
                          {
                              operationsStarted--;
                          }));
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error2: " + e.Message);
            }
        });
            #endregion

            #region QUERY USER APP REQUESTS
            if (!currentlyLoadingAppRequests)
            {
                operationsStarted++;
                currentlyLoadingAppRequests = true;
                FB.API(QUERY_USER_APP_REQUESTS, HttpMethod.GET,
#if WSA_FACEBOOK
		( FBResult fbResult ) =>	{

		IGraphResult r = new IGraphResult( fbResult );
#else
        (IGraphResult r) =>
        {
#endif
            try
            {
                if (r.Error != null)
                {
                    currentlyLoadingAppRequests = false;
                    operationsStarted--;
                    return;
                }

                if (r.Cancelled)
                {
                    currentlyLoadingAppRequests = false;
                    operationsStarted--;
                    return;
                }
                Debug.Log(r.RawResult);

                object dataList;

                if (r.ResultDictionary.TryGetValue("data", out dataList))
                {
                    var messages = (List<object>)dataList;

                    foreach (object message in messages)
                    {
                        Dictionary<string, object> messageData = message as Dictionary<string, object>;
                        object id, data, nameFrom = null, idFrom = null;
                        string dataAstString = null;

                        if (messageData.TryGetValue("data", out data))
                        {
                            dataAstString = (string)data;
                            switch (dataAstString)
                            {
                                case DATA_ASK:
                                case DATA_SEND:
                                    break;
                                default:
                                    continue;
                            }
                        }

                        if (string.IsNullOrEmpty(dataAstString))
                            continue;


                        messageData.TryGetValue("id", out id);

                        object fromObj;

                        if (messageData.TryGetValue("from", out fromObj))
                        {
                            var fromData = fromObj as Dictionary<string, object>;

                            fromData.TryGetValue("id", out idFrom);
                            fromData.TryGetValue("name", out nameFrom);
                        }

                        FacebookUser user = new FacebookUser();
                        user.id = (string)idFrom;
                        user.name = (string)nameFrom;

                        MessagesData messageUser = new MessagesData();
                        messageUser.requestID = (string)id;
                        messageUser.type = dataAstString.Contains(DATA_SEND) ? MessagesType.Send : MessagesType.Ask;
                        messageUser.user = user;

                        currentFriendsRequests.Add(messageUser);
                    }
                }
                currentlyLoadingAppRequests = false;
                operationsStarted--;
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error3: " + e.Message);
            }
        });
            }
            #endregion

            StartCoroutine(WaitingLoadingUserData());
        }

        public void RefreshAppRequests(System.Action<bool> onRequestComplete)
        {
            Debug.Log("RefreshAppRequests");
            StartCoroutine(CheckInternetConnection((WebConnectionState connectionState) =>
          {
              if (currentlyLoadingAppRequests)
              {
                  Debug.Log("RefreshAppRequests failed because of currentlyLoadingAppRequests is true");
                  onRequestComplete(false);
                  return;
              }
              if (connectionState == WebConnectionState.Connect && FB.IsLoggedIn)
              {
                  currentlyLoadingAppRequests = true;
                  FB.API(QUERY_USER_APP_REQUESTS, HttpMethod.GET,
#if WSA_FACEBOOK
		    ( FBResult fbResult ) =>	{
		    IGraphResult r = new IGraphResult( fbResult );
#else
            (IGraphResult r) =>
          {
#endif
              if (r.Error != null)
              {
                  currentlyLoadingAppRequests = false;
                  onRequestComplete(false);
                  return;
              }

              if (r.Cancelled)
              {
                  currentlyLoadingAppRequests = false;
                  onRequestComplete(false);
                  return;
              }

              currentFriendsRequests.Clear();
              Debug.Log("RefreshAppRequests " + r.RawResult);

              object dataList;

              if (r.ResultDictionary.TryGetValue("data", out dataList))
              {
                  var messages = (List<object>)dataList;
                  foreach (object message in messages)
                  {
                      Dictionary<string, object> messageData = message as Dictionary<string, object>;
                      object id, data, nameFrom = null, idFrom = null;
                      string dataAstString = null;

                      if (messageData.TryGetValue("data", out data))
                      {
                          dataAstString = (string)data;
                          switch (dataAstString)
                          {
                              case DATA_ASK:
                              case DATA_SEND:
                                  break;
                              default:
                                  continue;
                          }
                      }

                      if (string.IsNullOrEmpty(dataAstString))
                          continue;


                      messageData.TryGetValue("id", out id);

                      object fromObj;

                      if (messageData.TryGetValue("from", out fromObj))
                      {
                          var fromData = fromObj as Dictionary<string, object>;

                          fromData.TryGetValue("id", out idFrom);
                          fromData.TryGetValue("name", out nameFrom);
                      }

                      FacebookUser user = new FacebookUser();
                      user.id = (string)idFrom;
                      user.name = (string)nameFrom;

                      MessagesData messageUser = new MessagesData();
                      messageUser.requestID = (string)id;
                      messageUser.type = dataAstString.Contains(DATA_SEND) ? MessagesType.Send : MessagesType.Ask;
                      messageUser.user = user;

                      currentFriendsRequests.Add(messageUser);
                  }
              }
              currentlyLoadingAppRequests = false;
              onRequestComplete(true);
          });
              }
              else
              {
                  onRequestComplete(false);
              }
          }));
        }

        private string DeserializePictureURL(object userObject)
        {
#if WSA_FACEBOOK
		Facebook.JsonObject user = userObject as Facebook.JsonObject;

		object pictureObj;

		if( user.TryGetValue( "picture", out pictureObj ) )
		{
			var pictureData = ( Facebook.JsonObject ) ( ( ( Facebook.JsonObject ) pictureObj )[ "data" ] );
			return ( string ) pictureData[ "url" ];
		}
#else
            Dictionary<string, object> user = userObject as Dictionary<string, object>;
            object pictureObj;

            if (user.TryGetValue("picture", out pictureObj))
            {
                var pictureData = (Dictionary<string, object>)(((Dictionary<string, object>)pictureObj)["data"]);
                return (string)pictureData["url"];
            }
#endif
            return null;
        }

        private bool IsNullOrEmpty(string str)
        {
            return string.IsNullOrEmpty(str) || str.ToLower().Trim() == "null";
        }

        private void LoadStorageSave()
        {
            if (string.IsNullOrEmpty(currentUser.id))
            {
                OnLoadStorageSaveFailed();
                return;
            }

            operationsStarted++;
            var currentFacebookID = LastLoggedInFacebookID;
            LastLoggedInFacebookID = User.id;
            Debug.Log($"xxxx currentFacebookID: {currentFacebookID} xxxxx, User.id: {User.id}");
            var accountLoginFlags = EFacebookAccountLoginFlags.None;
            if (string.IsNullOrEmpty(currentFacebookID))
            {
                accountLoginFlags |= EFacebookAccountLoginFlags.FirstLogin;
            }
            if (currentFacebookID != User.id)
            {
                accountLoginFlags |= EFacebookAccountLoginFlags.AccountChanged;
            }
            else
            {
                accountLoginFlags |= EFacebookAccountLoginFlags.SameAccount;
            }
            var facebookAccountWasChanged = !string.IsNullOrEmpty(currentFacebookID) && currentFacebookID != User.id;
            //LoadFromCloudQueue.PutOperationToQueue(() =>
            //{
            //    //Loading data about UserID by FacebookID
            //    Native.FirebaseManager.Instance.ReadUserData(currentUser.id, CloudDBType.FACEBOOK_ID_MAP, (string data, bool isError) =>
            //    {
            //        operationsStarted--;
            //        if (isError)
            //        {
            //            OnLoadStorageSaveFailed();
            //            return;
            //        }
            //        else if (!IsNullOrEmpty(data))//UserID by FacebookID Map Exists
            //        {
            //            Native.UserIDWrap userIDData = null;
            //            try
            //            {
            //                userIDData = JsonUtility.FromJson<Native.UserIDWrap>(data);
            //            }
            //            catch (System.Exception exception)
            //            {
            //                LogError("LoadStorageSave (Getting UserID by FacebookID): {0}", exception.Message);
            //                OnLoadStorageSaveFailed();
            //                return;
            //            }

            //            ProcessProfileLoadingByProfileID(userIDData.userID, accountLoginFlags, (bool successfully) =>
            //            {
            //                Log("Process Profile Loading By PlayerID. Successfully: {0}", successfully);
            //                if (successfully)
            //                {
            //                    //GameManager.Instance.SetProfileFacebookID(currentUser.id);
                               CompletePendingOperationWithResult(true);
            //                   FirebaseSavesByDeviceController.Disable();
            LoadFromCloudQueue.OnCompleteLoadFromCloud();
            //                    currentLoadingUserData = false;
            //                }
            //            });
            //        }
            //        else//No data about UserID by FacebookID was found
            //        {
            //            Log("Trying Load Save Data By FacebookID");
            //            TryLoadSaveByFacebookID(facebookAccountWasChanged, (bool successfully) =>
            //            {
            //                if (successfully)
            //                {
            //                    CompletePendingOperationWithResult(true);
            //                    FirebaseSavesByDeviceController.Disable();
            //                    LoadFromCloudQueue.OnCompleteLoadFromCloud();
            //                    currentLoadingUserData = false;
            //                }
            //                else
            //                {
            //                    LogError("TryLoadSaveByFacebookID: Loading save data by Facebook ID Error");
            //                    OnLoadStorageSaveFailed();
            //                }
            //            });
            //        }
            //    });
            //});
        }

        private void TryLoadSaveByFacebookID(bool facebookAccountWasChanged, System.Action<bool> onComplete)
        {
            operationsStarted++;
            //Native.FirebaseManager.Instance.ReadUserData(currentUser.id, CloudDBType.USER_ID, (string data, bool isError) =>
            //{
            //    operationsStarted--;
            //    if (isError)
            //    {
            //        onComplete(false);
            //    }
            //    else
            //    {
            //        if (!IsNullOrEmpty(data))
            //        {
            //            SaveManager.Instance.OnStorageSaveLoaded(data, facebookAccountWasChanged);
            //        }
            //        else//No save data by FacebookID was found in cloud storage
            //        {
            //            Log("FirstFacebookLogin");
            //            //Этот аккаунт впервые связан с фейсбуком, сохраняем все данные игрока в облаке и выдаем награду за вход через фейсбук
            //            SaveManager.Instance.OnFirstFacebookLogin();
            //        }
            //        SaveDataAboutFacebookIdByProfileID();
            //        onComplete(true);
            //    }
            //});
        }

        private void SaveDataAboutFacebookIdByProfileID()
        {
            // If no data about FacebookID -> UserID in db creating new and writing to Cloud DB
            //GameManager.Instance.SetProfileFacebookID(currentUser.id);
            var jsonDataToSend = JsonUtility.ToJson(new Native.UserIDWrap() { userID = SaveManager.ProfileSettings.CurrentProfileID });
            Native.FirebaseManager.Instance.SaveUserData(currentUser.id, jsonDataToSend, CloudDBType.FACEBOOK_ID_MAP);

            Log("SaveDataAboutFacebookIdByProfileID ProfileID:{0} FacebookID:{1}", SaveManager.ProfileSettings.CurrentProfileID, currentUser.id);
        }

        private void ProcessProfileLoadingByProfileID(string profileID, EFacebookAccountLoginFlags facebookAccountLoginFlags, System.Action<bool> onComplete)
        {
            operationsStarted++;
            //Native.FirebaseManager.Instance.ReadUserData(profileID, CloudDBType.USER_ID, (string data, bool isError) =>
            //{
            //    operationsStarted--;

            //    if (IsNullOrEmpty(data))
            //    {
            //        LogError("LoadStorageSave: Data is Null");
            //        onComplete.InvokeSafely(true);
            //    }

            //    //string storageProfileID = null;
            //    Hashtable storageData = null;
            //    try
            //    {
            //        storageData = JSON.JsonDecode(data) as Hashtable;
            //        //var profileSettings = SaveConflictResolver.GetStorageSinglePref<SaveManager.ProfileSettings>(storageData, EPrefsKeys.ProfileSettings.ToString());
            //        //storageProfileID = profileSettings.ProfileID;
            //    }
            //    catch (System.Exception exception)
            //    {
            //        LogError("LoadStorageSave: {0}", exception.Message);
            //        OnLoadStorageSaveFailed();
            //        onComplete.InvokeSafely(false);
            //        return;
            //    }

            //    var currentProfileID = SaveManager.ProfileSettings.CurrentProfileID;
            //    Log("<b>ProcessProfileLoadingByProfileID</b> currentProfileID: {0}  storageProfileID: {1}. Login Flags: {2}", currentProfileID, profileID, facebookAccountLoginFlags);

            //    if (currentProfileID == profileID || string.IsNullOrEmpty(currentProfileID))
            //    {
            //        SaveManager.ProfileSettings.SetProfileID(profileID);
            //        if (SaveConflictResolver.DeviceProgressIsBetter(storageData))
            //        {
            //           // SaveDataAboutFacebookIdByProfileID();
            //            SaveManager.Instance.SaveAllToStorage(CloudDBType.USER_ID);
            //        }
            //        else
            //        {
            //            SaveManager.Instance.OverrideSavesData(storageData);
            //            SaveManager.ProfileSettings.SetProfileID(profileID);
            //        }
            //    }
            //    else
            //    {
            //        if ((facebookAccountLoginFlags & (EFacebookAccountLoginFlags.FirstLogin | EFacebookAccountLoginFlags.SameAccount)) != 0)
            //        {
            //            if (SaveConflictResolver.DeviceProgressIsBetter(storageData))
            //            {
            //                SaveManager.ProfileSettings.SetProfileID(profileID);
            //                SaveManager.Instance.SaveAllToStorage(CloudDBType.USER_ID);
            //            }
            //            else
            //            {
            //                SaveManager.Instance.OverrideSavesData(storageData);
            //                SaveManager.ProfileSettings.SetProfileID(profileID);
            //            }
            //        }
            //        else if ((facebookAccountLoginFlags & EFacebookAccountLoginFlags.AccountChanged) != 0)
            //        {
            //            SaveManager.Instance.OverrideSavesData(storageData);
            //            SaveManager.ProfileSettings.SetProfileID(profileID);
            //        }
            //    }
            //    onComplete.InvokeSafely(true);
            //});
        }

        private void OnLoadStorageSaveFailed()
        {
            Logout();
            currentLoadingUserData = false;
            OnFacebookLoginError(false);
            if (!currentAutoLogin)
            {
                FacebookUIController.ShowMessageWindow("Error on Data Loading");
            }
            LoadFromCloudQueue.OnCompleteLoadFromCloud();
        }
        #endregion

        #region COROUTINE
        private IEnumerator DownloadImageByID(string id, UnityAction callback)
        {
            WWW request = new WWW(REQUIRE_FACEBOOK_GRAPH + id + "/picture?type=large");
            yield return request;

            if (request.error != null)
            {
                Log("[FacebookManager.cs] Error Download Image By URL: " + request.error);

                if (callback != null)
                    callback();

                yield break;
            }

            Texture2D textureUserImage = new Texture2D(128, 128, TextureFormat.DXT1, false);
            request.LoadImageIntoTexture(textureUserImage);
            User.picture = Sprite.Create(textureUserImage, new Rect(0, 0, textureUserImage.width, textureUserImage.height), new Vector2(textureUserImage.width / 2, textureUserImage.height / 2));

            if (callback != null)
                callback();
        }

        private IEnumerator DownloadImageByURL(string url, FacebookUser user, UnityAction callback)
        {
            WWW request = new WWW(url);
            yield return request;

            if (request.error != null)
            {
                Debug.Log("[FacebookManager.cs] Error Download Image By URL: " + request.error);

                if (callback != null)
                    callback();

                yield break;
            }

            if (user != null)
            {
                Texture2D textureUserImage = new Texture2D(120, 120, TextureFormat.DXT1, false);
                request.LoadImageIntoTexture(textureUserImage);

                Sprite spr = Sprite.Create(textureUserImage, new Rect(0, 0, textureUserImage.width, textureUserImage.height), new Vector2(textureUserImage.width / 2, textureUserImage.height / 2));
                user.picture = spr;
            }

            if (callback != null)
                callback();
        }

        private IEnumerator CheckInternetConnection(UnityAction<WebConnectionState> connection)
        {
            WWW request = new WWW("http://google.com");
            yield return request;

            WebConnectionState stateConnection = !string.IsNullOrEmpty(request.error) ? WebConnectionState.NoInternet : WebConnectionState.Connect;
            connection(stateConnection);
        }

        private IEnumerator WaitingLoadingUserData()
        {
            float timeout = 0.0f;
            yield return new WaitForEndOfFrame();
            FacebookUIController.ShowMessageWindow("Downloading Profile data...", false);
            //UIPopupFacebookConnect.current.Show( "Facebook", "Download Profile data...", false );

            while (operationsStarted > 0)
            {
                yield return null;
                timeout += Time.unscaledDeltaTime;

                if (timeout >= TIMEOUT_LIMIT)
                {
                    Log("WaitingLoadingUserData ended by timeout");
                    operationsStarted = 0;
                }
            }
            if (!wasErrorOnLogin)
            {
                FacebookUIController.ChangeStatusIcon(FacebookUIController.EConnectionState.CONNECTED);
                //FacebookUIController.ShowMessageWindow(TextSheetLoader.GetStringST("t_0268"));
                Log("[FacebookManager.cs] On Login Complete!");
                OnFacebookLogin();
                isInitialized = true;
            }
            //UIMap.ReloadOnMap ();
        }

        #endregion

#if WSA_FACEBOOK
	/// <summary>
	/// Wrapper class for WSA platform
	/// </summary>
	private class IGraphResult
	{
		private FBResult fbResult;
        #region PROPERTIES
		public string Error
		{
			get 
			{
				return fbResult == null ? "fbResult is null" : fbResult.Error;
			}
		}

		public bool Cancelled
		{
			get {
				return fbResult.Error == null ? false : fbResult.Error == "-1";
			}
		}

		public string RawResult
		{
			get
			{
				return fbResult.Text;
			}
		}

		public IDictionary<string, object> ResultDictionary
		{
			get {
				return fbResult.Json;
			}
		}
        #endregion

		public IGraphResult( FBResult fbResult )
		{
			this.fbResult = fbResult;
		}
	}
#endif
    }
}
