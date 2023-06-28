using System;
using System.Collections.Generic;
using UnityEngine;

public class HideMenuContent : MonoBehaviour
{
    Camera mainCamera;
     [SerializeField] List<UIElementsToHide> allUIElementsToHide = new List<UIElementsToHide>();

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        GetChildUIElements();
        InvokeRepeating(nameof(CheckIfUIIsvisible), 0, 0.1f);
    }

    void OnEnable()
    {
       GetChildUIElements(); 
    }

    void GetChildUIElements()
    {
        allUIElementsToHide = new List<UIElementsToHide>();
        foreach (Transform child in transform)
        {
            allUIElementsToHide.Add(child.GetComponent<UIElementsToHide>());
            child.gameObject.SetActive(true);
        }
    }


    void CheckIfUIIsvisible()
    {
        foreach (var rect in allUIElementsToHide)
        {
            if (rect.CurrentRect.IsFullyVisibleFrom(mainCamera))
            {
                rect.HideShowChildren(true);
            }else
                rect.HideShowChildren(false);
        } 
    }


}
