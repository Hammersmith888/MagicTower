using System.Collections.Generic;
using UnityEngine;

public interface IUpdatable
{
    bool canBeRemovedFromUpdate
    {
        get;
    }

    void UpdateObject();
}

public class UpdatableHolder : MonoBehaviour
{
    private List<IUpdatable> updatableObjects = new List<IUpdatable>();
    private int i;
#if UNITY_EDITOR
    [UnityEngine.SerializeField]
#endif
	private int cachedCount;

    private bool paused;

    private static UpdatableHolder _instance;
    public static UpdatableHolder Current
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("UpdatableHolder").AddComponent<UpdatableHolder>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance.GetInstanceID() != this.GetInstanceID())
        {
            UnityEngine.Debug.LogWarning("!!Duplicated UpdatableHolder DELETED!!");
            Destroy(gameObject);
        }
    }

    public void AddToUpdate(IUpdatable newObj)
    {
        updatableObjects.Add(newObj);
        cachedCount++;
    }

    public void RemoveFromUpdate(IUpdatable updatable)
    {
        if (updatableObjects.Contains(updatable))
        {
            updatableObjects.Remove(updatable);
            cachedCount--;
        }
    }

    public void AddToUpdate(params IUpdatable[] newObjects)
    {
        updatableObjects.AddRange(newObjects);
        cachedCount += newObjects.Length;
    }

    public void ClearUpdatableObjects()
    {
        updatableObjects.Clear();
        cachedCount = 0;
    }

    public static void TogglePauseState(bool paused)
    {
        if (_instance != null)
        {
            _instance.paused = paused;
        }
    }

    private void Update()
    {
        if (paused)
        {
            return;
        }
        for (i = 0; i < cachedCount; i++)
        {
            if (updatableObjects[i] == null || updatableObjects[i].canBeRemovedFromUpdate)
            {
                updatableObjects.RemoveAt(i);
                i--;
                cachedCount--;
            }
            else
            {
                updatableObjects[i].UpdateObject();
            }
        }
    }
}
