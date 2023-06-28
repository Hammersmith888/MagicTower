using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Social;

public class FacebookIconsOnMapManager : MonoBehaviour
{

    [SerializeField]
    private UIMap uiMap;
    [SerializeField]
    private GameObject facebookIconPrefab;
    [SerializeField]
    private Vector3 playerIconPosition;
    [SerializeField]
    private Vector3 friendsIconPosition;
    [SerializeField]
    private float   additionalfriendIconOffset;
    [SerializeField]
    private int     maxFriendsIconsPerLvl;

    private List<FacebookOnMapIcon> activeFacebookIcons;
    private Dictionary<int, int>  friendsIconsOnlevel;

    private void Awake()
    {
        if (uiMap == null)
        {
            uiMap = GetComponent<UIMap>();
        }
        activeFacebookIcons = new List<FacebookOnMapIcon>();
        friendsIconsOnlevel = new Dictionary<int, int>();
        FacebookManager.OnFacebookLogin += OnFacebookLoginListener;
        FacebookManager.OnFacebookLogout += OnFacebookLogoutListener;
        Native.FirebaseManager.OnFriendProgress += AddIconToMap;
        if (FacebookManager.Instance.isLoggedIn)
        {
            UpdateIconsOnMap();
        }
    }

    private void OnDisable()
    {
        FacebookManager.OnFacebookLogin -= OnFacebookLoginListener;
        FacebookManager.OnFacebookLogout -= OnFacebookLogoutListener;
        Native.FirebaseManager.OnFriendProgress -= AddIconToMap;
    }

    private void UpdateIconsOnMap()
    {
        ClearActiveIcons();
        //SaveManager.GameProgress progress = PPSerialization.Load<SaveManager.GameProgress>( EPrefsKeys.Progress );
        //progress.bestScoreOnLevel = new int[ ] { 10,25,38,124,90};
        AddIconToMap(FacebookManager.Instance.User, PPSerialization.Load<SaveManager.GameProgress>(EPrefsKeys.Progress.ToString()), false);
        Native.FirebaseManager.Instance.GetUserFriends();
        //AddIconToMap( FacebookManager.Instance.user, PPSerialization.Load( EPrefsKeys.Progress ) as SaveManager.GameProgress, false );
        //AddIconToMap( FacebookManager.Instance.user, PPSerialization.Load( EPrefsKeys.Progress ) as SaveManager.GameProgress, false );

        //AddIconToMap( FacebookManager.Instance.user, new SaveManager.GameProgress() { finishCount = new int[ ] { 1, 1, 1 }, bestScoreOnLevel = new int[ ] { 25, 35, 45, 100 } }, false );
        //AddIconToMap( FacebookManager.Instance.user, new SaveManager.GameProgress() { finishCount = new int[ ] { 1, 1, 1 } }, false );
        //AddIconToMap( FacebookManager.Instance.user, new SaveManager.GameProgress() { finishCount = new int[ ] { 1, 1, 1 } }, false );
        //AddIconToMap( FacebookManager.Instance.user, new SaveManager.GameProgress() { finishCount = new int[ ] { 1, 1, 1 } }, false );

        //AddIconToMap( FacebookManager.Instance.user, new SaveManager.GameProgress() { finishCount = new int[ ] { 1, 1, 1, 1, 1, 1 } }, false );
    }

    private void ClearActiveIcons()
    {
        foreach (FacebookOnMapIcon facebookIconOnMap in activeFacebookIcons)
        {
            Destroy(facebookIconOnMap.gameObject);
        }
        activeFacebookIcons.Clear();
        friendsIconsOnlevel.Clear();
    }

    private void AddIconToMap(FacebookUser facebookUser, SaveManager.GameProgress progress)
    {
        AddIconToMap(facebookUser, progress, false);
    }

    private void AddIconToMap(FacebookUser facebookUser, SaveManager.GameProgress progress, bool isPlayer)
    {
        if (progress == null)
        {
            return;
        }
        int openLevel = progress.finishCount.Count(i => i > 0) + 1;
        Debug.Log("AddIconToMap: " + openLevel);
        Vector3 iconPos = isPlayer ? playerIconPosition : friendsIconPosition;
        int bestScoreOnLvLForSelectedUser = progress.GetBestScoreOnLvL(openLevel - 1);
        int bestPlayerScoreOnLvL = 0;
        if (!isPlayer)
        {
            bestPlayerScoreOnLvL = PPSerialization.Load<SaveManager.GameProgress>(EPrefsKeys.Progress.ToString()).GetBestScoreOnLvL(openLevel - 1);
            int friendsIconsNumber = 0;
            if (friendsIconsOnlevel.TryGetValue(openLevel, out friendsIconsNumber))
            {
                if (friendsIconsNumber < maxFriendsIconsPerLvl)
                {
                    friendsIconsOnlevel[openLevel]++;
                    iconPos.y += friendsIconsNumber * additionalfriendIconOffset;
                }
                else
                {
                    return;
                }
            }
            else
            {
                friendsIconsOnlevel.Add(openLevel, 1);
            }
        }
        else
        {
            bestPlayerScoreOnLvL = bestScoreOnLvLForSelectedUser;
        }
        if (uiMap != null)
        {
            Transform levelTransform = uiMap.GetLevelTransform(openLevel);
            if (levelTransform != null)
            {
                bool isMoveToNextLevelAnimPlaying = false;
                if (isPlayer && uiMap.IsNewLevelUnlocked)
                {
                    openLevel--;
                    if (openLevel >= 0)
                    {
                        Transform previousLevelTransform = uiMap.GetLevelTransform(openLevel);
                        if (previousLevelTransform != null)
                        {
                            isMoveToNextLevelAnimPlaying = true;
                            FacebookOnMapIcon icon = Instantiate(facebookIconPrefab, previousLevelTransform, false).GetComponent<FacebookOnMapIcon>();
                            icon.transform.localPosition = iconPos;
                            icon.Init(facebookUser.picture, bestPlayerScoreOnLvL, bestScoreOnLvLForSelectedUser, isPlayer);
                            icon.AnimateToLevel(levelTransform, iconPos);
                        }
                    }
                }
                if (!isMoveToNextLevelAnimPlaying)
                {
                    FacebookOnMapIcon icon = Instantiate(facebookIconPrefab, levelTransform, false).GetComponent<FacebookOnMapIcon>();
                    icon.transform.localPosition = iconPos;
                    icon.Init(facebookUser.picture, bestPlayerScoreOnLvL, bestScoreOnLvLForSelectedUser, isPlayer);
                }
            }
        }
    }

    private void OnFacebookLoginListener()
    {
        UpdateIconsOnMap();
        uiMap.UpdateView(needShowAnim: false);
    }

    private void OnFacebookLogoutListener()
    {
        ClearActiveIcons();
    }
}
