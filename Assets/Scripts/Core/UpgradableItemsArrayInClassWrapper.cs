
[System.Serializable]
public abstract class UpgradableItemsArrayInClassWrapper<T> : ArrayInClassWrapper<T> where T : BaseUpgradableShopItem, new()
{
    public UpgradableItemsArrayInClassWrapper() : base()
    {
    }

    public UpgradableItemsArrayInClassWrapper(int capacity) : base(capacity)
    {
    }

    override public void ValidateInnerArraySize()
    {
        base.ValidateInnerArraySize();
        ValidateUpgrades();
    }

    private void ValidateUpgrades()
    {
        for (int i = 0; i < innerArray.Length; i++)
        {
            innerArray[i].ValidateUpgradeLevelsArraySize();
        }
    }
}

