namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::ReferencedClassBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ReferencedClassBase {
    [FieldOffset(0x8)] public uint RefCount;

    [VirtualFunction(1)]
    public partial void Cleanup();

    [VirtualFunction(2)]
    public partial int IncRef();

    [VirtualFunction(3)]
    public partial int DecRef();
}
