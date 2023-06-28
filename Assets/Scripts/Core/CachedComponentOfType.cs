using UnityEngine;

//namespace Core
//{
	public class CacheComponentOfType<T> : MonoBehaviour where T : Component
	{
		public T cachedComponent;

		virtual public void Init( )
		{
			if( cachedComponent == null )
			{
				cachedComponent = GetComponent<T>();
			}
		}
	}
//}
