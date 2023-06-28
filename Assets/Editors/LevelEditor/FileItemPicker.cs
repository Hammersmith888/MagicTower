using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;

public class FileItemPicker : MonoBehaviour, IPointerDownHandler
{
    public static GameObject currentFileItem;
    public GameObject panelSelect;

    void Start()
    {
        currentFileItem = transform.parent.transform.GetChild(0).gameObject;
        //currentFileItem.GetComponent<Text>().fontStyle = FontStyle.Bold;
        panelSelect.SetActive(false);
    }

    public void OnPointerDown(PointerEventData _eventData)
    {
        if (gameObject != currentFileItem)
        {
            //currentFileItem.GetComponent<Text>().fontStyle = FontStyle.Normal;
            currentFileItem.GetComponent<FileItemPicker>().panelSelect.SetActive(false);
            currentFileItem = gameObject;
            //GetComponent<Text>().fontStyle = FontStyle.Bold;
            currentFileItem.GetComponent<FileItemPicker>().panelSelect.SetActive(true);
        } 
    }
}
