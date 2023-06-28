using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutorials;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUseFirstCrystal : MonoBehaviour
{
    private Tutorial_2 tutor;

    public TutorialUseFirstCrystal()
    {
    }

    public TutorialUseFirstCrystal(Tutorial_2 tutor)
    {
        this.tutor = tutor;
    }

    public static TutorialUseFirstCrystal instance;

    private void Awake()
    {
        instance = this;
    }

    public void Run()
    {
        var t = tutor.gameObject.AddComponent<TutorialUseFirstCrystal>();
        t.tutor = tutor;
    }

    IEnumerator Start()
    {
        // Debug.Log($"_Run start");
        yield return new WaitForEndOfFrame();
        //Tutorial.OpenBlock(timer:0.01f);

        //if ((SaveManager.GameProgress.Current.CompletedLevelsNumber == 15 && !SaveManager.GameProgress.Current.tutorial15lvl )
        //    || (SaveManager.GameProgress.Current.CompletedLevelsNumber == 45 && !SaveManager.GameProgress.Current.tutorial45lvl))
        //{
        //    TutorialOpen();
        //}
    }

    public void TutorialOpen(bool isOldVersion = false)
    {
        int idTutor = (int)ETutorialType.FIRST_CRYSTAL_SHOP;
        Core.GlobalGameEvents.Instance.LaunchEvent(Core.EGlobalGameEvent.TUTORIAL_START);
        tutor.gameObject.SetActive(true);
        if (!SaveManager.GameProgress.Current.tutorial[idTutor] && !isOldVersion)
        {
            //RobeGemInScrollSetMessage();
            //UIShop.Instance.ActiveStaffItems();
        }
        if (isOldVersion)
        {
            Tutorial.Open(target: UIShop.Instance.gemsBtn, focus: new Transform[] { UIShop.Instance.gemsBtn.transform }, mirror: true,
            rotation: new Vector3(0, 0, 0), offset: new Vector2(50, 50), waiting: 0, keyText: "");
            UIShop.Instance.gemsBtn.GetComponent<Button>().onClick.AddListener(OpenTut);
        }
    }

    void OpenTut()
    {
        UIShop.Instance.gemsBtn.GetComponent<Button>().onClick.RemoveListener(OpenTut);
        Tutorial.Close();
        var gemRed = GetGameTypeAndLevel(GemType.Red);
        var gemWhite = GetGameTypeAndLevel(GemType.White);

        if (gemRed != -1)
        {
            ShopGemItemSettings.instance.GemSelect(gemRed);
        }
        else if (gemWhite != -1)
        {
            ShopGemItemSettings.instance.GemSelect(gemWhite, GemType.White);
        }
        else
        {
            var gemItems = PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
            int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.White, 0);
            gemItems[gem1Id].count = 1;
            PPSerialization.Save(EPrefsKeys.Gems, gemItems);

            ShopGemItemSettings.instance.GemSelect(0, GemType.White);
        }
        RobeUseCrystalSetMessage();
    }

    private int GetGameTypeAndLevel(GemType type)
    {
        for (int i = 1; i <= 5; i++)
        {
            if (ShopGemItemSettings.instance.GetCount(type, i) != 0)
                return i - 1;
        }
        return -1;
    }

    private bool ValidationCrystal()
    {
        int count = 0;
        for (int i = 0; i < tutor.itemShabbyRobe.wear.gemsInSlots.Length; i++)
        {
            if (tutor.itemShabbyRobe.wear.gemsInSlots[i].type != GemType.None)
            {
                count++;
            }
        }

        return count == 0;
    }

   
    private void StaffFirstCrystalButtonClicked()
    {
        ContinueFirstCrystalTutor();
    }

    public void ContinueFirstCrystalTutor()
    {
        if (!SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.FIRST_CRYSTAL_SHOP])
        {
            //tutor.gameObject.SetActive(true);
           // UIShop.Instance.ActiveStaffItems();
            var gemItems = PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
            int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.Blue, 0);
            gemItems[gem1Id].count += 2;
            PPSerialization.Save(EPrefsKeys.Gems, gemItems);
            ShopGemItemSettings.instance.GemSelect(0, GemType.Blue);
            //Extensions.CallActionAfterDelayWithCoroutine(tutor, 0.03f, RobeGemInScrollSetMessage, true);
        }
    }

    //Step 1
    private void RobeGemInScrollSetMessage()
    {
        tutor.robeGemInScroll.onClick.AddListener(OnAddGemToRobeButtonClicked);
        tutor.closeGems.SetActive(false);
        Tutorial.Open(target: tutor.robeGemInScroll.gameObject,
            focus: new Transform[] { tutor.robeGemInScroll.transform.parent.parent, tutor.staffsButton.transform },
            mirror: false, rotation: new Vector3(0, 0, 0), 
            offset: new Vector2(75, 90), 
            waiting: 0f, 
            keyText: "t_0505");
    }

    private void OnAddGemToRobeButtonClicked()
    {
       
        tutor.robeGemInScroll.onClick.RemoveListener(OnAddGemToRobeButtonClicked);
        tutor.gameObject.SetActive(false);
        Tutorial.Close();
        RobeUseCrystalSetMessage();
    }

    //Step 2
    private void RobeUseCrystalSetMessage()
    {
        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(false);
        tutor.gemInsertToItemChoese.ActivateItem("cape"); 
        ContinueFirstCrystalTutor();
        tutor.useCrystal.onClick.AddListener(OnInsertCrystalInRobeButtonClicked);
        tutor.useCrystal.gameObject.SetActive(true);
        var tut = Tutorial.Open(target: tutor.useCrystal.gameObject, 
            focus: new Transform[] { tutor.useCrystal.transform }, mirror: false, rotation: new Vector3(0, 0, 0), 
            offset: new Vector2(120, 30), waiting: 0);
        tut.disableAnimation = true;
        tut.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    private void OnInsertCrystalInRobeButtonClicked()
    {
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        tutor.useCrystal.onClick.RemoveListener(OnInsertCrystalInRobeButtonClicked);
        tutor.gameObject.SetActive(false);
        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(true);
        UIShop.Instance.ActiveStaffItems();
        Tutorial.Close();
        //RobePopupInfoSetMessage();
        
      
    }

    //Step 3
    private void RobePopupInfoSetMessage()
    {
        UIShop.Instance.ActiveStaffItems();
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        Tutorial.Close();
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 2)
        {
            tutor.robePopupInfo.onClick.AddListener(RobePopupInfoButtonOnClick);
            Tutorial.Open(target: tutor.robePopupInfo.gameObject, 
                focus: new Transform[] { tutor.robePopupInfo.transform },
                mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(35, 80), waiting: 0.3f, keyText: "t_0278");
        }
        tutor.closeGems.SetActive(true);
        tutor.gameObject.SetActive(false);
        SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.FIRST_CRYSTAL_SHOP] = true;
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 15)
            SaveManager.GameProgress.Current.tutorial15lvl = true;
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 45)
            SaveManager.GameProgress.Current.tutorial45lvl = true;
        SaveManager.GameProgress.Current.Save();
    }


    private void RobePopupInfoButtonOnClick()
    {
        tutor.gameObject.SetActive(false);
        tutor.itemShabbyRobe.UseWear(5); //такой же слот назначен в редакторе
        tutor.itemGrandfathersCrutch.UseWear(0); //такой же слот назначен в редакторе

        tutor.infoWearWindow.hideWindowEvent -= ShowUnlockPopup;
        tutor.infoWearWindow.hideWindowEvent += ShowUnlockPopup;
        Tutorial.Close();
        tutor.closeWearInfo.SetActive(true);
        tutor.closeWearInfo.GetComponent<Button>().onClick.AddListener(() =>
        {
            //UIAchievementsHelper.instance.OpenTutorialBtn();
        });
    }

    public void ShowUnlockPopup()
    {
        tutor.infoWearWindow.hideWindowEvent -= ShowUnlockPopup;
        string description = tutor.itemShabbyRobe.wearName.text + ",\n";
        description += tutor.itemGrandfathersCrutch.wearName.text;
    }
}