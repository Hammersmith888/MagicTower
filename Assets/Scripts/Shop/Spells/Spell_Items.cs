using UnityEngine;

// Item для заклинаний в магазине
[System.Serializable]
public class SpellItem : BaseUpgradableShopItem
{
    public const byte SpellsNumber = 12;
    public const byte MaxUpgradeLevelIndex = 7;

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
public class Spell_Items : UpgradableItemsArrayInClassWrapper<SpellItem>
{
    protected override int ValidArraySize
    {
        get
        {
            return SpellItem.SpellsNumber;
        }
    }

    public Spell_Items() : base(SpellItem.SpellsNumber) { }

    public Spell_Items(int capacity) : base(capacity)
    {
    }
}
