using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleLoad : MonoBehaviour
{
    public Image img;
    Image cur;
    
    void Start()
    {
        cur = GetComponent<Image>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    cur.color = new Color(cur.color.r, cur.color.g, cur.color.b, img.color.a);
    //}
}
