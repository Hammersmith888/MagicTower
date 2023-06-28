using UnityEngine;

public class ObjectPoolManager < T, D, I > : MonoBehaviour where T : IPoolObject where D : ObjectInPoolData where I : ObjectPoolManager< T,D,I >
{
	[SerializeField]
	protected D[ ] objectsInPoolData;

	protected static I instance;

	protected MultipleObjectsPool<D, T> objectsPool;

	virtual public void Init( )
	{
		//instance = this;
#if UNITY_EDITOR
		objectsPool = new MultipleObjectsPool<D, T>( objectsInPoolData, transform );
#else
		objectsPool = new MultipleObjectsPool<D, T>( objectsInPoolData, null );
#endif

	}

	public static T GetObjectByName( string objectName )
	{
		if( instance != null )
		{
			return instance.objectsPool.GetObjectFromPoolByName( objectName );
		}
		return default(T);
	}

#if UNITY_EDITOR
	void OnDrawGizmosSelected( )
	{
		if( objectsInPoolData != null )
		{
			for( int i = 0; i < objectsInPoolData.Length; i++ )
			{
				if( objectsInPoolData[i].getPrefab != null )
				{
					objectsInPoolData[i].nameEDITOR = objectsInPoolData[i].getPrefab.name;
				}
			}
		}
	}
#endif
}
