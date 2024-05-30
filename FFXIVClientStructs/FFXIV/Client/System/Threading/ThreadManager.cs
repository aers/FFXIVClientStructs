namespace FFXIVClientStructs.FFXIV.Client.System.Threading;

[StructLayout(LayoutKind.Explicit, Size = 0x1048)]
public unsafe partial struct ThreadManager {
    [FieldOffset(0x0008)] public nint FrameworkThread;
    [FieldOffset(0x0010)] public void* CriticalSection;
    [FieldOffset(0x0038), FixedSizeArray] internal FixedSizeArray512<Pointer<Thread>> _threads;
    //8 byte
    [FieldOffset(0x1040)] public int ThreadCount;
}
