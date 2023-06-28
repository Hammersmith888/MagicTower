using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve jumpSpeedCurve;
    [SerializeField]
    private AnimationCurve jumpHeightCurve;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float jumpTime;

    private bool jumping = false;
    private bool interrupted = false;
    private Vector2 jumpDelta;
    private Vector2 lastProgress;
    private float jumpStartTime;

    public bool IsJumping()
    {
        return jumping;
    }

    public float GetCurrentJumpHeight()
    {
        if (!jumping)
            return 0.0f;

        float animProgress = (Time.time - jumpStartTime) / jumpTime;
        animProgress = Mathf.Min(animProgress, 1.0f);
        return jumpHeightCurve.Evaluate(animProgress) * jumpHeight;
    }

    public Vector2 GetJumpDelta()
    {
        if (!jumping || interrupted)
            return Vector2.zero;

        float animProgress = (Time.time - jumpStartTime) / jumpTime;
        animProgress = Mathf.Min(animProgress, 1.0f);
        Vector2 currentProgress = jumpSpeedCurve.Evaluate(animProgress) * jumpDelta;
        Vector2 delta = currentProgress - lastProgress;
        lastProgress = currentProgress;
        return delta;
    }

    public void Jump(Vector2 newDelta)
    {
        if (!jumping)
        {
            jumping = true;
            interrupted = false;
            jumpDelta = newDelta;
            jumpStartTime = Time.time;
            lastProgress = Vector2.zero;
            StartCoroutine(CheckForFinish());
        }
    }

    public IEnumerator CheckForFinish()
    {
        while (Time.time - jumpStartTime < jumpTime)
            yield return null;

        jumping = false;
    }

    public void InterruptJump()
    {
        if (jumping)
            interrupted = true;
    }
}
