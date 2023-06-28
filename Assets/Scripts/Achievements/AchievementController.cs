using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using static SaveManager;

namespace Achievement
{
    public class AchievementController : MonoBehaviour
    {
        public static AchievementController instance;
        public Sprite defaultSprite;
        private void Awake()
        {
            instance = this;
        }

        [System.Serializable]
        public class Data
        {
            public Achievement achievement;
            public string keyName;
            public string keyDescription;
            public string idGPGS;
            public string idGameService;
            public int countToFinish;
            public int award;
            public DataSave save = new DataSave();

            public float midleCount { get{ return (float)save.countMade / (float)countToFinish * 100f; } }

            public bool isSuccess => save.countMade >= countToFinish;
        }

        // новая система сохранений
        [System.Serializable]
        public class DataSave
        {
            public Achievement achievement;
            public int countMade;
            public bool viewed;
            public bool took;
        }

        [System.Serializable]
        public class SaveAchievements
        {
            public List<DataSave> saves = new List<DataSave>();
        }

        #region ACHIEVEMENT NAME
        public enum Achievement
        {
            FirstWin,
            Multispell,
            Machine,
            SweetTime,
            HeroRoad,
            KillZombie,
            VictoryRoad,
            Treasurer,
            Invulnerable,
            Hero,
            GreamRiper,
            Pyromaniac,
            IronWill,
            SrongerBetter,
            UpgradeMaster,
            Timelord,
            Survivor,
            TeslaMaster,
            Boss_70,
            RollingStone,
            AuraCleaner,
            ScrollMaster,
            Healer,
            IAmPower,
            Boss_15,
            Boss_45,
            KillAllSkeletons,
            WalkingDead,
            Archmage,
            MasterOfStaves,
            Craftsman,
            PremiumMage,
            Boss_30,
            IceStrike,
            Boss_95,
            Miner
        }
        #endregion


        public List<Data> data = new List<Data>();
        [SerializeField]
        List<Sprite> sprites = new List<Sprite>(); 

        [Header("Editor")]
        public bool setEditor;
        public Achievement editorAchievement;
        public int valueEditor;

        IEnumerator Start()
        {
            Load();

            var value = PlayerPrefs.GetString("SweetTimer");
            if (string.IsNullOrEmpty(value))
            {
                PlayerPrefs.SetString("SweetTimer", DateTime.Now.ToString());
                Set(Achievement.SweetTime, 1);
                Save();
            }
            else
            {
                var str = PlayerPrefs.GetString("SweetTimer");
                if(str != "")
                {
                    DateTime dateTime = Convert.ToDateTime(str);
                    DateTime currentDate = DateTime.Now;
                    TimeSpan result = currentDate - dateTime;
                    double dayes = result.TotalDays;
                    Debug.Log($"days: {dayes}");
                    PlayerPrefs.SetString("SweetTimer", DateTime.Now.ToString());
                    if (dayes >= 1 && dayes < 2)
                    {
                        Set(Achievement.SweetTime, 1);
                        Save();
                    }
                }
                
            }

            yield return new WaitForSeconds(3);
            if(setEditor)
            {
                var d = Set(editorAchievement, valueEditor);
                Debug.Log($"value: {d.Item1}, view: {d.Item2}, took: {d.Item3}");
                Save();
            }
            
        }

        /// <summary>
        /// если выполнено значение для ачивки, возвращает <int (кол-во выполненых шагов), bool (была ли просмотрена), bool (была ли награда забрана)>
        /// если <int, bool - true (ачивка получена), bool>
        /// </summary>
        /// <returns></returns>
        public static Tuple<int,bool,bool> Set(Achievement achievement, int value)
        {
            int count = 0;
            bool view = false;
            bool take = false;
            for (int i = 0; i < instance.data.Count; i++)
            {
                if (instance.data[i].achievement == achievement)
                {
                    instance.data[i].save.countMade += value;
                    try
                    {
                        UnityEngine.Social.ReportScore(instance.data[i].save.countMade, instance.data[i].idGPGS, (bool success) =>
                        {
                            // handle success or failure
                        });
                    }
                    catch (Exception) { }

                    if (instance.data[i].save.countMade >= instance.data[i].countToFinish)
                    {
                        if(!instance.data[i].save.viewed)
                        {
                            instance.data[i].save.viewed = view = true;
                            Debug.Log($"success: {instance.data[i].achievement}");
                            AchivementUI.Open(instance.data[i]);
                        }
                        take = instance.data[i].save.took;
                    }
                }
            }
            return new Tuple<int, bool, bool>(count, view, take);
        }

        /// <summary>
        /// проверка ачивки
        /// если выполнено значение для ачивки, возвращает <int (кол-во выполненых шагов), bool (была ли просмотрена), bool (была ли награда забрана)>
        /// если <int, bool - true (ачивка получена), bool>  
        /// </summary>
        /// <param name="achievement"></param>
        /// <returns></returns>
        public static Tuple<int,bool,bool> Check(Achievement achievement)
        {
            return Set(achievement, 0);
        }
        /// <summary>
        /// устанавкливаем переменную как взяли награду
        /// </summary>
        /// <param name="achievement"></param>
        public static void SetTake(Achievement achievement)
        {
            for (int i = 0; i < instance.data.Count; i++)
            {
                if (instance.data[i].achievement == achievement)
                {
                    if (!instance.data[i].save.took)
                        instance.data[i].save.took = true;
                }
            }
        }
        /// <summary>
        /// получаем переменную о состоянии награды
        /// </summary>
        /// <param name="achievement"></param>
        /// <returns></returns>
        public static bool GetTake(Achievement achievement)
        {
            for (int i = 0; i < instance.data.Count; i++)
            {
                if (instance.data[i].achievement == achievement)
                    return instance.data[i].save.took;
            }
            return false;
        }
        /// <summary>
        /// получить кол-во у которых не получена награда
        /// </summary>
        /// <returns></returns>
        public static int GetCountNotTakeAward()
        {
            int count = 0;
            for (int i = 0; i < instance.data.Count; i++)
            {
                if (!instance.data[i].save.took && instance.data[i].save.viewed)
                {
                    Debug.Log($"opened: {instance.data[i].achievement}");
                    count++;
                }
            }
            return count;
        }

        public static Tuple<int,int> GetCountOpened()
        {
            int count = 0;
            for (int i = 0; i < instance.data.Count; i++)
            {
                if (instance.data[i].save.took)
                    count++;
            }
            return new Tuple<int, int>(count, instance.data.Count);
        }

        public static void Save(bool cloud = true)
        {
            SaveAchievements data = new SaveAchievements(); 
            for (int i = 0; i < instance.data.Count; i++)
            {
                data.saves.Add(instance.data[i].save);
            }
            PPSerialization.Save(EPrefsKeys.AchievementSave, data, cloud);
        }

        public static void Load()
        {
            SaveAchievements data = PPSerialization.Load<SaveAchievements>(EPrefsKeys.AchievementSave);
            if(data == null)
            {
                Debug.Log("Achievement save is null");
                data = new SaveAchievements();
                data.saves = new List<DataSave>();
                for (int i = 0; i < instance.data.Count; i++)
                    data.saves.Add(new DataSave { achievement = instance.data[i].achievement });

                MigrateFromOld();
            }
            for (int i = 0; i < instance.data.Count; i++)
            {
                if (instance.data[i].achievement == data.saves[i].achievement)
                    instance.data[i].save = data.saves[i];
            }
        }

        /// <summary>
        /// получить иконку ачивки по ид
        /// </summary>
        /// <returns></returns>
        public static Sprite GetSprite(Achievement achievement)
        {
            for (int i = 0; i < instance.sprites.Count; i++)
            {
                if (instance.sprites[i].name == achievement.ToString())
                    return instance.sprites[i];
            }

            //Debug.LogError($"achievemnt: {achievement} hasn`t sprite");
            return instance.defaultSprite;
        }

        private static void MigrateFromOld()
        {
            //storage[0] = heroRoad;                   //+
            //storage[1] = treasurer;                  //+
            //storage[2] = hero;                       //+
            //storage[3] = ironWill;                   //+
            //storage[4] = grimReaper;                 //+
            //storage[5] = strongerBetter;             //+
            //storage[6] = victoryRoad;                //+
            //storage[7] = craftMaste;                 //+
            //storage[8] = sweetTimes;                 //+
            //storage[9] = kingslayer;                 //+
            //storage[10] = timebreaker;               //+
            //storage[11] = impregnable;               //+
            //storage[12] = grinder;                   //+
            //storage[13] = survivor;                  //+
            //storage[14] = multispell;                //+
            //storage[15] = pyromaniac;                //+
            //storage[16] = masterTesla;               //+
            //storage[17] = santaMan;                  //+
            //storage[18] = theySeeMeRollin;           //+
            //storage[19] = auraCleaner;               //+
            //storage[20] = scrollmaster;              //+
            //storage[21] = getThoseZombies;           //+
            //storage[22] = getThoseSkeletons;         //+
            //storage[23] = miner;                     //+
            //storage[24] = premiumMage;               //+
            //storage[25] = crafter;                   //+
            //storage[26] = staffMaster;               //+
            //storage[27] = archmage;                  //+
            //storage[28] = livingDead;                //+
            //storage[29] = gotThePower;               //+
            //storage[30] = firstWint;                 //+
            //storage[31] = firstKill;                 //+
            //storage[32] = healer;                    //+
            //storage[33] = boss_15;                   //+
            //storage[34] = boss_30;                   //+
            //storage[35] = boss_45;                   //+
            //storage[36] = boss_70;                   //+
            //storage[37] = boss_95;                   //+

            //var viewed = PPSerialization.Load<AchieveViewed>(EPrefsKeys.AchieveViewed);
            //if (viewed != null)
            //{

            // значит старая версия игры
            if (SaveManager.GameProgress.Current.CompletedLevelsNumber > 3 && instance.data[GetDataForMigration(Achievement.FirstWin)].save.viewed == false)
            {
                Debug.LogWarning("Migrate achievement");

                var currentLevel = SaveManager.GameProgress.Current.CompletedLevelsNumber;

                SetAchievementDone(GetDataForMigration(Achievement.VictoryRoad), true, true);
                SetAchievementDone(GetDataForMigration(Achievement.FirstWin), true, true);

                if (currentLevel >= 7)
                {
                    SetAchievementDone(GetDataForMigration(Achievement.KillZombie));
                }
                if (currentLevel >= 15)
                {
                    SetAchievementDone(GetDataForMigration(Achievement.Boss_15));
                }
                if (currentLevel >= 20)
                {
                    SetAchievementDone(GetDataForMigration(Achievement.KillAllSkeletons));
                }
                if (currentLevel >= 30)
                {
                    SetAchievementDone(GetDataForMigration(Achievement.Boss_30));
                }

                // делаем 0 что бы бальше не было миграции
                //viewed.viewed[0] = false;
                //PPSerialization.Save(EPrefsKeys.AchieveViewed, viewed, true);

                Save();
            }

            //}
        }

        private static void SetAchievementDone(int index, bool isViewed = false, bool isTook = false)
        {
            instance.data[index].save.countMade = instance.data[index].countToFinish;
            instance.data[index].save.viewed = isViewed;
            instance.data[index].save.took = isTook;
        }

        //private void OldMigrate()
        //{
        //    var storage = PPSerialization.Load<Achievement_Items>(EPrefsKeys.AchievementItems);
        //    var conditions = PPSerialization.Load<IntArrayWrapper>(EPrefsKeys.AchievemtConditions);

        //    int x = GetDataForMigration(Achievement.HeroRoad);
        //    instance.data[x].save.countMade = conditions[0];
        //    instance.data[x].save.viewed = viewed.viewed[0];
        //    instance.data[x].save.took = storage[0].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Treasurer);
        //    instance.data[x].save.countMade = conditions[1];
        //    instance.data[x].save.viewed = viewed.viewed[1];
        //    instance.data[x].save.took = storage[1].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.IronWill);
        //    instance.data[x].save.countMade = conditions[2];
        //    instance.data[x].save.viewed = viewed.viewed[2];
        //    instance.data[x].save.took = storage[2].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Hero);
        //    instance.data[x].save.countMade = conditions[3];
        //    instance.data[x].save.viewed = viewed.viewed[3];
        //    instance.data[x].save.took = storage[3].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.GreamRiper);
        //    instance.data[x].save.countMade = conditions[4];
        //    instance.data[x].save.viewed = viewed.viewed[4];
        //    instance.data[x].save.took = storage[4].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.SrongerBetter);
        //    instance.data[x].save.countMade = conditions[5];
        //    instance.data[x].save.viewed = viewed.viewed[5];
        //    instance.data[x].save.took = storage[5].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.VictoryRoad);
        //    instance.data[x].save.countMade = conditions[6];
        //    instance.data[x].save.viewed = viewed.viewed[6];
        //    instance.data[x].save.took = storage[6].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.UpgradeMaster);
        //    instance.data[x].save.countMade = conditions[7];
        //    instance.data[x].save.viewed = viewed.viewed[7];
        //    instance.data[x].save.took = storage[7].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.SweetTime);
        //    instance.data[x].save.countMade = conditions[8];
        //    instance.data[x].save.viewed = viewed.viewed[8];
        //    instance.data[x].save.took = storage[8].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Machine);
        //    instance.data[x].save.countMade = conditions[9];
        //    instance.data[x].save.viewed = viewed.viewed[9];
        //    instance.data[x].save.took = storage[9].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Timelord);
        //    instance.data[x].save.countMade = conditions[10];
        //    instance.data[x].save.viewed = viewed.viewed[10];
        //    instance.data[x].save.took = storage[10].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Invulnerable);
        //    instance.data[x].save.countMade = conditions[11];
        //    instance.data[x].save.viewed = viewed.viewed[11];
        //    instance.data[x].save.took = storage[11].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Craftsman);
        //    instance.data[x].save.countMade = conditions[12];
        //    instance.data[x].save.viewed = viewed.viewed[12];
        //    instance.data[x].save.took = storage[12].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Survivor);
        //    instance.data[x].save.countMade = conditions[13];
        //    instance.data[x].save.viewed = viewed.viewed[13];
        //    instance.data[x].save.took = storage[13].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Multispell);
        //    instance.data[x].save.countMade = conditions[14];
        //    instance.data[x].save.viewed = viewed.viewed[14];
        //    instance.data[x].save.took = storage[14].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Pyromaniac);
        //    instance.data[x].save.countMade = conditions[15];
        //    instance.data[x].save.viewed = viewed.viewed[15];
        //    instance.data[x].save.took = storage[15].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.TeslaMaster);
        //    instance.data[x].save.countMade = conditions[16];
        //    instance.data[x].save.viewed = viewed.viewed[16];
        //    instance.data[x].save.took = storage[16].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.IceStrike);
        //    instance.data[x].save.countMade = conditions[17];
        //    instance.data[x].save.viewed = viewed.viewed[17];
        //    instance.data[x].save.took = storage[17].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.RollingStone);
        //    instance.data[x].save.countMade = conditions[18];
        //    instance.data[x].save.viewed = viewed.viewed[18];
        //    instance.data[x].save.took = storage[18].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.AuraCleaner);
        //    instance.data[x].save.countMade = conditions[19];
        //    instance.data[x].save.viewed = viewed.viewed[19];
        //    instance.data[x].save.took = storage[19].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.ScrollMaster);
        //    instance.data[x].save.countMade = conditions[20];
        //    instance.data[x].save.viewed = viewed.viewed[20];
        //    instance.data[x].save.took = storage[20].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.KillZombie);
        //    instance.data[x].save.countMade = conditions[21];
        //    instance.data[x].save.viewed = viewed.viewed[21];
        //    instance.data[x].save.took = storage[21].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.KillAllSkeletons);
        //    instance.data[x].save.countMade = conditions[22];
        //    instance.data[x].save.viewed = viewed.viewed[22];
        //    instance.data[x].save.took = storage[22].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Miner);
        //    instance.data[x].save.countMade = conditions[23];
        //    instance.data[x].save.viewed = viewed.viewed[23];
        //    instance.data[x].save.took = storage[23].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.PremiumMage);
        //    instance.data[x].save.countMade = conditions[24];
        //    instance.data[x].save.viewed = viewed.viewed[24];
        //    instance.data[x].save.took = storage[24].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.TeslaMaster);
        //    instance.data[x].save.countMade = conditions[25];
        //    instance.data[x].save.viewed = viewed.viewed[25];
        //    instance.data[x].save.took = storage[25].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.MasterOfStaves);
        //    instance.data[x].save.countMade = conditions[26];
        //    instance.data[x].save.viewed = viewed.viewed[26];
        //    instance.data[x].save.took = storage[26].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Archmage);
        //    instance.data[x].save.countMade = conditions[27];
        //    instance.data[x].save.viewed = viewed.viewed[27];
        //    instance.data[x].save.took = storage[27].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.WalkingDead);
        //    instance.data[x].save.countMade = conditions[28];
        //    instance.data[x].save.viewed = viewed.viewed[28];
        //    instance.data[x].save.took = storage[28].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.IAmPower);
        //    instance.data[x].save.countMade = conditions[29];
        //    instance.data[x].save.viewed = viewed.viewed[29];
        //    instance.data[x].save.took = storage[29].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.FirstWin);
        //    instance.data[x].save.countMade = conditions[30];
        //    instance.data[x].save.viewed = viewed.viewed[30];
        //    instance.data[x].save.took = storage[30].currentState == AchievmentState.THREE_STAR_HAVED;
        //    //storage[31] = firstKill;                 //+

        //    x = GetDataForMigration(Achievement.Healer);
        //    instance.data[x].save.countMade = conditions[32];
        //    instance.data[x].save.viewed = viewed.viewed[32];
        //    instance.data[x].save.took = storage[32].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Boss_15);
        //    instance.data[x].save.countMade = conditions[33];
        //    instance.data[x].save.viewed = viewed.viewed[33];
        //    instance.data[x].save.took = storage[33].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Boss_30);
        //    instance.data[x].save.countMade = conditions[34];
        //    instance.data[x].save.viewed = viewed.viewed[34];
        //    instance.data[x].save.took = storage[34].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Boss_45);
        //    instance.data[x].save.countMade = conditions[35];
        //    instance.data[x].save.viewed = viewed.viewed[35];
        //    instance.data[x].save.took = storage[35].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Boss_70);
        //    instance.data[x].save.countMade = conditions[36];
        //    instance.data[x].save.viewed = viewed.viewed[36];
        //    instance.data[x].save.took = storage[36].currentState == AchievmentState.THREE_STAR_HAVED;

        //    x = GetDataForMigration(Achievement.Boss_95);
        //    instance.data[x].save.countMade = conditions[37];
        //    instance.data[x].save.viewed = viewed.viewed[37];
        //    instance.data[x].save.took = storage[37].currentState == AchievmentState.THREE_STAR_HAVED;

        //}

        private static int GetDataForMigration(Achievement achievement)
        {
            for (int i = 0; i < instance.data.Count; i++)
            {
                if (instance.data[i].achievement == achievement)
                    return i;
            }
            return 0;
        }
    }
}
