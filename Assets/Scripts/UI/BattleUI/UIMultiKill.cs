using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMultiKill : MonoBehaviour
{
    public static List<int> golds;

    [SerializeField]
    public GameObject textInChiledren;
    private LevelSettings levelSettings;

    private int marksKills;

    private Text textInChildrenText;
    private Animator textInChildrenTextAnimator;

    private Coroutine currentCountFrameKillsCoroutines = null;

    private float timeForKillsSpend = 0f;

    private string doubleKill;
    private string tripleKill;
    private string multiKill;

    private void Start()
    {
        marksKills = 0;
        golds = new List<int>();

        textInChiledren.SetActive(false);
        textInChildrenText = textInChiledren.GetComponent<Text>();
        textInChildrenTextAnimator = textInChiledren.GetComponent<Animator>();

        levelSettings = LevelSettings.Current;

        GetLocalization();
    }

    private void GetLocalization()
    {
        doubleKill = TextSheetLoader.GetStringST("t_0008");
        tripleKill = TextSheetLoader.GetStringST("t_0009");
        multiKill = TextSheetLoader.GetStringST("t_0252");
    }

    private IEnumerator CountKill()
    {
        yield return new WaitForSeconds(0.4f);
        ShowMultiKills(marksKills);
    }

    public void IncKills()
    {
        marksKills++;
        if (currentCountFrameKillsCoroutines == null)
        {
            currentCountFrameKillsCoroutines = StartCoroutine(CountKill()); 
        }
    }

    private void ShowMultiKills(int killsNumber)
    {
        if (currentCountFrameKillsCoroutines != null)
        {
            StopCoroutine(currentCountFrameKillsCoroutines);
            currentCountFrameKillsCoroutines = null;
        }
        marksKills = 0;
        timeForKillsSpend = 0f;
        string streakText = string.Empty;
        switch (killsNumber)
        {
            case 0:
                return;
            case 1:
                return;
            case 2:
                streakText = doubleKill; // Double Kill!
                break;
            case 3:
                streakText = tripleKill; // Triple Kill!
                break;
            default:
                streakText = multiKill; // Multi  Kill!
                break;
        }
        AddGold(killsNumber);

        textInChildrenText.text = streakText;
        if (!textInChiledren.activeSelf)
            textInChiledren.SetActive(true);
        else
            textInChildrenTextAnimator.SetTrigger(AnimationPropertiesCach.instance.restartAnim);
    }

    private void AddGold(int diff)
    {
        int gold = 0;
        if (diff > golds.Count)
        {
            gold = 10;
        }
        else
        {
            for (int i = golds.Count - 1; i >= golds.Count - diff; i--)
            {
                gold += golds[i];
            }
        }

        // Добавление золота
        levelSettings.coinsValue.text = (int.Parse(levelSettings.coinsValue.text) + gold).ToString();
    }
}
