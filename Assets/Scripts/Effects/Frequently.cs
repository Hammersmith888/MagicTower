using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frequently : MonoBehaviour
{

    float rndSpeed = 1;
    bool reverse = false;
    float rndScale = 0;
    float wait = 0;

    void Start()
    {
        rndScale = Random.Range(0.8f, 1.5f);
        rndSpeed = Random.Range(80, 150f);
        wait = Random.Range(5f, 15f);
    }

    void Update()
    {
        transform.Rotate(Vector3.back, Time.unscaledDeltaTime * rndSpeed);
        var scale = transform.localScale.x;
        wait -= Time.unscaledDeltaTime;
        if (scale > 1.4f && !reverse )
        {
            reverse = true;
        }
        else if (scale <= 0 && reverse && wait < 0)
        {
            reverse = false;
            rndScale = Random.Range(0.8f, 1.5f);
            rndSpeed = Random.Range(80, 150f);
            wait = Random.Range(5f, 15f);
        }

        if (reverse)
            scale -= (Time.unscaledDeltaTime * 0.8f);
        else
            scale += (Time.unscaledDeltaTime * 0.8f);
        scale = Mathf.Clamp(scale, 0, 1.5f);
        transform.localScale = new Vector3(scale, scale, 1);
    }
}
