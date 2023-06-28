using System;
using System.Collections.Generic;
using UnityEngine;

public class UIElementsToHide : MonoBehaviour
{
    public RectTransform CurrentRect { get; set; }
    List<Transform> allChildObjectsToHide = new List<Transform>();
    

    void Start()
    {
        CurrentRect = (RectTransform) transform;
        
        foreach (Transform c in transform)
        {
           allChildObjectsToHide.Add(c); 
        } 
    }

    public void HideShowChildren(bool state)
    {
        foreach (var c in allChildObjectsToHide)
        {
           c.gameObject.SetActive(state); 
        } 
    }
}
