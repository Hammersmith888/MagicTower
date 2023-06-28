using UnityEngine;

public static class LoadFromCloudQueue
{
    public static bool IsAnyLoadFromCloudOperationActive
    {
        get; private set;
    }

    private static System.Action onLoadFromCloudOperationComplete;

    public static void PutOperationToQueue(System.Action onPreviousLoadOperationComplete)
    {
        if (IsAnyLoadFromCloudOperationActive)
        {
            Debug.LogFormat("OnStartLoadFromCloud: currently some load operation active, new operation queued");
            onLoadFromCloudOperationComplete += onPreviousLoadOperationComplete;
        }
        else
        {
            IsAnyLoadFromCloudOperationActive = true;
            onPreviousLoadOperationComplete.InvokeSafely();
        }

    }

    public static void UnregistedFromLoadQueue(System.Action onPreviousLoadOperationComplete)
    {
        onLoadFromCloudOperationComplete -= onPreviousLoadOperationComplete;
    }

    public static void OnCompleteLoadFromCloud()
    {
        if (onLoadFromCloudOperationComplete != null)
        {
            Debug.LogFormat("OnCompleteLoadFromCloud: queued operation activated");
            onLoadFromCloudOperationComplete();
            onLoadFromCloudOperationComplete = null;
        }
        else
        {
            IsAnyLoadFromCloudOperationActive = false;
        }
    }
}
