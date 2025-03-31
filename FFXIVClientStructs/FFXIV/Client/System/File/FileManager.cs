namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::FileManager
//   Client::System::Framework::Task
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x141a8)]
public unsafe partial struct FileManager {
    [StaticAddress("48 8B 3D ?? ?? ?? ?? 48 85 C0", 3, isPointer: true)]
    public static partial FileManager* Instance();

    [FieldOffset(0x38)] public FileThread* FileThread;
}
