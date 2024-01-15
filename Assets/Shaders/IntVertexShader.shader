Shader "Custom/IntVertexShader"
{
    Properties
    {
		[NoScaleOffset] _MainTex("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
		_EmissionMap("Emission Map", 2D) = "white" {}
		[HDR]_EmissionColor("Emission Color", Color) = (0,0,0)
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
		_GeoRes("Geometric Resolution", Float) = 40
    }
			SubShader
		{
			Pass
			{
				Tags {"LightMode" = "ForwardBase"}
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"
				#include "Lighting.cginc"

			// compile shader into multiple variants, with and without shadows
			// (we don't care about any lightmaps yet, so skip these variants)
			#pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight
			// shadow helper functions and macros
			#include "AutoLight.cginc"

			float _GeoRes;

			struct v2f
			{
				float2 uv : TEXCOORD0;
				SHADOW_COORDS(1) // put shadows data into TEXCOORD1
				fixed3 diff : COLOR0;
				fixed3 ambient : COLOR1;
				float4 pos : SV_POSITION;
			};
			v2f vert(appdata_base v)
			{
				v2f o;
				//o.pos = UnityObjectToClipPos(int4( v.vertex));
				

				//float4 wp = mul(UNITY_MATRIX_MV, v.vertex);
				float4 wp = UnityObjectToClipPos(v.vertex);
				wp.xyz = floor(wp.xyz * _GeoRes) / _GeoRes;
				o.pos = wp;

				o.uv = v.texcoord;
				half3 worldNormal = UnityObjectToWorldNormal(v.normal);
				half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
				o.diff = nl * _LightColor0.rgb;
				o.ambient = ShadeSH9(half4(worldNormal,1));
				// compute shadows data
				TRANSFER_SHADOW(o)
				return o;
			}

			sampler2D _MainTex;
			sampler2D _EmissionMap;
			float4 _EmissionColor;

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
			half4 emission = tex2D(_EmissionMap, i.uv) * _EmissionColor;
			col.rgb += emission;
			// compute shadow attenuation (1.0 = fully lit, 0.0 = fully shadowed)
			fixed shadow = SHADOW_ATTENUATION(i);
			// darken light's illumination with shadow, keep ambient intact
			fixed3 lighting = i.diff * shadow + i.ambient;
			
			col.rgb *= lighting;
			
			return col;
		}
		ENDCG
	}

			// shadow casting support
			UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
		}
}
