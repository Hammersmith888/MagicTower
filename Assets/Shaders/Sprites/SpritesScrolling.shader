Shader "Custom/Sprites/SpritesScrolling"
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

		[Space(20)]_CameraBackground("Camera Background", Color) = (1,1,1,0)
		_Scale_X("Scale by X", Float )= 1
		_ScrollSpeed("ScrollSpeed", Float) = 1
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
		//Blend One SrcAlpha

	Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma target 2.0
#pragma multi_compile_instancing
#pragma multi_compile _ PIXELSNAP_ON
#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
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
            UNITY_SETUP_INSTANCE_ID (IN);
            UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
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
		fixed4 _CameraBackground;
		fixed _ScrollSpeed;
		fixed4 _Layer1Anim;
		fixed4 _Layer2Anim;
        float _EnableExternalAlpha;

		fixed4 CalculateLayerColorAlphaBlend(fixed4 dstCol, half2 texcoord, fixed4 layerParams, float time)
		{
			half2 uv = texcoord;
			uv.x += layerParams.x + layerParams.y * time;
			uv.y += layerParams.z;
			fixed x_uv = _Scale_X * uv.x;
			uv.x = x_uv - ( floor ( x_uv / 1 ) );

			fixed4 srcCol = tex2D( _MainTex, uv );
			//srcCol.rgb *= _Color * layerParams.z;
#if ETC1_EXTERNAL_ALPHA
			// get the color from an external texture (usecase: Alpha support for ETC1 on android)
			fixed4 alpha = tex2D (_AlphaTex, uv);
            srcCol.a = lerp (srcCol.a, alpha.r, _EnableExternalAlpha);
#endif //ETC1_EXTERNAL_ALPHA
			srcCol.a *= layerParams.w;

			//dstCol.rgb = dstCol.a * (dstCol.rgb - srcCol.rgb) + srcCol.rgb;
			dstCol.rgb = srcCol.a * (srcCol.rgb - dstCol.rgb) + dstCol.rgb;
			//dstCol.rgb = ( srcCol.a * srcCol.rgb ) + ( ( 1 - srcCol.a ) * dstCol.rgb );
			
			//fixed3 blendedRGB = (srcCol.a * srcCol.rgb) + lerp( (1 - srcCol.a) * srcCol.rgb, ((1 - srcCol.a) * dstCol.rgb), dstCol.a);
			//dstCol.rgb = blendedRGB;/*+ ( (1 - srcCol.a) * ( dstCol.rgb ) )*/;
						
			dstCol.a = 1 - ((1 - dstCol.a) * (1 - srcCol.a));
			//dstCol.rgb += srcCol.rgb;
			
			return dstCol;
		}
		//output = (source alpha * source fragment) + ((1 – source alpha) * destination fragment). destination is ColorBuffer

		fixed4 SampleSpriteTexture(float2 uv)
		{
			fixed time = _Time.x * _ScrollSpeed;
			fixed4 dstCol = _CameraBackground;

			//half2 uv2 = uv;
			//uv2.x += _Layer1Anim.x + _Layer1Anim.y * time;
			//uv2.y += _Layer1Anim.z;
			//fixed x_uv = _Scale_X * uv2.x;
			//uv2.x = x_uv - (floor(x_uv / 1));

			//fixed4 dstCol = tex2D(_MainTex, uv2);
			////srcCol.rgb *= _Color * layerParams.z;
			//dstCol.a *= _Layer1Anim.w;
			//dstCol.rgb *= dstCol.a;
			//dstCol.rgb = lerp((1, 1, 1), dstCol.rgb, dstCol.a);

			dstCol = CalculateLayerColorAlphaBlend(dstCol, uv, _Layer1Anim, time);
			dstCol = CalculateLayerColorAlphaBlend(dstCol, uv, _Layer2Anim, time);

			//dstCol = lerp((1, 1, 1, 0), dstCol, dstCol.a);
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
