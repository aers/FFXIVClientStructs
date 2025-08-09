namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

[GenerateInterop]
[Inherits<PVShader>]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct ComputeShader {
    [FieldOffset(0x60)] public void* DirectXObject;
}
