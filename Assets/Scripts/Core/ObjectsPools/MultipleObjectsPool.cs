using System.Collections.Generic;
using UnityEngine;

public class MultipleObjectsPool<T, M> where T : IPoolObjectData where M : IPoolObject
{
	private Dictionary<string, ObjectsPoolMono<M>> objectsPoolsMap;

	public MultipleObjectsPool(IPoolObjectData[ ] _poolObjectsData, Transform parent)
	{
		objectsPoolsMap = new Dictionary<string, ObjectsPoolMono<M>>();

		foreach( IPoolObjectData objData in _poolObjectsData )
		{
			objectsPoolsMap.Add( objData.getPrefab.name, new ObjectsPoolMono<M>( objData.getPrefab, parent, objData.getStartCount ) );
		}
	}

	public M GetObjectFromPoolByName(string name)
	{
		if( objectsPoolsMap.ContainsKey( name ) )
		{
			return objectsPoolsMap[name].GetObjectFromPool();
		}
		return default( M );
	}

	public List<M> GetAllObjectsInPool( )
	{
		List<M> result = new List<M>();
		foreach( ObjectsPoolMono<M> objPool in objectsPoolsMap.Values )
		{
			result.AddRange( objPool.objectsList );
		}
		return result;
	}

	public void ExecuteOnAll(System.Action<M> action)
	{
		foreach( ObjectsPoolMono<M> objPool in objectsPoolsMap.Values )
		{
			objPool.ExecuteOnAll( action );
		}
	}
}

