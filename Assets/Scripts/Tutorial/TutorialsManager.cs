
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorials
{
    public enum ETutorialType
    {
        None,
        KILLENEMY_COLLECTCOIN_UPGRADE,
        NEED_TO_FIND,
        MAP_START_LEVEL_2,
        USE_ACID_SCROLL,
        USE_HEALTH_POTION,
        USE_MANA_POTION,
        USE_NEW_SPELL,
        SHOP_UPGRADE_MANA,
        SHOP_UPGRADE_HEALTH,
        SHOP_UPGRADE_DRAGON,
        SHOP_UPGRADE_WALL,
        CLICK_INFO_BUTTON_LVL_5,
        TUTORIAL_BOSS_IS_COMING,
        USE_POWER_POTION,
        MEET_THE_BIRD, // старый ключ от тутора птички. Данный индекс (15) использовался в других туторах почему-то
        DAILY_SPIN,
        DAILY_REWARD,
        CHANGE_LIGHTNINGS,
        FIRST_CRYSTAL_INGAME,
        FIRST_CRYSTAL_SHOP,
        COMBINE_TWO_CRYSTALS,
        REWARD_ACHIEVEMENT,
        SPELL_4_SLOT,
        SCROLL_4_SLOT,
        BIRD,
        DOUBLE_SPEED_BUTTON,
        CASUAL_MODE_BUTTON,
        CASUAL_MODE_AUTO_HP,
        CHANGE_SPELL,
        STREAM_SPELL,
        WALL_UPDATE,
        DRAGON_UPDATE
    }

    public class TutorialsManager : MonoBehaviour
    {
        public static ETutorialType ActiveTutorial
        {
            get; private set;
        }

        public static bool IsAnyTutorialActive
        {
            get
            {
                return ActiveTutorial != ETutorialType.None;
            }
        }

        public static bool IsTutorialActive(ETutorialType tutorialType)
        {
            return ActiveTutorial == tutorialType;
        }

        public static void OnTutorialStart(ETutorialType tutorType)
        {
            ActiveTutorial = tutorType;
        }

        public static void OnTutorialCompleted()
        {
            if (ActiveTutorial != ETutorialType.None)
            {
                MarkTutorialAsComplete(ActiveTutorial);
                ActiveTutorial = ETutorialType.None;
            }
        }

        public static bool[] MarkTutorialAsComplete(ETutorialType tutorType)
        {
            SaveManager.GameProgress.Current.tutorial[(int)tutorType] = true;
            SaveManager.GameProgress.Current.Save();
            return SaveManager.GameProgress.Current.tutorial;
        }

        public static bool GetMarkTutorial(ETutorialType tutorType)
        {
            //Debug.Log($"SaveManager.GameProgress.Current: {SaveManager.GameProgress.Current}");
            return SaveManager.GameProgress.Current.tutorial[(int)tutorType];
        }

        public static void MarkTutorialsAsUnComplete_Test(params ETutorialType[] tutorsTypes)
        {
            if (!tutorsTypes.IsNullOrEmpty())
            {
                for (int i = 0; i < tutorsTypes.Length; i++)
                {
                    SaveManager.GameProgress.Current.tutorial[(int)tutorsTypes[i]] = false;
                }
                SaveManager.GameProgress.Current.Save();
            }
            
        }
    }
}
