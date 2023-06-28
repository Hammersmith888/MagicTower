
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T s_Instance;

    public static T Instance
    {
        get
        {
            CreateInstanceIfNone();
            return s_Instance;
        }
    }

    public static T CreateInstanceIfNone()
    {
        if (s_Instance == null)
        {
            s_Instance = GameObject.FindObjectOfType(typeof(T)) as T;
            if (s_Instance == null)
            {
                GameObject gameObject = new GameObject(typeof(T).Name);
                GameObject.DontDestroyOnLoad(gameObject);

                s_Instance = gameObject.AddComponent(typeof(T)) as T;
            }
        }
        return s_Instance;
    }

    protected bool isOtherInstanceExists
    {
        get
        {
            return (s_Instance != null && s_Instance.GetInstanceID() != this.GetInstanceID());
        }
    }

    virtual protected void Awake()
    {
        if (isOtherInstanceExists)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}