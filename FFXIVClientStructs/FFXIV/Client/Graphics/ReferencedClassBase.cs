namespace FFXIVClientStructs.FFXIV.Client.Graphics;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
[GenerateInterop(isInherited: true)]
public unsafe partial struct ReferencedClassBase {
    [FieldOffset(0x8)] public uint RefCount;
}
