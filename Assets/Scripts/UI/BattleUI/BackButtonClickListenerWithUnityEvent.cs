
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class BackButtonClickListenerWithUnityEvent : MonoBehaviour, IOnbackButtonClickListener
    {
        public UnityEvent OnBackButtonClicked;
        public bool clearAllOtherListeners;
        public bool Enabled = true;

        private void Awake()
        {
            try
            {
                UIBackbtnClickDispatcher.Current_Dispatcher.AddOnBackButtonListener(this, clearAllOtherListeners);
            }
            catch (System.Exception) { }
        }

        public void OnBackButtonClick()
        {
            if (Enabled && OnBackButtonClicked != null)
            {
                OnBackButtonClicked.Invoke();
            }
        }
    }
}
