namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::FileAccessPath
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe partial struct FileAccessPath {
    [FieldOffset(0x000), FixedSizeArray(isString: true)] internal FixedSizeArray260<char> _buffer;
    [FieldOffset(0x208)] public char* LongStringPtr;

    public override string ToString() {
        return LongStringPtr != null ? new string(LongStringPtr) : BufferString;
    }
}
