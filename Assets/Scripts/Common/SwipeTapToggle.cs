using UnityEngine;
using UnityEngine.UI;

public class SwipeTapToggle : MonoBehaviour {

    public SwipeController swipeControl;
    public TapController tapControl;

    public GameObject[] tapBtns;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void ChangeControl()
    {
        if (swipeControl.enabled)
        {
            swipeControl.enabled = false;
            tapControl.enabled = true;
            for (int i = 0; i < tapBtns.Length; i++)
                tapBtns[i].GetComponent<Button>().enabled = true;
            transform.GetChild(0).GetComponent<Text>().text = "Now Tap";
        } else
        {
            swipeControl.enabled = true;
            tapControl.enabled = false;
            for (int i = 0; i < tapBtns.Length; i++)
                tapBtns[i].GetComponent<Button>().enabled = false;
            transform.GetChild(0).GetComponent<Text>().text = "Now Swipe";
        }
    }
}