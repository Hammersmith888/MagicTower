Shader "Custom/Sprites/Lava"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
	    [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0

		_Scale_X("Scale by X", Float )= 1
		_ScrollSpeed("ScrollSpeed", Float) = 1
		///x - Layer texture offset
		///y - Layer texture scroll multiplier
		///z - y uv offset
		///w - Layer alpha multiplier
		_Layer1Anim("Layer 1 Animation params", Vector) = (1,1,1,1)
			
		[Space(20)]_DistortTex("Distortion Texture", 2D) = "white" {}
		_DistortFactor("Distortion Factor", Range(0,1)) = 0
		_DistortScrollX("Distortion Scroll X",float) = 0
		_DistortScrollY("Distortion Scroll Y",float) = 0

		[Space(20)]_AlphaMask("Alpha Mask", 2D) = "white" {}
		_Cutoff("Alpha cutoff", Range(0,1)) = 0.01
			
		[Header(Debug)][Toggle(DEBUG_ALPHA_MASK_ON)] _DebugAlphaMask("Debug Alpha Mask", Float) = 0
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

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

	Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma target 2.0
#pragma multi_compile_instancing
#pragma multi_compile _ PIXELSNAP_ON
#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
#pragma multi_compile DEBUG_ALPHA_MASK_OFF DEBUG_ALPHA_MASK_ON
#include "UnityCG.cginc"

		struct appdata_t
		{
			float4 vertex   : POSITION;
			fixed4 color    : COLOR;
			float2 texcoord : TEXCOORD0;
		};

		struct v2f
		{
			float4 vertex   : SV_POSITION;
			fixed4 color : COLOR;
			float2 texcoord  : TEXCOORD0;
			float2 uv_distort  : TEXCOORD1;
			float2 uv_a_mask  : TEXCOORD2;
		};

		fixed4 _Color;
		fixed _Scale_X;
		
		sampler2D _DistortTex;
		sampler2D _AlphaMask;
		float4 _DistortTex_ST;
		float4 _AlphaMask_ST;

		v2f vert(appdata_t IN)
		{
			v2f OUT;
			IN.vertex.x *= _Scale_X;
			OUT.vertex = UnityObjectToClipPos(IN.vertex);
			OUT.texcoord = IN.texcoord;
			OUT.uv_distort = TRANSFORM_TEX(IN.texcoord, _DistortTex);
			OUT.uv_a_mask = TRANSFORM_TEX(IN.texcoord, _AlphaMask);
			OUT.color = IN.color * _Color;
	#ifdef PIXELSNAP_ON
			OUT.vertex = UnityPixelSnap(OUT.vertex);
	#endif
			return OUT;
		}

        float _EnableExternalAlpha;
		sampler2D _MainTex;
		sampler2D _AlphaTex;

		fixed _ScrollSpeed;
		fixed4 _Layer1Anim;
		fixed _DistortFactor;
		fixed _DistortScrollX;
		fixed _DistortScrollY;
		fixed _Cutoff;

		fixed4 CalculateLayerColorAlphaBlend( half2 texcoord, half2 distortion, fixed4 layerParams, float time)
		{
			half2 uv = texcoord + distortion;
			uv.x += layerParams.x + layerParams.y * time;
			uv.y += layerParams.z;
			fixed x_uv = _Scale_X * uv.x;
			uv.x = x_uv - (floor(x_uv / 1));


			fixed4 srcCol = tex2D(_MainTex, uv );
			//srcCol.rgb *= _Color * layerParams.z;
#if ETC1_EXTERNAL_ALPHA
			// get the color from an external texture (usecase: Alpha support for ETC1 on android)
			fixed4 alpha = tex2D (_AlphaTex, uv);
            srcCol.a = lerp (srcCol.a, alpha.r, _EnableExternalAlpha);
#endif //ETC1_EXTERNAL_ALPHA
			srcCol.a *= layerParams.w;
			srcCol.rgb *= srcCol.a;

			//dstCol.rgb = dstCol.a * (dstCol.rgb - srcCol.rgb) + srcCol.rgb;
			//dstCol.rgb = srcCol.a * (srcCol.rgb - dstCol.rgb) + dstCol.rgb;
			//dstCol.a = 1 - ((1 - dstCol.a) * (1 - srcCol.a));
			return srcCol;
		}


		fixed4 frag(v2f IN) : SV_Target
		{
			fixed time = _Time.x * _ScrollSpeed;

			half2 distortUV = IN.uv_distort;
			distortUV.x += _DistortScrollX *_Time.x;
			distortUV.y += _DistortScrollY *_Time.x;
			half2 distortion = UnpackNormal( tex2D( _DistortTex, distortUV ) ) * _DistortFactor;

			fixed4 dstCol = CalculateLayerColorAlphaBlend( IN.texcoord, distortion, _Layer1Anim, time);
			fixed alphaMask = 1 - tex2D(_AlphaMask, IN.uv_a_mask).r;
			dstCol *= alphaMask;

#if DEBUG_ALPHA_MASK_ON
			dstCol = lerp( dstCol, (1, 1, 1, 1), 1 - alphaMask );
#endif
			clip(dstCol.a - _Cutoff);
			return dstCol;
		}
		ENDCG
	}
	}

}
