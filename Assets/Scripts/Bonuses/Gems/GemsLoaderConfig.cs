
using UnityEngine;

[CreateAssetMenu(fileName = "GemsLoaderConfig", menuName = "Custom/GemsLoaderConfig")]
public class GemsLoaderConfig : ScriptableObject
{
    [System.Serializable]
    private class GemTexture
    {
        [ResourceFile(resourcesFolderPath ="Gems")]
        public string textureName;
        public Gem gem;
    }
    [System.Serializable]
    private class BuffTexture
    {
        [ResourceFile(resourcesFolderPath ="Gems/Buffs")]
        public string textureName;
        public BuffType buff;
    }

    [System.Serializable]
    private class DescriptionText
    {
        public string stringId;
        public BuffType buff;
    }

    [System.Serializable]
    private class GemsByType
    {
        public GemType gemType;
        public GemTexture[] gemTextures;
    }

    [SerializeField]
    [ResourceFile(resourcesFolderPath ="Gems")]
    private string defaultGemTexture;
    [SerializeField]
    private GemsByType[] gemTextures;

    [SerializeField]
    [ResourceFile(resourcesFolderPath ="Gems/Buffs")]
    private string defaultBuffTexture;
    [SerializeField]
    private BuffTexture[] buffTextures;
    [SerializeField]
    private DescriptionText[] buffDescriptions;

    private static GemsLoaderConfig _instance;
    public static GemsLoaderConfig Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<GemsLoaderConfig>("GemsLoaderConfig");
            }
            return _instance;
        }
    }


    public string GetGem(Gem gem)
    {
        if (gemTextures.IsNullOrEmpty())
        {
            return defaultGemTexture;
        }
        for (int i = 0; i < gemTextures.Length; i++)
        {
            if (gemTextures[i].gemType == gem.type || i == gemTextures.Length - 1)
            {
                for (int j = 0; j < gemTextures[i].gemTextures.Length; j++)
                {
                    if (gemTextures[i].gemTextures[j].gem.gemLevel == gem.gemLevel || j == gemTextures[i].gemTextures.Length - 1)
                    {
                        return gemTextures[i].gemTextures[j].textureName;
                    }
                }
            }
        }
        return defaultGemTexture;
    }

    public string GetBuff(BuffType buff)
    {
        if (buffTextures.IsNullOrEmpty())
        {
            return defaultBuffTexture;
        }
        for (int i = 0; i < buffTextures.Length; i++)
        {
            if (buffTextures[i].buff == buff || i == buffTextures.Length - 1)
            {
                return buffTextures[i].textureName;
            }
        }
        return defaultBuffTexture;
    }

    public string GetStringId(BuffType buff)
    {
        string defaultID = "";
        if (buffDescriptions.IsNullOrEmpty())
        {
            return defaultID;
        }
        for (int i = 0; i < buffDescriptions.Length; i++)
        {
            if (buffDescriptions[i].buff == buff || i == buffDescriptions.Length - 1)
            {
                return buffDescriptions[i].stringId;
            }
        }
        return defaultID;
    }


}
