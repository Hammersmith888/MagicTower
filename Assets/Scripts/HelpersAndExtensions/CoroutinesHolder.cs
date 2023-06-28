using System.Collections;
using UnityEngine;

public class CoroutinesHolder : MonoBehaviour
{
    private static CoroutinesHolder instance;

    public static void StartCoroutine(System.Func<IEnumerator> coroutine)
    {
        if (instance == null)
        {
            instance = new GameObject("CoroutinesHolder").AddComponent<CoroutinesHolder>();
        }
        instance.StartCoroutine(coroutine());
    }


    public static void CallActionAfterDelay(System.Action onComplete, float delay)
    {
        CoroutinesHolder corouTineHolder = new GameObject("CoroutinesHolder_WaitForEndOfFrame").AddComponent<CoroutinesHolder>();
        corouTineHolder.CallActionAfterDelayWithCoroutine(delay, onComplete, true);
    }

    public static void ExecuteAtAndEndOfFrame(System.Action onComplete)
    {
        CoroutinesHolder corouTineHolder = new GameObject("CoroutinesHolder_WaitForEndOfFrame").AddComponent<CoroutinesHolder>();
        corouTineHolder.InternalExecuteAtAndEndOfFrame(onComplete);
    }

    public static void ExecuteAfterConditionComplete(System.Func<bool> predicate, System.Action onComplete)
    {
        CoroutinesHolder corouTineHolder = new GameObject("CoroutinesHolder_WaitUntil").AddComponent<CoroutinesHolder>();
        corouTineHolder.StartCoroutine(corouTineHolder.CoroutineWithWaitUntil(predicate, onComplete));
    }

    private void InternalExecuteAtAndEndOfFrame(System.Action onComplete)
    {
        StartCoroutine(WaitToEndOfFrameAndExecute(onComplete));
    }

    private IEnumerator CoroutineWithWaitUntil(System.Func<bool> predicate, System.Action onComplete)
    {
        yield return new WaitUntil(predicate);
        onComplete.InvokeSafely();
        Destroy(gameObject);
    }

    private IEnumerator WaitToEndOfFrameAndExecute(System.Action onComplete)
    {
        yield return new WaitForEndOfFrame();
        onComplete.InvokeSafely();
        Destroy(gameObject);
    }
}
