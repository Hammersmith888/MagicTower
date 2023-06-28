Shader "Custom/Sprites/SpritesScrolling_With_Space"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
		[Space(20)]_CameraBackground("Camera Background", Color) = (1,1,1,0)
		
		_ScrollSpeed("ScrollSpeed", Float) = 1
		
		[Space(10)]_Scale_X("Scale by X", Float ) = 1
		_Cycles_X("Cycles by X", Float) = 1
		_Space_X("Space by X", Float) = 0

		[Space(10)]_Scale_Y("Scale by Y", Float) = 1
		_Cycles_Y("Cycles by Y", Float) = 1
		_Space_Y("Space by Y", Float) = 0


		///x - Layer texture offset
		///y - Layer texture scroll multiplier
		///z - y uv offset
		///w - Layer alpha multiplier
		_Layer1Anim("Layer 1 Animation params", Vector) = (1,1,1,1)
		_Layer2Anim("Layer 2 Animation params", Vector) = (1,1,1,1)
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
#pragma multi_compile _ PIXELSNAP_ON
#pragma shader_feature ETC1_EXTERNAL_ALPHA
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
		fixed _Scale_X;

		v2f vert(appdata_t IN)
		{
			v2f OUT;
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
		fixed4 _CameraBackground;
		fixed _ScrollSpeed;
		fixed _Space_X;
		fixed _Cycles_X;

		fixed _Scale_Y;
		fixed _Space_Y;
		fixed _Cycles_Y;

		fixed4 _Layer1Anim;
		fixed4 _Layer2Anim;
		

		fixed4 CalculateLayerColorAlphaBlend(fixed4 dstCol, half2 texcoord, fixed4 layerParams, float time)
		{
			half2 uv = texcoord;
			uv.x += layerParams.x + layerParams.y * time;
			uv.y += layerParams.z;

			//uv.y *= _Scale_Y;

			fixed y_uv = _Scale_Y * uv.y;
			fixed uvYCycleMax = _Cycles_Y + _Space_Y;
			uv.y = y_uv - (floor(y_uv / 1) * 1);

			fixed x_uv = _Scale_X * uv.x;
			fixed uvCycleMax = _Cycles_X + _Space_X;
			uv.x = x_uv - ( floor( x_uv / uvCycleMax ) * uvCycleMax);

			fixed alphaMultiplier = step(uv.x, _Cycles_X) *  step(uv.y, _Cycles_Y);

			fixed4 srcCol = tex2D(_MainTex, uv);
			//srcCol.rgb *= _Color * layerParams.z;
#if ETC1_EXTERNAL_ALPHA
			// get the color from an external texture (usecase: Alpha support for ETC1 on android)
			srcCol.a = tex2D(_AlphaTex, uv).r;
#endif //ETC1_EXTERNAL_ALPHA
			srcCol.a *= layerParams.w * alphaMultiplier;

			//dstCol.rgb *= dstCol.a;
			//srcCol.rgb *= srcCol.a;

			dstCol.rgb = dstCol.a * (dstCol.rgb - srcCol.rgb) + srcCol.rgb;
			//dstCol.rgb = srcCol.a * (srcCol.rgb - dstCol.rgb) + dstCol.rgb;
			dstCol.a = 1 - ((1 - dstCol.a) * (1 - srcCol.a));
			return dstCol;
		}

		fixed4 CalculateLayerColor( half2 texcoord, fixed4 layerParams, float time)
		{
			half2 uv = texcoord;
			uv.x += layerParams.x + layerParams.y * time;
			uv.y += layerParams.z;

			fixed y_uv = _Scale_Y * uv.y;
			fixed uvYCycleMax = _Cycles_Y + _Space_Y;
			uv.y = y_uv - (floor(y_uv / 1) * 1);

			fixed x_uv = _Scale_X * uv.x;
			fixed uvXCycleMax = _Cycles_X + _Space_X;
			uv.x = x_uv - (floor(x_uv / uvXCycleMax) * uvXCycleMax);

			fixed alphaMultiplier = step(uv.x, _Cycles_X) *  step(uv.y, _Cycles_Y);

			fixed4 srcCol = tex2D(_MainTex, uv);
			srcCol.a *= layerParams.w * alphaMultiplier;
			//srcCol.rgb *= srcCol.a;
			return srcCol;
		}

		fixed4 SampleSpriteTexture(float2 uv)
		{
			fixed time = _Time.x * _ScrollSpeed;
			fixed4 dstCol = _CameraBackground;


			//dstCol = CalculateLayerColor( uv, _Layer1Anim, time );
			dstCol = CalculateLayerColorAlphaBlend(dstCol, uv, _Layer1Anim, time);
			dstCol = CalculateLayerColorAlphaBlend(dstCol, uv, _Layer2Anim, time);
			return dstCol;
		}

		fixed4 frag(v2f IN) : SV_Target
		{
			fixed4 c = SampleSpriteTexture(IN.texcoord) * IN.color;
			c.rgb *= c.a;
			return c;
		}
		ENDCG
	}
	}

}
