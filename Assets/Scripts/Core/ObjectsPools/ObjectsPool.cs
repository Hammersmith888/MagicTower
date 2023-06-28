using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectsPool<T> where T : IPoolObject
{
    public List<T> objectsList { get; protected set; }

    private System.Func<T> createInstanceMethod;
    private int i;
    private int count;

    public ObjectsPool(int startNumber, System.Func<T> createInstanceMethodRef )
    {
        createInstanceMethod = createInstanceMethodRef;
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
        for(  i = 0; i < count; i++ )
        {
            if( objectsList[ i ].canBeUsed )
            {
                return objectsList[ i ];
            }
        }
        return CreateNewObject();
    }

    private T CreateNewObject( )
    {
        count++;
        T poolObj = createInstanceMethod();
        poolObj.Init();
        objectsList.Add( poolObj );
        return poolObj;
    }


    public void ExecuteOnAll( System.Action<T> function )
    {
        for( i = 0; i < count; i++ )
        {
            function( objectsList[ i ] );
        }
    }
}
