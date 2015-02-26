//// SimpleColorShifting 
//// 全體偏色

float4 ShiftedColor;

texture2D ColorMap;
sampler2D ColorMapSampler = sampler_state
{
    Texture = <ColorMap>;
};

struct PixelShaderInput
{
    float2 TexCoord : TEXCOORD0;
};

float4 PixelShaderFunction(PixelShaderInput input) : COLOR0
{
	//當前顏色
    float4 srcRGBA = tex2D(ColorMapSampler, input.TexCoord);
	float _r_ =(srcRGBA.r * ShiftedColor.r * ShiftedColor.a) + (srcRGBA.r * (1.0 - ShiftedColor.a));
	float _g_ =(srcRGBA.g * ShiftedColor.g * ShiftedColor.a) + (srcRGBA.g * (1.0 - ShiftedColor.a));
	float _b_ =(srcRGBA.b * ShiftedColor.b * ShiftedColor.a) + (srcRGBA.b * (1.0 - ShiftedColor.a));
	float4 finalRGBA = float4(_r_,_g_,_b_,srcRGBA.a);
    //float fmax = max(srcRGBA.r, max(srcRGBA.g, srcRGBA.b));
    //float fmin = min(srcRGBA.r, min(srcRGBA.g, srcRGBA.b));
    //float delta = fmax - fmin;

    //float4 originalDestColor = float4(1, 0, 0, 1);
    //float4 deltaDestColor = originalDestColor - ShiftedColor;

    //float4 finalRGBA = srcRGBA - (deltaDestColor * delta);

    //return finalRGBA;
	return finalRGBA;
}

technique Technique1
{
    pass ColorTransform
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}