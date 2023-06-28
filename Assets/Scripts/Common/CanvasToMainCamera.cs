using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToMainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var c = GetComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceCamera;
        c.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
