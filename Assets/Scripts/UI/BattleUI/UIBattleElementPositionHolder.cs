using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public partial class  UIBattleElementPositionHolder : MonoBehaviour
    {
        [SerializeField]
        private EUIElementType elementType;

        [SerializeField]
        private RectTransform topCanvasTransform;
        [SerializeField]
        private Transform targetTransf;

        [SerializeField]
        private AnimationBase animationOnItemReachedElement;

        private Vector3 worldPos;
        public Vector3 getElementPosition
        {
            get
            {
                return worldPos;
            }
        }

        private static Dictionary<EUIElementType, UIBattleElementPositionHolder> uiElementsPositionsHolder = new Dictionary<EUIElementType, UIBattleElementPositionHolder>();

        public static UIBattleElementPositionHolder GetUIElementHolderByType(EUIElementType elementType)
        {
            UIBattleElementPositionHolder result = null;
            uiElementsPositionsHolder.TryGetValue(elementType, out result);
            return result;
        }

        private void Start()
        {
            worldPos = Helpers.UIWorildPosToCameraWorldPos(targetTransf.position, topCanvasTransform);

#if UNITY_EDITOR || UNITY_WSA
            Core.GlobalGameEvents.Instance.AddListenerToEvent(Core.EGlobalGameEvent.RESOLUTION_CHANGE, ResolutionChangeEventListener);
#endif
            uiElementsPositionsHolder.Add(elementType, this);

            this.GetComponentIfNull(ref animationOnItemReachedElement);
        }

#if UNITY_EDITOR || UNITY_WSA
        private void ResolutionChangeEventListener(Core.BaseEventParams eventParams)
        {
            worldPos = Helpers.UIWorildPosToCameraWorldPos(targetTransf.position, topCanvasTransform);
        }
#endif

        private void OnDestroy()
        {
#if UNITY_EDITOR || UNITY_WSA
            Core.GlobalGameEvents.Instance.RemoveListenerFromEvent(Core.EGlobalGameEvent.RESOLUTION_CHANGE, ResolutionChangeEventListener);
#endif
            if (uiElementsPositionsHolder.ContainsKey(elementType))
            {
                uiElementsPositionsHolder.Remove(elementType);
            }
        }

        virtual public void OnItemReachedElementPosition()
        {
            if (animationOnItemReachedElement != null)
            {
                animationOnItemReachedElement.PlayAnimation();
            }
        }

#if UNITY_EDITOR

        //[SerializeField]
        //private bool visualizePositionOnEditor;

        //public Vector2 posOnCanvas;
        //public Vector2 sizeDelta;
        //public Vector2 viewPortPos;
        //private void OnDrawGizmosSelected( )
        //{
        //	if( visualizePositionOnEditor )
        //	{
        //		Vector2 pos = targetTransf.position - topCanvasTransform.position;
        //		posOnCanvas = pos;


        //		sizeDelta = topCanvasTransform.sizeDelta;
        //		sizeDelta.x *= topCanvasTransform.localScale.x;
        //		sizeDelta.y *= topCanvasTransform.localScale.y;

        //		pos += sizeDelta / 2f;
        //		pos.x /= sizeDelta.x;
        //		pos.y /= sizeDelta.y;

        //		viewPortPos = pos;

        //		worldPos = Helpers.getMainCamera.ViewportToWorldPoint( pos );
        //		worldPos.z = -15f;

        //		Gizmos.DrawSphere( worldPos, 0.5f );


        //	}
        //}
#endif
    }
}
