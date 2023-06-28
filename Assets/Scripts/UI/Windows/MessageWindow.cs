using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MessageWindow : UIWindowBase
    {
        public enum EMessageWindowType
        {
            COINS, SYNCHRONIZATION, FRIENDS_INVITE, UNLOCK_ITEM, FREE_INFO
        }

        private const string RESOURCES_PATH_FORMAT ="UI/{0}_MessageWindow";

        [SerializeField]
        protected Text    messageLbl, title;

        [SerializeField]
        private Button  closeButton;
        [SerializeField]
        private Canvas  canvas;

        private static int currentSortOrder = 25;
        private static GameObject synchronizationWindow;

        [SerializeField]
        UIConsFlyAnimation effect;

        int curCoins, startCoins;
        [SerializeField]
        float effectSpeed = 1;

        EMessageWindowType windowType;

        private void Start()
        {
            
        }

        #region Static
        public static void Show(EMessageWindowType windowType, string message, string label = "")
        {
            GameObject obj = Resources.Load(string.Format(RESOURCES_PATH_FORMAT, windowType.ToString())) as GameObject;
            if (obj != null && !string.IsNullOrEmpty(message))
            {
                Instantiate(obj).GetComponent<MessageWindow>().Show(message, label: label);
            }


        }

        public static void Show(EMessageWindowType windowType)
        {
            GameObject obj = Resources.Load(string.Format(RESOURCES_PATH_FORMAT, windowType.ToString())) as GameObject;
            if (obj != null)
            {
                Instantiate(obj).GetComponent<MessageWindow>().Show(null);
            }
        }

        public static void ToggleSynchronizationWindow(bool showWindow)
        {
            if (showWindow)
            {
                if (synchronizationWindow != null)
                {
                    synchronizationWindow.SetActive(true);
                }
                else
                {
                    synchronizationWindow = Instantiate(Resources.Load(string.Format(RESOURCES_PATH_FORMAT, EMessageWindowType.SYNCHRONIZATION.ToString())) as GameObject);
                }
            }
            else
            {
                if (synchronizationWindow != null)
                {
                    Destroy(synchronizationWindow);
                }
            }
        }
        #endregion

        public void Init()
        {
            closeButton.onClick.AddListener(Close);
        }

        virtual public void Show(string message, bool canBeClosed = true, string label = "t_0362")
        {
            if (!string.IsNullOrEmpty(message))
            {
                if(messageLbl != null)
                    messageLbl.text = message;
            }
            gameObject.SetActive(true);
            closeButton.gameObject.SetActive(canBeClosed);
            if (canvas != null)
            {
                canvas.sortingOrder = currentSortOrder;
            }
            if(title != null)
                title.text = TextSheetLoader.Instance.GetString(label);
        }

        protected override void OnCloseWithBackButton()
        {
            Close();
        }

        public void Close()
        {
            //effect.PlayEffect();
            if (destroyOnClose)
            {
                Destroy(gameObject);
                currentSortOrder--;
            }
            else
            {
                gameObject.SetActive(false);
            }
            if (canvas != null)
            {
                currentSortOrder--;
            }
        }
    }
}
