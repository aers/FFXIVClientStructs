namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine;

[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct RefCountedString {
    [FieldOffset(0)] public int NumRefs;
    [FieldOffset(4)] public fixed byte Data[260];
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct StringTable {
    [FieldOffset(0x00)] public StdVector<Pointer<RefCountedString>> Strings;
    [FieldOffset(0x18)] public int NumNulls;
}
