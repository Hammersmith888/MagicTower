using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnableObjectCallback
{
    void OnStart();
}

public class EnableObject : MonoBehaviour
{
    public IEnableObjectCallback script;

    void Start()
    {
        script.OnStart();
    }
}
