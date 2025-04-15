using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::ShaderManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1D0)]
public unsafe partial struct ShaderManager {
    // This is technically not an array, but we want to use it in Dalamud to show loaded Shader Packages.
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray56<Pointer<ShaderPackageResourceHandle>> _shaderPackageResourceHandles;
    [FieldOffset(0x1C8)] private ShaderCodeResourceHandle* CopyEnvLocationShaderCodeResourceHandle;
}
