Shader "Custom/ColorSchemePP"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _BgColor ("Background Color", Color) = (0.0, 0.0, 0.0, 1.0)
        _FgColor ("Foreground Color", Color) = (1.0, 1.0, 1.0, 1.0)
        //_IntpFactor ("Interpolation Factor", Range(0.0, 1.0)) = 0.0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct a2f
            {
                float4 vertexOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertexCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (a2f v)
            {
                v2f o;
                o.vertexCS = UnityObjectToClipPos(v.vertexOS);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            float4 _BgColor;
            float4 _FgColor;
            //float _IntpFactor;

            float4 frag (v2f i) : SV_Target
            {
                float4 intpFactor = tex2D(_MainTex, i.uv).r;
                
                return lerp(_BgColor, _FgColor, intpFactor);
            }
            ENDCG
        }
    }
}
