using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Tutorials;

public class TutorialAchievement : MonoBehaviour
{
    private bool animatePointer;

    [SerializeField]
    private GameObject root;
    [SerializeField]
    private GameObject darkBackground;
    [SerializeField]
    private RectTransform handPointer;
    [SerializeField]
    private RectTransform handPointerPressed;

    private bool isStart = false;
    private Button buyButton;
    private void Awake()
    {
        root.SetActive(false);
    }

    private void OnDisable()
    {
        DisableComponents();
    }

    private void OnSetupAllAchievementGameObjectsEvent(GameObject firstCompleteAch)
    {
        Debug.LogError(firstCompleteAch.GetComponent<AchievementItem>().currentState);

        if (firstCompleteAch == null)
        {
            return;
        }
        //if (firstCompleteAch.GetComponent<AchievementItem>().currentState != AchievmentState.ZERO_STAR_HAVED)
        //{
        //}
        if (IsComplete())
        {
            return;
        }

        StartTutorial(firstCompleteAch);
    }

    private bool IsComplete()
    {
       return SaveManager.GameProgress.Current.tutorial[(int)(ETutorialType.REWARD_ACHIEVEMENT)];
    }

    private void Update()
    {
        if (GameObject.Find("MainPanel") && SaveManager.GameProgress.Current.CompletedLevelsNumber==1)
        {
            GameObject.Find("MainPanel").GetComponent<Image>().enabled =false;
        }
    }

    private void StartTutorial(GameObject item)
    {
        isStart = true;
        //root.gameObject.SetActive(true);

        Transform buy = item.transform.Find("BuyBtn");
        buyButton = buy.GetComponent<Button>();
        buyButton.onClick.RemoveListener(OnClickHandler);
        buyButton.onClick.AddListener(OnClickHandler);

        //Debug.Log($"right RECT: {buy.gameObject.GetComponent<RectTransform>().anchoredPosition}, pos: {buy.position}");

        var tut = Tutorial.Open(target: buy.gameObject, focus: new Transform[] { item.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(70,25), waiting: 0);
        tut.dublicateObj = false;
        //FocusUIButtonTutorial(buy.gameObject);
        //TutorialUtils.AddCanvasOverride(item);
    }

    private void OnClickHandler()
    {
        Debug.LogError("End");

        DisableComponents();
        buyButton.onClick.RemoveListener(OnClickHandler);
        SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.REWARD_ACHIEVEMENT] = true;
        ShopSpellItemSettings.Current.countOpen = 0;
        UIShop.Instance.openPanel = 0;
        SaveManager.GameProgress.Current.Save();
        Tutorial.Close();
    }

    private void DisableComponents()
    {
        if (isStart)
        {
            isStart = false;
            TutorialUtils.ClearAllCanvasOverrides();
            root.SetActive(false);
        }
    }

    private void FocusUIButtonTutorial(GameObject objectToFocusOn)
    {
        animatePointer = true;
        StartCoroutine(_Open(objectToFocusOn));
    }

    IEnumerator _Open(GameObject objectToFocusOn)
    {
        gameObject.SetActive(true);
        RectTransform rect = objectToFocusOn.GetComponent<RectTransform>();
        var targetPosition = rect.GetRectCenter(normalizedOffsetFactor: new Vector2(-0.25f, 0.25f));
        targetPosition.z = 0;
        StartCoroutine(PointTheHandAt(targetPosition + new Vector3(0, 15f, 0)));
        yield return new WaitForEndOfFrame();
    }

    private IEnumerator PointTheHandAt(Vector3 position)
    {
        darkBackground.SetActive(true);
        SetupHandTransform(handPointer, position);
        SetupHandTransform(handPointerPressed, position);
        handPointer.gameObject.SetActive(true);
        handPointerPressed.gameObject.SetActive(false);

        var handPointerImageComponent = handPointer.GetComponent<Image>();
        handPointerImageComponent.color = new Color(1f, 1f, 1f, 1f);
        var click = false;
        while (animatePointer == true)
        {
            handPointer.gameObject.SetActive(animatePointer ? click : false);
            handPointerPressed.gameObject.SetActive(animatePointer ? !click : false);
            yield return new WaitForSecondsRealtime(click ? 0.5f : 0.2f);
            click = !click;
            if (!animatePointer)
                break;
        }
        handPointerImageComponent.color = new Color(1f, 1f, 1f, 0f);
        yield break;
    }

    private void SetupHandTransform(RectTransform rectTarnsform, Vector3 centerPosition)
    {
        var scale = rectTarnsform.lossyScale;
        var size = rectTarnsform.rect.size;
        centerPosition.x = (size.x / 2f) * scale.x;
        centerPosition.y = (size.y / 2f) * scale.y;
        rectTarnsform.localPosition = centerPosition;
    }
}