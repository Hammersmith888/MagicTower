using UnityEngine;

namespace Animations
{
    public class AlphaColorAnimation : MonoBehaviour
    {
        public enum EAnimationType
        {
            ONCE, LOOP, PING_PONG
        }
        #region VARIABLES
        public IColorHolder colorHolder;
        public bool setColorHolderAutomatically;
        public bool collectAllColorHoldersIncludingChild;

        public float fromAlpha;
        public float toAlpha;
        public float animationTime;
        public FloatRange randomizeAnimationTimeBy;

        public AnimationCurve effectCurve;
        public bool useCurve;
        public EAnimationType animationType = EAnimationType.ONCE;
        public bool autoStart;
        public bool disableObjectAtEnd;
        public bool useUnscaledTime;

        protected bool forwardDirection = true;
        protected BaseTimer timer;
        protected System.Action onAnimationEnd;
        public GameObject gameobjectCached
        {
            get; private set;
        }

        protected bool inited = false;
        #endregion

        public bool IsPlaying
        {
            get
            {
                return timer.isActive;
            }
        }

        // Use this for initialization
        protected void Awake()
        {
            Init();
            if (autoStart)
            {
                Animate();
            }
            else
            {
                enabled = false;
            }
        }

        public void Init()
        {
            if (!inited)
            {
                inited = true;
                gameobjectCached = gameObject;
                animationTime += randomizeAnimationTimeBy.random;
                timer = new BaseTimer(animationTime, false, OnAnimationEnd, useUnscaledTime);
                if (colorHolder == null)
                {
                    if (setColorHolderAutomatically)
                    {
                        if (GetComponent<SpriteRenderer>() != null)
                        {
                            colorHolder = gameobjectCached.AddComponent<SpriteRendererColorHolder>();
                        }
                        else if (GetComponent<UnityEngine.UI.Image>() != null)
                        {
                            colorHolder = gameobjectCached.AddComponent<UIImageColorHolderComponent>();
                        }
                        //else if( GetComponent<TextMesh>() != null )
                        //{
                        //    colorHolder = gameobjectCached.AddComponent<TextMeshColorHolder>();
                        //}
                        else if (GetComponent<CanvasGroup>() != null)
                        {
                            colorHolder = gameobjectCached.AddComponent<CanvasGroupAlphaHolder>();
                        }
                        else
                        {
                            Debug.LogWarning("Can't find suitable component to add color holder for object " + gameobjectCached.name);
                        }
                    }
                    else
                    {
                        if (collectAllColorHoldersIncludingChild)
                        {
                            colorHolder = new MultipleObjectsColorHolder(GetComponentsInChildren<IColorHolder>());
                        }
                        else
                        {
                            colorHolder = GetComponentInChildren<IColorHolder>();
                        }
                    }
                }
                if (colorHolder != null)
                {
                    colorHolder.Init();
                }
            }
        }

        public void Pause()
        {
            timer.Pause();
        }

        public void Resume()
        {
            timer.Resume();
        }

        public void SetColor(Color color)
        {
            colorHolder.color = color;
        }

        public void SetAlpha(float alpha)
        {
            colorHolder.alpha = alpha;
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
            forwardDirection = true;
            Animate(animationTime);
        }

        public void Animate(System.Action callback, bool forward = true)
        {
            forwardDirection = forward;
            Animate(animationTime, fromAlpha, callback);
        }

        public void Animate(float time, float startAlpha, System.Action callback = null)
        {
            enabled = true;
            gameobjectCached.SetActive(true);
            fromAlpha = startAlpha;
            colorHolder.alpha = forwardDirection ? fromAlpha : toAlpha;
            timer.Start(time, callback);
        }

        public void Animate(float time, bool forward = true, System.Action callback = null)
        {
            forwardDirection = forward;
            Animate(time, fromAlpha, callback);
        }

        public void AnimateFromCurrentColor(float endAlpha, System.Action callback = null)
        {
            enabled = true;
            gameobjectCached.SetActive(true);
            fromAlpha = colorHolder.alpha;
            toAlpha = endAlpha;
            timer.Start(animationTime, callback);
        }

        protected void OnAnimationEnd()
        {
            if (disableObjectAtEnd)
            {
                gameobjectCached.SetActive(false);
            }
            if (onAnimationEnd != null)
            {
                onAnimationEnd();
            }
        }

        private float timerProgress;
        protected void Update()
        {
            if (timer.isActive)
            {
                timer.Update();
                timerProgress = useCurve ? effectCurve.Evaluate(timer.progress) : timer.progress;/*forwardDirection ? timer.progress : 1f - timer.progress;*/
                colorHolder.alpha = forwardDirection ? Mathf.Lerp(fromAlpha, toAlpha, timerProgress) : Mathf.Lerp(toAlpha, fromAlpha, timerProgress);
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
                    else
                    {
                        enabled = false;
                    }
                }
            }
        }

#if UNITY_EDITOR
        [Header( "Editor variables" )]
        public bool swapValues;
        public bool updateTime;
        protected void OnDrawGizmosSelected()
        {
            if (swapValues)
            {
                swapValues = false;
                float temp = fromAlpha;
                fromAlpha = toAlpha;
                toAlpha = temp;
            }
            if (updateTime)
            {
                updateTime = false;
                timer.Start(animationTime);
            }
        }
#endif
    }
}
