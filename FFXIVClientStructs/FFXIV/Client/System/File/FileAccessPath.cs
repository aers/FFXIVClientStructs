namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::FileAccessPath
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe partial struct FileAccessPath {
    [FieldOffset(0x000), FixedSizeArray(isString: true)] internal FixedSizeArray260<char> _buffer;
    [FieldOffset(0x208)] public char* LongStringPtr;

    public override string ToString() {
        if (LongStringPtr == null)
            fixed (char* p = Buffer)
                return new string(p);
        else
            return new string(LongStringPtr);
    }
}
