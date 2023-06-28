using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshLayer : MonoBehaviour
{
    public string sortingLayerName = string.Empty; //initialization before the methods
    public int orderInLayer = 0;
    public Renderer MyRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (sortingLayerName != string.Empty)
        {
            MyRenderer = GetComponent<MeshRenderer>();
            MyRenderer.sortingLayerName = sortingLayerName;
            MyRenderer.sortingOrder = orderInLayer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
