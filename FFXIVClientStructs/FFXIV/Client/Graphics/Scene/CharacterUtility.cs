using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::CharacterUtility
//   Client::Graphics::Singleton
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x590)]
public unsafe partial struct CharacterUtility {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 83 B9", 3, isPointer: true)]
    public static partial CharacterUtility* Instance();

    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray114<Pointer<ResourceHandle>> _resourceHandles;

    [FieldOffset(0x3F0)] public ConstantBuffer* LegacyBodyDecalColorCBuffer;
    [FieldOffset(0x3F8)] public ConstantBuffer* FreeCompanyCrestColorCBuffer;

    public ConstantBufferPointer<Vector4> LegacyBodyDecalColorTypedCBuffer => new(LegacyBodyDecalColorCBuffer);
    public ConstantBufferPointer<Vector4> FreeCompanyCrestColorTypedCBuffer => new(FreeCompanyCrestColorCBuffer);
}
