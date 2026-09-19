using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.PostEffect;

// shader/sm5/posteffect/DepthOfFieldCocLut_Update.shcd
[GenerateInterop]
[Inherits<PostEffectPart>]
[VirtualTable("48 89 6C 24 40 33 D2 B9 F8 00 00 00 E8 ?? ?? ?? ??", 0x84)]
[StructLayout(LayoutKind.Explicit, Size = 0xF8)]
public unsafe partial struct PostEffectDepthOfFieldCocLut {
    [FieldOffset(0xA0)] public uint WeightParameterIndex;
    [FieldOffset(0xA4)] public uint CocParameterIndex;
    [FieldOffset(0xA8)] public uint LutSamplerIndex;
    [FieldOffset(0xB0)] public ConstantBuffer* CocParameterBuffer;
    [FieldOffset(0xB8)] public ConstantBuffer* DisabledCocParameterBuffer;

    [FieldOffset(0xC0)] public float NearFocusDistance;
    [FieldOffset(0xC4)] public float NearPlane;
    [FieldOffset(0xC8)] public float FarFocusDistance;
    [FieldOffset(0xCC)] public float FarBlurDistance;
    [FieldOffset(0xD0)] public float NearBlurRate;
    [FieldOffset(0xD4)] public float FarBlurRate;
    [FieldOffset(0xD8)] public float EffectMaskRate;
    [FieldOffset(0xDC)] public float FocalLength;
    [FieldOffset(0xE0)] public float FocusDistance;
    [FieldOffset(0xE4)] public float FNumber;
    [FieldOffset(0xEC)] public float PreviousFrameWeight;
    [FieldOffset(0xF0)] public float PreviousRangeScale;

    [FieldOffset(0xF4)] public bool ResetHistory;
    [FieldOffset(0xF5)] public bool UseManualDepthOfField;
    [FieldOffset(0xF6)] public bool DisableCoc;
}
