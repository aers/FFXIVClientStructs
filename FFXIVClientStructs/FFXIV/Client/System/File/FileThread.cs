namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::FileThread
//   Client::System::Threading::Thread
//     Client::System::Common::NonCopyable
[StructLayout(LayoutKind.Explicit, Size = 0x2518)]
public unsafe struct FileThread {
    [FieldOffset(0x0008)] public void* SecurityAttributes; // https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-createeventa
}
