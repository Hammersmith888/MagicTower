
[System.Serializable]
public class UpgradeItem : BaseUpgradableShopItem
{
    public enum UpgradeType { None, Knowledge, Fortification, GuardPet, FireBarrier, GuardPetFrost };
    public const int ItemsNumber = 5;
    //TODO: Fix different behaviour or make more elegant
    public const int MaxUpgradeLevelIndex = 7;//Because of different upgrade behaviour for CharacterUpgrades :/

    public bool _active = true;

    public override byte GetMaxUpgradeLevelIndex
    {
        get
        {
            return MaxUpgradeLevelIndex;
        }
    }
}

[System.Serializable]
public class Upgrade_Items : UpgradableItemsArrayInClassWrapper<UpgradeItem>
{
    protected override int ValidArraySize
    {
        get
        {
            return UpgradeItem.ItemsNumber;
        }
    }

    public Upgrade_Items() : this(UpgradeItem.ItemsNumber) { }

    public Upgrade_Items(int capacity) : base(capacity)
    {
        ValidateInnerArraySize();
        //for (int i = 0; i < innerArray.Length; i++)
        //{
        //    innerArray[i].ValidateUpgradeLevelsArraySize();
        //}
    }
}