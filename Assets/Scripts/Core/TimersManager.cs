using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#region Timers classes


[System.Serializable]
public class BaseTimer : IPoolObject
{
    private float timer;
    [SerializeField]
    protected float time;
    protected System.Action callBack;
    protected bool active;
    protected bool useUnscaledTime;

    #region Properties
    public float getTime
    {
        get
        {
            return time;
        }
    }

    public virtual float progress
    {
        get
        {
            return timer / time;
        }
    }

    public virtual float timeLeft
    {
        get
        {
            return time - timer;
        }
    }

    public bool isActive
    {
        get
        {
            return active;
        }
    }
    #endregion

    #region IPoolObject implementation
    public bool canBeUsed
    {
        get
        {
            return !active;
        }
    }

    public void Init()
    {
    }
    #endregion

    public BaseTimer()
    {
    }

    public BaseTimer(float _time, bool start = false, System.Action _callBack = null, bool _useUnscaledTime = false)
    {
        timer = 0;
        time = _time;
        callBack = _callBack;
        active = start;
        useUnscaledTime = _useUnscaledTime;
    }

    public void AddCallback(System.Action _callBack)
    {
        callBack += _callBack;
    }

    public virtual void Start()
    {
        Start(time);
    }

    public virtual void Start(float t)
    {
        active = true;
        timer = 0;
        time = t;
    }

    public void Start(float t, System.Action _callBack)
    {
        callBack = _callBack;
        Start(t);
    }

    public void Pause()
    {
        active = false;
    }

    public void Resume()
    {
        active = true;
    }

    public virtual bool Update()
    {
        return Update(useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
    }

    public virtual bool Update(float timeDelta)
    {
        if (active)
        {
            timer += timeDelta;
            if (timer >= time)
            {
                active = false;
                if (callBack != null)
                {
                    callBack();
                }
                return !active;
            }
        }
        return false;
    }
}

public class RealTimeTimer : BaseTimer
{
    protected float startTime;
    protected float endTime;

    public override float progress
    {
        get
        {
            return (Time.realtimeSinceStartup - startTime) / time;
        }
    }

    public override float timeLeft
    {
        get
        {
            return endTime - Time.realtimeSinceStartup;
        }
    }

    public RealTimeTimer()
    {
    }

    public RealTimeTimer(float _time, bool start = false, System.Action _callBack = null)
    {
        time = _time;
        callBack = _callBack;
        if (start)
        {
            Start();
        }
    }

    public override void Start(float t)
    {
        active = true;
        time = t;
        startTime = Time.realtimeSinceStartup;
        endTime = startTime + t;
    }

    public override bool Update()
    {
        if (active)
        {
            if (Time.realtimeSinceStartup >= endTime)
            {
                active = false;
                if (callBack != null)
                {
                    callBack();
                }
                return true;
            }
        }
        return false;
    }
}
#endregion

public class TimersManager : MonoBehaviour
{
    private static TimersManager _instance;
    public static TimersManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("TimerManager").AddComponent<TimersManager>();
                _instance.InitializePool();
            }
            return _instance;
        }
    }

    private ObjectsPool<BaseTimer> timersPool;

    private bool paused;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            InitializePool();
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void InitializePool()
    {
        timersPool = new ObjectsPool<BaseTimer>(2, () =>
       {
           return new BaseTimer();
       });
    }

    public static void AddTimer(float time, System.Action callBack)
    {
        instance.timersPool.GetObjectFromPool().Start(time, callBack);
    }

    //public static BaseTimer AddTimer( float time, System.Action callBack )
    //{
    //	BaseTimer timer = instance.timersPool.GetObjectFromPool();
    //	return timer;
    //}

    public static System.Action AddTimerAndReturnStopHandler(float time, System.Action callBack)
    {
        BaseTimer timer = instance.timersPool.GetObjectFromPool();
        timer.Start(time, callBack);
        return timer.Pause;
    }

    private void UpdateTimer(BaseTimer timer)
    {
        timer.Update();
    }

    public static void TogglePauseState(bool paused)
    {
        if (instance != null)
        {
            instance.paused = paused;
        }
    }

    public static void StopAllTimers()
    {
        instance.timersPool.ExecuteOnAll((BaseTimer timer) =>
       {
           timer.Pause();
       });
    }

    void Update()
    {
        if (paused)
        {
            return;
        }
        timersPool.ExecuteOnAll(UpdateTimer);
    }
}
