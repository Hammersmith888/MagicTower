using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsPreview : MonoBehaviour
{
    public static AdsPreview instance;

    void Awake()
    {
        instance = this;
        Debug.LogError(gameObject.name);
    }


    [SerializeField]
    GameObject panel, buttons, hammer;



    public bool isShow = false;

    [SerializeField]
    UnityEngine.UI.Text text;

    public bool disabledAds {
        get
        {
            return SaveManager.GameProgress.Current.disableAds;
        }
    }

    public void Play()
    {
        Debug.Log($"ADs.AdsManager.Instance.isAnyVideAdAvailable: {ADs.AdsManager.Instance.isAnyVideAdAvailable}");
    }
    public void Open()
    {
        //PPSerialization.Save("AdsPreviewCount", "2");
        //PPSerialization.Save("AdsDisabledPayment", "0");
        if (!CASAdsController.Instance.IsRewardedLoaded())
            return;
        try
        {
            var x = int.Parse(PPSerialization.GetJsonDataFromPrefs("AdsPreviewCount"));
        }
        catch
        {
            PPSerialization.Save("AdsPreviewCount", "0");
        }
        if (disabledAds)
            return;
        isShow = true;
        panel.SetActive(true);
        hammer.SetActive(false);
        buttons.SetActive(false);
        text.text = TextSheetLoader.Instance.GetString("t_0561");

        StartCoroutine(_Open());
    }

    IEnumerator _Open()
    {
        PPSerialization.Save("AdsPreviewCount", (int.Parse(PPSerialization.GetJsonDataFromPrefs("AdsPreviewCount")) + 1).ToString());
        yield return new WaitForSeconds(2);
        //&& SaveManager.GameProgress.Current.CompletedLevelsNumber >= 4
        if (int.Parse(PPSerialization.GetJsonDataFromPrefs("AdsPreviewCount")) >= (SaveManager.GameProgress.Current.CompletedLevelsNumber >= 17 ? 2 : 5) )
        {
            hammer.SetActive(true);
            buttons.SetActive(true);
            text.text = TextSheetLoader.Instance.GetString("t_0562");
        }
        else
            isShow = false;
    }

    public void No()
    {
        //panel.SetActive(false);
        isShow = false;
        PPSerialization.Save("AdsPreviewCount", "0");
        Open();
    }

    public void Yes()
    {
        //Purchaser.Instance.BuyDisbaleAds();
        Purchaser.Instance.Buy10kWithRemoveAds();
    }

    public void Bought()
    {
        if (panel != null)
            panel.SetActive(false);

        PopupWindow.Create(gameObject.transform, "", TextSheetLoader.Instance.GetString("t_0571").Replace("/n", System.Environment.NewLine), CloseWindow);
        PPSerialization.Save("AdsPreviewCount", "0");
        SaveManager.GameProgress.Current.disableAds = true;
        SaveManager.GameProgress.Current.Save();
    }

    void CloseWindow()
    {
        Debug.Log("CloseWindow");
        isShow = false;
    }
}
