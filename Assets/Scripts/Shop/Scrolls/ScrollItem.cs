using UnityEngine;

// Item для свитков в магазине
[System.Serializable]
public class ScrollItem : BaseConsumableShopItem
{
    public const int ItemsNumber = 6;
    public const byte MaxUpgradeLevelIndex = 7;

    [SerializeField]
    public byte order;// Порядок (номер) каким был этот свиток открыт, необходимо чтобы затем расположить на игровой сцене в таком же порядке
    [SerializeField]
    public bool active;
    [SerializeField]
    public byte slot;

    public override byte GetMaxUpgradeLevelIndex
    {
        get
        {
            return MaxUpgradeLevelIndex;
        }
    }
}

[System.Serializable]
public class Scroll_Items : UpgradableItemsArrayInClassWrapper<ScrollItem>
{
    protected override int ValidArraySize
    {
        get
        {
            return ScrollItem.ItemsNumber;
        }
    }

    public Scroll_Items() : base(ScrollItem.ItemsNumber)
    {
    }

    public Scroll_Items(int capacity) : base(capacity)
    {
    }
}
