using Kernel = FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct ShaderCodeResourceHandle {
    [FieldOffset(0x0)] public ResourceHandle ResourceHandle;
    [FieldOffset(0xB0)] public Kernel.Shader* Shader;
}
