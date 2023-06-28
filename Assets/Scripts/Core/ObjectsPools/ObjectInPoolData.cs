using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInPoolData : IPoolObjectData
{
#if UNITY_EDITOR
	[HideInInspector]
	public string nameEDITOR;
#endif
	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private int startCount;

	public GameObject getPrefab
	{
		get
		{
			return prefab;
		}
	}

	public int getStartCount
	{
		get
		{
			return startCount;
		}
	}
}
