namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::ShaderSceneKey
// Client::Graphics::Kernel::ShaderSubViewKey
// These two classes are nominally different, but structurally identical.
[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct ShaderKey {
    internal const int Size = 0x10;

    [FieldOffset(0)] public void* Vtbl;

    [FieldOffset(0x8)] public uint KeyCRC;
    [FieldOffset(0xC)] public uint ValueCRC;
}
