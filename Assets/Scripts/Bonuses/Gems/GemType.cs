public enum GemType
{
	Red,
	Blue,
	White,
	Yellow,
	None
}

[System.Serializable]
public class GemItem : BaseConsumableShopItem
{
	public Gem gem = new Gem();
}

[System.Serializable]
public class Gem_Items : ArrayInClassWrapper<GemItem>
{
	public Gem_Items(int capacity) : base( capacity )
	{}
}
