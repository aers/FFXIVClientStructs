using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

[GenerateInterop]
[Inherits<ResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct ShaderPackageResourceHandle {
    [FieldOffset(0xB0)] public ShaderPackage* ShaderPackage;
}
