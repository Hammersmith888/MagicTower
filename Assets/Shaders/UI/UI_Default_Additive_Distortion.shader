Shader "UI/Default_AlphaInR_Distortion"
{
	Properties
	{
		_DistortTex("Distortion Texture", 2D) = "white" {}
		_DistortMask("Distortion Mask", 2D) = "white" {}
		_DistortFactor("Distortion Factor", Range(0,1)) = 0
		_DistortScrollX("Distortion Scroll X",float) = 0
		_DistortScrollY("Distortion Scroll Y",float) = 0
		_Cutoff("Alpha cutoff", Range(0,1)) = 0.01

		[Space(10)][PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)

		_StencilComp("Stencil Comparison", Float) = 8
		_Stencil("Stencil ID", Float) = 0
		_StencilOp("Stencil Operation", Float) = 0
		_StencilWriteMask("Stencil Write Mask", Float) = 255
		_StencilReadMask("Stencil Read Mask", Float) = 255

		_ColorMask("Color Mask", Float) = 15
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "TransparentCutout"
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
		float2 uv_distort  : TEXCOORD2;
		UNITY_VERTEX_OUTPUT_STEREO
	};

	fixed4 _Color;
	fixed4 _TextureSampleAdd;
	float4 _ClipRect;
	sampler2D _DistortTex;
	float4 _DistortTex_ST;

	v2f vert(appdata_t v)
	{
		v2f OUT;
		UNITY_SETUP_INSTANCE_ID(v);
		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
		OUT.worldPosition = v.vertex;
		OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);
		OUT.uv_distort = TRANSFORM_TEX(v.texcoord, _DistortTex);
		OUT.texcoord = v.texcoord;

		OUT.color = v.color * _Color;
		return OUT;
	}

	sampler2D _MainTex;
	sampler2D _DistortMask;
	fixed _DistortFactor;
	fixed _DistortScrollX;
	fixed _DistortScrollY;
	fixed _Cutoff;

	fixed4 frag(v2f IN) : SV_Target
	{
		half4 color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd);

		half2 distortUV = IN.uv_distort;
		distortUV.x += _DistortScrollX *_Time.x;
		distortUV.y += _DistortScrollY *_Time.x;
		half2 distortion = UnpackNormal(tex2D(_DistortTex, distortUV)) * _DistortFactor;

		half2 uv = IN.texcoord;
		fixed distortionMask = tex2D(_DistortMask, uv).r;

		fixed4 distortCol = (tex2D(_MainTex, uv + distortion) + _TextureSampleAdd);

		color = lerp(color, distortCol, distortionMask);
		//color = distortCol;
		
		color.a *= color.r;
		color.rgb += 1.0 - color.a;
		color = IN.color * color;

		color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
		clip(color.a - _Cutoff);
		return color;
	}
		ENDCG
	}
	}
}

