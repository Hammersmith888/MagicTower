using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public interface IOnbackButtonClickListener
    {
        int GetInstanceID();

        void OnBackButtonClick();
    }

    public class UIBackbtnClickDispatcher : MonoBehaviour
    {
        protected List<IOnbackButtonClickListener> onBackButtonListeners = new List<IOnbackButtonClickListener>();

        private static bool isBackButtonEnabled = true;

        virtual protected bool IsBackButtonClicked
        {
            get
            {
                return Input.GetKeyDown(KeyCode.Escape);
                //return false;
            }
        }

        private static UIBackbtnClickDispatcher currentDispatcher;
        public static UIBackbtnClickDispatcher Current_Dispatcher
        {
            get
            {
                if (currentDispatcher == null)
                {
                    currentDispatcher = FindObjectOfType<UIBackbtnClickDispatcher>();
                    if (currentDispatcher == null)
                    {
                        currentDispatcher = new GameObject("UIBackbtnClickDispatcher").AddComponent<UIBackbtnClickDispatcher>();
                    }
                }
                return currentDispatcher;
            }
        }

        protected static void SetCurrentBackButtonDispatcher(UIBackbtnClickDispatcher newDispatcher, bool deletePreviousIfAny = true)
        {
            if (currentDispatcher != null)
            {
                newDispatcher.onBackButtonListeners.AddRange(currentDispatcher.onBackButtonListeners);
                if (deletePreviousIfAny)
                {
                    Destroy(currentDispatcher);
                }
                else
                {
                    currentDispatcher.onBackButtonListeners.Clear();
                }
            }
            currentDispatcher = newDispatcher;
        }

        public static void ToggleBackButtonDispatcher(bool enabled)
        {
            isBackButtonEnabled = enabled;
        }

        virtual public void AddOnBackButtonListener(IOnbackButtonClickListener listener, bool clearAllOther = false)
        {
            if (clearAllOther)
            {
                onBackButtonListeners.Clear();
            }
            else
            {
                int count = onBackButtonListeners.Count;
                for (int i = 0; i < count; i++)
                {
                    if (onBackButtonListeners[i].GetInstanceID() == listener.GetInstanceID())
                    {
                        Debug.LogFormat("IOnbackButtonClickListener with id {0} already registered", listener.GetInstanceID());
                        return;
                    }
                }
            }
            onBackButtonListeners.Add(listener);
        }

        virtual public void RemoveOnBackButtonListener(IOnbackButtonClickListener listener)
        {
            int count = onBackButtonListeners.Count;
            for (int i = 0; i < count; i++)
            {
                if (onBackButtonListeners[i].GetInstanceID() == listener.GetInstanceID())
                {
                    onBackButtonListeners.RemoveAt(i);
                    break;
                }
            }
        }

        virtual protected void Update()
        {
            //if (isBackButtonEnabled && IsBackButtonClicked)
            //{
            //    if (onBackButtonListeners != null && onBackButtonListeners.Count > 0)
            //    {
            //        onBackButtonListeners[onBackButtonListeners.Count - 1].OnBackButtonClick();
            //    }
            //}
        }
    }
}
