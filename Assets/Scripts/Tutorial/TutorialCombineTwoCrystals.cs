
using Tutorials;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCombineTwoCrystals
{
    private Tutorial_2 tutor;
    private int gemIndex;
    private GemType gemType;

    public TutorialCombineTwoCrystals(Tutorial_2 tutor)
    {
        this.tutor = tutor;
    }

    #region CombineTwoCrustal
    public void Run()
    {
        int idTutor = (int)ETutorialType.COMBINE_TWO_CRYSTALS;
        int idTutorialUpgradeMana = (int)ETutorialType.SHOP_UPGRADE_MANA;
        var shopHighlightingData = ELocalPrefsKey.ShopHighlightingData.Load<ShopHighlightingData>();

        Debug.Log($"------------ : {SaveManager.GameProgress.Current.tutorial[idTutor]},  {SaveManager.GameProgress.Current.tutorial[idTutorialUpgradeMana]}");

            if (!SaveManager.GameProgress.Current.tutorial[idTutor] && SaveManager.GameProgress.Current.tutorial[idTutorialUpgradeMana] //&& shopHighlightingData.spell[(int)Spell.SpellType.IceStrike]
           && SaveManager.GameProgress.Current.CompletedLevelsNumber >= 6)
        {
            ShopGemItemSettings.instance.GemSelect(1, GemType.Red);
            gemIndex = GetGemIndexForCombine(out gemType);
            if (gemIndex == -1)
            {
                var gemItems = PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
                int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.Red, 0);
                gemItems[gem1Id].count = 2;
                PPSerialization.Save(EPrefsKeys.Gems, gemItems);
            }

            gemIndex = GetGemIndexForCombine(out gemType);
            Debug.Log($"TutorialCombineTwoCrystals: {gemIndex}");
            if (gemIndex != -1)
            {
                UIShop.Instance.ActiveStaffItems();
                //достаточно ли монет для объединения 2 кристалов
                int combinePrice = 100;
                if (CoinsManager.Instance.Coins < combinePrice)
                    CoinsManager.AddCoinsST(combinePrice);
                if (CoinsManager.Instance.Coins >= combinePrice)
                {
                    UIShop.Instance.FocusItem(tutor.robeGemInScroll2.transform.parent.parent);
                    UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(false);
                    Core.GlobalGameEvents.Instance.LaunchEvent(Core.EGlobalGameEvent.TUTORIAL_START);

                    tutor.gemsBtn.gameObject.GetComponent<Button>().onClick.AddListener(GemsButtonClicked);

                    var c = Tutorial.Open(target: tutor.gemsBtn.gameObject, focus: new Transform[] { tutor.gemsBtn.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(75, 80), waiting: 0.5f, keyText: "t_0507");
                }
            }
        }
        
    }

    private void GemsButtonClicked()
    {
        Tutorial.Close();
        tutor.gemsBtn.GetComponent<Button>().onClick.RemoveListener(GemsButtonClicked);
        TutorialUtils.ClearAllCanvasOverrides();
       
        ShowCombineMessage();
    }

    private void ShowCombineMessage()
    {
        tutor.combineCrystals.onClick.AddListener(OnCombineClick);
        tutor.gemSettings.GemsSized[gemIndex].OnClick();
        tutor.gemInsertToItemChoese.ActivateItem("staff");
        tutor.gemSettings.BlockIncCountToCombine = true;

        var tut = Tutorial.Open(target: tutor.combineCrystals.gameObject, focus: new Transform[] { tutor.combineCrystals.gameObject.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(230, 50), waiting: 0.5f, keyText: "");
        tut.disableAnimation = true;
        tut.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    private void OnCombineClick()
    {
        tutor.combineCrystals.onClick.RemoveListener(OnCombineClick);

        Tutorial.Close();
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(true);
        tutor.gemSettings.BlockIncCountToCombine = false;
        tutor.gemSettings.GemsSized[gemIndex + 1].OnClick();

        tutor.btnCloseCombine.GetComponent<Button>().onClick.AddListener(CloseCombine);
    }

    void CloseCombine()
    {
        tutor.btnCloseCombine.GetComponent<Button>().onClick.RemoveListener(CloseCombine);
        tutor.useCrystal.onClick.AddListener(OnUse);
        Tutorial.OpenBlock(timer:0.6f);
        var tut = Tutorial.Open(target: tutor.useCrystal.gameObject, focus: new Transform[] { tutor.useCrystal.gameObject.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(75, 50), waiting: 0.5f, keyText: "");
        tut.disableAnimation = true;
        tut.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    void OnUse()
    {
        tutor.useCrystal.onClick.RemoveListener(OnUse);

        Tutorial.Close();

        UIShop.Instance.ActiveStaffItems();
        UIShop.Instance.FocusItem(tutor.pickRobeBtn.transform.parent);

        SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.COMBINE_TWO_CRYSTALS] = true;
        SaveManager.GameProgress.Current.Save();
    }

    private int GetGemIndexForCombine(out GemType type)
    {
        type = GemType.None;
        Gem_Items gemItems = LoadGemSaves();

        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].count >= 2)
            {
                type = gemItems[i].gem.type;
                return i;
            }
        }

        return -1;
    }

    private Gem_Items LoadGemSaves()
    {
        return PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
    }
    #endregion
}