// Simplified VertexLit shader, optimized for high-poly meshes. Differences from regular VertexLit one:
// - less per-vertex work compared with Mobile-VertexLit
// - supports only DIRECTIONAL lights and ambient term, saves some vertex processing power
// - no per-material color
// - no specular
// - no emission

Shader "Custom/VertexLit/Color Cutout Dissolve (Only Directional Lights, No shadows, NoLightMaps)" 
{
	Properties
	{
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
		[PerRendererData]_Color("Color Multiplier", Color) = (1,1,1,1)
		_Cutoff("Alpha cutoff", Range(0,1)) = 0.25

		[Space(20)]_DissolveThreshold("Dissolve Threshold", Range(0.0,1.0)) = 0
		_DissolveEdge("Edge",Range(0.01,0.5)) = 0.01
		_EdgeColor("Edge Color", Color) = (1,1,1,1)
		_EdgeAroundMultiplier("Edge Color Multiplier",float) = 1
		_DissolveMask("Dissolve Mask",2D) = "white"{}
		_DissolveMaskSize("Dissolve Mask Size",float) = 1
	}

	SubShader
	{
		//Tags{ "Queue" = "AlphaTest" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout" }
		//LOD 100
        Tags { "RenderType" = "Opaque"}
		//Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		//LOD 100
		//Blend SrcAlpha OneMinusSrcAlpha

	Pass
	{

		Name "FORWARD"
		Tags{ "LightMode" = "ForwardBase" }
		CGPROGRAM
		#pragma vertex vert_surf
		#pragma fragment frag_surf
		#pragma target 2.0
		#pragma multi_compile_fwdbase
		#pragma multi_compile_fog
		#include "HLSLSupport.cginc"
		#include "UnityCG.cginc"
		#include "Lighting.cginc"
		#include "AutoLight.cginc"

		inline float3 LightingLambertVS(float3 normal, float3 lightDir)
		{
			fixed diff = max(0, dot(normal, lightDir));
			return _LightColor0.rgb * diff;
		}

		sampler2D _MainTex;
		half4 _Color;
		half _Cutoff;

		sampler2D _DissolveMask;
		fixed _DissolveThreshold;
		fixed _DissolveMaskSize;
		half4 _EdgeColor;
		fixed _DissolveEdge;
		fixed _EdgeAroundMultiplier;

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			fixed4 mainTex = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = mainTex.rgb * _Color.rgb;
			o.Alpha = mainTex.a;

			//fixed4 dissolveMask = tex2D(_DissolveMask, IN.uv_MainTex * _DissolveMaskSize);

			//fixed edge = lerp(dissolveMask.r - _DissolveEdge, dissolveMask.r + _DissolveEdge, _DissolveThreshold);
			//fixed threshold = smoothstep(_DissolveThreshold - _DissolveEdge, _DissolveThreshold + _DissolveEdge, edge);

			//fixed edgearound = pow(threshold, 1);

			////fixed3 edgeColor = ( mainTex.rgb + _EdgeColor ) * _EdgeColor * _EdgeAroundMultiplier;

			//o.Albedo =  lerp(_EdgeColor * _EdgeAroundMultiplier, mainTex.rgb * _Color.rgb, edgearound);
			////mainTex = lerp(_EdgeColor * _EdgeAroundMultiplier, mainTex, edgearound);
			//o.Alpha = threshold;// step(threshold, dissolveMask.r);
			//clip( threshold * mainTex.a - _Cutoff);


		/*	o.Albedo = mainTex.rgb * _Color.rgb;
			o.Alpha = mainTex.a;
			clip(o.Alpha - _Cutoff);*/
		}

		struct v2f_surf
		{
			float4 pos : SV_POSITION;
			float2 pack0 : TEXCOORD0;
#ifdef LIGHTMAP_OFF
			fixed3 normal : TEXCOORD1;
#endif
#ifndef LIGHTMAP_OFF
			float2 lmap : TEXCOORD2;
#endif
#ifdef LIGHTMAP_OFF
			fixed3 vlight : TEXCOORD2;
#endif
			LIGHTING_COORDS(3,4)
				UNITY_FOG_COORDS(5)
		};

		float4 _MainTex_ST;

		v2f_surf vert_surf(appdata_full v)
		{
			v2f_surf o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.pack0.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
#ifndef LIGHTMAP_OFF
			o.lmap.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
#endif
			float3 worldN = UnityObjectToWorldNormal(v.normal);
#ifdef LIGHTMAP_OFF
			o.normal = worldN;
#endif
#ifdef LIGHTMAP_OFF

			o.vlight = ShadeSH9(float4(worldN,1.0));
			o.vlight += LightingLambertVS(worldN, _WorldSpaceLightPos0.xyz);

#endif // LIGHTMAP_OFF
			TRANSFER_VERTEX_TO_FRAGMENT(o);
			UNITY_TRANSFER_FOG(o,o.pos);
			return o;
		}

		fixed4 frag_surf(v2f_surf IN) : SV_Target
		{
			Input surfIN;
			surfIN.uv_MainTex = IN.pack0.xy;
			SurfaceOutput o;
			o.Albedo = 0.0;
			o.Emission = 0.0;
			o.Specular = 0.0;
			o.Alpha = 0.0;
			o.Gloss = 0.0;
	#ifdef LIGHTMAP_OFF
			o.Normal = IN.normal;
	#else
			o.Normal = 0;
	#endif
			surf(surfIN, o);
			fixed atten = LIGHT_ATTENUATION(IN);
			fixed4 c = 0;
	#ifdef LIGHTMAP_OFF
			c.rgb = o.Albedo * IN.vlight * atten;
	#endif // LIGHTMAP_OFF

	#ifndef LIGHTMAP_OFF
			fixed3 lm = DecodeLightmap(UNITY_SAMPLE_TEX2D(unity_Lightmap, IN.lmap.xy));
	#ifdef SHADOWS_SCREEN
			c.rgb += o.Albedo * min(lm, atten * 2);
	#else
			c.rgb += o.Albedo * lm;
	#endif
			c.a = o.Alpha;
	#endif // !LIGHTMAP_OFF
			//clip(c.a - _Cutoff);
			/*UNITY_APPLY_FOG(IN.fogCoord, c);
			UNITY_OPAQUE_ALPHA(c.a);*/


			fixed4 dissolveMask = tex2D(_DissolveMask, surfIN.uv_MainTex * _DissolveMaskSize);

			fixed edge = lerp(dissolveMask.r - _DissolveEdge, dissolveMask.r + _DissolveEdge, _DissolveThreshold);
			fixed threshold = smoothstep(_DissolveThreshold - _DissolveEdge, _DissolveThreshold + _DissolveEdge, edge);

			fixed edgearound = pow(threshold, 1);
			//fixed3 edgeColor = ( mainTex.rgb + _EdgeColor ) * _EdgeColor * _EdgeAroundMultiplier;
			c.rgb =  lerp(_EdgeColor * _EdgeAroundMultiplier, c.rgb, edgearound);
			//mainTex = lerp(_EdgeColor * _EdgeAroundMultiplier, mainTex, edgearound);
			c.a = o.Alpha * threshold;// step(threshold, dissolveMask.r);
			clip(c.a - _Cutoff);
			return c;
		}

			ENDCG
		}
		}

		FallBack "Mobile/VertexLit"
}

