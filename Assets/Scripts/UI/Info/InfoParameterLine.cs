using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class InfoLineData
{
    [HideInInspector]
    public Color titleColor, valueColor;
    public string titleLocaleId, valueLocaleId;
    public InfoLoaderConfig.TitleColorTypes enemyParamType;
    public UnityEngine.Events.UnityAction actionTapValue;

    public bool IsVisibleEmpty { get; set; }
    public bool IsVisibleIcon { get; set; }
    public Sprite[] ValueiIcon { get; set; }
    public string[] resistOrVulnarebilityTexts { get; set; }
}

public class InfoParameterLine : MonoBehaviour
{
    public RectTransform titleRectTransf, valueRectTransf;
    public LocalTextLoc titleText, valueText;
    [SerializeField]
    protected Button valueSubButton;

    public virtual void SetLineParameters(InfoLineData infoLineData)
    {
        SetTitleText(infoLineData);
        SetValueText(infoLineData);
        //if(gameObject.activeSelf)
        //    StartCoroutine(AutoPlaceValue());
        SetButton(infoLineData);
    }

    protected void SetTitleText(InfoLineData infoLineData)
    {
        titleText.TextComponent.color = infoLineData.titleColor;
        titleText.SetLocaleId(infoLineData.titleLocaleId);
        titleText.TextComponent.text += ":";
    }

    private void SetValueText(InfoLineData infoLineData)
    {
        valueText.TextComponent.color = infoLineData.valueColor;
        if (TextSheetLoader.Instance.GetString(infoLineData.valueLocaleId) != "")
        {
            valueText.SetLocaleId(infoLineData.valueLocaleId);
        }
        else
        {
            valueText.TextComponent.text = infoLineData.valueLocaleId;
        }

        valueText.TextComponent.text = valueText.TextComponent.text;
    }

    protected void SetButton(InfoLineData infoLineData)
    {
        if (infoLineData.actionTapValue == null)
        {
            return;
        }
        valueSubButton.enabled = true;
        valueSubButton.onClick.AddListener(infoLineData.actionTapValue);
    }

    protected IEnumerator AutoPlaceValue()
    {
        yield return new WaitForEndOfFrame();
        //var titleRectSize = titleRectTransf.rect.size;
        //var titleLocalPosition = new Vector3(titleRectSize.x / 2f - transform.GetComponent<RectTransform>().sizeDelta.x / 2f, 0f, 0f);
        //titleRectTransf.localPosition = titleLocalPosition;

        //float valuePositionX = (titleLocalPosition.x + (titleRectSize.x / 2)) + valueRectTransf.sizeDelta.x / 2f;
        //valuePositionX += 6; //space
        //Vector3 newValuePos = new Vector3(valuePositionX, titleLocalPosition.y, titleLocalPosition.z);

        //valueRectTransf.localPosition = newValuePos;
    }
}