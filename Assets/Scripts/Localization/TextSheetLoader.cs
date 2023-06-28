using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LanguageTexts
{
    public string LangId;
    public string _id;

    public string _en;
    public string _ru;
    public string _de;
    public string _sp;
    public string _jp;
    public string _cn;
    public string _ko;
}

[System.Serializable]
public class LangTextsSubParameters
{
    public string _id;
    public string font;
    public string fontstyle;
    public float fontsize;
    public float linespacing;
    public float maxsize;
    public string color;
    public string bestfit;
    public string alignment;
}

public class TextSheetLoader : MonoBehaviour
{
    [System.Serializable]
    public class Language_Texts : ArrayInClassWrapper<LanguageTexts>
    {
        public Language_Texts()
        {
        }

        public Language_Texts(int capacity) : base(capacity)
        {
        }
    }

    [System.Serializable]
    public class Lang_TextsSubParameters : ArrayInClassWrapper<LangTextsSubParameters>
    {
        public Lang_TextsSubParameters()
        {
        }

        public Lang_TextsSubParameters(int capacity) : base(capacity)
        {
        }
    }

    [System.Serializable]
    public class OneLoc
    {
        public string _langId;
        public string _text;
    }

    [System.Serializable]
    public class SingleTextLoc
    {
        public string _textId;
        public List<OneLoc> oneLoc = new List<OneLoc>();
    }

    [SerializeField]
    private List<SingleTextLoc> _texts = new List<SingleTextLoc>();
    [SerializeField]
    private List<Lang_TextsSubParameters> subParams = new List<Lang_TextsSubParameters>();

    //[SerializeField]
    //private Language_Texts _textsTemp;

    public static TextSheetLoader Instance;


    public string langId;
    private int langIndex = 0;

    private FontsLocalizationConfig fontsChoise;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        fontsChoise = GetComponent<FontsLocalizationConfig>();
    }

    void Start()
    {
        SetDefaultLanguage();
    }

    public LangTextsSubParameters GetTextParams(string _id)
    {
        if (string.IsNullOrEmpty(_id))
        {
            return null;
        }
        int subParamsNumber = subParams[langIndex].getInnerArray.Length;
        for (int i = 0; i < subParamsNumber; i++)
        {
            if (_id == subParams[langIndex][i]._id)
            {
                return subParams[langIndex][i];
            }
        }

        return null;
    }

    public static string GetStringST(string _id)
    {
        if (Instance != null)
        {
            return Instance.GetString(_id);
        }
        return _id;
    }

    bool once = false;

    public string GetString(string _id)
    {
        if (string.IsNullOrEmpty(_id))
        {
            return "";
        }
        string to_return = "";
        int textsCount = _texts.Count;
        int locCount;

        //Debug.Log($"GET STRING  =============: {textsCount}");

        //if (!once)
        //{
        //    for (int i = 0; i < textsCount; i++)
        //    {
        //        locCount = _texts[i].oneLoc.Count;
        //        for (int j = 0; j < locCount; j++)
        //        {
        //            if (_texts[i].oneLoc[j]._langId == langId)
        //                Debug.Log($"start lang: {_texts[i]._textId}, count: {_texts[i].oneLoc[j]._text}");
        //        }
        //    }
        //    once = true;
        //}

        for (int i = 0; i < textsCount; i++)
        {
            //Debug.Log($"_id: {_id},  _texts[i]._textId: {_texts[i]._textId}");
            if (_id == _texts[i]._textId)
            //if (System.String.Equals(_id, _texts[i]._textId))
            {
                locCount = _texts[i].oneLoc.Count;
                for (int j = 0; j < locCount; j++)
                {
                    if (_texts[i].oneLoc[j]._langId == langId)
                    {
                        to_return = _texts[i].oneLoc[j]._text;
                        break;
                    }
                }
                break;
            }
        }
        return to_return;
    }

    public Font GetFont(FontLang _type)
    {
        return fontsChoise.GetFont(_type);
    }

    public Font GetFontFromLang(string thisLangId, FontLang _type)
    {
        if (thisLangId == langId)
        {
            return fontsChoise.GetFont(_type);
        }
        else
        {
            return fontsChoise.GetFontByLang(thisLangId, _type);
        }
        //Font to_return = fontsChoise.Fonts[ 0 ]._fonts[ 0 ]._thisFont;
        //int fontsLangId = 0;
        //for( int i = 0; i < fontsChoise.Fonts.Count; i++ )
        //{
        //	if( fontsChoise.Fonts[ i ]._langId == thisLangId )
        //	{
        //		fontsLangId = i;
        //		break;
        //	}
        //}
        //for( int i = 0; i < fontsChoise.Fonts[ fontsLangId ]._fonts.Length; i++ )
        //{
        //	if( fontsChoise.Fonts[ fontsLangId ]._fonts[ i ]._type == _type )
        //	{
        //		to_return = fontsChoise.Fonts[ fontsLangId ]._fonts[ i ]._thisFont;
        //		break;
        //	}
        //}
        //return to_return;
    }

    public void SetDefaultLanguage(string setLang = "Unknown")
    {
        if (!PlayerPrefs.HasKey("CurrentLanguage"))
        {
            PlayerPrefs.SetString("CurrentLanguage", Application.systemLanguage.ToString());
        }
        else if (setLang != "Unknown")
        {
            PlayerPrefs.SetString("CurrentLanguage", setLang);
        }
        string savedId = PlayerPrefs.GetString("CurrentLanguage");
        langId = "EN";
        switch (savedId)
        {
            case "English":
                langIndex = 0;
                langId = "EN";
                break;
            case "Unknown":
                langIndex = 0;
                langId = "EN";
                break;
            case "Russian":
                langIndex = 1;
                langId = "RU";
                break;
            case "German":
                langIndex = 2;
                langId = "DE";
                break;
            case "Spanish":
                langIndex = 3;
                langId = "SP";
                break;
            case "Japanese":
                langIndex = 4;
                langId = "JP";
                break;
            case "Chinese":
                langIndex = 5;
                langId = "CN";
                break;
            case "ChineseTraditional":
                langIndex = 5;
                langId = "CN";
                break;
            case "Korean":
                langIndex = 6;
                langId = "KO";
                break;
        }

        fontsChoise.ReloadFonts(langId);
        ReSetAllTextsOnScene();
    }

    private void ReSetAllTextsOnScene()
    {
        LocalTextLoc[] textsOnScene = GameObject.FindObjectsOfType<LocalTextLoc>();
        foreach (LocalTextLoc changeText in textsOnScene)
        {
            changeText.SetText();
        }
    }

#if UNITY_EDITOR
    public void SetOfflineTextsEditor(CloudConnectorCore.QueryType query, List<string> objTypeNames, List<string> jsonData)
    {
        Debug.Log("Saving");
        var _textsTemp = Language_Texts.Create<Language_Texts>(GSFUJsonHelper.JsonArray<LanguageTexts>(jsonData[8]));
        _texts.Clear();
        subParams.Clear();
        for (int i = 0; i < 7; i++)
        {
            var tempParams = Lang_TextsSubParameters.Create<Lang_TextsSubParameters>(GSFUJsonHelper.JsonArray<LangTextsSubParameters>(jsonData[9 + i]));
            if (tempParams != null)// && tempParams.Length != 0)
            {
                subParams.Add(tempParams);
            }
        } 

        foreach (LanguageTexts textTemp in _textsTemp)
        {
            if (!string.IsNullOrEmpty(textTemp._id))
            {
                OneLoc firstLoc = new OneLoc();
                SingleTextLoc newLoc = new SingleTextLoc();
                newLoc._textId = textTemp._id;
                firstLoc._langId = "EN";
                //Debug.Log(textTemp._en);
                firstLoc._text = textTemp._en.Replace("[l]", "\n");
                newLoc.oneLoc.Add(firstLoc);
                OneLoc firstLoc1 = new OneLoc();
                firstLoc1._langId = "RU";
                firstLoc1._text = textTemp._ru.Replace("[l]", "\n");
                newLoc.oneLoc.Add(firstLoc1);
                OneLoc firstLoc2 = new OneLoc();
                firstLoc2._langId = "DE";
                firstLoc2._text = textTemp._de.Replace("[l]", "\n");
                newLoc.oneLoc.Add(firstLoc2);
                OneLoc firstLoc3 = new OneLoc();
                firstLoc3._langId = "SP";
                firstLoc3._text = textTemp._sp.Replace("[l]", "\n");
                newLoc.oneLoc.Add(firstLoc3);
                OneLoc firstLoc4 = new OneLoc();
                firstLoc4._langId = "JP";
                firstLoc4._text = textTemp._jp.Replace("[l]", "\n");
                newLoc.oneLoc.Add(firstLoc4);
                OneLoc firstLoc5 = new OneLoc();
                firstLoc5._langId = "CN";
                firstLoc5._text = textTemp._cn.Replace("[l]", "\n");
                newLoc.oneLoc.Add(firstLoc5);
                OneLoc firstLoc6 = new OneLoc();
                firstLoc6._langId = "KO";
                firstLoc6._text = textTemp._ko.Replace("[l]", "\n");
                newLoc.oneLoc.Add(firstLoc6);
                _texts.Add(newLoc);
            }
        }
    }

    [Space(20f)]
    [Header("Find Key:")]
    public string localeKey;
    public bool findLocaleKey;

    [Header("Find Text:")]
    public string localeText;
    public bool findLocaleText;

    private void OnDrawGizmosSelected()
    {
        if (findLocaleKey)
        {
            findLocaleKey = false;
            Find(ValidationLocalKey, GetText);
        }
        else if (findLocaleText)
        {
            findLocaleText = false;
            Find(ValidationText, GetLocalKey);
        }
    }

    private void Find(System.Func<OneLoc, bool> onValidation,
                      System.Func<OneLoc, string> onGetString)
    {
        int textsCount = _texts.Count;
        for (int i = 0; i < textsCount; i++)
        {
            var locCount = _texts[i].oneLoc.Count;
            for (int j = 0; j < locCount; j++)
            {
                if (onValidation(_texts[i].oneLoc[j]))
                {
                    Debug.Log("№: " + i + " textId: " + _texts[i]._textId + "  " + j + "  " + onGetString(_texts[i].oneLoc[j]));
                    break;
                }
            }
        }
    }

    private bool ValidationLocalKey(OneLoc loc)
    {
        return loc._langId == langId;
    }

    private bool ValidationText(OneLoc loc)
    {
        return !string.IsNullOrEmpty(localeText) && loc._text.IndexOf(localeText) != -1;
    }

    private string GetText(OneLoc loc)
    {
        return loc._text;
    }

    private string GetLocalKey(OneLoc loc)
    {
        return loc._text;
    }
#endif
}