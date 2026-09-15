using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.PostEffect;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct PostEffectPart {
    [FieldOffset(0x08)] public ShaderCodeResourceHandle* PixelShader;
    [FieldOffset(0x10)] public void* ParameterData;
    [FieldOffset(0x18)] public void* ConstantBufferBindings;
    [FieldOffset(0x20)] public void* SamplerBindings;
    [FieldOffset(0x28)] public Texture* InputTexture;
    [FieldOffset(0x38), FixedSizeArray] internal FixedSizeArray5<Pointer<Texture>> _outputTextures;
    [FieldOffset(0x8C)] public byte ParameterCount;
    [FieldOffset(0x8D)] public byte SamplerCount;
    [FieldOffset(0x8E)] public byte OutputCount;
    [FieldOffset(0x94)] public sbyte VertexShaderIndex;
    [FieldOffset(0x98)] public byte Flags;

    [VirtualFunction(3)]
    public partial bool Resolve();

    [VirtualFunction(4)]
    public partial bool IsValid();

    [VirtualFunction(5)]
    public partial void Draw();
}
