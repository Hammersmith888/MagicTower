
using UnityEngine;
using UnityEngine.UI;

public class GemInfoHelper : MonoBehaviour
{
    [SerializeField]
    LocalTextLoc _des;
    public LocalTextLoc description
    {
        get { return _des; }
        set
        {
            _des = value;
            _des.parameters.maxsize = 40;
        }
    }
    public Image icon;
    public Text emptyText;

    private void Start()
    {
        emptyText.gameObject.SetActive(false);
    }
}
