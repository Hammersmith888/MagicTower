using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class InfoBaseData
{
    public string titleText, descriptionText, levelFirstTimeText;
    public Sprite iconSprite;
    public List<InfoLineData> infoLineDatas = new List<InfoLineData>();

}

public class InfoBasePanel : MonoBehaviour
{
    [SerializeField]
    public GameObject backgroundObject;

    [SerializeField] private GameObject mainPanel, auraPanel, auraPanel1, auraPanel2, auraPanel3, lvlAtAura1, lvlAtAura2, lvlAtAura3;
    public UnityAction onDestroyAction;
    [SerializeField]
    protected RectTransform linesGroup;
    [SerializeField]
    protected ScrollRect scrollRect;
    [SerializeField]
    protected LocalTextLoc titleText, descriptionText, levelFirstTime;
    [SerializeField]
    Text levelFirstTimeValue;
    [SerializeField]
    protected Image iconImage;
    public List<InfoParameterLine> infoParameterLines = new List<InfoParameterLine>();

    public static InfoBasePanel instance;

    private void Awake()
    {
        instance = this;
        transform.localPosition+=new Vector3(0, -50, 0);
    }

    private void Start()
    {
        if (mainscript.CurrentLvl == 2)
        {
            SaveManager.GameProgress.Current.tutorialInfoLevel2 = true;
            SaveManager.GameProgress.Current.Save();
        }
    }
    void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus)
            DestroyIt();
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DestroyIt();
        }
    }

    public virtual void SetBaseData(InfoBaseData infoBaseData, int enemyType = -1)
    {
        if (mainPanel != null)
            mainPanel.SetActive(true);
        if (auraPanel != null)
            auraPanel.SetActive(false);
        //Проставляем пришедшие базовые данные если объекты для них назначены
        if (enemyType == (int)EnemyType.aura_properties1 || enemyType == (int)EnemyType.aura_properties2 || enemyType == (int)EnemyType.aura_properties3)
        {
            mainPanel.SetActive(false);
            auraPanel.SetActive(true);
            auraPanel1.SetActive(true);//enemyType == (int)EnemyType.aura_properties1);
            auraPanel2.SetActive(true);//enemyType == (int)EnemyType.aura_properties2);
            auraPanel3.SetActive(true);//enemyType == (int)EnemyType.aura_properties3);
            titleText.TextComponent.alignment = TextAnchor.MiddleCenter;
            descriptionText.TextComponent.alignment = TextAnchor.MiddleCenter;
            lvlAtAura1.SetActive(true);
            lvlAtAura2.SetActive(true);
            lvlAtAura3.SetActive(true);
            levelFirstTime = lvlAtAura1.GetComponent<LocalTextLoc>();
            lvlAtAura1.transform.GetChild(0).GetComponent<Text>().text = infoBaseData.levelFirstTimeText;
            lvlAtAura2.transform.GetChild(0).GetComponent<Text>().text = infoBaseData.levelFirstTimeText;
            lvlAtAura3.transform.GetChild(0).GetComponent<Text>().text = infoBaseData.levelFirstTimeText;

        }

        if (iconImage != null)
        {
            iconImage.sprite = infoBaseData.iconSprite;
        }
        if (titleText != null)
        {
            titleText.SetLocaleId(infoBaseData.titleText);
        }
        if (descriptionText != null)
        {
            descriptionText.SetLocaleId(infoBaseData.descriptionText);
        }

        if (levelFirstTime != null)
        {
            levelFirstTime.SetLocaleId(infoBaseData.levelFirstTimeText);
            levelFirstTimeValue.text = infoBaseData.levelFirstTimeText;
        }

        if (linesGroup == null || infoBaseData.infoLineDatas.Count <= 0)
        {
            return;
        }

        if (enemyType == (int)EnemyType.aura_properties1 || enemyType == (int)EnemyType.aura_properties2 || enemyType == (int)EnemyType.aura_properties3)
        {
            titleText.TextComponent.text = TextSheetLoader.Instance.GetString("t_0551");
            descriptionText.TextComponent.text = TextSheetLoader.Instance.GetString("t_0552");
            titleText.TextComponent.alignment = TextAnchor.MiddleCenter;
            descriptionText.TextComponent.alignment = TextAnchor.MiddleCenter;
        }


        LineBuilder(infoBaseData);
    }

    private void LineBuilder(InfoBaseData infoBaseData)
    {
        int viewCount = 0;
        for (int dataIndex = 0, line = 0; dataIndex < infoBaseData.infoLineDatas.Count; dataIndex++)
        {
            if (!ValidationLine(infoBaseData.infoLineDatas[dataIndex]))
            {
                continue;
            }

            if (line < infoParameterLines.Count && viewCount < infoParameterLines.Count)
            {
                //Если данные подходят для текущей въюшки
                if (ComparingLineParameterWithLineData(infoParameterLines[line], infoBaseData.infoLineDatas[dataIndex]))
                {
                    infoParameterLines[line].SetLineParameters(infoBaseData.infoLineDatas[dataIndex]);
                    line++;
                }
                else
                {
                    RemoveParameterLine(line);
                    InsertParameterLine(line, infoBaseData.infoLineDatas[dataIndex]);
                    line++;
                }
            }
            else
            {
                AddParameterLine(infoBaseData.infoLineDatas[dataIndex]);
            }
            viewCount++;
        }
        StartCoroutine(_LineBuild());
        CutLines(infoParameterLines.Count - viewCount);
    }

    IEnumerator _LineBuild()
    {
        yield return new WaitForEndOfFrame();
        List<int> index = new List<int>();
        List<float> size = new List<float>();
        List<float> sizeSort = new List<float>();
        for (int i = 0; i < infoParameterLines.Count; i++)
        {
            if(infoParameterLines[i].valueText == null)
            {
                index.Add(i);
                size.Add(infoParameterLines[i].titleRectTransf.sizeDelta.x);
                sizeSort.Add(infoParameterLines[i].titleRectTransf.sizeDelta.x);
            }
        }

        if (sizeSort.Count <= 1)
            yield break;

        sizeSort.Sort();
        sizeSort.Reverse();
        int ind = 0;
        float ss = 0;
        for (int i = 0; i < size.Count; i++)
        {
            if(sizeSort[0] == size[i])
                ss = size[i];
            if (sizeSort[1] == size[i])
                ind = index[i];
        }

        infoParameterLines[ind].titleRectTransf.gameObject.GetComponent<UnityEngine.UI.ContentSizeFitter>().enabled = false;
        infoParameterLines[ind].titleRectTransf.sizeDelta = new Vector2(
            ss,
            infoParameterLines[ind].titleRectTransf.sizeDelta.y
            );
    }

    private void CutLines(int count)
    {
        for (int i = infoParameterLines.Count - 1, j = 0; j < count; i--, j++)
        {
            RemoveParameterLine(i);
        }
    }

    private bool ValidationLine(InfoLineData line)
    {
        if (line.IsVisibleEmpty)
        {
            return false;
        }

        return true;
    }

    private void RemoveParameterLine(int index)
    {
        if (index < 0 || index >= infoParameterLines.Count)
        {
            return;
        }
        if (infoParameterLines[index] != null && infoParameterLines[index].gameObject)
        {
            Destroy(infoParameterLines[index].gameObject);
        }
        infoParameterLines.RemoveAt(index);
    }

    private void AddParameterLine(InfoLineData data)
    {
        InfoParameterLine line = CleateParameterLine(data.IsVisibleIcon);
        line.SetLineParameters(data);
        infoParameterLines.Add(line);
    }

    private void InsertParameterLine(int index, InfoLineData data)
    {
        InfoParameterLine line = CleateParameterLine(data.IsVisibleIcon);
        line.SetLineParameters(data);
        infoParameterLines.Insert(index, line);
    }

    private InfoParameterLine CleateParameterLine(bool isIcon)
    {
        GameObject tempLine = null;
        RectTransform linePrefab = InfoLoaderConfig.Instance.InfoLineObject;
        RectTransform linePrefabIcon = InfoLoaderConfig.Instance.InfoIconObject;
        RectTransform currentPrefab = isIcon ? linePrefabIcon : linePrefab;

        tempLine = Instantiate(currentPrefab.gameObject, linesGroup.transform) as GameObject;
        return tempLine.GetComponent<InfoParameterLine>();
    }

    private bool ComparingLineParameterWithLineData(InfoParameterLine line, InfoLineData data)
    {
        if (data.IsVisibleIcon && line is InfoParameterLineIcon) // icon field
        {
            return true;
        }
        if (!data.IsVisibleIcon && !(line is InfoParameterLineIcon)) // text field
        {
            return true;
        }
        return false;
    }

    public void DestroyIt()
    {   
        if (PanelInfoDescription.instance != null)
            PanelInfoDescription.instance.Close();
        if (onDestroyAction != null)
        {
            onDestroyAction();
        }

        if (mainscript.CurrentLvl == 5)
        {
            SaveManager.GameProgress.Current.tutorial5lvl = true;
            SaveManager.GameProgress.Current.Save();
            Tutorial.Close();
        }

        if (mainscript.CurrentLvl == 17)
            SaveManager.GameProgress.Current.tutorial17lvl = true;
        if (mainscript.CurrentLvl == 19)
            SaveManager.GameProgress.Current.tutorial19lvl = true;
        if (mainscript.CurrentLvl == 22)
            SaveManager.GameProgress.Current.tutorial22lvl = true;

        SaveManager.GameProgress.Current.Save();
        if (mainscript.CurrentLvl == 17 
            || mainscript.CurrentLvl == 19
            || mainscript.CurrentLvl == 22
            )
        {
            Tutorial.Close();
        }

        var o = FindObjectOfType<Tutorial_2>();

        if(o != null)
            o.CloseInfo();


        Destroy(gameObject);
    }
}