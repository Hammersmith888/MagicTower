using UnityEngine;
using System.Collections;

public class ChangeSortingLayer : MonoBehaviour {

	void Start () {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = "Elements";
        meshRenderer.sortingOrder = 1;
	}
}
