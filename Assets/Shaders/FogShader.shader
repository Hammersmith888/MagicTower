Shader "Custom/Fog"
{
	Properties 
	{
		_Texture("Texture", 2D ) = "white" {}
		_Color ("Main Color", Color) = (1,1,1,1)

		_SpeedMultiplier("SpeedMultiplier", Float) = 1
		///x - Layer texture offset
		///y - Layer texture scroll multiplier
		///z - Layer color multiplier
		_Layer1Anim("Layer 1 Animation params", Vector) = (1,1,1,1)
		_Layer2Anim("Layer 2 Animation params", Vector) = (1,1,1,1)
		_Layer3Anim("Layer 3 Animation params", Vector) = (1,1,1,1)
		_Layer4Anim("Layer 4 Animation params", Vector) = (1,1,1,1)
		//_Layer5Anim("Layer 5 Animation params", Vector) = (1,1,1,1)
		//_Layer6Anim("Layer 6 Animation params", Vector) = (1,1,1,1)
	}

SubShader {
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

	Pass {  
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata_t
			{
				float4 vertex : POSITION;
				half2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
			};

			sampler2D _Texture;
			float4 _Texture_ST;
			fixed _SpeedMultiplier;
			fixed4 _Color;
			fixed4 _Layer1Anim;
			fixed4 _Layer2Anim;
			fixed4 _Layer3Anim;
			fixed4 _Layer4Anim;
			//fixed4 _Layer5Anim;
			//fixed4 _Layer6Anim;
			
			
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _Texture);
				return o;
			}
			
			fixed4 CalculateLayerColorAlphaBlend(fixed4 dstCol, half2 texcoord, fixed4 layerParams, float time )
			{
				half2 uv = texcoord;
				uv.x += layerParams.x + layerParams.y * time;
				fixed4 srcCol = tex2D(_Texture, uv);
				srcCol.rgb *= _Color * layerParams.z;
				srcCol.a *= layerParams.w;


				dstCol.rgb = srcCol.a * (srcCol.rgb - dstCol.rgb) + dstCol.rgb;
				dstCol.a += srcCol.a;
				//dstCol.a = max(srcCol.a, dstCol.a);
				//dstCol.a = 1 - ( ( 1 - dstCol.a ) * (1 - srcCol.a) );

				uv = texcoord;
				uv.x += -layerParams.x - layerParams.y * time;
				uv.y = -uv.y;

				srcCol = tex2D(_Texture, uv);
				srcCol.rgb *= _Color.rgb * layerParams.z;
				srcCol.a *= layerParams.w;

				dstCol.rgb = srcCol.a * (srcCol.rgb - dstCol.rgb) + dstCol.rgb;
				//dstCol.a = 1 - ( (1 - dstCol.a) * (1 - srcCol.a) );
				//dstCol.a = max(srcCol.a, dstCol.a);
				dstCol.a += srcCol.a;
				return dstCol;
			}

			fixed4 CalculateLayerColor(fixed4 dstCol, half2 texcoord, fixed4 layerParams, float time )
			{
				half2 uv = texcoord;
				uv.x += layerParams.x + layerParams.y * time;
				fixed4 srcCol = tex2D( _Texture, uv );
				srcCol.rgb *= _Color * layerParams.z;
				srcCol.a *= layerParams.w;


				dstCol.rgb = srcCol.a * (srcCol.rgb - dstCol.rgb) + dstCol.rgb;
				//dstCol.a += srcCol.a;
				dstCol.a = max( srcCol.a , dstCol.a);
				//dstCol.a = 1 - ( ( 1 - dstCol.a ) * (1 - srcCol.a) );

				uv = texcoord;
				uv.x += -layerParams.x - layerParams.y * time; 
				uv.y = -uv.y;

				srcCol = tex2D( _Texture, uv );
				srcCol.rgb *= _Color.rgb * layerParams.z;
				srcCol.a *= layerParams.w;

				dstCol.rgb = srcCol.a * ( srcCol.rgb - dstCol.rgb ) + dstCol.rgb;
				//dstCol.a = 1 - ( (1 - dstCol.a) * (1 - srcCol.a) );
				dstCol.a = max(srcCol.a, dstCol.a);
				//dstCol.a += srcCol.a;
				return dstCol;

			}

			fixed4 frag (v2f i) : COLOR
			{
				float time = _Time.x * _SpeedMultiplier;
				fixed4 dstCol = fixed4(1, 1, 1, 0);

				dstCol = CalculateLayerColorAlphaBlend( dstCol, i.texcoord, _Layer1Anim, time );
				dstCol = CalculateLayerColorAlphaBlend( dstCol, i.texcoord, _Layer2Anim, time );

				//dstCol = CalculateLayerColor(dstCol, i.texcoord, _Layer3Anim, time);

				/*dstCol = CalculateLayerColor(dstCol, i.texcoord, _Layer1Anim, time);
				dstCol = CalculateLayerColor(dstCol, i.texcoord, _Layer2Anim, time);
				dstCol = CalculateLayerColor(dstCol, i.texcoord, _Layer3Anim, time);
				dstCol = CalculateLayerColor(dstCol, i.texcoord, _Layer3Anim, time);*/


				return dstCol;
			}
		ENDCG
	}
}

}
