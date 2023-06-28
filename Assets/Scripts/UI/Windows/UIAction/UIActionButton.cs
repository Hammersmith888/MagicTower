
using UnityEngine;
using UnityEngine.UI;

public class UIActionButton : MonoBehaviour
{
    [SerializeField]
    private Text timerLabel;

    public static UIActionButton Current;

    public static Vector3 Position
    {
        get
        {
            if (Current != null)
            {
                return Current.transform.position;
            }
            return new Vector3(0f, 0f, 0f);
        }
    }

    private void Awake()
    {
        Current = this;
    }

    private void Start()
    {
        //Current.transform.parent.gameObject.SetActive(false);
    }

    public static void Toggle(bool enabled)
    {
        if (Current != null)
        {
            Debug.Log($"TOOGLE");
            Current.transform.parent.gameObject.SetActive(enabled);
        }
    }

    public static void SetTimerText(string text)
    {
        if (Current != null)
        {
            Current.timerLabel.text = text;
        }
    }
}
