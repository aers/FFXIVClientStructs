using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.PostEffect;

// shader/sm5/posteffect/ColorFilter_DarkBlend.shcd
[GenerateInterop]
[Inherits<PostEffectPart>]
[VirtualTable("48 89 6C 24 40 33 D2 B9 D0 00 00 00 E8 ?? ?? ?? ??", 0x81)]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct PostEffectColorFilterDarkBlend {
    [FieldOffset(0xA0), FixedSizeArray] internal FixedSizeArray3<Pointer<Texture>> _lutTextures;
    [FieldOffset(0xB8)] public uint LutIndex;
    [FieldOffset(0xBC)] public uint MatrixParameterIndex;
    [FieldOffset(0xC0)] public uint LutParameterIndex;
    [FieldOffset(0xC4)] public uint LutSamplerIndex;
    [FieldOffset(0xC8)] public uint DarkMatrixParameterIndex;
    [FieldOffset(0xCC)] public uint DarkParameterIndex;

    [MemberFunction("48 8B C4 48 89 58 ?? 55 56 41 56 48 8D 68 ?? 48 81 EC ?? ?? ?? ?? 0F 29 78")]
    public partial void UpdateLut();
}
