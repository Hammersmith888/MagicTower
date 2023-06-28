
using UnityEngine;
using UnityEngine.UI;

public class UIFinalMenuConfig : MonoBehaviour, IUIToBlockWhileReplicaActiveProvider
{
    [SerializeField]
    private Button[] UIButtons;
    [SerializeField]
    private UI.BackButtonClickListenerWithUnityEvent VictoryMenuBackButtonListener;
    [SerializeField]
    private UI.BackButtonClickListenerWithUnityEvent DefeatMenuBackButtonListener;

    private void OnEnable()
    {
        UIToBlockWhileReplicaActiveProvider.Current = this;
    }

    private void OnDisable()
    {
        UIToBlockWhileReplicaActiveProvider.Current = null;
    }

    public void ToggleUIIntercationState(bool enabled)
    {
        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(enabled);
        VictoryMenuBackButtonListener.Enabled = enabled;
        DefeatMenuBackButtonListener.Enabled = enabled;
        for (int i = 0; i < UIButtons.Length; i++)
        {
            if (UIButtons[i] != null)
                UIButtons[i].interactable = enabled;
        }
    }
}
