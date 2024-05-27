using Kernel = FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
[GenerateInterop]
[Inherits<ResourceHandle>]
public unsafe partial struct ShaderCodeResourceHandle {
    [FieldOffset(0xB0)] public Kernel.Shader* Shader;
}
