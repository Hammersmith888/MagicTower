
using System.Collections.Generic;
using UnityEngine;

public class CloudSavesLoadingProcessTracker
{
    private HashSet<string> startedProcessesIDs;
    private int activeProcessesCount;
    private System.Action onAllProcessesCompleted;

    public bool IsAnyProcessActive => activeProcessesCount > 0;
    public int ActiveProcessesCount => activeProcessesCount;

    public static CloudSavesLoadingProcessTracker m_Instance;
    public static CloudSavesLoadingProcessTracker Instance
    {
        get {
            if (m_Instance == null)
            {
                m_Instance = new CloudSavesLoadingProcessTracker();
            }
            return m_Instance; }
    }

    private CloudSavesLoadingProcessTracker()
    {
        startedProcessesIDs = new HashSet<string>();
    }

    public void CallActionWhenAllProcessesCompleted(System.Action action)
    {
        if (IsAnyProcessActive)
        {
            onAllProcessesCompleted += action;
        }
        else
        {
            action();
        }
    }

    public void OnProcessStarted(string processID = "<None>")
    {
        //Debug.Log($"<b>CloudSavesLoadingProcessTracker</b>: OnProcessStarted <b>[{processID}]</b>. {activeProcessesCount}");
        //if (!startedProcessesIDs.Add(processID))
        //{
        //    Debug.LogErrorFormat("<b>[{0}]</b>  Process Already Added!", processID);
        //    return;
        //}
        //activeProcessesCount++;
    }

    public void OnProcessCompleted(string processID = "<None>")
    {
        //Debug.Log($"<b>CloudSavesLoadingProcessTracker</b>: OnProcessCompleted <b>[{processID}]</b>. {activeProcessesCount}");
        //if (!startedProcessesIDs.Remove(processID))
        //{
        //    Debug.LogErrorFormat("<b>[{0}]</b>  Process not started and can't be stopped!", processID);
        //    return;
        //}
        //if (activeProcessesCount > 0)
        //{
        //    activeProcessesCount--;
        //    if (activeProcessesCount == 0)
        //    {
        //        //Workaround for situation when in callback was started new process and called CallActionWhenAllProcessesCompleted function
        //        var actionToCall = onAllProcessesCompleted;
        //        onAllProcessesCompleted = null;
        //        actionToCall.InvokeSafely();
        //    }
        //}
    }

    public void Reset()
    {
        startedProcessesIDs.Clear();
        activeProcessesCount = 0;
        onAllProcessesCompleted = null;
    }
}
