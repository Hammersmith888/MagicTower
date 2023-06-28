using UnityEngine;

public class BaseUpdatableObject : MonoBehaviour, IUpdatable
{
	private bool registered;
	private bool removeFromUpdate;

	virtual public bool canBeRemovedFromUpdate
	{
		get
        {
			return removeFromUpdate || this == null || gameObject == null || !gameObject.activeSelf;
		}
	}

	virtual public void UpdateObject( )
	{
	}

	public void RegisterForUpdate( )
	{
		if( !registered )
		{
			registered = true;
			removeFromUpdate = false;
			//Debug.Log( "RegisterForUpdate "+gameObject.name+" "+GetType() );
			UpdatableHolder.Current.AddToUpdate( this );
		}
	}

	public void UnregisterFromUpdate( bool removeInstantly = false )
	{
		if( registered )
		{
			registered = false;
			removeFromUpdate = true;
			//Debug.Log( "UnregisterFromUpdate " + gameObject.name + " " + GetType() );
			if( removeInstantly )
			{
				UpdatableHolder.Current.RemoveFromUpdate( this );
			}
		}
	}

}
