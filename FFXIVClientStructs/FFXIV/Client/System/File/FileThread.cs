namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::FileThread
//   Client::System::Threading::Thread
//     Client::System::Common::NonCopyable
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2518)]
public unsafe partial struct FileThread {
    [FieldOffset(0x0008)] public void* SecurityAttributes; // https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-createeventa
    [FieldOffset(0x0028), FixedSizeArray] internal FixedSizeArray20<Pointer<SqPackManager>> _sqPackManagers;
}
