namespace EndlessMode
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    [CreateAssetMenu(fileName = "EndlessModeLoaderConfig", menuName = "Custom/EndlessModeLoaderConfig")]
    public class EndlessModeLoaderConfig : ScriptableObject
    {

        private static EndlessModeLoaderConfig _instance;
        public static EndlessModeLoaderConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<EndlessModeLoaderConfig>("EndlessModeLoaderConfig");
                }
                return _instance;
            }
        }

        [System.Serializable]
        public class EndlessGemDrop
        {
            public int powerToDrop;
            public List<GemDrop> gemDrops;
        }

        [System.Serializable]
        public class EndlessCasketDrop
        {
            public int powerToDrop;
            public List<CasketDrop> casketDrops;
        }

        [System.Serializable]
        public class EndlessCustomLevel
        {
            public int powerToLevelSet;
            public int levelNumber;
        }

        public List<EndlessMode.EnemyGroupClass> enemyGroupClasses = new List<EndlessMode.EnemyGroupClass>();
        [SerializeField]
        private List<EndlessGemDrop> gemDrops = new List<EndlessGemDrop>();
        [SerializeField]
        private List<EndlessCasketDrop> casketDrops = new List<EndlessCasketDrop>();
        [SerializeField]
        private List<EndlessCustomLevel> endlessCustomLevels = new List<EndlessCustomLevel>();

        public float defaultLevelViewLength = 180f;

        public EndlessMode.EnemyGroupClass GetGroupClass(EndlessMode.EnemyGroupType enemyGroupType)
        {
            for (int i = 0; i < enemyGroupClasses.Count; i++)
            {
                if (enemyGroupClasses[i].enemyGroupType == enemyGroupType)
                {
                    return enemyGroupClasses[i];
                }
            }
            return enemyGroupClasses[0];
        }

        public int GetEnemyPower(EnemyType enemyType)
        {
            int to_return = 0;

            for (int i = 0; i < enemyGroupClasses.Count; i++)
            {
                for (int j = 0; j < enemyGroupClasses[i].enemies.Count; j++)
                {
                    if (enemyGroupClasses[i].enemies[j].enemyType == enemyType)
                    {
                        to_return = enemyGroupClasses[i].enemies[j].power;
                    }
                }
            }
            return to_return;
        }

        public List<GemDrop> GetGemDrops(int currentPower)
        {
            List<GemDrop> to_return = new List<GemDrop>();

            for (int i = 0; i < gemDrops.Count; i++)
            {
                if (gemDrops[i].powerToDrop <= currentPower)
                {
                    to_return = gemDrops[i].gemDrops;
                }
            }

            return to_return;
        }

        public List<CasketDrop> GetCasketDrops(int currentPower)
        {
            List<CasketDrop> to_return = new List<CasketDrop>();

            for (int i = 0; i < casketDrops.Count; i++)
            {
                if (casketDrops[i].powerToDrop <= currentPower)
                {
                    to_return = casketDrops[i].casketDrops;
                }
            }

            return to_return;
        }

        public int GetCustomLevel(int currentPower)
        {
            int getId = currentPower % endlessCustomLevels.Count;
            return endlessCustomLevels[getId].levelNumber;
            //int to_return = 0;

            //for (int i = 0; i < endlessCustomLevels.Count; i++)
            //{
            //    if (endlessCustomLevels[i].powerToLevelSet >= currentPower)
            //    {
            //        to_return = endlessCustomLevels[i].levelNumber;
            //    }
            //}

            //return to_return;
        }
    }
}