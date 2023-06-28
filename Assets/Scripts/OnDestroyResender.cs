using UnityEngine;

public class OnDestroyResender : MonoBehaviour
{
    public event System.Action OnDestroyEvent;

    private void OnDestroy()
    {
        if (OnDestroyEvent != null)
        {
            OnDestroyEvent();
        }
    }
}
