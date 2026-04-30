namespace FFXIVClientStructs.FFXIV.Common.Component.Environment;

[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct AllocatorInterface {
    [VirtualFunction(0)]
    public partial AllocatorInterface* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial T* MemAlloc<T>(ulong size) where T : unmanaged;

    [VirtualFunction(2)]
    public partial T* Free<T>(T* ptr) where T : unmanaged;
}
