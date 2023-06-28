using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOnMap : MonoBehaviour
{
    [SerializeField]
    EnemyType enemy;

    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => { PanelInfoDescription.instance.ShowEnemyScreen((enemy)); });
    }
}

