using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.PostEffect;

// Client::Graphics::PostEffect::PostEffectChain
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct PostEffectChain {
    [FieldOffset(0x08)] public PostEffectPart** Parts;
    [FieldOffset(0x10)] public uint PartCount;
    [FieldOffset(0x20)] public uint CommonParameterIndex;
    [FieldOffset(0x28)] public ConstantBuffer* CommonBuffer;
    [FieldOffset(0x30)] public float Scale;
    [FieldOffset(0x34)] public uint EnabledPartMask;
}
