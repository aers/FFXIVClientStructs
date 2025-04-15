using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::OffscreenRenderingManager
// renderer responsible for UI character models - tryon, inspect, etc
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct OffscreenRenderingManager {
    [StaticAddress("48 89 98 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? E8 ?? ?? ?? ??", 10, isPointer: true)]
    public static partial OffscreenRenderingManager* Instance();

    [FieldOffset(0xC8), FixedSizeArray] internal FixedSizeArray4<Pointer<Camera>> _cameras;

    [FieldOffset(0x148)] public ShaderPackageResourceHandle* PrimitiveVSHandle;
    [FieldOffset(0x150)] public ShaderPackageResourceHandle* PrimitivePSHandle;
    [FieldOffset(0x158)] public ShaderPackage* PrimitiveVSPackage;
    [FieldOffset(0x160)] public ShaderPackage* PrimitivePSPackage;
}
