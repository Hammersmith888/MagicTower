
public interface IUIToBlockWhileReplicaActiveProvider
{
    void ToggleUIIntercationState(bool enabled);
}

public class UIToBlockWhileReplicaActiveProvider
{
    public static IUIToBlockWhileReplicaActiveProvider Current;

    public static void ToggleUIInteractionState(bool enabled)
    {
        if (Current != null)
        {
            Current.ToggleUIIntercationState(enabled);
        }
    }
}
