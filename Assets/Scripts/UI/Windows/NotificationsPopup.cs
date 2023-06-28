using UnityEngine;

public class NotificationsPopup : MonoBehaviour
{
    private System.Action<bool> onSelectNotificationsStateAction;

    public void Init(System.Action<bool> onSelectNotificationsStateAction)
    {
        this.onSelectNotificationsStateAction = onSelectNotificationsStateAction;
        transform.SetAsLastSibling();
    }

    public void SelectNotificationsState(bool enabled)
    {
        onSelectNotificationsStateAction.InvokeSafely(enabled);
        Destroy(gameObject);
    }
}
