namespace FFXIVClientStructs.FFXIV.Client.System.Memory;

// Client::System::Memory::IMemoryModule
[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct IMemoryModule {
    [VirtualFunction(0)]
    public partial IMemoryModule* Dtor(byte freeFlags);

    [VirtualFunction(4)]
    public partial void* AlignedMalloc(IMemorySpace* space, ulong size, ulong alignment);

    [VirtualFunction(5)]
    public partial void* AlignedMalloc2(IMemorySpace* space, ulong size, ulong alignment, byte a5);

    [VirtualFunction(6)]
    public partial void* AlignedRealloc(void* ptr, ulong size, ulong alignment);

    [VirtualFunction(7)]
    public partial void Free(void* ptr);
}
