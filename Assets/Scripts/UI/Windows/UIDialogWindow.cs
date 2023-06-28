
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIDialogWindow : UIWindowBase
    {
        [SerializeField]
        private Text titleLbl;
        [SerializeField]
        private LocalTextLoc messsageLabelLocalizationComponent;

        private System.Action<bool> onCloseAction;

        private static UIDialogWindow current;
        const string RESOURCES_PATH = "UI/DialogWindow";

        public static UIDialogWindow Show(string messageTextLocaleID, string titleText = null, System.Action<bool> onCloseAction = null)
        {
            if (current != null)
            {
                current.Close();
            }
            current = (Instantiate(Resources.Load(RESOURCES_PATH)) as GameObject).GetComponent<UIDialogWindow>();
            current.Init(messageTextLocaleID, titleText, onCloseAction);
            return current;
        }

        private void Init(string messageTextLocaleID, string titleText = null, System.Action<bool> onCloseAction = null)
        {
            this.onCloseAction = onCloseAction;
            if (string.IsNullOrEmpty(titleText))
            {
                titleLbl.gameObject.SetActive(false);
            }
            else
            {
                titleLbl.text = titleText;
            }
            messsageLabelLocalizationComponent.SetLocaleId(messageTextLocaleID);
        }

        protected override void OnCloseWithBackButton()
        {
            Close();
        }

        public void Close(bool result = false)
        {
            current = null;
            if (onCloseAction != null)
            {
                onCloseAction(result);
            }
            Destroy(gameObject);
        }
    }
}
