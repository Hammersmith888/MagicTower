using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WearLoaderConfig", menuName = "Custom/WearLoaderConfig")]
public class WearLoaderConfig : ScriptableObject {
	[System.Serializable]
	private class WearWithName
	{
		public string name;
		public Wear wear;
	}
	[SerializeField]
	private Wear defaultWear;
	[SerializeField]
	private WearWithName[] capes, staves;

	public Wear GetWear(WearType usedWear, int id)
	{
		Wear to_return = new Wear();
		if (usedWear == WearType.cape) {
			for (int i = 0; i < capes.Length; i++) {
				if (i == id){
					to_return = capes [i].wear;
					break;
				}
			}
		} else if (usedWear == WearType.staff){
			for (int i = 0; i < staves.Length; i++) {
				if (i == id){
					to_return = staves [i].wear;
					break;
				}
			}
		}
		return to_return;
	}
}
