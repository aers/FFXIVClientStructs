namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::FileManager
//   Client::System::Framework::Task
[StructLayout(LayoutKind.Explicit, Size = 0x141a8)]
public unsafe struct FileManager {
    [FieldOffset(0x38)] public FileThread* FileThread;
}
