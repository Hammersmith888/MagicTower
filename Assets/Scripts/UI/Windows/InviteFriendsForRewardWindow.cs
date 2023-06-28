using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InviteFriendsForRewardWindow : MonoBehaviour
    {
        [SerializeField] UIConsFlyAnimation fly;
        private Transform target;

        // Invite Panels
        [SerializeField] GameObject shareFree;
        [SerializeField] GameObject shareFirst;
        [SerializeField] GameObject shareGetCoins;

        private byte currentInvite = 0;
        public static InviteFriendsForRewardWindow Instance;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void OnEnable()
        {
            SetCurrentPanel();
        }

        public void SetCurrentPanel()
        {
            DiactivePanel();

            currentInvite = (byte)SaveManager.GameProgress.Current.countInvite;

            if (currentInvite == 0)
                shareFirst.SetActive(true);
            else if (currentInvite == 1 && !SaveManager.GameProgress.Current.takeAwardInvite)
                shareGetCoins.SetActive(true);
            else 
                shareFree.SetActive(true);
        }

        private void DiactivePanel()
        {
            shareFree.SetActive(false);
            shareFirst.SetActive(false);
            shareGetCoins.SetActive(false);
        }

        public void Share()
        {
            StartCoroutine(ShareCoroutine());
        }

        private IEnumerator ShareCoroutine()
        {
            ShareController.instance.Share();
            yield return new WaitForSeconds(0.2f);

            if (!SaveManager.GameProgress.Current.takeAwardInvite)
            {
                AnalyticsController.Instance.LogMyEvent("PressShareFriend");
                AnalyticsController.Instance.LogMyEvent("GetShareFriend");
            }
            else
                AnalyticsController.Instance.LogMyEvent("PressShareFriend_More");

            yield break;
        }

        public void TakeAward()
        {
            ClosePanel();
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }
    }
}
