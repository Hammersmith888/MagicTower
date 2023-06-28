using UnityEngine;

namespace UI
{
    public enum EReplicaID
    {
        None = 0,

        Level1_Boss, Level1_Mage, Level1_Completed_Enemy,

        Level2_Mage2 = 11, Level2_Enemy, Level2_Mage2_FirstCrystal1, Level2_Mage2_FirstCrystal2,

        // Level3_Complete_Enemy = 20,

        Level4_Enemy = 30, Level4_Mage1,

        Level5_Enemy = 40,
        Level5_Mage,

        Level9_Mage = 50,

        Level7_Mage = 60, Level7_Enemy,

        Level11_Boss = 70, Level11_Mage,

        Level15_Boss = 80, Level15_Mage, Level15_Win_Mage, Level15_Lose_Boss, Level15_Completed_Boss,

        Shop_Bought_Magic_Any_Level3 = 100, Shop_Bought_Robe_Any,

        Level18_Mage,
        Level20_Boss,
        Level27_Boss,
        Level27_Mage,
        Level30_Boss,
        Level30_Mage,
        Level30_Lose_Boss,
        Level33_Mage,
        Level41_Mage,
        Level45_Boss,
        Level45_Mage,
        Level51_Mage,
        Level55_Mage,
        Level61_Mage,
        Level66_Boss,
        Level70_Boss,
        Level70_Boss2,
        Level70_Mage,
        Level74_Mage,
        Level77_Boss,
        Level84_Mage,
        Level84_DemonFatty,
        Level89_DemonGrunt,
        Level95_Mage,
        Level95_Mage2,
        Level95_Boss,
        Level95_BossHp,
        Level95_Boss2,
        Shop_Meteor_Upgrade,
        Shop_Blizzard_Upgrade,
        Mage_Poution_Power_Use,
        Mage_Poution_Mana_Use,
        Mage_Meteor_Use,
        Mage_Blizzard_Use,
        Level20_Boss_Map,
        Level49_Boss_Map,

        Level_95_start_wave_1,
        Level_95_finish,
        Level_95_killBoss,
        Level_kill_boss,
        Level_kill_boss_skelet,
        Level_kill_boss_ghul,
        Level_kill_boss_demon,

        Mage_Wall_Upgrade
    }

    [System.Serializable]
    public class ReplicaData
    {
#if UNITY_EDITOR
        [SerializeField]
        //[HideInInspector]
        [PickStringValueFromOtherProperty(propertyToGetValueName = "replicaID")]
        private string description;
#endif
        public EReplicaID replicaID;
        public int level;
        public Sprite emotionImage;
        [Space(10f)]
        public string replicaTextLocalizationKey;
        [ResourceFile(resourcesFolderPath = "Sounds/Replicas")]
        public string replicaSoundFile;
        public float delayPlayReplicaSound = 1.1f;
        [Space(10f)]
        public bool pauseTimeOnReplica;
        public float showReplicaTime;
        public Vector2 replicaBubbleAnchorePos;
        [Range(0.1f, 2f)]
        public float scale = 1f;
        public bool FlipChatBubbleByX;
        public bool BlockPlayerInput;
        public bool RestartLevelMusic;
    }


    public static class ReplicaIDExtensions
    {
        public static bool WasShown(this EReplicaID replicaID)
        {
            return PlayerPrefs.GetInt(replicaID.ToString(), 0) == 1;
        }

        public static void SetAsShown(this EReplicaID replicaID)
        {
            PlayerPrefs.SetInt(replicaID.ToString(), 1);
        }

        public static void SetAsNotShown(this EReplicaID replicaID)
        {
            PlayerPrefs.SetInt(replicaID.ToString(), 0);
        }
    }
}
