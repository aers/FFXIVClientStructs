namespace FFXIVClientStructs.FFXIV.Client.Graphics;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct ReferencedClassBase
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x8)] public uint RefCount;
}