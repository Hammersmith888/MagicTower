using UnityEngine;

[System.Serializable]
public class BaseUpgradableShopItem
{
    private const byte  DefaultMaxUpgradeLevelIndex = 7;

    public bool                 unlock;//Actually is 'unlocked can't rename because of serialization
    public bool effectUnlock;
    [System.NonSerialized]
    public ObfuscatedInt        unlockCoins;

    public byte                 upgradeLevel;

    [System.NonSerialized]
    public ObfuscatedInt[]      upgradeCoins;
    public ObfuscatedFloat[]      values;

    virtual public byte GetMaxUpgradeLevelIndex
    {
        get { return DefaultMaxUpgradeLevelIndex; }
    }

    public BaseUpgradableShopItem()
    {
        upgradeCoins = new ObfuscatedInt[GetMaxUpgradeLevelIndex + 1];
        values = new ObfuscatedFloat[GetMaxUpgradeLevelIndex + 1];
        ValidateUpgradeLevelsArraySize();
    }

    public void ValidateUpgradeLevelsArraySize()
    {
        if (upgradeCoins.IsNullOrEmpty())
        {
            upgradeCoins = new ObfuscatedInt[GetMaxUpgradeLevelIndex + 1];
            values = new ObfuscatedFloat[GetMaxUpgradeLevelIndex + 1];
        }
        else if (upgradeCoins.Length != GetMaxUpgradeLevelIndex)
        {
            //Debug.LogFormat("<b>{0}</b> Upgrade levels number is not valid. Old size: {1} New size: {2}", this.GetType().Name, upgradeCoins.Length, GetMaxUpgradeLevelIndex);
            var newArray = new ObfuscatedInt[GetMaxUpgradeLevelIndex + 1];
            for (int i = 0; i < newArray.Length; i++)
            {
                if (i < upgradeCoins.Length && upgradeCoins[i] != null)
                {
                    newArray[i] = upgradeCoins[i];
                }
                else
                {
                    newArray[i] = 0;
                }
            }
            upgradeCoins = newArray;

            var newArray2 = new ObfuscatedFloat[GetMaxUpgradeLevelIndex + 1];
            for (int i = 0; i < newArray2.Length; i++)
            {
                if (i < values.Length && values[i] != null)
                {
                    newArray2[i] = values[i];
                }
                else
                {
                    newArray2[i] = 0;
                }
            }
            values = newArray2;
        }
    }
}
