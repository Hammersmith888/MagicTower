﻿Shader "Custom/Sprites/Additive_Scrolling_2Layers"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0

		[Space(20)]_CameraBackground("Camera Background", Color) = (1,1,1,0)
		_ScrollSpeed("ScrollSpeed", Float) = 1
		///x - Layer texture offset
		///y - Layer texture scroll multiplier
		///z - y uv offset
		///w - Layer alpha multiplier
		_Layer1Anim("Layer 1 Animation params", Vector) = (1,1,1,1)
		_Layer2Anim("Layer 2 Animation params", Vector) = (1,1,1,1)

		[Space(10)]_Scale_X("Scale by X", Float) = 1
		_Cycles_X("Cycles by X", Float) = 1
		_Space_X("Space by X", Float) = 0

		[Space(10)]_Scale_Y("Scale by Y", Float) = 1
		_Cycles_Y("Cycles by Y", Float) = 1
		_Space_Y("Space by Y", Float) = 0

		[Space(10)]_Cutoff("Alpha cutoff", Range(0,1)) = 0.01
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
		Blend SrcAlpha One
		//Blend One OneMinusSrcAlpha
	
	Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma target 2.0
#pragma multi_compile _ PIXELSNAP_ON
#pragma shader_feature ETC1_EXTERNAL_ALPHA
#pragma multi_compile DEBUG_ALPHA_MASK_OFF DEBUG_ALPHA_MASK_ON
#include "UnityCG.cginc"

		struct appdata_t
		{
			float4 vertex   : POSITION;
			float4 color    : COLOR;
			float2 texcoord : TEXCOORD0;
		};

		struct v2f
		{
			float4 vertex   : SV_POSITION;
			fixed4 color : COLOR;
			float2 texcoord  : TEXCOORD0;
		};

		fixed4 _Color;
		v2f vert(appdata_t IN)
		{
			v2f OUT;
			//IN.vertex.x *= _Scale_X;
			OUT.vertex = UnityObjectToClipPos(IN.vertex);
			OUT.texcoord = IN.texcoord;
			OUT.color = IN.color * _Color;
	#ifdef PIXELSNAP_ON
			OUT.vertex = UnityPixelSnap(OUT.vertex);
	#endif

			return OUT;
		}

		sampler2D _MainTex;
		sampler2D _AlphaTex;
		fixed _ScrollSpeed;
		fixed4 _CameraBackground;
		fixed4 _Layer1Anim;
		fixed4 _Layer2Anim;

		fixed _Scale_X;
		fixed _Space_X;
		fixed _Cycles_X;

		fixed _Scale_Y;
		fixed _Space_Y;
		fixed _Cycles_Y;
		fixed _Cutoff;

		fixed4 CalculateLayerColorAlphaBlend( fixed4 dstCol, half2 texcoord, fixed4 layerParams, float time)
		{
			half2 uv = texcoord;
			uv.x += layerParams.x + layerParams.y * time;
			uv.y += layerParams.z;
		
			fixed y_uv = _Scale_Y * uv.y;
			fixed uvYCycleMax = _Cycles_Y + _Space_Y;
			uv.y = y_uv - (floor(y_uv / uvYCycleMax) * uvYCycleMax);

			fixed x_uv = _Scale_X * uv.x;
			fixed uvCycleMax = _Cycles_X + _Space_X;
			uv.x = x_uv - (floor(x_uv / uvCycleMax) * uvCycleMax);

			fixed alphaMultiplier = step(uv.x, _Cycles_X) *  step(uv.y, _Cycles_Y);

			fixed4 srcCol = tex2D(_MainTex, uv);
#if ETC1_EXTERNAL_ALPHA
			// get the color from an external texture (usecase: Alpha support for ETC1 on android)
			srcCol.a = tex2D(_AlphaTex, uv).r;
#endif //ETC1_EXTERNAL_ALPHA
			srcCol.a *= layerParams.w * alphaMultiplier;

			dstCol.rgb = dstCol.a * (dstCol.rgb - srcCol.rgb) + srcCol.rgb;
			//dstCol.rgb = srcCol.a * (srcCol.rgb - dstCol.rgb) + dstCol.rgb;
			dstCol.a = 1 - ((1 - dstCol.a) * (1 - srcCol.a));
			return dstCol;
		}

		fixed4 CalculateLayerColorAddBlend(fixed4 dstCol, half2 texcoord, fixed4 layerParams, float time)
		{
			half2 uv = texcoord;
			uv.x += layerParams.x + layerParams.y * time;
			uv.y += layerParams.z;

			fixed y_uv = _Scale_Y * uv.y;
			fixed uvYCycleMax = _Cycles_Y + _Space_Y;
			uv.y = y_uv - (floor(y_uv / uvYCycleMax) * uvYCycleMax);

			fixed x_uv = _Scale_X * uv.x;
			fixed uvCycleMax = _Cycles_X + _Space_X;
			uv.x = x_uv - (floor(x_uv / uvCycleMax) * uvCycleMax);

			fixed alphaMultiplier = step(uv.x, _Cycles_X) *  step(uv.y, _Cycles_Y);

			fixed4 srcCol = tex2D(_MainTex, uv);
			srcCol.a = srcCol.r;
			srcCol.a *= layerParams.w * alphaMultiplier;

			dstCol.rgb = dstCol.rgb + srcCol.rgb;
			//dstCol.rgb = srcCol.a * (srcCol.rgb - dstCol.rgb) + dstCol.rgb;
			dstCol.a = 1 - ((1 - dstCol.a) * (1 - srcCol.a));
			return dstCol;
		}

		fixed4 frag(v2f IN) : SV_Target
		{
			fixed time = _Time.x * _ScrollSpeed;
			fixed4 dstCol = _CameraBackground;
			dstCol = CalculateLayerColorAddBlend(dstCol, IN.texcoord, _Layer1Anim, time);
			dstCol = CalculateLayerColorAddBlend(dstCol, IN.texcoord, _Layer2Anim, time);

			dstCol *= IN.color;
			dstCol.rgb *= dstCol.a;
			clip(dstCol.a - _Cutoff);
			return dstCol;
		}
		ENDCG
	}
	}

}
