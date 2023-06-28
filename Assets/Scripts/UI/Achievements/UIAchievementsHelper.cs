
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIAchievementsHelper : MonoBehaviour
{
    public static UIAchievementsHelper instance;


    [SerializeField]
    private GameObject AchievementsRewardsNotificationObj;
    [SerializeField]
    private Text AchievementsRewardsNumberLabel;
    [SerializeField]
    private GameObject AchievementsButtonBackgroundShining;
    [SerializeField]
    private Image AchievementsButton;
    [SerializeField]
    private Sprite AchievementsButtonNormalImage;
    [SerializeField]
    private Sprite AchievementsButtonShiningImage;

    [SerializeField]
    bool isMap = false;


    [SerializeField]
    Text totalProgressText;

    int coountGet = 0;

    bool isReturn = false;
    private Button achievementButton;

    private void Awake()
    {
        instance = this;
    }

    private IEnumerator Start()
    {
        achievementButton = gameObject.GetComponentInChildren<Button>();

        StartCoroutine(_SS());
        yield return null;
        yield return null;
        var p1 = Achievement.AchievementController.GetCountOpened();
        if(totalProgressText != null)
            totalProgressText.text = p1.object1 + "/" + p1.object2;

        var scene = SceneManager.GetActiveScene().name;
        if (scene == "Shop" || scene == "Map")
            StartCoroutine(CheckState());
    }

    private IEnumerator CheckState()
    {
        while (true)
        {
            var scene = SceneManager.GetActiveScene().name;
            if (scene != "Shop" && scene != "Map")
            {
                yield return new WaitForSecondsRealtime(1f);
                continue;
            }

            SetAchievementsButtonState(Achievement.AchievementController.GetCountNotTakeAward());
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    IEnumerator _SS()
    {
        isReturn = true;
        yield return new WaitForSecondsRealtime(1f);
        isReturn = false;
    }

    public void OpenTutorialBtn()
    { 
        Debug.Log($"OpenTutorialBtn: {SaveManager.GameProgress.Current.tutAchivement}");
        if (!SaveManager.GameProgress.Current.tutAchivement)
        {
            Tutorial.Close();
            var t = Tutorial.Open(target: gameObject, focus: new Transform[] { gameObject.transform }, mirror: true, rotation: new Vector3(0, 0, -30f), offset: new Vector2(50, 50), waiting: 0);
            t.dublicateObj = false;
            achievementButton.onClick.AddListener(OpenAch);
        }

        SaveManager.GameProgress.Current.tutAchivement = true;
        SaveManager.GameProgress.Current.Save();
    }
    void OpenAch()
    {
        Tutorial.Close();
        achievementButton.onClick.RemoveListener(OpenAch);
    }

    public void Open(GameObject o)
    {
        if (isReturn)
            return;
        o.SetActive(true);
    }

    private void SetAchievementsButtonState(int unclaimedAchievementsNumber)
    {
        if (AchievementsButton == null)
        {
            return;
        }
        var isAnyUnclaimedReward = unclaimedAchievementsNumber > 0;
        coountGet = unclaimedAchievementsNumber;
        if (isAnyUnclaimedReward)
        {
            AchievementsRewardsNumberLabel.text = unclaimedAchievementsNumber.ToString();
        }
        if (!isMap)
            AchievementsButton.sprite = isAnyUnclaimedReward ? AchievementsButtonShiningImage : AchievementsButtonNormalImage;
        AchievementsButtonBackgroundShining.SetActive(isAnyUnclaimedReward);
        AchievementsRewardsNotificationObj.SetActive(isAnyUnclaimedReward);

        if (totalProgressText != null)
        {
            var p1 = Achievement.AchievementController.GetCountOpened();
            totalProgressText.text = p1.object1 + "/" + p1.object2;
        }
    }


}
