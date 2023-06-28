using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWindow : MonoBehaviour
{
    public delegate void CloseClick();
    CloseClick closeMethod;

    public static GameObject prefab = null;
    public static void Create(Transform parent ,string label, string text, string textBtn, CloseClick _event = null)
    {
        if (prefab == null)
            prefab = Resources.Load("UI/CanvasPopupWindow") as GameObject;
        var obj = Instantiate(prefab, parent) as GameObject;
        obj.GetComponentInChildren<PopupWindow>().Set(label, text, textBtn, _event);
    }

    public static void Create(Transform parent, string label, string text, CloseClick _event = null)
    {
        if (prefab == null)
            prefab = Resources.Load("UI/CanvasPopupWindow") as GameObject;
        var obj = Instantiate(prefab, parent) as GameObject;
        obj.GetComponentInChildren<PopupWindow>().Set(label, text, TextSheetLoader.Instance.GetString("t_0572"), _event);
    }


    [SerializeField]
    Text label, text, btnText;

    public void Set(string label, string text, string textBtn, CloseClick _event)
    {
        Debug.Log("Popup Window");
        this.label.text = label;
        this.text.text = text;
        //btnText.text = textBtn;
        closeMethod = _event;
    }

    public void Close()
    {
        closeMethod();
        Destroy(gameObject);
    }
}
