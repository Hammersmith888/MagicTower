using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace Social
{
    public enum MessagesType
    {
        None,
        Ask,
        Send
    }

    public class MessagesData
    {
        public MessagesType type;
        public string requestID;
        public FacebookUser user;
    }

    public class UIMessageContainer : MonoBehaviour
    {
        #region EVENTS

        public static UnityAction<GameObject> OnMessageRemove = delegate{};

        #endregion


        #region PROPERTY

        public string requestID
        {
            get
            {
                return currentData.requestID;
            }
        }

        public MessagesType messageType
        {
            get
            {
                return currentData.type;
            }
        }

        #endregion


        [Header("Reference")]
        [SerializeField]
        private Image pointerAvatar = null;
        [SerializeField]
        private Text pointerLabelName = null;
        [SerializeField]
        private Text pointerLabelDiscription = null;
        [Header("Reference Button")]
		//[SerializeField] private UIButton pointerButtonGet = null;
		//[SerializeField]
		//private UIButton pointerButtonSendAndGet = null;
		//[SerializeField] private UIButton pointerButtonIgnore = null;
		private MessagesData currentData = null;
        private bool currentRemoving = false;



        void Start()
        {
            //if( pointerButtonSendAndGet != null )
            //	pointerButtonSendAndGet.onClick.AddListener( OnClickSendAndGet );
        }

        public void SetMessageData(MessagesData data)
        {
            if (data == null)
                return;


            currentData = data;

            if (currentData.user != null)
            {
                if (pointerAvatar != null)
                    pointerAvatar.sprite = currentData.user.picture;

                if (pointerLabelName != null)
                    pointerLabelName.text = currentData.user.name;
            }

            if (currentData.type == MessagesType.Ask)
            {
                if (pointerLabelDiscription != null)
                    pointerLabelDiscription.text = "A friend ask you to send him life!";
            }
            else
            {
                if (pointerLabelDiscription != null)
                    pointerLabelDiscription.text = "A friend sent you life!";
            }
        }


        #region INTERNAL

        private void OnClickSendAndGet()
        {
            if (currentData.type == MessagesType.Ask)
            {
                OnClickSend();
            }
            else
            {
                OnClickGet();
            }
        }

        private void OnClickSend()
        {
            if (currentData != null)
            {
                FacebookManager.Instance.SendLife(new string[] { currentData.user.id });
                //UIPopupTextMessage.current.Show( "You send life for your friend!", "Send Life", false );

                OnClickIgnore();
            }
        }

        private void OnClickGet()
        {
            if (currentData != null)
            {
                if (currentData.type == MessagesType.Send)
                {
                    //UIPopupRewards.current.Show( RewardsType.Live, 1 );

                    OnClickIgnore();
                }
            }
        }

        private void OnClickIgnore()
        {
            if (currentData != null && !currentRemoving)
            {
                currentRemoving = true;

                FacebookManager.Instance.DeleteRequest(currentData.requestID);
                FacebookManager.Instance.friendsRequests.Remove(currentData);

                OnMessageRemove(gameObject);
            }
        }

        #endregion


        private void OnEnable()
        {
            if (currentData != null && currentData.user.picture == null)
            {
                foreach (FacebookUser us in FacebookManager.Instance.friendsOnline)
                {
                    if (us.id == currentData.user.id)
                    {
                        currentData.user.picture = us.picture;
                        pointerAvatar.sprite = currentData.user.picture;
                        break;
                    }
                }
            }
        }
    }
}