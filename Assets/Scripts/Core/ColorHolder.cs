using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColorHolder
{
	Color color
	{
		set;
	}

	float alpha
	{
		get; set;
	}
}

public static class ColorHolder
{
	public static IColorHolder[ ] GetColorHolders( this Renderer[] renderers )
	{
		IColorHolder[ ] result = new IColorHolder[ renderers.Length ];
		for( int i = 0; i < renderers.Length; i++ )
		{
			result[ i ] = renderers[ i ].CreateColorHolder();
		}
		return result;
	}

	public static IColorHolder CreateColorHolder( this Renderer renderer )
	{
		if( renderer == null )
		{
			return null;
		}
		else if ( renderer is SpriteRenderer)
		{
			return new SpriteRendererColorHolder( renderer as SpriteRenderer );
		}
		else
		{
		//	Debug.LogErrorFormat("Unrealized IColorHolder for renderer type: {0} object name: {1} ",renderer.GetType(),renderer.name );
			return new MeshRendererColorHolder( renderer );
		}
	}	
}

#region IColorHolder Implementations
public class SpriteRendererColorHolder : IColorHolder
{
	private SpriteRenderer spriteRenderer;

	public SpriteRendererColorHolder( SpriteRenderer spriteRenderer )
	{
		this.spriteRenderer = spriteRenderer;
	}

	public Color color
	{
		set {
			spriteRenderer.color = value;
		}
	}

	public float alpha
	{
		set {
			Color c = spriteRenderer.color;
			c.a = value;
			spriteRenderer.color = c;
		}

		get {
			return spriteRenderer.color.a;
		}
	}
}

public class MeshRendererColorHolder : IColorHolder
{
	private Renderer renderer;
	private bool useSharedMaterials;
	private int colorPropertyID;

	private Material material;

	private static readonly Dictionary<string, string> SHADER_NAME_TO_COLOR_PROPERTY_MAP = new Dictionary<string, string>()
	{
		{"Mobile/Particles/VertexLit Blended","_TintColor"},
		{"Particles/Alpha Blended","_TintColor"},
		{"Particles/Additive","_TintColor"},
		{"Particles/VertexLit Blended","_EmisColor"}
	};

	const string DEFAULT_COLOR_PROPERTY_NAME ="_Color";


	public MeshRendererColorHolder( Renderer renderer, string colorPropertyName = null, bool useSharedMaterials = false )
	{
		this.useSharedMaterials = useSharedMaterials;
		this.renderer = renderer;

		material = useSharedMaterials ? renderer.sharedMaterial : renderer.material;

		if( string.IsNullOrEmpty( colorPropertyName ) )
		{
			IMaterialColorPropertyNameProvider colorPropertyNameProvider = renderer.GetComponent<IMaterialColorPropertyNameProvider>();
			if( colorPropertyNameProvider != null )
			{
				colorPropertyName = colorPropertyNameProvider.getMaterialColorPropertyName;
			}
			else
			{
				if( !SHADER_NAME_TO_COLOR_PROPERTY_MAP.TryGetValue( renderer.sharedMaterial.shader.name, out colorPropertyName ) )
				{
					colorPropertyName = DEFAULT_COLOR_PROPERTY_NAME;
				}
			}
		}
		colorPropertyID = Shader.PropertyToID( colorPropertyName );
	}

	public Color color
	{
		set
        {
            if (material.HasProperty(colorPropertyID))
            {
                //Material material = useSharedMaterials ? renderer.sharedMaterial : renderer.material;
                material.SetColor(colorPropertyID, value);
                //Material[ ] materials = useSharedMaterials ? renderer.sharedMaterials : renderer.materials;
                //for( int i = 0; i < materials.Length; i++ )
                //{
                //	materials[ i ].SetColor( colorPropertyID, value );
                //}
            }
        }
        get
        {
            if (material.HasProperty(colorPropertyID)) //useSharedMaterials ? renderer.sharedMaterial.GetColor( colorPropertyID ) : renderer.material.GetColor( colorPropertyID );
            {
                return material.GetColor(colorPropertyID);
            } 
            return Color.white;
        }
	}


	public float alpha
	{
		set
        {
            if (material.HasProperty(colorPropertyID))
            {
                //Material material = useSharedMaterials ? renderer.sharedMaterial : renderer.material;
                Color color = material.GetColor(colorPropertyID);
                color.a = value;
                material.SetColor(colorPropertyID, color);
                //Material[ ] materials = useSharedMaterials ? renderer.sharedMaterials : renderer.materials;
                //for( int i = 0; i < materials.Length; i++ )
                //{
                //	Color color = materials[ i ].GetColor( colorPropertyID );
                //	color.a = value;
                //	materials[ i ].SetColor( colorPropertyID, color );
                //}
            }
        }
		get
        {
			return color.a;
		}
	}
}

//public class DummyColorHolder : IColorHolder
//{

//	public Color color
//	{
//		set{
//		}
//	}
//	public float alpha
//	{
//		set {
//		}

//		//get {
//		//	return 0;
//		//}
//	}
//}
#endregion
