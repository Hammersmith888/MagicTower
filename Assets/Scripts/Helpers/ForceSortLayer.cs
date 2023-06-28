using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ForceSortLayer : MonoBehaviour {
	public string sortLayer="Default";
	public int layerorder=0;

	// Use this for initialization
	void Start () {
		SetSortLayer(transform);
	}

//	void Update( )
//	{
//		if ( Application.isPlaying==false ) SetSortLayer(transform);
//	}
	void SetSortLayer( Transform root )
	{
		if ( root.GetComponent<Renderer>()!=null )
		{
			root.GetComponent<Renderer>().sortingLayerName=sortLayer;
			root.GetComponent<Renderer>().sortingOrder = layerorder;
		}
		for (int i=0;i<root.childCount;i++)
		{
			SetSortLayer(root.GetChild(i));
		}
#if !UNITY_EDITOR
        Destroy (this);
#endif
	}
	
}
