using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.PostEffect;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct PostEffectResources {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 4C 8B 44 D0 10 4D 85 C0 74 ?? 49 83 B8 B0 00 00 00 00 74 ?? F6 81 98 00 00 00 08 74 ?? 80 B9 8E 00 00 00 00 76 ?? 48 83 79 38 00", 3, isPointer: true)]
    public static partial PostEffectResources* Instance();

    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray16<Pointer<ShaderCodeResourceHandle>> _vertexShaders;
    [FieldOffset(0x90)] public void* VertexDeclaration;
    [FieldOffset(0x98)] public void* VertexBuffer;
    [FieldOffset(0xA8)] public ConstantBuffer* ParamBuffer;
    [FieldOffset(0xB8)] public ConstantBuffer* SamplingOffsetBuffer;
    [FieldOffset(0xC8)] public ConstantBuffer* DynamicViewportResolutionBuffer;
}
