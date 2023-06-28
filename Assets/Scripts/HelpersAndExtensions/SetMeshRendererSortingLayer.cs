using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMeshRendererSortingLayer : MonoBehaviour
{
	[SerializeField]
	private string sortingLayerName;
	[SerializeField]
	private int sortingOrder;
	[SerializeField]
	private Renderer[] meshRenderers;

	private void Awake( )
	{
		if( meshRenderers.IsNullOrEmpty() )
		{
			meshRenderers = new Renderer[ ] { GetComponentInChildren<Renderer>()};
		}
		for( int i = 0; i < meshRenderers.Length; i++ )
		{
			meshRenderers[ i ].sortingLayerName = sortingLayerName;
			meshRenderers[ i ].sortingOrder = sortingOrder;
		}
	}

#if UNITY_EDITOR
	[SerializeField]
	private bool setInEditor;
	[SerializeField]
	private bool collectRenderersInEditor;
	private void OnDrawGizmosSelected( )
	{
		if( setInEditor )
		{
			setInEditor = false;
			Awake();
		}
		if( collectRenderersInEditor )
		{
			collectRenderersInEditor = false;
			meshRenderers = GetComponentsInChildren<Renderer>();
		}
	}
#endif
}
