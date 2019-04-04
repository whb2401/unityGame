Shader "ThermalDisturbance"
{
    Properties
    {
		_DistortStrength("DistortStrength", Range(0,1)) = 0.2
		_DistortTimeFactor("DistortTimeFactor", Range(0,1)) = 1		
		_NoiseTex("NoiseTexture", 2D) = "white" {}
    }
    SubShader
    {
        Tags {"RenderType" = "Transparent"	"Queue" = "Transparent"}
		ZWrite Off
		Cull Off
		GrabPass
		{
			"_GrabTempTex"
		}
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float4 grabPos : TEXCOORD1;
            };

            sampler2D _NoiseTex;
            float4 _NoiseTex_ST;
			uniform float _DistortTimeFactor;
			uniform float _DistortStrength;

			sampler2D _GrabTempTex;
			float4 _GrabTempTex_ST;

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				o.grabPos = ComputeGrabScreenPos(o.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _NoiseTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				float4 offset = tex2D(_NoiseTex, i.uv - _Time.xy * _DistortTimeFactor);
				i.grabPos.xy -= offset.xy * _DistortStrength;

                fixed4 col = tex2D(_GrabTempTex, i.grabPos.xy/ i.grabPos.w);
                return col;
            }
            ENDCG
        }
    }
}
