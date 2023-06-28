using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Buff{
	public BuffType buffType;
	public float buffValue;
}

[CreateAssetMenu(fileName = "BuffsLoaderConfig", menuName = "Custom/BuffsLoaderConfig")]
public class BuffsLoaderConfig : ScriptableObject {
	[System.Serializable]
	public class BuffValue{
		public Gem usedGem = new Gem();
		public WearType usedWear;
		public Buff buff = new Buff();
	}

	[SerializeField]
	private Buff defaultBuff;
	[SerializeField]
	public BuffValue[] capeBuffs, staffBuffs;

	public Buff GetGemBuffInWear(Gem usedGem, WearType usedWear)
	{
		Buff to_return = new Buff(){buffType = BuffType.none};
		if (usedWear == WearType.cape) {
			foreach (BuffValue tempBuff in capeBuffs) {
				//Debug.Log($"tempBuff.usedGem.gemLevel: {tempBuff.usedGem.gemLevel}, usedGem.gemLevel: {usedGem.gemLevel}");
				//Debug.Log($"tempBuff.usedGem.type: {tempBuff.usedGem.type},  usedGem.type: { usedGem.type}");
				if (tempBuff.usedGem.gemLevel == usedGem.gemLevel && tempBuff.usedGem.type == usedGem.type) {
					to_return = tempBuff.buff;
					break;
				}
			}
		} else if (usedWear == WearType.staff){
			foreach (BuffValue tempBuff in staffBuffs) {
				if (tempBuff.usedGem.gemLevel == usedGem.gemLevel && tempBuff.usedGem.type == usedGem.type) {
					to_return = tempBuff.buff;
					break;
				}
			}
		}
		return to_return;
	}
}
