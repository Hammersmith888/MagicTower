Shader "Custom/TiledSprite"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
		_Scale_X("Scale by X",Float)= 1
		_Max_X("Max X",Range(0,1)) = 1
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
		fixed _Max_X;

		v2f vert(appdata_t IN)
		{
			v2f OUT;
			IN.vertex.x *= _Scale_X;
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

		fixed4 SampleSpriteTexture(float2 uv)
		{
			fixed x_uv = _Scale_X * uv.x;
			uv.x = x_uv - ( floor(x_uv / _Max_X) ) * _Max_X;
			//uv.x = x_uv - (floor(x_uv));
			fixed4 color = tex2D(_MainTex, uv);

	#if ETC1_EXTERNAL_ALPHA
			// get the color from an external texture (usecase: Alpha support for ETC1 on android)
			color.a = tex2D(_AlphaTex, uv).r;
	#endif //ETC1_EXTERNAL_ALPHA

			return color;
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
