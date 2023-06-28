Shader "Custom/Sprites/Distortion"
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

			
		[Space(20)]_DistortTex("Distortion Texture", 2D) = "white" {}
		_DistortMask("Distortion Mask", 2D) = "white" {}
		_DistortFactor("Distortion Factor", Range(0,1)) = 0
		_DistortScrollX("Distortion Scroll X",float) = 0
		_DistortScrollY("Distortion Scroll Y",float) = 0
		_Cutoff("Alpha cutoff", Range(0,1)) = 0.01
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
		};

		fixed4 _Color;
		
		sampler2D _DistortTex;
		float4 _DistortTex_ST;

		v2f vert(appdata_t IN)
		{
			v2f OUT;
			OUT.vertex = UnityObjectToClipPos(IN.vertex);
			OUT.texcoord = IN.texcoord;
			OUT.uv_distort = TRANSFORM_TEX(IN.texcoord, _DistortTex);
			OUT.color = IN.color * _Color;
	#ifdef PIXELSNAP_ON
			OUT.vertex = UnityPixelSnap(OUT.vertex);
	#endif
			return OUT;
		}

		sampler2D _MainTex;
		sampler2D _AlphaTex;
        float _EnableExternalAlpha;
		sampler2D _DistortMask;

		fixed _DistortFactor;
		fixed _DistortScrollX;
		fixed _DistortScrollY;
		fixed _Cutoff;

		fixed4 frag(v2f IN) : SV_Target
		{
			half2 distortUV = IN.uv_distort;
			distortUV.x += _DistortScrollX *_Time.x;
			distortUV.y += _DistortScrollY *_Time.x;
			half2 distortion = UnpackNormal( tex2D( _DistortTex, distortUV ) ) * _DistortFactor;

			half2 uv = IN.texcoord;
			fixed distortionMask = tex2D(_DistortMask, uv).r;

			fixed4 srcCol = tex2D(_MainTex, uv);
			fixed4 distortCol = tex2D( _MainTex, uv + distortion );
			srcCol = lerp(srcCol, distortCol, distortionMask );
			//srcCol.rgb *= _Color * layerParams.z;
#if ETC1_EXTERNAL_ALPHA
			// get the color from an external texture (usecase: Alpha support for ETC1 on android)
			fixed4 alpha = tex2D (_AlphaTex, uv);
            srcCol.a = lerp (srcCol.a, alpha.r, _EnableExternalAlpha);
            //fixed4 alpha = tex2D (_AlphaTex, uv);
            //srcCol.a = lerp (srcCol.a, alpha.r, _EnableExternalAlpha);
#endif
            srcCol.rgb *= srcCol.a;
//#endif //ETC1_EXTERNAL_ALPHA
		

			clip(srcCol.a - _Cutoff);
			return srcCol;
		}
		ENDCG
	}
	}

}
