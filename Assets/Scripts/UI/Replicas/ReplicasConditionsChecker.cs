
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System;
using Tutorials;

namespace UI
{
    //TODO: Очень много хардкода и компромисных решений для скорости,
    //веротянее всего можно вынести дополнительные параметры в конфиг (уровень для показа, тип реплики, id реплики для ответа и т.п.) и реализовать здесь только их обработку 
    public class ReplicasConditionsChecker : MonoBehaviour
    {
        private static ReplicasConditionsChecker _current;
        public static ReplicasConditionsChecker Current
        {
            get
            {
                if (_current == null)
                {
                    _current = FindObjectOfType<ReplicasConditionsChecker>();
                }
                return _current;
            }
        }

        private int enemyCharacterReplicaOnLevelCounter;//temp
        private int currentLevelMageReplicasCounter;
        private Transform CurrentEnemyForReplicaAnchor;
        private GameObject[] CurrentEnemyForReplicaRendererObjects;

        private bool levelWasWon;
        private bool bossIsDead = false;
        private int manaCounter = 0;
        private Transform demonBossReplicaAnchor;
        private GameObject[] demonBossRendererObjects;

        private void Awake()
        {
            _current = this;
            ReplicaUI.ResetStaticCounters();
            ReplicaUI.OnReplicaComplete += OnReplicaCompleted;
            BattleEventsMono.BattleEvents.AddListenerToEvent(EBattleEvent.LEVEL_COMPLETED, CheckReplicasOnLevelCompleted);
            BattleEventsMono.BattleEvents.AddListenerToEvent(EBattleEvent.ENEMY_WAVE_SPAWNED, CheckReplicaOnEnemyWaveSpawned);
            BattleEventsMono.BattleEvents.AddListenerToEvent(EBattleEvent.ENEMY_DEAD, CheckReplicaOnEnemyDead);
            BattleEventsMono.BattleEvents.AddListenerToEvent(EBattleEvent.POTION_USE, OnPoutionUse);
            BattleEventsMono.BattleEvents.AddListenerToEvent(EBattleEvent.SPELL_USE, OSpellUse);
            ShopGameEvents.Instance.AddListenerToEvent(EShopGameEvent.BONUS_BOUGHT, OnShopBonusBought);
            ShopGameEvents.Instance.AddListenerToEvent(EShopGameEvent.SPELL_UPGRADED, OnShopSpellUpgraded);
            BattleEventsMono.BattleEvents.AddListenerToEvent(EBattleEvent.ENEMY_50_PERCENT_HEALTH, CheckReplicaOnEnemy50PercentHp);
            CasketWithNewItem.CasketCollected += CasketWithNewItemOpen;
            CheckReplicaOnLevelStart();
        }

        public void OnMapQuit()
        {
            ReplicaUI.OnReplicaComplete -= OnReplicaCompleted;
            BattleEventsMono.BattleEvents.RemoveListenerFromEvent(EBattleEvent.LEVEL_COMPLETED, CheckReplicasOnLevelCompleted);
            BattleEventsMono.BattleEvents.RemoveListenerFromEvent(EBattleEvent.ENEMY_WAVE_SPAWNED, CheckReplicaOnEnemyWaveSpawned);
            BattleEventsMono.BattleEvents.RemoveListenerFromEvent(EBattleEvent.ENEMY_DEAD, CheckReplicaOnEnemyDead);
            BattleEventsMono.BattleEvents.RemoveListenerFromEvent(EBattleEvent.POTION_USE, OnPoutionUse);
            BattleEventsMono.BattleEvents.RemoveListenerFromEvent(EBattleEvent.SPELL_USE, OSpellUse);
            ShopGameEvents.Instance.RemoveListenerFromEvent(EShopGameEvent.BONUS_BOUGHT, OnShopBonusBought);
            ShopGameEvents.Instance.RemoveListenerFromEvent(EShopGameEvent.SPELL_UPGRADED, OnShopSpellUpgraded);
            BattleEventsMono.BattleEvents.RemoveListenerFromEvent(EBattleEvent.ENEMY_50_PERCENT_HEALTH, CheckReplicaOnEnemy50PercentHp);
            CasketWithNewItem.CasketCollected -= CasketWithNewItemOpen;
            if (levelWasWon)
            {
                ReplicasData.MarkAsShownReplicasForLevel(mainscript.CurrentLvl);
            }
        }
        
        private void OnReplicaCompleted(EReplicaID replicaID)
        {
            ReplicaUIDarkBackground.CanvasEnable();
           // Debug.Log($"edpcika id: {replicaID}");
            switch (replicaID)
            {
                case EReplicaID.Level2_Mage2:
                    ReplicaUI.ShowReplicaOnCharacter(EReplicaID.Level2_Enemy, CurrentEnemyForReplicaAnchor, UIControl.Current.transform, CurrentEnemyForReplicaRendererObjects);
                    break;
                case EReplicaID.Level7_Mage:
                    ReplicaUI.ShowReplicaOnCharacter(EReplicaID.Level7_Enemy, CurrentEnemyForReplicaAnchor, UIControl.Current.transform, CurrentEnemyForReplicaRendererObjects);
                    break;
                case EReplicaID.Level11_Boss:
                    break;
                case EReplicaID.Level15_Boss:
                    break;
                case EReplicaID.Level27_Boss:
                    break;
                case EReplicaID.Level30_Boss:
                    break;
                case EReplicaID.Level45_Boss:
                    break;
                case EReplicaID.Level70_Boss2:
                    break;
                case EReplicaID.Level95_Mage:
                    UI.ReplicaUI.ShowReplica(UI.EReplicaID.Level_95_start_wave_1, UIControl.Current.transform);
                     break;
                case EReplicaID.Level95_Boss:
                    try
                    {
                        if(this)
                            this.CallActionAfterDelayWithCoroutine(1f, ShowLevelMageReplica);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e.Message);
                    }
                    break;
                case EReplicaID.Level84_Mage:
                    this.CallActionAfterDelayWithCoroutine(1f, Level84_ShowDemonFattyMessage);
                    break;
            }
           
        }

        private void Level84_ShowDemonFattyMessage()
        {
            ReplicaUI.ShowReplicaOnCharacter(EReplicaID.Level84_DemonFatty, CurrentEnemyForReplicaAnchor, UIControl.Current.transform, CurrentEnemyForReplicaRendererObjects);
        }

        public void ShowEnemyCharacterReplica(Transform enemyReplicaAnchor, EnemyType enemyType, GameObject[] characterRendererObjects = null)
        {
            switch (mainscript.CurrentLvl)
            { 
                case 1:
                    ReplicaUI.ShowReplicaOnCharacter(EReplicaID.Level1_Boss, enemyReplicaAnchor, UIControl.Current.transform, characterRendererObjects);
                    break;
                case 2:
                    CurrentEnemyForReplicaAnchor = enemyReplicaAnchor;
                    CurrentEnemyForReplicaRendererObjects = characterRendererObjects;
                    ShowLevelMageReplica();
                    break;
                case 7:
                    if (enemyCharacterReplicaOnLevelCounter <= 0)
                    {
                        CurrentEnemyForReplicaAnchor = enemyReplicaAnchor;
                        CurrentEnemyForReplicaRendererObjects = characterRendererObjects;
                        ShowLevelMageReplica();
                        enemyCharacterReplicaOnLevelCounter++;
                    }
                    break;
                case 15:
                    GameObject[] obj = new GameObject[characterRendererObjects.Length + PlayerController.Instance.m_mageRendererObjects.Length];
                    List<GameObject> objs = new List<GameObject>();
                    for (int i = 0; i < characterRendererObjects.Length; i++)
                        objs.Add(characterRendererObjects[i]);
                    for (int i = 0; i < PlayerController.Instance.m_mageRendererObjects.Length; i++)
                        objs.Add(PlayerController.Instance.m_mageRendererObjects[i]);
                    for (int i = 0; i < objs.Count; i++)
                        obj[i] = objs[i];

                    WaweEnemy(enemyReplicaAnchor, enemyType, EnemyType.zombie_boss, EReplicaID.Level15_Boss, obj);
                    break;
                case 30:
                    WaweEnemy(enemyReplicaAnchor, enemyType, EnemyType.skeleton_king, EReplicaID.Level30_Boss, characterRendererObjects);
                    break;
                case 45:
                    // WaweEnemy(enemyReplicaAnchor, enemyType, EnemyType.burned_king, EReplicaID.Level45_Boss, characterRendererObjects);
                    if(enemyType == EnemyType.burned_king)
                        ReplicaUI.ShowReplicaOnCharacter(EReplicaID.Level45_Boss, enemyReplicaAnchor, UIControl.Current.transform, characterRendererObjects);
                    break;
                case 70:
                    WaweEnemy(enemyReplicaAnchor, enemyType, EnemyType.ghoul_boss, EReplicaID.Level70_Boss2, characterRendererObjects);
                    break;
                case 84:
                    WaweEnemyMageReplica(enemyReplicaAnchor, enemyType, EnemyType.demon_fatty, characterRendererObjects);
                    break;
                case 89:
                    WaweEnemyDemonGrunt(enemyReplicaAnchor, enemyType, EnemyType.demon_grunt, EReplicaID.Level89_DemonGrunt, characterRendererObjects);
                    break;
                case 95:
                    if (WaweEnemy(enemyReplicaAnchor, enemyType, EnemyType.demon_boss, EReplicaID.Level95_Boss, characterRendererObjects))
                    {
                        demonBossReplicaAnchor = enemyReplicaAnchor;
                        demonBossRendererObjects = characterRendererObjects;
                    }
                    break;
            }
        }

        private bool WaweEnemyDemonGrunt(Transform enemyReplicaAnchor, EnemyType enemyType, EnemyType validationEnemyType, EReplicaID replica, GameObject[] characterRendererObjects)
        {
            if (enemyCharacterReplicaOnLevelCounter <= 0 && enemyType == validationEnemyType)
            {
                DemonGrunt demonGrunt = enemyReplicaAnchor.root.GetComponent<DemonGrunt>();
                System.Action replicaEnemy = () =>
                {
                    WaweEnemy(enemyReplicaAnchor, enemyType, validationEnemyType, replica, characterRendererObjects);
                };
                System.Action OnSpawn = () =>
                {
                    this.CallActionAfterDelayWithCoroutine(3f, replicaEnemy);
                };
                demonGrunt.spawnEvent += OnSpawn;
                return true;
            }
            return false;
        }

        private bool WaweEnemy(Transform enemyReplicaAnchor, EnemyType enemyType, EnemyType validationEnemyType, EReplicaID replica, GameObject[] characterRendererObjects)
        {
            if (enemyCharacterReplicaOnLevelCounter <= 0 && enemyType == validationEnemyType)
            {
                CurrentEnemyForReplicaAnchor = enemyReplicaAnchor;
                CurrentEnemyForReplicaRendererObjects = characterRendererObjects;
                Debug.Log($"WaweEnemy replica: ");
                ReplicaUI.ShowReplicaOnCharacter(replica, enemyReplicaAnchor, UIControl.Current.transform, characterRendererObjects);
                enemyCharacterReplicaOnLevelCounter++;

                return true;
            }

            return false;
        }

        private void WaweEnemyMageReplica(Transform enemyReplicaAnchor, EnemyType enemyType, EnemyType validationEnemyType, GameObject[] characterRendererObjects)
        {
            if (enemyCharacterReplicaOnLevelCounter <= 0 && enemyType == validationEnemyType)
            {
                CurrentEnemyForReplicaAnchor = enemyReplicaAnchor;
                CurrentEnemyForReplicaRendererObjects = characterRendererObjects;
                ShowLevelMageReplica();
                enemyCharacterReplicaOnLevelCounter++;
            }
        }


        public void ShowLevelMageReplica()
        {
            var selectedReplicaID = LevelToMageReplica();
            //System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
            //System.Diagnostics.StackFrame frame = stackTrace.GetFrame(1); // The caller frame
            //string methodName = frame.GetMethod().Name;    // Method name
            //string fileName = frame.GetFileName();         // File name
            //int lineNumber = frame.GetFileLineNumber(); // Line number

            //Debug.Log("StayPath: " + methodName + "()" + "\n" + fileName + ":" + lineNumber);
            //Debug.Log("ShowLevelMageReplica replica");
            ShowMageReplica(selectedReplicaID);
        }

        public void ShowMageReplica(EReplicaID replicaId)
        {
            var mageReplicaAnchor = PlayerController.MageReplicaAnchor;
            if (mageReplicaAnchor == null)
            {
                return;
            }

            if (replicaId != EReplicaID.None)
            {
                Debug.Log("ShowMageReplica replica");
                ReplicaUI.ShowReplicaOnCharacter(replicaId, mageReplicaAnchor, UIControl.Current.transform, PlayerController.MageRenderObjectsForReplica);
                currentLevelMageReplicasCounter++;
            }
        }

        private EReplicaID LevelToMageReplica()
        {
            Debug.Log("LevelToMageReplica replica: {currentLevelMageReplicasCounter}");
            var selectedReplicaID = EReplicaID.None;
            switch (mainscript.CurrentLvl)
            {
                //case 1:
                //    selectedReplicaID = EReplicaID.Mage_Poution_Mana_Use;
                //    break;
                case 2:
                    switch (currentLevelMageReplicasCounter)
                    {
                        case 0:
                            selectedReplicaID = EReplicaID.Level2_Mage2;
                            break;
                        case 1:
                            selectedReplicaID = EReplicaID.Level2_Mage2_FirstCrystal1;
                            break;
                    }
                    break;
                case 4:
                    selectedReplicaID = EReplicaID.Level4_Mage1;
                    break;
                case 5:
                    selectedReplicaID = EReplicaID.Level4_Mage1;
                    break;
                case 7:
                    selectedReplicaID = EReplicaID.Level7_Mage;
                    break;
                case 9:
                    selectedReplicaID = EReplicaID.Level9_Mage;
                    break;
                case 11:
                    selectedReplicaID = EReplicaID.Level11_Mage;
                    break;
                case 15:
                    switch (currentLevelMageReplicasCounter)
                    {
                        case 0:
                            selectedReplicaID = EReplicaID.Level15_Mage;
                            break;
                        case 1:
                            selectedReplicaID = EReplicaID.Level15_Win_Mage;
                            break;
                    }
                    selectedReplicaID = EReplicaID.Level15_Mage;
                    break;
                case 18:
                    selectedReplicaID = EReplicaID.Level18_Mage;
                    break;
                //case 27:
                //    //selectedReplicaID = EReplicaID.Level27_Mage;
                //    break;
                case 30:
                        selectedReplicaID = EReplicaID.Level30_Mage;
                    break;
                //case 33:
                //   // selectedReplicaID = EReplicaID.Level33_Mage;
                //    break;
                //case 41:
                //    selectedReplicaID = EReplicaID.Level41_Mage;
                //    break;
                case 45:
                    // selectedReplicaID = EReplicaID.Level45_Mage;
                    if (currentLevelMageReplicasCounter == 0)
                        selectedReplicaID = EReplicaID.Level15_Win_Mage;
                    //else
                    //    selectedReplicaID = EReplicaID.Level2_Mage2_FirstCrystal2;
                    break;
                case 51:
                    selectedReplicaID = EReplicaID.Level51_Mage;
                    break;
                case 55:
                    selectedReplicaID = EReplicaID.Level55_Mage;
                    break;
                case 61:
                    selectedReplicaID = EReplicaID.Level61_Mage;
                    break;
                case 70:
                    if (currentLevelMageReplicasCounter == 0)
                        selectedReplicaID = EReplicaID.Level70_Mage;
                    break;
                case 74:
                    selectedReplicaID = EReplicaID.Level74_Mage;
                    break;
                case 84:
                    selectedReplicaID = EReplicaID.Level84_Mage;
                    break;
                case 95:
                    if (currentLevelMageReplicasCounter == 0)
                        selectedReplicaID = EReplicaID.Level95_Mage;
                    if (currentLevelMageReplicasCounter == 1)
                        selectedReplicaID = EReplicaID.Level95_Mage2;
                    break;
            }

            return selectedReplicaID;
        }

        public void CheckReplicaOnLevelStart()
        {
            if (mainscript.CurrentLvl == 2)
            {
                this.CallActionAfterDelayWithCoroutine(12f, ShowLevelMageReplica);
            }
        }

        private void CheckReplicaOnEnemyWaveSpawned(BaseEventParams eventParams)
        {
            int waveIndex = (eventParams as Core.EventParameterWithSingleValue<int>).eventParameter;
            switch (mainscript.CurrentLvl)
            {
                case 1:
                    if (waveIndex == 1)
                        this.CallActionAfterDelayWithCoroutine(3.0f, ShowLevelMageReplica);
                    break;
                case 4:
                    if(waveIndex == 0)
                        this.CallActionAfterDelayWithCoroutine(3f, ShowLevelMageReplica);
                    if(waveIndex == 2)
                        ReplicaUI.ShowReplica(EReplicaID.Level4_Enemy, UIControl.Current.transform);
                    break;
                case 5:
                    if (waveIndex == 3)
                    {
                        ReplicaUI.ShowReplica(EReplicaID.Level5_Enemy, UIControl.Current.transform);
                    }
                    break;
                case 9:
                    if (waveIndex == 1)
                    {
                        this.CallActionAfterDelayWithCoroutine(3f, ShowLevelMageReplica);
                    }
                    break;
                case 11:
                    if (waveIndex == 1)
                    {
                        ReplicaUI.ShowReplica(EReplicaID.Level11_Boss, UIControl.Current.transform);
                    }
                    break;
                case 18:
                    if (waveIndex == 0)
                    {
                        this.CallActionAfterDelayWithCoroutine(4f, ShowLevelMageReplica);
                    }
                    break;
                case 20:
                    if (waveIndex == 0)
                    {
                        this.CallActionAfterDelayWithCoroutine(3f, Level20_ShowBossReplica);
                    }
                    break;
                case 27:
                    if (waveIndex == 1)
                    {
                        this.CallActionAfterDelayWithCoroutine(3f, Level27_ShowBossReplica);
                    }
                    break;
                case 33:
                    if (waveIndex == 1)
                    {
                        this.CallActionAfterDelayWithCoroutine(2f, ShowLevelMageReplica);
                    }
                    break;
                //case 41:
                //    if (waveIndex == 0)
                //    {
                //        this.CallActionAfterDelayWithCoroutine(3f, ShowLevelMageReplica);
                //    }
                    //break;
                case 45:
                    if (waveIndex == 0)
                    {
                        //this.CallActionAfterDelayWithCoroutine(3f, Level45_ShowBossReplica);
                    }
                    break;
                case 51:
                    if (waveIndex == 0)
                    {
                        this.CallActionAfterDelayWithCoroutine(3f, ShowLevelMageReplica);
                    }
                    break;
                case 61:
                    if (waveIndex == 2)
                    {
                        this.CallActionAfterDelayWithCoroutine(3f, ShowLevelMageReplica);
                    }
                    break;
                case 66:
                    if (waveIndex == 0)
                    {
                        this.CallActionAfterDelayWithCoroutine(3f, Level66_ShowBossReplica);
                    }
                    break;
                case 70:
                    if (waveIndex == 0)
                    {
                        this.CallActionAfterDelayWithCoroutine(2f, Level70_ShowBossReplica);
                    }
                    break;
                case 74:
                    if (waveIndex == 0)
                    {
                        this.CallActionAfterDelayWithCoroutine(3f, ShowLevelMageReplica);
                    }
                    break;
                case 77:
                    if (waveIndex == 2)
                    {
                        this.CallActionAfterDelayWithCoroutine(3f, Level77_ShowBossReplica);
                    }
                    break;
                case 95:
                    if (waveIndex == 0)
                    {
                        this.CallActionAfterDelayWithCoroutine(2f, ShowLevelMageReplica);
                    }
                    break;
            }
        }

        private void Level77_ShowBossReplica()
        {
            ReplicaUI.ShowReplica(EReplicaID.Level77_Boss, UIControl.Current.transform);
        }

        private void Level66_ShowBossReplica()
        {
            ReplicaUI.ShowReplica(EReplicaID.Level66_Boss, UIControl.Current.transform);
        }

        private void Level27_ShowBossReplica()
        {
            ReplicaUI.ShowReplica(EReplicaID.Level27_Boss, UIControl.Current.transform);
        }

        private void Level20_ShowBossReplica()
        {
            ReplicaUI.ShowReplica(EReplicaID.Level20_Boss, UIControl.Current.transform);
        }

        private void Level45_ShowBossReplica()
        {
           // ReplicaUI.ShowReplica(EReplicaID.Level45_Boss, UIControl.Current.transform);
        }
        private void Level70_ShowBossReplica()
        {
            ReplicaUI.ShowReplica(EReplicaID.Level70_Boss, UIControl.Current.transform);
        }

        private void CheckReplicaOnEnemyDead(BaseEventParams eventParams)
        {
            switch (mainscript.CurrentLvl)
            {
                case 30:
                    if (eventParams.GetParameterSafe<EnemyType>() == EnemyType.skeleton_king)
                    {
                        bossIsDead = true;
                    }
                    break;
            }
        }

        private void CheckReplicasOnLevelCompleted(BaseEventParams eventParams)
        {
            levelWasWon = (eventParams as EventParameterWithSingleValue<bool>).eventParameter;
            switch (mainscript.CurrentLvl)
            {
                case 30:
                    if (bossIsDead)
                    {
                        bossIsDead = false;
                        ReplicaUI.ShowReplica(EReplicaID.Level30_Lose_Boss, UIControl.Current.transform);
                    }
                    break;
                case 55:
                    if (levelWasWon)
                    {
                        ShowLevelMageReplica();
                    }
                    break;
                case 95:
                    if (levelWasWon)
                    {
                        ReplicaUI.ShowReplica(EReplicaID.Level95_Boss2, UIControl.Current.transform);
                    }
                    break;
            }
        }

        private void ShowReplicaAfterFirstLevelWin()
        {
            ReplicaUI.ShowReplica(EReplicaID.Level1_Completed_Enemy, UIControl.Current.transform);
        }

        private void ShowReplicaAfter15LevelWin()
        {
            ReplicaUI.ShowReplica(EReplicaID.Level15_Completed_Boss, UIControl.Current.transform);
        }

        #region SHOP
        private void OnShopBonusBought(BaseEventParams eventParams)
        {
            var bonusNumber = (eventParams as EventParameterWithSingleValue<int>).eventParameter;
            if (bonusNumber == 0 || bonusNumber == 1)
            {
                if (!EReplicaID.Shop_Bought_Robe_Any.WasShown())
                {
                    EReplicaID.Shop_Bought_Robe_Any.SetAsShown();
                    ReplicaUI.ShowReplicaInShop(EReplicaID.Shop_Bought_Robe_Any, ReplicaUICanvas.CanvasTransform);
                }
            }
        }

        private void OnShopSpellUpgraded(BaseEventParams eventParams)
        {
            var eventParameter = (eventParams as EventParameterWithTwoValues<int, int>);

            switch (eventParameter.value1)
            {
                case 8: //Meteor
                    if (eventParameter.value2 >= 0 && !EReplicaID.Shop_Meteor_Upgrade.WasShown())
                    {
                        EReplicaID.Shop_Meteor_Upgrade.SetAsShown();
                        ReplicaUI.ShowReplicaInShop(EReplicaID.Shop_Meteor_Upgrade, ReplicaUICanvas.CanvasTransform);
                    }
                    return;
                case 10: //Blizzard
                    if (eventParameter.value2 >= 0 && !EReplicaID.Shop_Blizzard_Upgrade.WasShown())
                    {
                        EReplicaID.Shop_Blizzard_Upgrade.SetAsShown();
                        ReplicaUI.ShowReplicaInShop(EReplicaID.Shop_Blizzard_Upgrade, ReplicaUICanvas.CanvasTransform);
                    }
                    return;
            }
            if (eventParameter.value2 >= 2 && !EReplicaID.Shop_Bought_Magic_Any_Level3.WasShown())
            {
               
                if (mainscript.CurrentLvl <= 15)
                {
                    EReplicaID.Shop_Bought_Magic_Any_Level3.SetAsShown();
                    ReplicaUI.ShowReplicaInShop(EReplicaID.Shop_Bought_Magic_Any_Level3, ReplicaUICanvas.CanvasTransform);
                }
            }
        }
        #endregion

        private void CasketWithNewItemOpen()
        {
            //switch (mainscript.CurrentLvl)
            //{
            //    case 55:
            //        this.CallActionAfterDelayWithCoroutine(4f, ShowLevelMageReplica);
            //        break;
            //}
        }

        private void OnPoutionUse(BaseEventParams eventParams)
        {
            var eventData = eventParams.GetParameterSafe<PotionUseParameters>();
            switch (eventData.potionType)
            {
                case PotionManager.EPotionType.Power:
                    if (!EReplicaID.Mage_Poution_Power_Use.WasShown())
                    {
                        UsePowerPotion.Current.SpawnPotionEffect();
                        EReplicaID.Mage_Poution_Power_Use.SetAsShown();
                    }
                    break;
                case PotionManager.EPotionType.Mana:
                    manaCounter++;
                    if (manaCounter >= 30 && !EReplicaID.Mage_Poution_Mana_Use.WasShown())
                    {
                        EReplicaID.Mage_Poution_Mana_Use.SetAsShown();
                        ShowMageReplica(EReplicaID.Mage_Poution_Mana_Use);
                    }
                    break;
            }
        }

        private void OSpellUse(BaseEventParams eventParams)
        {
            Spell.SpellType spell = eventParams.GetParameterSafe<Spell.SpellType>();
            switch (spell)
            {
                case Spell.SpellType.Meteor:
                    if (!EReplicaID.Mage_Meteor_Use.WasShown())
                    {
                        EReplicaID.Mage_Meteor_Use.SetAsShown();
                        ShowMageReplica(EReplicaID.Mage_Meteor_Use);
                    }
                    break;
                case Spell.SpellType.Blizzard:
                    if (!EReplicaID.Mage_Blizzard_Use.WasShown())
                    {
                        EReplicaID.Mage_Blizzard_Use.SetAsShown();
                        ShowMageReplica(EReplicaID.Mage_Blizzard_Use);
                    }
                    break;
            }
        }

        private void CheckReplicaOnEnemy50PercentHp(BaseEventParams eventParams)
        {
            if (eventParams.GetParameterSafe<EnemyType>() == EnemyType.demon_boss)
            {
                WaweEnemy(demonBossReplicaAnchor,
                          EnemyType.demon_boss,
                          EnemyType.demon_boss,
                          EReplicaID.Level95_BossHp,
                          demonBossRendererObjects);
            }
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                var enumValues = System.Enum.GetValues(typeof(EReplicaID));
                foreach (EReplicaID enumValue in enumValues)
                {
                    enumValue.SetAsNotShown();
                }
                Debug.Log("Replicas shown state reseted");
            }
        }
#endif
    }
}
