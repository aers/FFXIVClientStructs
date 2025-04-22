namespace FFXIVClientStructs.FFXIV.Client.System.Threading;

// Client::System::Threading::ThreadManager
//   Client::System::Common::NonCopyable
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1048)]
public unsafe partial struct ThreadManager {
    [StaticAddress("48 89 B3 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 8B", 10, isPointer: true)]
    public static partial ThreadManager* Instance();

    [FieldOffset(0x0008)] public nint FrameworkThread;
    [FieldOffset(0x0010)] public void* CriticalSection;
    [FieldOffset(0x0038), FixedSizeArray] internal FixedSizeArray512<Pointer<Thread>> _threads;
    //8 byte
    [FieldOffset(0x1040)] public int ThreadCount;
}
