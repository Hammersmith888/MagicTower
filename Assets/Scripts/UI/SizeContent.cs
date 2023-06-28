using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeContent : MonoBehaviour
{
    [SerializeField]
    Vector3 scale = new Vector3(0.85f, 0.85f, 1f);
    void Start()
    {
        //Debug.Log($"size of screen: {Camera.main.aspect}");

        if (Camera.main.aspect >= 1.8f)
            transform.localScale = new Vector3(scale.x, scale.y, 1);
    }

    private void OnEnable()
    {
        if (this.gameObject.name == "FinalMenu" && GameObject.FindObjectOfType<UIAdsToManaWindow>())
        {
            GameObject noMana = GameObject.FindObjectOfType<UIAdsToManaWindow>().gameObject;
            if (noMana != null)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
