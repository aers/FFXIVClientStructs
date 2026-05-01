namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::FileThread
//   Client::System::Threading::Thread
//     Client::System::Common::NonCopyable
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2518)]
public unsafe partial struct FileThread {
    [FieldOffset(0x0008)] public void* SecurityAttributes; // https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-createeventa

    [MemberFunction("44 88 4C 24 ?? 44 89 44 24 ?? 53 56")]
    public partial byte ReadSqPack(FileDescriptor* fileDescriptor, int priority, bool isSync);

    [MemberFunction("40 56 41 56 48 83 EC ?? 0F BE 02")]
    public partial byte DoFileJob(FileDescriptor* fileDescriptor, int priority, bool isSync);
}
