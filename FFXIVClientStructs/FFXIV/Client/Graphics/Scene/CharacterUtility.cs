using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[StructLayout(LayoutKind.Explicit, Size = 0x410)]
public unsafe partial struct CharacterUtility {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 83 B9", 3, true)]
    public static partial CharacterUtility* Instance();

    public const int ResourceHandleCount = 87;

    [FieldOffset(0x0)] public void* vtbl;

    [FixedSizeArray<Pointer<ResourceHandle>>(ResourceHandleCount)]
    [FieldOffset(0x8)] public fixed byte ResourceHandles[ResourceHandleCount * 8];

    [FieldOffset(0x2F8)] public ConstantBuffer* LegacyBodyDecalColorCBuffer;
    [FieldOffset(0x300)] public ConstantBuffer* FreeCompanyCrestColorCBuffer;

    public readonly ConstantBufferPointer<Vector4> LegacyBodyDecalColorTypedCBuffer => new(LegacyBodyDecalColorCBuffer);
    public readonly ConstantBufferPointer<Vector4> FreeCompanyCrestColorTypedCBuffer => new(FreeCompanyCrestColorCBuffer);
}
