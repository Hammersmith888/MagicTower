using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BaseBackButtonListener : MonoBehaviour, IOnbackButtonClickListener
    {
        [SerializeField]
        private Button button;

        private void OnEnable()
        {
            if (button == null)
            {
                button = GetComponentInChildren<Button>();
            }
            UIBackbtnClickDispatcher.Current_Dispatcher.AddOnBackButtonListener(this);
        }

        private void OnDisable()
        {
            UIBackbtnClickDispatcher.Current_Dispatcher.RemoveOnBackButtonListener(this);
        }

        public void OnBackButtonClick()
        {
            if (button != null)
            {
                button.onClick.Invoke();
            }
        }
    }
}
