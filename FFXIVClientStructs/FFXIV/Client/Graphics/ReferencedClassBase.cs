namespace FFXIVClientStructs.FFXIV.Client.Graphics;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ReferencedClassBase {
    [FieldOffset(0x8)] public uint RefCount;
}
