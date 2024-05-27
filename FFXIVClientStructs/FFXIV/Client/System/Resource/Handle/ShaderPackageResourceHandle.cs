using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
[GenerateInterop]
[Inherits<ResourceHandle>]
public unsafe partial struct ShaderPackageResourceHandle {
    [FieldOffset(0xB0)] public ShaderPackage* ShaderPackage;
}
