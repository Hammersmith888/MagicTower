using UnityEngine;
using System.Collections;

public abstract class ArrayInClassWrapper : IEnumerable
{
    virtual protected int ValidArraySize { get { return 0; } }

    virtual public IEnumerator GetEnumerator()
    {
        return null;
    }

    abstract public void ValidateInnerArraySize();
}

[System.Serializable]
public abstract class ArrayInClassWrapper<T> : ArrayInClassWrapper where T : new()
{
    [SerializeField]
    protected T[] innerArray;

    public T[] getInnerArray
    {
        get
        {
            return innerArray;
        }
    }

    public ArrayInClassWrapper()
    {
    }

    public ArrayInClassWrapper(int capacity)
    {
        innerArray = new T[capacity];
        for (int i = 0; i < innerArray.Length; i++)
        {
            innerArray[i] = new T();
        }
    }

    override public IEnumerator GetEnumerator()
    {
        return innerArray.GetEnumerator();
    }

    public static M Create<M>(T[] source) where M : ArrayInClassWrapper<T>, new()
    {
        M result = new M();
        result.innerArray = source;
        return result;
    }

    public T this[int index]
    {
        get
        {
            return innerArray[index];
        }
        set
        {
            innerArray[index] = value;
        }
    }

    public int Length
    {
        get
        {
            return innerArray.Length;
        }
    }

    override public void ValidateInnerArraySize()
    {
        if (ValidArraySize > 0)
        {
            ValidateInnerArraySize(ValidArraySize);
        }
    }

    private void ValidateInnerArraySize(int validArraySize)
    {
        if (innerArray == null)
        {
            innerArray = new T[validArraySize];
            for (int i = 0; i < validArraySize; i++)
            {
                innerArray[i] = CreateNewElement(i);
            }
        }
        else
        {
            if (innerArray.Length != validArraySize)
            {
                Debug.LogFormat("<b>{0}</b> old data is not valid. Old size: {1} New size: {2}", typeof(T), innerArray.Length, validArraySize);
                var newArray = new T[validArraySize];
                for (int i = 0; i < newArray.Length; i++)
                {
                    if (i < innerArray.Length && innerArray[i] != null)
                    {
                        newArray[i] = innerArray[i];
                    }
                    else
                    {
                        newArray[i] = CreateNewElement(i);
                    }
                }
                innerArray = newArray;
            }
        }
    }

    virtual protected T CreateNewElement(int currentElementIndex)
    {
        return new T();
    }
}
