using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class SaveManager
{
    [System.Serializable]
    public class GameProgress
    {
        public int[] finishCount; // Количество раз, которое был пройден каждый уровень
        public bool[] tutorial; // Какие части туториала пройдены: уровень 1, магазин, уровень 2
        public int[] freeResurrectionUsedOnLevel; // Какие части туториала пройдены: уровень 1, магазин, уровень 2
        public int gold; // Накопленное золото
        public int[] bestScoreOnLevel; //Рекорд на каждом уровне
        public DateTime VIPendTime;
        public bool VIP;
        public bool VIPold;
        public bool disableAds;

        public bool vipFirstWindow = false;
        public bool mapLowMana = false;
        public bool tutorialMyZombie = false;
        public bool tutorial5wall = false;
        public bool tutorialInfoLevel2 = false;
        public bool tutorialClickLvl3 = false;
        public bool tutorial12mine = false;
        public bool firstFireWallEnable = false;
        public bool tutorialSlot13 = false;
        public bool tutorialSlot17 = false;
        public bool tutorialSlot21 = false;
        public bool tutorialSlot26 = false;
        public bool tutorialSlot59 = false;
        public bool tutorialSlot67 = false;
        public bool tutorialSlot75 = false;
        public bool tutorialSlot80 = false;
        public bool tutorialOpenFreezeDragon = false;
        public bool tutorial5lvl = false;
        public bool tutorial6lvl = false;
        public bool tutorial7lvl = false;
        public bool tutorial8lvl = false;
        public bool tutorial15lvl = false;
        public bool tutorial30lvl = false;
        public bool tutorial45lvl = false;
        public bool tutorial70lvl = false;
        public bool tutorial95lvl = false;
        public bool tutorialx2Speed = false;
        public bool tutorialx2Speed8lvl = false;
        public bool tutorialEasy = false;
        public bool tutorialIceWind = false;
        public bool tutorialPowerPotion = false;
        public bool tutorial3Achi = false;
        public bool tutorialSellShop = false;

        public bool tutorialGetAch = false;


        public bool tutorialBossMapClik15 = false;
        public bool tutorialBossMapClik30 = false;
        public bool tutorialBossMapClik45 = false;
        public bool tutorialBossMapClik70 = false;
        public bool tutorialBossMapClik90 = false;


        public int countFreeSpin = 0;

        public bool tutorial17lvl;
        public bool tutorial19lvl;
        public bool tutorial22lvl;

        public bool firstLevelPotion;

        public string crownsUtc = "0";

        public int crownsCount = -1;
        public int crownsMoney = 500;
        public int countOpenedInfoZombie = 0;
        public List<int> arrayOpenedInfoZombie = new List<int>();
        public int[] arrayOpenedZombie;

        public bool blocker = false;

        public int[] autoActiveSpeel;

        public bool tutDailyReward;
        public bool tutAchivement;
        public bool tutorialRemoveGem;

        public string firstDayWinUtc;
        public int firstStart;
        public bool tutLevel6;

        public bool[] gemsAnimationSlot;
        public bool[] gemsAnimationGemSlot;

        public bool tutorial8Lvl;

        public string first_enter_date;

        public string infoBtns = "[]";

        public bool gemBoss11, gemBoss22, gemBoss33, gemBoss44, gemBoss55;

        public int countInvite;
        public bool takeAwardInvite;
        public int CompletedLevelsNumber => finishCount == null ? 0 : finishCount.Count(i => i > 0);

        public int typePromoCode;
        public string words_code = "[]";

        public bool tutLevel2;
        public int currentPatchNoteVersion = 0;

        private static GameProgress m_Current;
        public static GameProgress Current
        {
            get
            {
                EnsureGameProgressLoaded();
                return m_Current;
            }
        }

        private static void EnsureGameProgressLoaded()
        {
            if (m_Current == null)
            {
                m_Current = PPSerialization.Load<GameProgress>(EPrefsKeys.Progress);
                if (m_Current == null)
                {
                    Debug.Log($"GameProgress is null creating new...");
                    m_Current = new GameProgress();
                    m_Current.bestScoreOnLevel = new int[300];
                    m_Current.finishCount = new int[300];
                    m_Current.tutorial = new bool[50];
                    m_Current.freeResurrectionUsedOnLevel = new int[300];
                    m_Current.tutorial[1] = true; // Для того, чтобы при загрузке магазина из меню, не включался туториал
                    m_Current.autoActiveSpeel = new int[12];
                    PPSerialization.Save(EPrefsKeys.Progress.ToString(), m_Current);
                }
                Debug.Log($"--------- <b>Game Progress Loaded</b> ----------");
            }
        }

        public static void ForceReload()
        {
            m_Current = null;
            EnsureGameProgressLoaded();
        }

        public void InitWearGemsSave()
        {
            if (SaveManager.GameProgress.Current.gemsAnimationSlot == null)
            {
                SaveManager.GameProgress.Current.gemsAnimationSlot = new bool[14];
                SaveManager.GameProgress.Current.gemsAnimationGemSlot = new bool[14];
            }
            if (SaveManager.GameProgress.Current.gemsAnimationSlot.Length == 0)
            {
                Debug.Log($"int slots:");
                SaveManager.GameProgress.Current.gemsAnimationSlot = new bool[14];
                SaveManager.GameProgress.Current.gemsAnimationGemSlot = new bool[14];
            }
        }

        override public string ToString()
        {
            string result = "finishCount / bestScore: ";
            for (int i = 0; i < 10; i++)
            {
                result += i + ": " + finishCount[i] + "/" + bestScoreOnLevel[i] + " ";
            }

            result += "\ngold: " + gold;
            return result;
        }

        public void Save(bool toCloud = true)
        {
            PPSerialization.Save<GameProgress>(EPrefsKeys.Progress, this, toCloud);
        }

        public static void Validate()
        {
            EnsureGameProgressLoaded();
        }

        public void SetString(string name, string value)
        {
            if (name == "info_btns")
            {
                List<string> l = LitJson.JsonMapper.ToObject<List<string>>(infoBtns);
                if (!l.Contains(value))
                    l.Add(value);
                infoBtns = LitJson.JsonMapper.ToJson(l);
            }
            if (name == "words_promo")
            {
                List<string> l = LitJson.JsonMapper.ToObject<List<string>>(words_code);
                if (!l.Contains(value))
                    l.Add(value);
                words_code = LitJson.JsonMapper.ToJson(l);
            }
        }

        public string GetStringValue(string name, string value)
        {
            if (name == "info_btns")
            {
                List<string> l = LitJson.JsonMapper.ToObject<List<string>>(infoBtns);
                foreach (var o in l)
                {
                    if (o == value)
                        return value;
                }
                return "none";
            }
            if (name == "words_promo")
            {
                List<string> l = LitJson.JsonMapper.ToObject<List<string>>(infoBtns);
                foreach (var o in l)
                {
                    if (o == value)
                        return value;
                }
                return "none";
            }
            return "";
        }

        public List<string> GetStringList(string name)
        {
            if (name == "info_btns")
                return LitJson.JsonMapper.ToObject<List<string>>(infoBtns);
            if (name == "words_promo")
                return LitJson.JsonMapper.ToObject<List<string>>(words_code);

            return new List<string>();
        }
    }
}
