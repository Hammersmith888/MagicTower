using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAdsToManaWindow : MonoBehaviour
{
    [SerializeField]
    private Button viewButton, closeButton;
    [SerializeField]
    private Toggle dontShowCheckbox;
    private bool showAfter = true;
    [SerializeField]
    GameObject[] objs;
    [SerializeField]
    UIConsFlyAnimation flyAnimation;
    [SerializeField]
    Image imgIcon;

    bool isShowMana = false;
    [SerializeField]
    Text description;
    [SerializeField]
    GameObject[] icons;
    public enum TypePotions
    {
        Mana, Power, Health
    }
    public TypePotions type = TypePotions.Mana;

    void Start()
    {
        viewButton.onClick.AddListener(ShowAds);
        closeButton.onClick.AddListener(CloseIt);
        dontShowCheckbox.onValueChanged.AddListener(ToggleCheckBox);
        string mes = "";
        if (type == TypePotions.Mana)
            mes = "t_0509";
        if (type == TypePotions.Power)
            mes = "t_0639";
        if (type == TypePotions.Health)
            mes = "t_0672";
        description.text = TextSheetLoader.Instance.GetString(mes);
        icons[0].SetActive(type == TypePotions.Mana);
        icons[1].SetActive(type == TypePotions.Power);
        icons[2].SetActive(type == TypePotions.Health);
    }

    private void CloseIt()
    {
        if (!isShowMana)
        {
            Time.timeScale = LevelSettings.Current.usedGameSpeed;
            UIPauseController.Instance.pauseCalled = false;
            Destroy(gameObject);
            return;
        }
       // PlayerPrefs.SetInt(GameConstants.SaveIds.ShowAdsForMana, showAfter ? 1 : 0);
        
        StartCoroutine(_Close());
    }


    IEnumerator _Close()
    {
        viewButton.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        imgIcon.enabled = false;
        foreach (var o in objs)
            o.SetActive(false);
        var obj = GameObject.FindGameObjectWithTag("ManaTarget");
        if(isShowMana)
            flyAnimation.PlayEffect(obj.transform.position);
        yield return new WaitForSecondsRealtime(2f);
        UIPauseController.Instance.pauseCalled = false;
        Time.timeScale = LevelSettings.Current.usedGameSpeed;

        Destroy(gameObject);
    }

    private void ShowAds()
    {
        ADs.AdsManager.ShowVideoAd((bool viewResult) =>
        {
            if (viewResult)
            {
                isShowMana = true;
                if (type == TypePotions.Mana)
                    PotionManager.AddPotion(PotionManager.EPotionType.Mana, 5);
                if (type == TypePotions.Power)
                    PotionManager.AddPotion(PotionManager.EPotionType.Power, 5);
                if (type == TypePotions.Health)
                    PotionManager.AddPotion(PotionManager.EPotionType.Health, 5);

                AnalyticsController.Instance.LogMyEvent("Add_5_Bottles_" + type.ToString());
                Mana.Current.RestoreToFull();
                CloseIt();
            }
        });
    }

    private void ToggleCheckBox(bool on)
    {
        showAfter = !on;
        SaveManager.GameProgress.Current.mapLowMana = on;
        SaveManager.GameProgress.Current.Save();
    }

    private void OnDisable()
    {
        if (PlayerController.Instance.CurrentHealth == 0)
        {
            GameObject.FindObjectOfType<PlayerController>().ContinueGame();
        }
    }
}
