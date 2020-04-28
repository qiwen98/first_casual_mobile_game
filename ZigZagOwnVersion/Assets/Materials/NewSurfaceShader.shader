Shader "RandomFlip"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" "DisableBatching" = "True" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert(appdata v)
			{
				// position of pivot in world space
				float3 pivotWorldPos = float3(unity_ObjectToWorld[0].w, unity_ObjectToWorld[1].w, unity_ObjectToWorld[2].w);

				// randomness achieved by feeding trigonometry function with large numbers
				float flipHorizontally = sin((pivotWorldPos.x + pivotWorldPos.y + pivotWorldPos.z) * 1000) > 0;
				float flipVertically = cos((pivotWorldPos.x + pivotWorldPos.y + pivotWorldPos.z) * 1000) > 0;

				// randomly flipping uvs 
				float2 uv = lerp(v.uv, float2(1.0 - v.uv.x, v.uv.y), flipVertically);
				uv = lerp(uv, float2(uv.x, 1.0 - uv.y), flipHorizontally);

				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
			// apply fog
			UNITY_APPLY_FOG(i.fogCoord, col);
			return col;
		}
		ENDCG
	}
	}
}