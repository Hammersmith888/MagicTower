using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPoolMono<T> where T : IPoolObject
{
	public List<T> objectsList
	{
		get; protected set;
	}

	private GameObject objectPrefab;
	private Transform parentTransf;
	private int i;
	private int count;

	public ObjectsPoolMono(GameObject prefab, Transform parent, int startNumber)
	{
		objectPrefab = prefab;
		parentTransf = parent;
		Init( startNumber );
	}

	public void Init(int startNumber)
	{
		objectsList = new List<T>( startNumber );
		for( i = 0; i < startNumber; i++ )
		{
			CreateNewObject();
		}
	}

	public T GetObjectFromPool( )
	{
		for( i = 0; i < count; i++ )
		{
			if( objectsList[i].canBeUsed )
			{
				return objectsList[i];
			}
		}
		return CreateNewObject();
	}

	private T CreateNewObject( )
	{
		GameObject obj = GameObject.Instantiate( objectPrefab, parentTransf, false ) as GameObject;
		T poolObj = obj.GetComponentInChildren<T>();
		poolObj.Init();
		objectsList.Add( poolObj );
		count++;
		return poolObj;
	}

	public void ExecuteOnAll(System.Action<T> function)
	{
		for( i = 0; i < count; i++ )
		{
			function( objectsList[i] );
		}
	}
}
