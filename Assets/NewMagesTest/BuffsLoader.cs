using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsLoader : MonoBehaviour {

	public static BuffsLoader Instance;

	[SerializeField]
	private BuffsLoaderConfig buffsLoaderConfig;

	[SerializeField]
	private List<Buff> buffs = new List<Buff> ();
	private int capeId = -1, staffId = -1;
	// Use this for initialization
	void Awake () {
		Instance = this;
		LoadBuffs ();
		//Debug.Log($"bufs:", gameObject);
	}

	public void LoadBuffs()
	{
		buffs.Clear();
		Wear_Items wearItems = new Wear_Items (11);
		for (int i = 0; i < wearItems.Length; i++)
			wearItems[i] = new WearItem();
		wearItems = PPSerialization.Load<Wear_Items>( "Wears" );
		int totalStaves = 0;
		Wear cape = new Wear (), staff = new Wear();

		for (int i = 0; i < wearItems.Length; i++) {
			if (wearItems [i].wearParams.wearType == WearType.staff)
				totalStaves++;
		}
		for (int i = 0; i < wearItems.Length; i++) {
			
			if (wearItems [i].active) {
				if (wearItems [i].wearParams.wearType == WearType.cape) {
					cape = wearItems [i].wearParams;
					capeId = i - totalStaves;
				}
				if (wearItems [i].wearParams.wearType == WearType.staff) {
					staff = wearItems [i].wearParams;
					staffId = i;
				}
			}
		}
		if (cape != null) {
			if (cape.buffs != null) {
				for (int i = 0; i < cape.buffs.Count; i++) {
					buffs.Add (cape.buffs [i]);
				}
			}
			if (cape.gemsInSlots != null) {
				for (int i = 0; i < cape.gemsInSlots.Length; i++) {
					if (cape.gemsInSlots [i].type != GemType.None)
						buffs.Add (buffsLoaderConfig.GetGemBuffInWear (cape.gemsInSlots [i], WearType.cape));
				}
			}
		}
		if (staff != null) {
			if (staff.buffs != null) {
				for (int i = 0; i < staff.buffs.Count; i++) {
					buffs.Add (staff.buffs [i]);
				}
			}
			if (staff.gemsInSlots != null) {
				for (int i = 0; i < staff.gemsInSlots.Length; i++) {
					if (staff.gemsInSlots [i].type != GemType.None)
						buffs.Add (buffsLoaderConfig.GetGemBuffInWear (staff.gemsInSlots [i], WearType.staff));
				}
			}
		}
	}

	public float GetBuffValue(BuffType buffType)
	{
		float to_return = 0f;
		for (int i = 0; i < buffs.Count; i++) {
			///Debug.Log($"i: {i}, buffs [i].buffType: {buffs[i].buffType}");
			if (buffs [i].buffType == buffType)
				to_return += buffs [i].buffValue;
		}
		return to_return;
	}

	public int GetActiveWearId(WearType _type)
	{
		int to_return = 0;
		if (_type == WearType.cape) {
			if (capeId != -1)
				to_return = capeId;
			else
				to_return = -1;
		}

		if (_type == WearType.staff) {
            //if (staffId != -1)
            //	to_return = staffId;
            //else
            //	to_return = 0;
            to_return = staffId;
        }

		return to_return;
	}
	
}
