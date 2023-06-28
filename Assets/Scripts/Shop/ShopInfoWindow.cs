
using UnityEngine;

namespace UI
{
    public class ShopInfoWindow : UIWindowBase
    {
        [SerializeField]
        private GameObject[] childPanels;

        override protected void OnCloseWithBackButton()
        {
            for (int i = 0; i < childPanels.Length; i++)
            {
                childPanels[i].gameObject.SetActive(false);
            }
            base.OnCloseWithBackButton();
        }
    }
}
