Shader "Custom/Sprites/WithVertexOffset"
{
	Properties
	{
        _YThreshold ("Y Threshold", Float) = 1
        _XOffset ("X Offset", Float) = 1

	    [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
	    [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
	    Blend One OneMinusSrcAlpha
        //Blend SrcAlpha One

		Pass
		{
		CGPROGRAM
		#pragma vertex vert
        #pragma fragment frag
        #pragma target 2.0
        #pragma multi_compile_instancing
        #pragma multi_compile _ PIXELSNAP_ON
        #pragma multi_compile _ ETC1_EXTERNAL_ALPHAEd
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
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
			};
			
			fixed4 _Color;
            fixed _YThreshold;
            fixed _XOffset;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
                if(IN.vertex.y > _YThreshold)
                {
                    IN.vertex.x += _XOffset;
                }
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _AlphaTex;

			fixed4 SampleSpriteTexture (float2 uv)
			{
                fixed4 srcCol = tex2D(_MainTex, uv );
#if ETC1_EXTERNAL_ALPHA
			    // get the color from an external texture (usecase: Alpha support for ETC1 on android)
			    fixed4 alpha = tex2D (_AlphaTex, uv);
                srcCol.a = lerp (srcCol.a, alpha.r, _EnableExternalAlpha);
#endif //ETC1_EXTERNAL_ALPHA
			    return srcCol;
			}

			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
                c.rgb *= c.a;
				return c;
			}
		ENDCG
		}
	}
}
