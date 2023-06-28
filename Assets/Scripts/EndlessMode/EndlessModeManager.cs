namespace EndlessMode
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;

    public enum EnemyGroupType { any, zombie, skeleton, ghoul, demon };

    [System.Serializable]
    public class EnemyPower
    {
        public EnemyType enemyType;
        public int power;
    }

    [System.Serializable]
    public class EnemyGroupClass
    {
        public EnemyGroupType enemyGroupType;
        public int powerToEnable, powerToDisable;
        public List<EnemyPower> enemies = new List<EnemyPower>();

    }

    public class EndlessModeManager : MonoBehaviour
    {
        public static EndlessModeManager Current;

        private List<EnemyType> enemiesVariants = new List<EnemyType>();
        private int maxPowerOnLevel, powerForNewTypesCycle = 20000;
        private float currentPowerIncFactor = 1f, powerIncSpeedPerSecond = 20, playedTime, viewPlayedTime, changeBacksTimer = 180f;
        private float lastYspawnPos;
        private float spawnDelayMin = 0.05f, spawnDelayMax = 0.5f;
        private EnemyGroupType lastUsedGroupType = EnemyGroupType.any;
        private int lastSettedLevelNumber;

        private void Awake()
        {
            Current = this;
        }

        void Start()
        {
            changeBacksTimer = EndlessModeLoaderConfig.Instance.defaultLevelViewLength;

            lastSettedLevelNumber = mainscript.CurrentLvl = EndlessModeLoaderConfig.Instance.GetCustomLevel((int)(playedTime / changeBacksTimer));
            maxPowerOnLevel = 60;
            StartCoroutine(EnemiesCheckCoroutine());
            StartCoroutine(AutoChangeBackStates());
            StartCoroutine(UpdateTimerCounter());
            EnemiesGenerator.Instance.SetEndlessValues(null, null);

            if (!PotionManager.IsAnyPotion(PotionManager.EPotionType.Health) || !PotionManager.IsAnyPotion(PotionManager.EPotionType.Mana) || !PotionManager.IsAnyPotion(PotionManager.EPotionType.Power))
            {
                GiveBonusPotions();
            }

        }


        private void SetActualVariantsList()
        {
            List<EnemyGroupClass> enemyGroupClasses = new List<EnemyGroupClass>();

            enemiesVariants.Clear();

            for (int i = 0; i < EndlessModeLoaderConfig.Instance.enemyGroupClasses.Count; i++)
            {
                if (EndlessModeLoaderConfig.Instance.enemyGroupClasses[i].powerToEnable <= maxPowerOnLevel && EndlessModeLoaderConfig.Instance.enemyGroupClasses[i].powerToDisable >= maxPowerOnLevel)
                {
                    enemyGroupClasses.Add(EndlessModeLoaderConfig.Instance.enemyGroupClasses[i]);
                }
            }
            
            for (int i = 0; i < enemyGroupClasses.Count; i++)
            {
                for (int j = 0; j < enemyGroupClasses[i].enemies.Count; j++) {
                    if (EndlessModeLoaderConfig.Instance.GetEnemyPower(enemyGroupClasses[i].enemies[j].enemyType) <= maxPowerOnLevel - CurrentPowerOnLevel)
                    {
                        enemiesVariants.Add(enemyGroupClasses[i].enemies[j].enemyType);
                    }
                }
            }
        }

        private int CurrentPowerOnLevel
        {
            get
            {
                int to_return = 0;

                List<EnemyCharacter> enemiesAlive = EnemiesGenerator.Instance.enemiesOnLevelComponents;

                for (int i = 0; i < enemiesAlive.Count; i++)
                {
                    to_return += EndlessModeLoaderConfig.Instance.GetEnemyPower(enemiesAlive[i].enemyType);
                }
                return to_return;
            }
        }

        private EnemyType GetRandomEnemy
        {
            get
            {
                int totalChances = enemiesVariants.Count;

                for (int i = 0; i < enemiesVariants.Count; i++)
                {
                    int chance = UnityEngine.Random.Range(0, totalChances);

                    if (chance <= 1)
                    {
                        return enemiesVariants[i];
                    }
                    else
                    {
                        totalChances -= 1;
                    }
                }

                if (enemiesVariants.Count > 0)
                {
                    return enemiesVariants[0];
                }
                else
                {
                    return EnemyType.zombie_walk;
                }
            }
        }
        private float enemyPowerModificator;
        private IEnumerator EnemiesCheckCoroutine()
        {
            playedTime = 0f;
            while (PlayerController.Instance.CurrentHealth > 0)
            {
                if (CurrentPowerOnLevel < maxPowerOnLevel)
                {
                    enemyPowerModificator = 1f + ((float)(CurrentPowerOnLevel / powerForNewTypesCycle)) * 2f;
                    EnemiesGenerator.Instance.CreateEnemy(GetRandomEnemy, new Vector3(12f, lastYspawnPos, 0f), false, false, enemyPowerModificator);
                }

                float timeStep = UnityEngine.Random.Range(spawnDelayMin, spawnDelayMax);
                playedTime += timeStep;
                viewPlayedTime += timeStep;
                yield return new WaitForSeconds(timeStep);

                maxPowerOnLevel += (int)(currentPowerIncFactor * powerIncSpeedPerSecond * timeStep);
                currentPowerIncFactor = 1f + (float)(maxPowerOnLevel / powerForNewTypesCycle);
                RandomizeNewYPosition();

                SetActualVariantsList();
            }

            EnemiesGenerator.Instance.OnWin();

            yield break;
        }

        private void RandomizeNewYPosition()
        {
            lastYspawnPos = lastYspawnPos < 0 ? 
                UnityEngine.Random.Range(0f, GameConstants.MaxTopBorder * 0.7f) :
                UnityEngine.Random.Range(GameConstants.MaxBottomBorder * 0.7f, 0f);
        }

        private IEnumerator AutoChangeBackStates()
        {
            while (PlayerController.Instance.CurrentHealth > 0)
            {
                if (lastSettedLevelNumber != mainscript.CurrentLvl)
                {
                    SoundController.Instanse.FadeOutCurrentMusic();
                    SoundController.Instanse.stopAmbientSFX();
                }

                yield return new WaitForSeconds(1f);

                EnemiesGenerator.Instance.SetEndlessValues(EndlessModeLoaderConfig.Instance.GetGemDrops(maxPowerOnLevel), EndlessModeLoaderConfig.Instance.GetCasketDrops(maxPowerOnLevel));
                if (lastSettedLevelNumber != mainscript.CurrentLvl)
                {
                    Time.timeScale = 0f;

                    StartCoroutine(UIBlackPatch.Current.FadeInColorAnimation(UpdateSceneAtmosphere));

                    yield return new WaitForEndOfFrame();
                }

                mainscript.CurrentLvl = Mathf.Clamp(EndlessModeLoaderConfig.Instance.GetCustomLevel((int)(playedTime/changeBacksTimer)), mainscript.CurrentLvl, int.MaxValue);
            }


            yield break;
        }

        private void UpdateSceneAtmosphere()
        {
            lastSettedLevelNumber = mainscript.CurrentLvl;
            LocationLoader.Current.SetLocationView();
            SoundController.Instanse.RestartGamePlayMusicLooping();
            SoundController.Instanse.playAmbientSFX();
            StartCoroutine(UIBlackPatch.Current.FadeOutColorAnimation(StartNewRound));
        }

        private void StartNewRound()
        {
            GiveBonusPotions(5);

            changeBacksTimer = EndlessModeLoaderConfig.Instance.defaultLevelViewLength * UnityEngine.Random.Range(1.1f, 1.3f);
            viewPlayedTime = 0;
            Time.timeScale = LevelSettings.Current.usedGameSpeed;
        }

        private IEnumerator UpdateTimerCounter()
        {
            while (PlayerController.Instance.CurrentHealth > 0)
            {
                if (LevelWaveInfoText.Current != null)
                {
                    TimeSpan left = TimeSpan.FromSeconds((int)(changeBacksTimer - viewPlayedTime));
                    int mins = left.Minutes;
                    int seconds = left.Seconds;
                    if (left >= TimeSpan.Zero)
                    {
                        LevelWaveInfoText.Current.ShowSomethingInstead("" + mins.ToString("D2") + ":" + seconds.ToString("D2"));
                    }

                }
                yield return new WaitForSeconds(0.1f);
            }

            yield break;
        }

        private void GiveBonusPotions(int giveFactor = 1)
        {
            PotionManager.AddPotion(PotionManager.EPotionType.Health, giveFactor);
            PotionManager.AddPotion(PotionManager.EPotionType.Mana, giveFactor);
            PotionManager.AddPotion(PotionManager.EPotionType.Power, giveFactor);
        }
    }
}