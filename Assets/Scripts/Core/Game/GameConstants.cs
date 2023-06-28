using UnityEngine;
using System.IO;
public static class GameConstants
{
    public const string ENEMY_TAG = "Enemy";
    public const string FRIENDLY_ENEMY_TAG = "FriendlyEnemy";
    public const string COIN_TAG = "Coin";
    public const string CASKET_TAG = "Casket";
    public const string PLAYER_TAG = "Player";
    public const string BARRIER_TAG = "Barrier";
    public const string WALL_TAG ="Wall";

    public const float  MAX_SHOT_FLY_DISTANCE = 13.5f;
    public const float MaxTopBorder = 2.4f;
    public const float MaxBottomBorder = -2.4f;
    public const int TotalLevels = 95;

    public static float GameFieldYCenter
    {
        get
        {
            return MaxBottomBorder + (MaxTopBorder - MaxBottomBorder) / 2f;
        }
    }

    public static float GameFieldYSize
    {
        get
        {
            return MaxTopBorder - MaxBottomBorder;
        }
    }

    public static string BalanceJsonPath
    {
        get
        {
            return Path.Combine(Application.persistentDataPath, "Balance.json");
        }
    }

    public class SaveIds
    {
        public static string LastGemTypeShownInShop = "LastGemTypeShownInShop";
        public static string ShowAdsForMana = "ShowAdsForMana";

        public static string AutoUseManaSave = "AutoUseManaSave";
        public static string AutoUseHealthSave = "AutoUseHealthSave";
        public static string AutoUsePowerSave = "AutoUsePowerSave";
        public static string AutoUseSpellSave = "AutoUseSpellSave";
        public static string UseDoubleSpeedSave = "UseDoubleSpeedSave";
        public static string AutoSpellSlotsUsing = "AutoSpellSlotsUsing";
        public static string ShowLikeButtonOnMainMenu = "ShowLikeButtonOnMainMenu";
    }

    public class LinksIds
    {
        public static string GameVisitPage = "http://magicsiege.com/blog/";
    }
}
