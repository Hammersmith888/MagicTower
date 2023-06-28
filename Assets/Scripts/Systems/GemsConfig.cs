using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsConfig : MonoBehaviour
{
	[System.Serializable]
	public struct Parameters
	{
		public int n { get; set; }
		public string name { get; set; }
		public int level { get; set; }
		public int typeGem { get; set; }
		public int usedWear { get; set; }
		public int buffType { get; set; }
		public float buffValue { get; set; }
		public int cost_sell { get; set; }
	}

	[System.Serializable]
	public class GemsParameters : ArrayInClassWrapper<Parameters>
	{
		public GemsParameters()
		{
		}

		public GemsParameters(int capacity) : base(capacity)
		{
		}
	}

	public static void SetParams(List<GemsConfig.Parameters> gemsParams)
	{
		var capeBuffs = new BuffsLoaderConfig.BuffValue[40];
		var staffBuffs = new BuffsLoaderConfig.BuffValue[40];
		int iC = 0;
		int iS = 0;
		GemSellCostParameters[] costGems = new GemSellCostParameters[40];
		foreach (var o in gemsParams)
		{
			var obj = new BuffsLoaderConfig.BuffValue(); 
			if (o.usedWear == 0)
			{
				obj.usedGem =  new Gem { gemLevel = o.level, type = (GemType)o.typeGem };;
				obj.usedWear = WearType.cape;
				obj.buff = new Buff { buffValue = o.buffValue, buffType = (BuffType)o.buffType };
				capeBuffs[iC] = obj;

				costGems[iC] = new GemSellCostParameters { value = o.cost_sell };
				iC++;
			}
			if (o.usedWear == 1)
			{
				obj.usedGem = new Gem { gemLevel = o.level, type = (GemType)o.typeGem };
				obj.usedWear = WearType.staff;
				obj.buff = new Buff { buffValue = o.buffValue, buffType = (BuffType)o.buffType };
				staffBuffs[iS] = obj;
				iS++;
			}
		}
		BuffsLoaderConfig conf = Resources.Load("BuffsLoaderConfig") as BuffsLoaderConfig;
		conf.capeBuffs = capeBuffs;
		conf.staffBuffs = staffBuffs;
		BalanceTables.Instance.gemSellCostParams = costGems;
	}
}
