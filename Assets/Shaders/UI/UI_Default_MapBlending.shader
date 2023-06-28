Shader "Custom/MapBlending_UI_Sprite"
{
	Properties
	{
		_TextureToBlend("Texture To BlendWith", 2D) = "white" {}
		_BlendThreshold("Blend Threshold",Range(0,1)) = 1

		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		[Space(20)]_Color("Tint", Color) = (1,1,1,1)


		_StencilComp("Stencil Comparison", Float) = 8
		_Stencil("Stencil ID", Float) = 0
		_StencilOp("Stencil Operation", Float) = 0
		_StencilWriteMask("Stencil Write Mask", Float) = 255
		_StencilReadMask("Stencil Read Mask", Float) = 255

		_ColorMask("Color Mask", Float) = 15

		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip("Use Alpha Clip", Float) = 0
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}

	Stencil
	{
		Ref[_Stencil]
		Comp[_StencilComp]
		Pass[_StencilOp]
		ReadMask[_StencilReadMask]
		WriteMask[_StencilWriteMask]
	}

		Cull Off
		Lighting Off
		ZWrite Off
		ZTest[unity_GUIZTestMode]
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask[_ColorMask]

	Pass
	{
		Name "Default"
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma target 2.0

#include "UnityCG.cginc"
#include "UnityUI.cginc"

#pragma multi_compile __ UNITY_UI_ALPHACLIP

		struct appdata_t
		{
			float4 vertex   : POSITION;
			float4 color    : COLOR;
			float2 texcoord : TEXCOORD0;
			UNITY_VERTEX_INPUT_INSTANCE_ID
		};

		struct v2f
		{
			float4 vertex   : SV_POSITION;
			fixed4 color : COLOR;
			float2 texcoord  : TEXCOORD0;
			float4 worldPosition : TEXCOORD1;
			UNITY_VERTEX_OUTPUT_STEREO
		};

		fixed4 _Color;
		fixed4 _TextureSampleAdd;
		float4 _ClipRect;
		fixed _BlendThreshold;

		v2f vert(appdata_t v)
		{
			v2f OUT;
			UNITY_SETUP_INSTANCE_ID(v);
			UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
			OUT.worldPosition = v.vertex;
			OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

			v.texcoord.x *= 2;

			OUT.texcoord = v.texcoord;

			OUT.color = v.color * _Color;
			return OUT;
		}

		sampler2D _MainTex;
		sampler2D _TextureToBlend;

		fixed4 frag(v2f IN) : SV_Target
		{
			half4 texture1 = tex2D(_MainTex, IN.texcoord);
		//	IN.texcoord.x -= _BlendThreshold;
			half4 texture2 = tex2D(_TextureToBlend, IN.texcoord);

			half range = _BlendThreshold * 2;
			half rangeMin = 1 - _BlendThreshold;
			//half rangeMax = 1 + _BlendThreshold;

			half blendFactor = clamp( (IN.texcoord.x - rangeMin ) / range, 0, 1 );

			//texture1.a = IN.texcoord.x;
		/*	texture1.rgb *= step( IN.texcoord.x, 1 - _BlendThreshold );
			texture2.rgb *= step(1 + _BlendThreshold, IN.texcoord.x );
			half4 color = texture1 + texture2;*/

			half4 color = ( lerp( texture1, texture2, blendFactor ) + _TextureSampleAdd )* IN.color; //(tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color;

			color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
			//color.a *= 1000;

	#ifdef UNITY_UI_ALPHACLIP
			clip(color.a - 0.001);
	#endif

			return color;
		}
		ENDCG
	}
	}
}

