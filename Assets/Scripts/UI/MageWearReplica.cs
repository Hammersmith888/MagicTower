using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.UIElements;

public class MageWearReplica : MonoBehaviour
{
    public Sprite[] sprites;
	public Sprite green;
    void Start()
    {
		var id = -1;
		Wear_Items wearItems = new Wear_Items(11);
		for (int i = 0; i < wearItems.Length; i++)
			wearItems[i] = new WearItem();
		wearItems = PPSerialization.Load<Wear_Items>("Wears");
		int totalStaves = 0;
		Wear cape = new Wear(), staff = new Wear();

		for (int i = 0; i < wearItems.Length; i++)
		{
			if (wearItems[i].wearParams.wearType == WearType.staff)
				totalStaves++;
		}
		for (int i = 0; i < wearItems.Length; i++)
		{
			if (wearItems[i].active)
			{
				if (wearItems[i].wearParams.wearType == WearType.cape)
				{
					cape = wearItems[i].wearParams;
					id = i - totalStaves;
				}
			}
		}

		GetComponent<UnityEngine.UI.Image>().sprite = id >= 0 ? sprites[id] : green;

	}


}
