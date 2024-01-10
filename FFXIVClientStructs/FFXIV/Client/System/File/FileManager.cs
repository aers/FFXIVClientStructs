namespace FFXIVClientStructs.FFXIV.Client.System.File;

[StructLayout(LayoutKind.Explicit, Size = 0x141a8)]
public unsafe struct FileManager {
    [FieldOffset(0x38)] public FileThread* FileThread;
}
