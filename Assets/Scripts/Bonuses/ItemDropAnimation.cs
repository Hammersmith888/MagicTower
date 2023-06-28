using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropAnimation : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve      yAnimationCurve;
    [SerializeField]
    private FloatRange          animTimeRange;
    [SerializeField]
    private FloatRange          xDropRange;
    [SerializeField]
    private FloatRange          yUpOffsetRange;
    [SerializeField]
    private FloatRange          yDropOffsetRange;
    [SerializeField]
    private float               handleXDirection;

    private Transform           thisTransform;

    public void Init()
    {
        thisTransform = transform;
    }

    public void Play()
    {
        StopAllCoroutines();
        transform.localPosition = new Vector3(0f, 0f, 0f);
        float xDirection = Random.Range(0f, 100f) > 50f ? 1f : -1f;
        if (handleXDirection != 0)
        {
            xDirection = handleXDirection;
        }
        StartCoroutine(AnimationCoroutine(animTimeRange.random, xDropRange.random * xDirection, yUpOffsetRange.random, yDropOffsetRange.random));
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator AnimationCoroutine(float animTime, float targetX, float yUpPosition, float targetY)
    {
        float timer = 0;
        Vector3 startPos = thisTransform.localPosition;
        Vector3 currentAnimPos = startPos;
        float animationProgress = 0;
        float halfAnimTime = animTime / 2f;
        float currentTargetX = Mathf.Lerp(startPos.x, targetX, 0.5f);
        while (timer < halfAnimTime)//flying up
        {
            timer += Time.deltaTime;
            animationProgress = timer / halfAnimTime;
            currentAnimPos.x = Mathf.Lerp(startPos.x, currentTargetX, animationProgress);
            currentAnimPos.y = Mathf.Lerp(startPos.y, yUpPosition, yAnimationCurve.Evaluate(animationProgress));
            thisTransform.localPosition = currentAnimPos;
            yield return null;
        }

        startPos = currentAnimPos;
        timer = halfAnimTime;
        while (timer > 0)//flying down
        {
            timer -= Time.deltaTime;
            animationProgress = timer / halfAnimTime;
            currentAnimPos.x = Mathf.Lerp(targetX, startPos.x, animationProgress);
            currentAnimPos.y = Mathf.Lerp(targetY, startPos.y, yAnimationCurve.Evaluate(animationProgress));
            thisTransform.localPosition = currentAnimPos;
            yield return null;
        }
        yield return null;
    }

#if UNITY_EDITOR
    [Space(10f)]
    [SerializeField]
    private bool PlayAnimationEditor;
    private void OnDrawGizmosSelected()
    {
        if (PlayAnimationEditor)
        {
            PlayAnimationEditor = false;
            if (Application.isPlaying)
            {
                Init();
                Play();
            }
        }
    }
#endif

}
