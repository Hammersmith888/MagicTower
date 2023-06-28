using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplicaUIAutoDestroy : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 6f;

    // Update is called once per frame
    void Update()
    {
        DestroyReplicaUI();
    }

    void DestroyReplicaUI() //retarted stuff, but in some cases some routines never disabled this gameobject, so game just stopped. Refactor
    {
        timeToDestroy -= Time.deltaTime;

        if (timeToDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
