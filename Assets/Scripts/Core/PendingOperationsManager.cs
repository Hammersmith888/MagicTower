using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPendingOperation
{
    void StartOperation(System.Action<bool> operationCallback);
}

//PendingOperationsManager required for ensuring initialization of certain game systems that for some reasons was not initialized properly at the time
//Game system registered to pending operations manager when failed to do some required action
//"CheckPendingOperations" function will be called during fade screen between scenes in attempt to perform failed action of registered system one more time

// Example: When saves data loading from cloud DB was initiated but was failed for some reason, the data loader will register itself as IPendingOperation,
// and saves data loading attempt will be executed each time fade screen between scenes will be showed
public class PendingOperationsManager
{
    private List<IPendingOperation> pendingOperationsList = new List<IPendingOperation>();
    private List<int> operationToRemoveIndexes = new List<int>();

    const float MAX_WAIT_FOR_OPERATIONS_COMPLETION_TIME = 5f;

    private static PendingOperationsManager _instance;

    public static PendingOperationsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PendingOperationsManager();
            }
            return _instance;
        }
    }

    public void AddPendingOperation(IPendingOperation pendingOperation)
    {
        Debug.Log("PendingOperationsManager. AddPendingOperation");
        pendingOperationsList.Add(pendingOperation);
    }


    /// <summary>
    /// This called during fade screen between scenes
    /// </summary>
    /// <param name="actionAfterOperationsComplete"></param>
    public static void CheckPendingOperations(System.Action actionAfterOperationsComplete)
    {
        if (_instance == null)
        {
//            Debug.Log("PendingOperationsManager. NoPendingOperations: _instance == null");
            actionAfterOperationsComplete.InvokeSafely();
        }
        else
        {
            int count = _instance.pendingOperationsList.Count;
            if (count == 0)
            {
          //      Debug.Log("PendingOperationsManager. NoPendingOperations: operations count is 0 ");
                actionAfterOperationsComplete.InvokeSafely();
            }
            else
            {
          //      Debug.LogFormat("Starting {0} pending operations", count);
                int operationsRunning = 0;
                float operationsStartTime = Time.unscaledTime;
                for (int i = 0; i < count; i++)
                {
                    int indexToRemove = i;
                    operationsRunning++;
                    _instance.pendingOperationsList[i].StartOperation((bool operationCompletedSuccessfully) =>
                 {
                //     Debug.LogFormat("PendingOperationsManager. Pending operation ({0}) completed with result: {1}", indexToRemove, operationCompletedSuccessfully);
                     operationsRunning--;
                     if (operationCompletedSuccessfully)
                     {
                         _instance.operationToRemoveIndexes.Add(indexToRemove);
                     }
                 });
                }

                CoroutinesHolder.ExecuteAfterConditionComplete(() =>
               {
                   if (operationsRunning == 0 || Time.unscaledTime - operationsStartTime > MAX_WAIT_FOR_OPERATIONS_COMPLETION_TIME)
                   {
                    //   Debug.LogFormat("PendingOperationsManager. All Pending Operations completed Time Passed: {0}", Time.unscaledTime - operationsStartTime);

                       count = _instance.operationToRemoveIndexes.Count;
                       if (count > 0)
                       {
                           for (int i = 0; i < count; i++)
                           {
                               _instance.operationToRemoveIndexes.RemoveAt(i);
                               i--;
                               count--;
                           }
                           if (count == 0)
                           {
                               _instance = null;
                           }
                       }
                       return true;
                   }
                   else
                   {
                       return false;
                   }
               }, actionAfterOperationsComplete);
            }
        }
    }


}
