
using System;
using UnityEngine;
using UnityEngine.UI;

public class LocalTextLoc : MonoBehaviour
{
    [SerializeField]
    private string _thisID;

    [SerializeField]
    private FontLang fontType;

    [SerializeField]
    public LangTextsSubParameters parameters = new LangTextsSubParameters();

    public string CurrentText;

    [Space(15f)]
    [SerializeField]
    private bool matchRectWidthByText;
    [SerializeField]
    private float maxRectWidth;

    private string stringToAdd;
    private Vector2 defaultRectSize;

    public bool overrideFont = true;
    public bool overrideFontSize = false;
    private Text m_TextComponent;
    public Text TextComponent
    {
        get
        {
            if (m_TextComponent == null)
            {
                m_TextComponent = GetComponent<Text>();
            }
            return m_TextComponent;
        }
    }


    public string LocaleID
    {
        get
        {
            return _thisID;
        }
    }

    private RectTransform m_RectTransform;
    public RectTransform RectTransform
    {
        get
        {
            if (m_RectTransform == null)
            {
                m_RectTransform = GetComponent<RectTransform>();
            }
            return m_RectTransform;
        }
    }

    private void Awake()
    {
        defaultRectSize = RectTransform.sizeDelta;
    }

    public void SetLocaleId(string id)
    {
        _thisID = id;
        SetText();
    }

    private void OnEnable()
    {
        SetText();
    }

    public void SetTextWithoutParameters()
    {
        SetText(_thisID, true, false);
    }

    public void SetText(params object[] args)
    {
        SetText(_thisID, true, true, args);
    }

    public void SetText(string stringToAdd)
    {
        this.stringToAdd = stringToAdd;
        SetText(_thisID, true, true);
    }

    public void SetText(string localeID, bool useOriginalID, bool useParameters = true, params object[] args)
    {
        if (TextSheetLoader.Instance == null)
        {
#if UNITY_EDITOR
            Debug.Log("No test sheets");
#endif
        }
        CurrentText = TextSheetLoader.Instance.GetString(localeID);

        if (matchRectWidthByText)
        {
            if (defaultRectSize != new Vector2(0f, 0f))
            {
                RectTransform.sizeDelta = defaultRectSize;
            }
        }

        var newFont = TextSheetLoader.Instance.GetFont(fontType);
        if (newFont != null)
        {
            if (overrideFont)
            {
                TextComponent.font = newFont;
            }
            
        }

        //Debug.Log($"id: {localeID}, text: {CurrentText}");

        if (!args.IsNullOrEmpty())
        {
            var t = string.Format(CurrentText, args) + (stringToAdd == null ? "" : stringToAdd);
            TextComponent.text = t.Replace("/n", System.Environment.NewLine);
        }
        else if (CurrentText != "" || TextComponent.text == "")
        {
            var t = "" + CurrentText + (stringToAdd == null ? "" : stringToAdd);
            TextComponent.text = t.Replace("/n", System.Environment.NewLine);
        }

        if (useParameters)
        {
            ApplyParameters(useOriginalID ? _thisID : localeID);
        }

        if (overrideFontSize)
            GetComponent<Text>().fontSize = (int)parameters.maxsize;

        if (matchRectWidthByText)
        {
            var rectSize = RectTransform.sizeDelta;
            rectSize.x = Mathf.Min(TextComponent.preferredWidth, maxRectWidth);
            RectTransform.sizeDelta = rectSize;
        }
    }

    public void ScaleTextMaxSizeParameter(float scale)
    {
        parameters.maxsize = Mathf.Round(parameters.maxsize * scale);
    }

    private void ApplyParameters(string localeID)
    {
        var loadedParameters = TextSheetLoader.Instance.GetTextParams(localeID);

        if (loadedParameters != null)
        {
            parameters = loadedParameters;
        }

        //TextComponent.resizeTextForBestFit = true;
        //if (parameters.bestfit != "")
        //{
        //    if (parameters.bestfit == "off")
        //    {
        //        TextComponent.resizeTextForBestFit = false;
        //    }
        //}

        if (parameters.color != "")
        {
        }

        if (parameters.font != String.Empty && parameters._id!="")
        {
            Font font = Resources.Load("Fonts/"+parameters.font) as Font;
            TextComponent.font = font;
        }

        if (parameters.fontsize > 0.001f)
        {
            TextComponent.fontSize = (int)parameters.fontsize;
        }

        if (parameters.fontstyle != "")
        {
        }

        if (parameters.linespacing > 0.001f)
        {
            TextComponent.lineSpacing = parameters.linespacing;
        }

        if (parameters.maxsize > 0.001f && overrideFont)
        {
            TextComponent.resizeTextMaxSize = (int)parameters.maxsize;
        }
        if (parameters.alignment != "")
        {
            if (parameters.alignment == "MiddleLeft")
            {
                TextComponent.alignment = TextAnchor.MiddleLeft;
            }
            if (parameters.alignment == "MiddleCenter")
            {
                TextComponent.alignment = TextAnchor.MiddleCenter;
            }
            if (parameters.alignment == "MiddleRight")
            {
                TextComponent.alignment = TextAnchor.MiddleRight;
            }
            if (parameters.alignment == "UpperCenter")
            {
                TextComponent.alignment = TextAnchor.UpperCenter;
            }
        }
    }
}
