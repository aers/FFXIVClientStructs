namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct ShaderSceneKey {
    internal const int Size = 0x10;

    [FieldOffset(0)] public void* Vtbl;

    [FieldOffset(0x8)] public uint KeyCRC;
    [FieldOffset(0xC)] public uint ValueCRC;
}
