Shader "MurabitoB/LED_Wall"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _MaskTex("MaskTexture",2D) = "white"{}
        _InnerCircleRange("InnerCircleRange",Range (0, 0.7072)) = 0.5
        _OutterCircleRange("OutterCircleRange",Range(0,0.7072)) = 0.6 //maxDistance half of the square 2 , close to 0.707
        _BackGroundColor("BackGroundColor",Color) = (0,0,0,0)
        _OutterCircleBlendColor("OutterCircleBlendColor",Color) = (0.5,0.5,0.5,0.5)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile __ USE_MASK
            #pragma multi_compile __ USE_LUMINANCEDOTSIZE
            #pragma multi_compile __ USE_CLIPBACKGROUND
            #pragma multi_compile __ USE_FLOW
            #pragma multi_compile __ USE_SINGLECOLOR
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
  
            sampler2D _MainTex;
            #ifdef USE_MASK
                sampler2D _MaskTex;
            #endif
            #ifdef USE_CLIPBACKGROUND 
                fixed _ClipThreshold;
            #endif
            #ifdef USE_LUMINANCEDOTSIZE
                float _LuminanceMultiply;
            #endif
            #ifdef USE_FLOW
                fixed _Speedx;
                fixed _Speedy;
            #endif
            #ifdef USE_SINGLECOLOR
                fixed4 _SingleColor;
            #endif 
            float4 _MainTex_ST;
            half4 _MainTex_TexelSize;
            float _InnerCircleRange;
            float _OutterCircleRange;
            fixed4 _BackGroundColor;
            fixed4 _OutterCircleBlendColor;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            #ifdef USE_MASK
                fixed4 getColor(float2 uv)
                {
                    fixed4(1,1,1,1);
                    // sample the texture
                    fixed4 col = tex2D(_MainTex, uv);
                    #ifdef USE_FLOW
                        float2 fragPos = float2((uv.x + _Time.y * _Speedx) /_MainTex_TexelSize.x,(uv.y + _Time.y * _Speedy) / _MainTex_TexelSize.y);
                    #else
                        float2 fragPos = float2(uv.x /_MainTex_TexelSize.x,uv.y / _MainTex_TexelSize.y);
                    #endif
                    fragPos = float2(frac(fragPos.x),frac(fragPos.y));
                    #ifdef USE_LUMINANCEDOTSIZE
                        float luminance = Luminance(col) * _LuminanceMultiply;
                        fragPos = (fragPos -float2(0.5,0.5)) / luminance + float2(0.5,0.5);
                    #endif
                    fixed4 maskCol = tex2D(_MaskTex,fragPos);
                    col = maskCol * col;
                    return col;
                }
            #else
                fixed4 getColor(float2 uv)
                {
                    // sample the texture
                    fixed4 col = tex2D(_MainTex, uv);
                   #ifdef USE_FLOW
                        float2 fragPos = float2((uv.x + _Time.y * _Speedx) /_MainTex_TexelSize.x,(uv.y + _Time.y * _Speedy) / _MainTex_TexelSize.y);
                    #else
                        float2 fragPos = float2(uv.x /_MainTex_TexelSize.x,uv.y / _MainTex_TexelSize.y);
                    #endif
                    
                    fragPos = float2(frac(fragPos.x),frac(fragPos.y));
                    float fragDistance = 1;
                    fragDistance = distance(fragPos,float2(0.5,0.5)); //cal the distance from the circle center
                    #ifdef USE_LUMINANCEDOTSIZE
                        float luminance = Luminance(col) * _LuminanceMultiply;
                        if(fragDistance < (_InnerCircleRange * luminance))
                            return col;
                        else if(fragDistance > (_OutterCircleRange) * luminance)
                            return  _BackGroundColor;
                        col = _OutterCircleBlendColor * col;
                    #else
                        if(fragDistance < (_InnerCircleRange))
                            return col;
                        else if(fragDistance > (_OutterCircleRange))
                            return  fixed4(_BackGroundColor.rgb,0);
                        col = _OutterCircleBlendColor * col;
                    #endif
                    return col;
                }
            #endif
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = getColor(i.uv);
                #ifdef USE_SINGLECOLOR
                    col = Luminance(col) * _SingleColor;
                #endif
                #ifdef USE_CLIPBACKGROUND
                    clip(col.a - _ClipThreshold);
                #endif
                return col;
            }
            ENDCG
        }
    }
}
