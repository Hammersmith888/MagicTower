
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    public enum EAnimationType
    {
        ONCE, LOOP, PING_PONG
    }

    public Vector3          fromScale;
    public Vector3          toScale;
    public float            animationTime;
    public bool             disableObjectAtEnd;

    public AnimationCurve   effectCurve;
    public bool             useCurve;
    public EAnimationType   animationType = EAnimationType.ONCE;
    public bool             autoStart;
    public float            startDelay;

    protected bool          forwardDirection = true;
    protected BaseTimer     timer;
    protected System.Action onAnimationEnd;
    protected GameObject    obj;
    protected Transform     transf;

    protected bool inited = false;

    protected void Awake()
    {
        Init();
        if (autoStart)
        {
            if (startDelay <= 0)
            {
                Animate();
            }
            else
            {
                TimersManager.AddTimer(startDelay, Animate);
            }
        }
    }

    public void Init()
    {
        if (!inited)
        {
            inited = true;
            obj = gameObject;
            transf = transform;
            timer = new BaseTimer(animationTime, false, OnAnimationEnd);
        }
    }

    public void RegisterCallbackOnAnimationEnd(System.Action callback)
    {
        onAnimationEnd = callback;
    }

    public void AddOnAnimationEndCallback(System.Action callback)
    {
        onAnimationEnd += callback;
    }

    public void Animate()
    {
        Animate(animationTime);
    }

    public void Animate(System.Action callback)
    {
        Animate(animationTime, fromScale, callback);
    }

    public void Animate(float time, System.Action callback = null)
    {
        Animate(time, fromScale, callback);
    }

    public void Animate(float time, Vector3 startScale, System.Action callback = null)
    {
        obj.SetActive(true);
        fromScale = startScale;
        transf.localScale = startScale;
        timer.Start(time, callback);
    }

    protected void OnAnimationEnd()
    {
        if (onAnimationEnd != null)
        {
            onAnimationEnd();
        }
        if (disableObjectAtEnd)
        {
            obj.SetActive(false);
        }
    }

    private float timerProgress;
    protected void Update()
    {
        if (timer.isActive)
        {
            timer.Update();
            timerProgress = forwardDirection ? timer.progress : 1f - timer.progress;
            transf.localScale = Vector3.Lerp(fromScale, toScale, useCurve ? effectCurve.Evaluate(timerProgress) : timerProgress);
            if (!timer.isActive)
            {
                OnAnimationEnd();
                if (animationType == EAnimationType.LOOP)
                {
                    timer.Start();
                }
                else if (animationType == EAnimationType.PING_PONG)
                {
                    forwardDirection = !forwardDirection;
                    timer.Start();
                }
            }
        }
    }
}
