using UnityEngine;

namespace UI
{
    public class UIWindowBase : MonoBehaviour
    {
        [SerializeField]
        protected Transform currentTransform;
        [SerializeField]
        protected bool canBeClosedWithBackButton = true;
        [SerializeField]
        protected bool destroyOnClose;

        private static UIWindowBase lastActiveWindow;

        public static bool isAnyWindowActive
        {
            get
            {
                return lastActiveWindow != null && lastActiveWindow.gameObject.activeSelf;
            }
        }

        virtual protected void OnEnable()
        {
            if (currentTransform == null)
            {
                currentTransform = transform;
            }
            lastActiveWindow = this;
            currentTransform.SetAsLastSibling();
        }

        virtual protected void Update()
        {
            if (canBeClosedWithBackButton && Input.GetKeyDown(KeyCode.Escape))
            {
                OnCloseWithBackButton();
            }
        }

        virtual protected void OnCloseWithBackButton()
        {
            if (destroyOnClose)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
