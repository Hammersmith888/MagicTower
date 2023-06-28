
using UnityEngine;

namespace UI
{
    public class ReplicaUICanvas : MonoBehaviour
    {
        private static ReplicaUICanvas current;
        public static Transform CanvasTransform
        {
            get
            {
                if (current == null)
                {
                    current = FindObjectOfType<ReplicaUICanvas>();
                }
                return current.transform;
            }
        }

        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.A))
        //    {
        //        Core.ShopGameEvents.Instance.LaunchEvent(Core.EShopGameEvent.SPELL_UPGRADED, 0, 2);
        //    }
        //    if (Input.GetKeyDown(KeyCode.S))
        //    {
        //        Core.ShopGameEvents.Instance.LaunchEvent(Core.EShopGameEvent.BONUS_BOUGHT, 0);
        //    }
        //    if (Input.GetKeyDown(KeyCode.D))
        //    {
        //        Core.ShopGameEvents.Instance.LaunchEvent(Core.EShopGameEvent.BONUS_BOUGHT, 1);
        //    }
        //}
    }
}
