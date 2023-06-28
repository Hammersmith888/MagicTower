using UnityEngine;
using UnityEngine.UI;

public class FindAllButtonsAddAction : MonoBehaviour
{
    [SerializeField] Button[] closeButtons;
    void Start()
    {
        var allButtons = FindObjectsOfType<Button>(); //yes its retarded, but all ui here must be refactored in general
        foreach (var b in allButtons)
        {
          ////  b.onClick.AddListener(Pollfish.HidePollfish);
        }

        foreach (var b in closeButtons)
        {
         ////   b.onClick.AddListener(Pollfish.ShowPollfish);
        }
    }
}
