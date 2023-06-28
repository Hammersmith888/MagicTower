using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugShaderName : MonoBehaviour {

#if UNITY_EDITOR
	public string shaderName;
	[Space(15f)]
	public bool refresh;
	private void OnDrawGizmosSelected( )
	{
		if( refresh || string.IsNullOrEmpty( shaderName ) )
		{
			refresh = false;
			Renderer _renderer = GetComponent<Renderer>();
			if( _renderer != null && _renderer.sharedMaterial != null )
			{
				shaderName = _renderer.sharedMaterial.shader.name;
			}
			else
			{
				shaderName = "";
			}
		}
	}
#endif
}
