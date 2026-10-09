namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::IAllocator
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct IAllocator {
    [VirtualFunction(0)]
    public partial IAllocator* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void Cleanup();

    [VirtualFunction(2)]
    public partial void* Allocate(nint size, nint alignment);

    [VirtualFunction(3)]
    public partial void* Reallocate(void* ptr, nint newSize, nint newAlignment);

    [VirtualFunction(4)]
    public partial void Free(void* ptr);
}
