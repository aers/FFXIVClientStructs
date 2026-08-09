namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::FileHandleIndex
// A file handle is referred to by a uint32 that stores a page index 0-7, flags, and a handle index into that table.
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public partial struct FileHandleIndex {
    [BitField<uint>(nameof(HandleIndex), 0, 26)]
    [BitField<uint>(nameof(Flags), 26, 2)] // If either of these bits are set, this handle should be returned to the manager's pool via Return.
    [BitField<uint>(nameof(PageIndex), 28, 4)]
    [FieldOffset(0x00)] public uint Value;

    // Returns the file handle to the global file handle manager's empty pool and clears out this handle index.
    [MemberFunction("E8 ?? ?? ?? ?? 41 89 2F BB")]
    public partial void Return();

    // Resets the file handle that this file handle index refers to, if necessary.
    [MemberFunction("E8 ?? ?? ?? ?? 3C F6 74 1F")]
    public partial byte Reset();
}
