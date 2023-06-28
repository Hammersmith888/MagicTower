using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSourceAnim : MonoBehaviour
{

    public float speed = 1;
    public Material mat;
    public LineRenderer line;

    Material _mat;
    public float current = 0;

    public bool isEnable = true;

    public float aColor = 0;

    void Start()
    {
        _mat = Instantiate(mat) as Material;
        line.material = _mat;
    }

    // Update is called once per frame
    void Update()
    {
        current = current + Time.deltaTime * speed;
        //_mat.SetTextureOffset("_MainTex", new Vector2(current, 0));
    }
}
