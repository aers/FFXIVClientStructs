namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct Shader {
    [FieldOffset(0)] public void* Vtbl;

    // byte at 0x08 has been observed to always be 1
}
