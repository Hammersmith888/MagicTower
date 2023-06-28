using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoParameterLineIcon : InfoParameterLine {

    [Header("Icon:")]
    [SerializeField]
    private HorizontalLayoutGroup group;
    [SerializeField]
    public Image firsIcon;
    private List<Image> imageItems = new List<Image>();

    public override void SetLineParameters(InfoLineData infoLineData)
    {
        Clear();
        SetTitleText(infoLineData);
        SetIcons(infoLineData);
        //StartCoroutine(AutoPlaceValue());
        SetButton(infoLineData);
        StartCoroutine(_Set());
    }

    IEnumerator _Set()
    {
        yield return new WaitForEndOfFrame();
        firsIcon.color = Color.white;
        for (int i = 0; i < imageItems.Count; i++)
        {
            imageItems[i].color = Color.white;
        }
    }

    private void Clear()
    {
        for (int i = 0; i < imageItems.Count; i++)
        {
            if (imageItems[i] == null || imageItems[i].gameObject == null)
            {
                continue;
            }
            Destroy(imageItems[i].gameObject);
        }
        imageItems.Clear();
    }

    private void SetIcons(InfoLineData infoLineData)
    {
        bool first = false;
        Image inst = null;
        for (int i = 0; i < infoLineData.ValueiIcon.Length; i++)
        {
            if (infoLineData.ValueiIcon[i] == null)
            {
                continue;
            }

            if (!first)
            {
                firsIcon.gameObject.SetActive(true);
                firsIcon.sprite = infoLineData.ValueiIcon[i];
                firsIcon.color = new Color(0, 0, 0, 0);
                AddPopupToIcon(firsIcon.gameObject, infoLineData, i);
                first = true;
                continue;
            }
            inst = Instantiate(firsIcon, group.transform);
            inst.sprite = infoLineData.ValueiIcon[i];
            inst.color = new Color(0,0,0,0);
            AddPopupToIcon(inst.gameObject, infoLineData, i);
            imageItems.Add(inst);
        }

    }

    private void GivePopupToIconTouch(Vector3 position, string descText)
    {
        GameObject descPopup = Instantiate(AnyWindowsLoaderConfig.Instance.GetWindowOfType(AnyWindowsLoaderConfig.WindowType.microInfoResist), transform.parent.parent.parent) as GameObject;
        descPopup.transform.position = position;
        descPopup.GetComponent<MicroInfoResist>().OpenIt(descText);
    }

    private void AddPopupToIcon(GameObject iconObj, InfoLineData infoLineData, int iconId)
    {
        Button iconAutoButton = iconObj.GetComponent<Button>();
        if (iconAutoButton == null)
        {
            iconAutoButton = iconObj.gameObject.AddComponent<Button>();
        }

        iconAutoButton.onClick.RemoveAllListeners();

        string descText = infoLineData.resistOrVulnarebilityTexts[iconId];

        iconAutoButton.onClick.AddListener(delegate { GivePopupToIconTouch(iconObj.transform.position, descText); });
    }
}