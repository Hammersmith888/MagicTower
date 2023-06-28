
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ReplicaUIDarkBackground : MonoBehaviour
    {
        [SerializeField]
        private Canvas Canvas;
        [SerializeField]
        private Animations.AlphaColorAnimation[] BackgroundImageAlphaColorHolder;
        [SerializeField][Range(0f,1f)]
        private float BackgroundAlpha = 0.8f;

        private static ReplicaUIDarkBackground current;

        Button btn;

        private void Awake()
        {
            current = this;
            foreach (var o in BackgroundImageAlphaColorHolder)
            {
                if(o != null)
                    o.Init();
            }

            Canvas.overrideSorting = true;
            Canvas.sortingOrder = 120;
            foreach (var o in current.BackgroundImageAlphaColorHolder)
            {
                if (o != null)
                    o.gameObject.SetActive(false);
            }
            //if (btn == null)
            //{
            //    btn = BackgroundImageAlphaColorHolder.gameObject.AddComponent<Button>();
            //    btn.transition = Selectable.Transition.None;
            //    btn.onClick.AddListener(CloseReplica);
            //}
        }


        public void CloseReplica()
        {
            var repls = FindObjectsOfType<ReplicaUI>();
            foreach (var o in repls)
                o.OnCloseClick();
        }

        public static void CanvasEnable()
        {
            if (current != null)
            {
                current.Canvas.enabled = true;
            }
        }

        public static void CanvasDisable()
        {
            if (current != null)
            {
                current.Canvas.enabled = false;
            }
        }

        public static void FadeIn()
        {
            if (current != null)
            {
                foreach (var o in current.BackgroundImageAlphaColorHolder)
                {
                    if (o != null)
                        o.AnimateFromCurrentColor(current.BackgroundAlpha);
                }
            }
        }

        public static void FadeOut()
        {
            if (current != null)
            {
                foreach (var o in current.BackgroundImageAlphaColorHolder)
                {
                    if (o != null)
                        o.AnimateFromCurrentColor(0f, () => { o.gameObject.SetActive(false); });
                }
            }
        }
    }
}
