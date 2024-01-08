namespace FFXIVClientStructs.FFXIV.Client.System.File;

[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe struct FileAccessPath {
    [FieldOffset(0x000)] public fixed char Buffer[260];
    [FieldOffset(0x208)] public char* LongStringPtr;

    public override string ToString() {
        if (LongStringPtr == null)
            fixed (char* p = Buffer)
                return new string(p);
        else
            return new string(LongStringPtr);
    }
}
