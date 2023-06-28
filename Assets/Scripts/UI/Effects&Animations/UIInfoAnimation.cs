
using System.Collections;
using UnityEngine;

public class UIInfoAnimation : MonoBehaviour
{
    private const float ScaleAnimationCycleTime = 0.5f;
    private const float ScaleValue = 1.1f;

    [SerializeField]
    private AnimationCurve scaleCurve;

    private bool stopAnimation;
    private bool isAnimating;

    private float timer;
    private Vector3 startScale;
    private Vector3  targetScale;

    public void AnimateButton()
    {
        Debug.Log("AnimateButton " + isAnimating);
        if (!isAnimating)
        {
            stopAnimation = false;
            timer = 0f;
            startScale = new Vector3(1f, 1f, 1f);
            targetScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
            isAnimating = true;
        }
    }

    public void StopAnimation()
    {
        Debug.Log("StopAnimation " + isAnimating);
        stopAnimation = true;
    }

    private void Update()
    {
        if(isAnimating)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, targetScale, scaleCurve.Evaluate(timer / ScaleAnimationCycleTime));
            if (timer >= ScaleAnimationCycleTime)
            {
                timer -= ScaleAnimationCycleTime;
                var temp = startScale;
                startScale = targetScale;
                targetScale = temp;
                if (stopAnimation && startScale.x < ScaleValue)
                {
                    isAnimating = false;
                    stopAnimation = false;
                }
            }
        }
    }
}
