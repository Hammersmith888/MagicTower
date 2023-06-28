using UnityEngine;
using UnityEngine.UI;
using Social;

public class FacebookUIController : MonoBehaviour
{
    public enum EConnectionState
    {
        NOT_CONNECTED, CONNECTING, CONNECTED
    }

    [SerializeField]
    private GameObject      facebookLoginWindow;
    [SerializeField]
    private UI.MessageWindow   facebookMessagesWindow;
    [SerializeField]
    private Button          facebookLoginLogoutBtn;
    [SerializeField]
    private Button          facebookOkOnLoginBtn;
    [SerializeField]
    private Button          inviteFriendsButton;
    [SerializeField]
    private FBStateIcon     fbStateIcon;

    const string SIGNOUT_MESSAGE = "Your saves will not be synchronized with cloud, you are sure want to sign out?";

    public static FacebookUIController current
    {
        get; private set;
    }

    private void Awake()
    {
        current = this;
        facebookMessagesWindow.Init();
        if (facebookLoginLogoutBtn != null)
            facebookLoginLogoutBtn.onClick.AddListener(OnLoginLogoutClick);
        if (facebookOkOnLoginBtn != null)
            facebookOkOnLoginBtn.onClick.AddListener(OnOkLoginToFacebook);

        if (inviteFriendsButton != null)
        {
            inviteFriendsButton.onClick.AddListener(OnInviteFriendsClick);
            inviteFriendsButton.transform.GetChild(0).GetComponentInChildren<Button>().onClick.AddListener(OnInviteFriendsClick);
        }
    }

    public void ShowLoginWindowIfWasNotLoggedIn()
    {
        if (!FacebookManager.Instance.isLoggedIn)
        {
            facebookLoginWindow.SetActive(true);
        }
    }

    private void OnInviteFriendsClick()
    {
        Debug.Log("OnInviteFriendsClick " + FacebookManager.Instance.isLoggedIn);
        //if( FacebookManager.Instance.isLoggedIn )
        //{
        //	FacebookManager.Instance.Invite();
        //}
        //else
        //{
        //	ShowMessageWindow( "You not logged in" );
        //}
        UI.MessageWindow.Show(UI.MessageWindow.EMessageWindowType.FRIENDS_INVITE);
    }

    private void OnLoginLogoutClick()
    {
        if (FacebookManager.Instance.isLoggedIn)
        {
            UI.UIDialogWindow.Show(SIGNOUT_MESSAGE, "Facebook", result =>
           {
               if (result)
               {
                   ChangeStatusIconInner(EConnectionState.NOT_CONNECTED);
                   FacebookManager.Instance.Logout();
               }
           });
        }
        else
        {
            facebookLoginWindow.SetActive(true);
        }
    }

    public void OnOkLoginToFacebook()
    {
        facebookLoginWindow.SetActive(false);
        ChangeStatusIconInner(EConnectionState.CONNECTING);
        FacebookManager.Instance.Login();
    }

    public static void ShowMessageWindow(string message, bool canBeClosed = true)
    {
        Debug.LogFormat( "ShowMessageWindow {0}", message );
        if (current != null)
        {
            if(message != "")
                current.facebookMessagesWindow.Show(message, canBeClosed);
        }
    }

    public static void ChangeStatusIcon(EConnectionState connectionState)
    {
        if (current != null)
        {
            //Debug.LogFormat( "ChangeStatusIcon {0}", connectionState );
            current.ChangeStatusIconInner(connectionState);
        }
    }

    public static void CloseMessageWindow()
    {
        if (current != null)
        {
            current.facebookMessagesWindow.Close();
        }
    }

    private void ChangeStatusIconInner(EConnectionState connectionState)
    {
        if (fbStateIcon == null)
        {
            return;
        }
        switch (connectionState)
        {
            case EConnectionState.NOT_CONNECTED:
                fbStateIcon.SetNotConnectedState();
                break;
            case EConnectionState.CONNECTING:
                fbStateIcon.SetConnectingState();
                break;
            case EConnectionState.CONNECTED:
                fbStateIcon.SetConnectedState();
                break;
        }
    }
}
