using UI;
using UnityEngine;

public class ShareController : MonoBehaviour
{
    public static ShareController instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void ShareDone(NativeShare.ShareResult result)
    {
        if (result == NativeShare.ShareResult.Shared)
        {
            SaveManager.GameProgress.Current.countInvite++;
            SaveManager.GameProgress.Current.Save();

            InviteFriendsForRewardWindow.Instance.SetCurrentPanel();
        }
    }

    public void Share()
    {
        new NativeShare().SetText(TextSheetLoader.GetStringST("t_0712") + " https://play.google.com/store/apps/details?id=com.akpublish.magicsiege&gl")
                 .SetCallback((result, shareTarget) => ShareDone(result)).Share();
    }
}