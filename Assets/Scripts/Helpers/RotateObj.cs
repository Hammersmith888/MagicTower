using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float speed = 1;
    public float radius = 1;
    public bool play = true;
    public Transform center;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            //transform.Rotate(center.position * radius, Time.unscaledDeltaTime * speed);
            transform.RotateAround(center.position, Vector3.back, speed * Time.unscaledDeltaTime);
        }   
    }
}
