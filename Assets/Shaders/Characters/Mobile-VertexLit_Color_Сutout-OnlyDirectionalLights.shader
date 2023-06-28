// Simplified VertexLit shader, optimized for high-poly meshes. Differences from regular VertexLit one:
// - less per-vertex work compared with Mobile-VertexLit
// - supports only DIRECTIONAL lights and ambient term, saves some vertex processing power
// - no per-material color
// - no specular
// - no emission

Shader "Custom/VertexLit/Color Cutout (Only Directional Lights, No shadows, NoLightMaps)" 
{
	Properties
	{
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
		[PerRendererData]_Color("Color Multiplier", Color) = (1,1,1,1)
		_Cutoff("Alpha cutoff", Range(0,1)) = 0.5
	}

		SubShader
		{
		Tags{ "Queue" = "AlphaTest" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout" }
		LOD 100
		
		// Non-lightmapped
		Pass
		{
			Tags{ "LightMode" = "Vertex" }
			Alphatest Greater[_Cutoff]
			AlphaToMask True
			ColorMask RGB
			Material
		{
			Diffuse[_Color]
			Ambient[_Color]
		}
		Lighting On
		SetTexture[_MainTex]
		{
			Combine texture * primary DOUBLE, texture * primary
		}
	}
	}
}

