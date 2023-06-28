Shader "Custom/Sprites/AlphaInR_Scrolling_OneLayer_AlphaMask"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
		_ScrollSpeed("ScrollSpeed", Float) = 1
		///x - Layer texture offset
		///y - Layer texture scroll multiplier
		///z - y uv offset
		///w - Layer alpha multiplier
		_Layer1Anim("Layer 1 Animation params", Vector) = (1,1,1,1)

		[Space(10)]_Scale_X("Scale by X", Float) = 1
		_Cycles_X("Cycles by X", Float) = 1
		_Space_X("Space by X", Float) = 0

		[Space(10)]_Scale_Y("Scale by Y", Float) = 1
		_Cycles_Y("Cycles by Y", Float) = 1
		_Space_Y("Space by Y", Float) = 0

		[Space(10)]_Cutoff("Alpha cutoff", Range(0,1)) = 0.01

		[Toggle(USE_ALPHA_MASK_ON)] _UseAlphaMask("Use Alpha Mask", Float) = 0
		[Toggle(ALPHA_MASK_R_ON)] _AlphaMask_R("Alpha Mask R", Float) = 0
		[Toggle(ALPHA_MASK_G_ON)] _AlphaMask_G("Alpha Mask G", Float) = 0
		_AlphaMask("Alpha Mask", 2D) = "white" {}
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
		//Blend One OneMinusSrcAlpha
	
	Pass
	{
		CGPROGRAM
#pragma vertex vert
//#pragma fragment frag
#pragma target 2.0
#pragma multi_compile _ PIXELSNAP_ON
#pragma shader_feature ETC1_EXTERNAL_ALPHA
#pragma multi_compile DEBUG_ALPHA_MASK_OFF DEBUG_ALPHA_MASK_ON
#pragma multi_compile USE_ALPHA_MASK_OFF USE_ALPHA_MASK_ON
#pragma multi_compile ALPHA_MASK_R_OFF ALPHA_MASK_R_ON
#pragma multi_compile ALPHA_MASK_G_OFF ALPHA_MASK_G_ON
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
#if USE_ALPHA_MASK_ON
			float2 uv_a_mask  : TEXCOORD1;
#endif
		};

		fixed4 _Color;
#if USE_ALPHA_MASK_ON
		sampler2D _AlphaMask;
		float4 _AlphaMask_ST;
#endif

		v2f vert(appdata_t IN)
		{
			v2f OUT;
			//IN.vertex.x *= _Scale_X;
			OUT.vertex = UnityObjectToClipPos(IN.vertex);
			OUT.texcoord = IN.texcoord;
#if USE_ALPHA_MASK_ON
			OUT.uv_a_mask = TRANSFORM_TEX(IN.texcoord, _AlphaMask);
#endif
			OUT.color = IN.color * _Color;
	#ifdef PIXELSNAP_ON
			OUT.vertex = UnityPixelSnap(OUT.vertex);
	#endif
			return OUT;
		}

		sampler2D _MainTex;
		sampler2D _AlphaTex;
		fixed _ScrollSpeed;
		fixed4 _Layer1Anim;

		fixed _Scale_X;
		fixed _Space_X;
		fixed _Cycles_X;

		fixed _Scale_Y;
		fixed _Space_Y;
		fixed _Cycles_Y;
		fixed _Cutoff;

		fixed4 frag(v2f IN) : SV_Target
		{
			fixed time = _Time.x * _ScrollSpeed;

			half2 uv = IN.texcoord;
			uv.x += _Layer1Anim.x + _Layer1Anim.y * time;
			uv.y += _Layer1Anim.z;

			fixed y_uv = _Scale_Y * uv.y;
			fixed uvYCycleMax = _Cycles_Y + _Space_Y;
			uv.y = y_uv - (floor(y_uv / uvYCycleMax) * uvYCycleMax);

			fixed x_uv = _Scale_X * uv.x;
			fixed uvCycleMax = _Cycles_X + _Space_X;
			uv.x = x_uv - (floor(x_uv / uvCycleMax) * uvCycleMax);

			fixed alphaMultiplier = step(uv.x, _Cycles_X) *  step(uv.y, _Cycles_Y);

			fixed4 color = tex2D(_MainTex, uv);
#if USE_ALPHA_MASK_ON
#if ALPHA_MASK_G_ON
			fixed alphaMask = 1 - tex2D(_AlphaMask, IN.uv_a_mask).g;
#else
			fixed alphaMask = 1 -  tex2D(_AlphaMask, IN.uv_a_mask).r;
#endif
			color.a = color.r * _Layer1Anim.w * alphaMultiplier * IN.color.a * alphaMask;
			color.rgb = IN.color.rgb * color.a;
#if DEBUG_ALPHA_MASK_ON
			color = lerp( color, (1, 1, 1, 1), 1 - alphaMask);		
#endif
#else
			color.a = color.r * _Layer1Anim.w * alphaMultiplier * IN.color.a;
			color.rgb = IN.color.rgb * color.a;
#endif
			clip(color.a - _Cutoff);
			return color;
		}
		ENDCG
	}
	}

}
