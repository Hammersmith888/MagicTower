
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Xml;
using Tutorials;

//TODO: Rename this
public class mainscript : MonoBehaviour
{
    public static mainscript Instance;

    public static int CurrentLvl = 1;

    public static int levelOpenSellGem = 14;

    public static bool ZeroEnergy = false;

    public static int strings_count;
    private XmlDocument _doc;
    private TextAsset textAsset;

    public static int level15restart = 0;

    private void OnEnable()
    {
        SpecialOffer.saveData = PlayerPrefs.HasKey("SaveDataIsHere")
            ? PPSerialization.Load<SpecialOffer.SaveData>("special_offer")
            : new SpecialOffer.SaveData();
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
                Destroy(gameObject);
        }
    }

    public static bool AutoUnlockPlayerUpgrades()
    {
        UpgradeItem.UpgradeType upgradeType = UpgradeItem.UpgradeType.None;
        return AutoUnlockPlayerUpgrades(out upgradeType);
    }

    public static bool AutoUnlockPlayerUpgrades(out UpgradeItem.UpgradeType upgradeType)
    {
        upgradeType = UpgradeItem.UpgradeType.None;
        bool isAnyUpgradesChanges = false;
      
        var gameProgress = PPSerialization.Load<SaveManager.GameProgress>(EPrefsKeys.Progress);

        Debug.Log($"gameProgress: {gameProgress.finishCount.Length}");

        int openLevel = gameProgress.finishCount.Count(i => i > 0) + 1;
        Tutorial_2 tutorShopScript = Tutorial_2.Instance;


        var upgradeItems = PPSerialization.Load<Upgrade_Items>(EPrefsKeys.Upgrades);
        gameProgress.tutorial[(int)ETutorialType.SHOP_UPGRADE_MANA] = (upgradeItems[0].unlock && upgradeItems[0].upgradeLevel != 0);
        gameProgress.tutorial[(int)ETutorialType.SHOP_UPGRADE_HEALTH] = (upgradeItems[1].unlock && upgradeItems[1].upgradeLevel != 0);
        gameProgress.tutorial[(int)ETutorialType.SHOP_UPGRADE_DRAGON] = (upgradeItems[2].unlock && upgradeItems[2].upgradeLevel != 0);
        gameProgress.tutorial[(int)ETutorialType.SHOP_UPGRADE_WALL] = (upgradeItems[3].unlock && upgradeItems[3].upgradeLevel != 0);
        gameProgress.Save();

        //Numbers: levelToUnlock, tutorialIndex, upgradeIndex
        int activeUpgradeTutorial = -1;
        bool upgradeKnowledge = CheckUpgradeTutorial(openLevel, 5, (int)ETutorialType.SHOP_UPGRADE_MANA, 0, gameProgress, upgradeItems, ref activeUpgradeTutorial);
        isAnyUpgradesChanges |= upgradeKnowledge;
        if (upgradeKnowledge)
        {
            upgradeType = UpgradeItem.UpgradeType.Knowledge;
        }

        bool upgradeFortification = CheckUpgradeTutorial(openLevel, 8, (int)ETutorialType.SHOP_UPGRADE_HEALTH, 1, gameProgress, upgradeItems, ref activeUpgradeTutorial);
        isAnyUpgradesChanges |= upgradeFortification;
        if (upgradeFortification)
        {
            upgradeType = UpgradeItem.UpgradeType.Fortification;
        }

        bool upgradeGuardPet = CheckUpgradeTutorial(openLevel, 15, (int)ETutorialType.SHOP_UPGRADE_DRAGON, 2, gameProgress, upgradeItems, ref activeUpgradeTutorial);
        isAnyUpgradesChanges |= upgradeGuardPet;
        if (upgradeGuardPet)
        {
            upgradeType = UpgradeItem.UpgradeType.GuardPet;
        }

        bool upgradeFireBarrier = CheckUpgradeTutorial(openLevel, 18, (int)ETutorialType.SHOP_UPGRADE_WALL, 3, gameProgress, upgradeItems, ref activeUpgradeTutorial);
        isAnyUpgradesChanges |= upgradeFireBarrier;
        if (upgradeFireBarrier)
        {
            upgradeType = UpgradeItem.UpgradeType.FireBarrier;
        }
        //Debug.Log($"AutoUnlockPlayerUpgrades: {openLevel > 50 }, { (!upgradeItems[4].unlock || upgradeItems[4].upgradeLevel == 0)}");
        if (PPSerialization.GetJsonDataFromPrefs("tut_" + UpgradeItem.UpgradeType.GuardPetFrost.ToString()) == "" && openLevel > 50 && (!upgradeItems[4].unlock || upgradeItems[4].upgradeLevel == 0))
        {
            upgradeItems[4].unlock = true;
            upgradeItems[4].upgradeLevel = 0;
            upgradeType = UpgradeItem.UpgradeType.GuardPetFrost;
            //bool upgradeGuardPetFrost = true;
            isAnyUpgradesChanges = true;
            activeUpgradeTutorial = 5;
            PPSerialization.Save("tut_" + UpgradeItem.UpgradeType.GuardPetFrost.ToString(), "1");
        }
        if (isAnyUpgradesChanges)
        {
            PPSerialization.Save(EPrefsKeys.Upgrades, upgradeItems);
            if (Tutorial_2.Instance != null)
            {
               // Debug.Log("-------- UPGRADE TUTORIAL START");
                Tutorial_2.Instance.RunUpgradesTutorial(activeUpgradeTutorial);
            }
        }

        var isAnyWearTutorial = false;

        if (UIShop.Instance != null)
        {
            var onList = UIShop.Instance.onOffLinks.bigSheet[0].innerList;
            var offList = UIShop.Instance.onOffLinks.bigSheet[1].innerList;
            var on = openLevel >= 3;
            for (int i = 0; i < onList.Count; i++)
            {
                onList[i].GetComponent<Button>().interactable = on;
            }
            for (int i = 0; i < offList.Count; i++)
            {
                offList[i].SetActive(!on);
            }
            if (on && Tutorial_2.Instance != null && gameProgress.tutorial[1] || !SaveManager.GameProgress.Current.tutorial15lvl || !SaveManager.GameProgress.Current.tutorial45lvl)
            {
                //isAnyWearTutorial = !gameProgress.tutorial[14] || !gameProgress.tutorial[15];
                PPSerialization.Save(EPrefsKeys.Progress, gameProgress);
                Tutorial_2.Instance.UseFirstCrystal.Run();
            }

            Tutorial_2.Instance.SpellTutorial4SlotAreFull.Run();
            Tutorial_2.Instance.ScrollTutorial4SlotAreFull.Run();
        }
        
        return isAnyWearTutorial || isAnyUpgradesChanges;
    }

    private static bool CheckUpgradeTutorial(int openedLevelsNumber, int levelToUnlock, int tutorialIndex, int upgradeIndex, SaveManager.GameProgress gameProgress, Upgrade_Items upgradeItems, ref int activeUpgradeTutorial)
    {
        if (openedLevelsNumber > levelToUnlock && !gameProgress.tutorial[tutorialIndex])
        {
            upgradeItems[upgradeIndex].unlock = true;
            upgradeItems[upgradeIndex].upgradeLevel = 0;
            if (activeUpgradeTutorial < 0)
            {
                activeUpgradeTutorial = upgradeIndex + 1;
            }
            return true;
        }
        return false;
    }

    public Sprite GetPictureByLang(string _path, string _langId)
    {
        Sprite to_return = Resources.Load(_path + _langId, typeof(Sprite)) as Sprite;
        return to_return;
    }

    public string GetTextByLang(string _id, string _langId)
    {
        string to_return = "";
        foreach (XmlNode node in _doc.DocumentElement)
        {
            strings_count = node.Attributes.Count + 1;
            for (int i = 0; i < node.Attributes.Count; i++)
            {
                if (node.Attributes[i].Name == (_id + _langId))
                {
                    string temp_str = node.Attributes[i].Value;
                    to_return = temp_str.Replace("[newl]", "\n");
                    break;
                }
            }
        }
        return to_return;
    }
}
