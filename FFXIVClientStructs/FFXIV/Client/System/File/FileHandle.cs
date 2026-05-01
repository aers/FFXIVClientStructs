namespace FFXIVClientStructs.FFXIV.Client.System.File;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct FileHandle {
    [FieldOffset(0x00)] public byte IsInUse; // 0 = this handle is free
    [FieldOffset(0x01)] public byte LastIOResult; // Last result code from a file operation, 1 = success
    [FieldOffset(0x02)] public byte State2;
    [FieldOffset(0x03)] public byte HasAllocatedBuffer; // 1 = AllocatedBuffer needs to be freed

    [FieldOffset(0x08)] public void* AllocatedBuffer; // Tracks the buffer allocated by ReadFile with filemode LoadFileResource so it can be destroyed
    [FieldOffset(0x10)] public ulong ResultLength;
    [FieldOffset(0x18)] public FileHandle* NextFree;

    [MemberFunction("E8 ?? ?? ?? ?? 44 87 63 08")]
    public partial void Reset(byte openFileResult);
}

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
