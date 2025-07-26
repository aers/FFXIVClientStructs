namespace FFXIVClientStructs.FFXIV.Client.System.Threading;

// Client::System::Threading::Thread
//   Client::System::Common::NonCopyable
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct Thread {
    [FieldOffset(0x08)] public nint EventHandle;
    [FieldOffset(0x10)] public nint ThreadHandle;
    [FieldOffset(0x18)] public int ThreadId;
    [FieldOffset(0x1C)] public int AffinityMask;
    [FieldOffset(0x20)] public bool HasRequestedStop;

    [VirtualFunction(0)]
    public partial Thread* Dtor(byte flags);

    [VirtualFunction(1)]
    public partial void RequestStop();

    // [VirtualFunction(2)]
    // public partial bool vf2(); // mov al, 1

    // [VirtualFunction(3)]
    // public partial int vf3(); // xor eax, eax

    // [VirtualFunction(4)]
    // public partial ? vf4(); // nullsub

    [VirtualFunction(5)]
    public partial void Run();
}
