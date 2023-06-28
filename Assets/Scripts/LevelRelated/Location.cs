using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public static Location instance;
    
    void Awake()
    {
        instance = this;
    }

    public float min, max;
}
