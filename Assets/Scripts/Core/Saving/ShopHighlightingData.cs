
// Какие элементы уже были подсвечены в магазине, после открытия 
[System.Serializable]
public class ShopHighlightingData : IValidatable
{
    public bool[] spell;
    public bool[] scroll;
    public bool[] castle;

    public ShopHighlightingData()
    {
        spell = new bool[20];
        scroll = new bool[20];
        castle = new bool[20];
    }

    public void Validate()
    {
        if (spell.IsNullOrEmpty())
        {
            spell = new bool[20];
        }
        if (scroll.IsNullOrEmpty())
        {
            scroll = new bool[20];
        }
        if (castle.IsNullOrEmpty())
        {
            castle = new bool[20];
        }
    }

    public static ShopHighlightingData Load()
    {
        return ELocalPrefsKey.ShopHighlightingData.Load<ShopHighlightingData>();
    }
}

public static class ShopHighlightingDataExtension
{
    public static void Save(this ShopHighlightingData data)
    {
        ELocalPrefsKey.ShopHighlightingData.Save(data);
    }
}
