using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
//using UnityEngine.Experimental.PlayerLoop;

public class PanelInfoDescription : MonoBehaviour
{
    public static PanelInfoDescription instance;

    void Awake()
    {
        instance = this;
    }
    private List<InfoLoaderConfig.EnemyBaseData> enemies = new List<InfoLoaderConfig.EnemyBaseData>();

    [SerializeField]
    GameObject[] btns;
    [SerializeField]
    Text textNewCount;

    int current;

    bool isOpen = false;

    GameObject currentUpInfoObject;

    [SerializeField]
    bool showOnMap = false;
    [SerializeField]
    bool showOnLevel = false;

    bool btnsActive = true;
    int count = 0;

    public bool isShowBtn = true;

    IEnumerator Start()
    {
        if(textNewCount != null)
        {
            textNewCount.transform.parent.parent.gameObject.GetComponent<Animator>().enabled = false;
            textNewCount.transform.parent.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(2f);

        SaveManager.GameProgress.Current.arrayOpenedInfoZombie.Clear();
        if (SaveManager.GameProgress.Current.arrayOpenedZombie == null)
            SaveManager.GameProgress.Current.arrayOpenedZombie = new int[0];
        foreach (var o in SaveManager.GameProgress.Current.arrayOpenedZombie)
        {
            SaveManager.GameProgress.Current.arrayOpenedInfoZombie.Add(o);
        }
        UpdateIcon();
    }

    void UpdateIcon()
    {
        int openLevel = SaveManager.GameProgress.Current.CompletedLevelsNumber;
        count = 0;
        foreach (var o in InfoLoaderConfig.Instance.infoEnemiesDatas)
        {
            if (o.openLevel <= openLevel + 1 && o.openLevel != -1 && showOnMap == o.showOnMap
            || o.openLevel <= openLevel + 1 && o.openLevel != -1 && showOnLevel == o.showOnLevel)
            {
                if (SaveManager.GameProgress.Current.arrayOpenedInfoZombie.IndexOf((int)o.enemyType) == -1)
                {
//                    Debug.Log($"type info: {o.enemyType}");
                    count++;
                }
            }
        }
        if (count > 0)
        {
            if (textNewCount != null)
            {
                textNewCount.text = count.ToString();
                textNewCount.transform.parent.gameObject.SetActive(true);
                textNewCount.transform.parent.parent.gameObject.GetComponent<Animator>().enabled = true;
            }
        }
        else
        {
            if (textNewCount != null)
            {
                textNewCount.text = count.ToString();
                textNewCount.transform.parent.gameObject.SetActive(false);
                textNewCount.transform.parent.parent.gameObject.GetComponent<Animator>().enabled = false;
            }
        }
    }

    public void Open()
    {
        Time.timeScale = 0.01f;
        Debug.Log($"Open");
        UpdateData(EnemyType.None);
        ShowEnemyScreen(enemies[enemies.Count - 1].enemyType, true, enemies.Count - 1);
       
        if (textNewCount != null)
        {
            if (count == 0)
            {
                textNewCount.transform.parent.gameObject.SetActive(false);
                textNewCount.transform.parent.parent.gameObject.GetComponent<Animator>().enabled = false;
            }
        }
    }

    public void ShowEnemyScreen(EnemyType enemyType, bool btns = true, int index = 0)
    {
        if (currentUpInfoObject != null)
            Destroy(currentUpInfoObject);
        currentUpInfoObject = Instantiate(InfoLoaderConfig.Instance.InfoEnemyObject, transform) as GameObject;

        if(enemies.Count == 0)
            UpdateData(EnemyType.None);

        if (index >= 0)
        {
            SaveManager.GameProgress.Current.arrayOpenedInfoZombie.Add((int)enemies[index].enemyType);
            SaveManager.GameProgress.Current.arrayOpenedZombie = new int[SaveManager.GameProgress.Current.arrayOpenedInfoZombie.Count];
        }
        for (int i = 0; i < SaveManager.GameProgress.Current.arrayOpenedZombie.Length; i++)
        {
            SaveManager.GameProgress.Current.arrayOpenedZombie[i] = SaveManager.GameProgress.Current.arrayOpenedInfoZombie[i];
        }
        SaveManager.GameProgress.Current.Save();

        InfoBasePanel enemyPanel = currentUpInfoObject.GetComponent<InfoBasePanel>();
        InfoBaseData infoBaseData = InfoLoaderConfig.Instance.GetEnemyBaseData(enemyType);
        if (infoBaseData == null)
            return;
        enemyPanel.SetBaseData(infoBaseData, (int)enemyType);
        isOpen = true;

        btnsActive = btns;
        UpdateData(enemyType);
        UpdateIcon();
    }

    void UpdateData(EnemyType enemyType = EnemyType.None)
    {
        enemies.Clear();
        int openLevel = SaveManager.GameProgress.Current.CompletedLevelsNumber;
        foreach (var o in InfoLoaderConfig.Instance.infoEnemiesDatas)
        {
            if (o.openLevel <= openLevel + 1 && o.openLevel != -1 && showOnMap == o.showOnMap
            || o.openLevel <= openLevel + 1 && o.openLevel != -1 && showOnLevel == o.showOnLevel)
                enemies.Add(o);
        }


        enemies = enemies.OrderBy(o => o.openLevel).ToList();

        int i = 0;
        int has = -1;
        foreach (var o in enemies)
        {
            if (enemyType != EnemyType.None)
            {
                if (o.enemyType == enemyType)
                {
                    current = i;
                    has++;
                    break;
                }
            }
            i++;
        }
        if (has == -1)
            btnsActive = false;

        UpdateBtns();
    }

    public void Close()
    {
        isOpen = false;
        btns[0].transform.parent.gameObject.SetActive(false);
        if (LevelSettings.Current != null)
            Time.timeScale = LevelSettings.Current.usedGameSpeed;
    }


    void UpdateBtns()
    {
        if (!btnsActive)
        {
            foreach (var b in btns)
                b.SetActive(false);
            return;
        }
        Debug.Log($"current: {current}, enemies: {enemies.Count}");
        var v = 3;
        if (current == 0)
            v = 1;
        if (current >= enemies.Count - 1)
            v = 0;
        if (enemies.Count == 0 || current == 0 && enemies.Count == 1)
            v = -1;
        SetBtns(v);
    }

    void SetBtns(int value) // if == -1 all deisable 3 == all open
    {
        foreach (var b in btns)
            b.SetActive(value == 3);

        if (value != -1 && value != 3)
            btns[value].SetActive(true);

        if(isShowBtn)
            btns[0].transform.parent.gameObject.SetActive(true);
        btns[0].transform.parent.SetAsLastSibling();
    }

    public void Next()
    {
        if (!isOpen)
            return;

        current++;
        if (current >= enemies.Count)
            current = enemies.Count - 1;
        ShowEnemyScreen(enemies[current].enemyType, true, current);
    }

    public void Back()
    {
        if (!isOpen)
            return;

        current--;
        if (current <= 0)
            current = 0;
        ShowEnemyScreen(enemies[current].enemyType, true, current);
    }
}
