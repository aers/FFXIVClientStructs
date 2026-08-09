namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::FileHandle
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
