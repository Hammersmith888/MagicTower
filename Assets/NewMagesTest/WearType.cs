using System.Collections.Generic;
public enum WearType
{
	cape, staff, none
}

public enum CapeType{
	
}

[System.Serializable]
public class Wear{
	public WearType wearType;
	public List<Buff> buffs = new List<Buff> ();

	public Gem[] gemsInSlots;
}
