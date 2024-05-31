namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct RefCountedString {
    [FieldOffset(0)] public int NumRefs;
    [FieldOffset(4), FixedSizeArray(isString: true)] internal FixedSizeArray260<byte> _data;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct StringTable {
    [FieldOffset(0x00)] public StdVector<Pointer<RefCountedString>> Strings;
    [FieldOffset(0x18)] public int NumNulls;
}
