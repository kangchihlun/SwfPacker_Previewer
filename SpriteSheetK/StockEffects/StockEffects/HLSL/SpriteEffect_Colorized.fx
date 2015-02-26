//// SimpleColorShifting 
//// 全體偏色


#include "Macros.fxh"


DECLARE_TEXTURE(Texture, 0);


BEGIN_CONSTANTS
MATRIX_CONSTANTS

    float4x4 MatrixTransform    _vs(c0) _cb(c0);

END_CONSTANTS
float4 ShiftedColor;

void SpriteVertexShader(inout float4 color    : COLOR0,
                        inout float2 texCoord : TEXCOORD0,
                        inout float4 position : SV_Position)
{
    position = mul(position, MatrixTransform);
}


float4 SpritePixelShader(float4 color : COLOR0,
                         float2 texCoord : TEXCOORD0) : SV_Target0
{
	float4 srcRGBA = SAMPLE_TEXTURE(Texture, texCoord) * color;
	float _r_ =(srcRGBA.r * ShiftedColor.r * ShiftedColor.a) + (srcRGBA.r * (1.0 - ShiftedColor.a));
	float _g_ =(srcRGBA.g * ShiftedColor.g * ShiftedColor.a) + (srcRGBA.g * (1.0 - ShiftedColor.a));
	float _b_ =(srcRGBA.b * ShiftedColor.b * ShiftedColor.a) + (srcRGBA.b * (1.0 - ShiftedColor.a));
	float4 finalRGBA = float4(_r_,_g_,_b_,srcRGBA.a);
    return finalRGBA;
}


technique SpriteBatch
{
    pass
    {
        VertexShader = compile vs_2_0 SpriteVertexShader();
        PixelShader  = compile ps_2_0 SpritePixelShader();
    }
}
