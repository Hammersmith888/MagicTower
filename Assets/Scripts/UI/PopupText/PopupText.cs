using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupText : MonoBehaviour {

    private static List<PopupText> list = new List<PopupText>();

    [SerializeField]
    private LocalTextLoc textUI;
    [SerializeField]
    private RectTransform rect;
    [SerializeField]
    private RectTransform rectPanel, rectText;
    [SerializeField]
    private Animator _animator;


    public static void Show(string text, Transform parent, float timer, float scale=1, bool isLeft = true)
    {
        GameObject obj = Instantiate(Resources.Load("UI/PopupButtonUI"), parent) as GameObject;
        obj.GetComponent<PopupText>().Set(text, timer, scale, isLeft);
    }




    public void Set(string text, float timer, float scale, bool left)
    {
        textUI.SetLocaleId(text);
        rect.localScale = new Vector3(scale, scale, scale);
        rect.pivot = new Vector2(left ? 0.15f : -0.85f, -0.12f);
        rectPanel.localRotation = Quaternion.Euler(0, (left ? 180 : 0),0);
        rectText.localRotation = Quaternion.Euler(0, (left ? 180 : 0),0);
        rect.localPosition = new Vector3(0, 0, 0);
        StartCoroutine(_Close(timer));
    }

    IEnumerator _Close(float timer)
    {
        yield return new WaitForSeconds(timer);
        _animator.SetTrigger("Hide");
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
