namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::IAllocator
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)] // Unknown size of abstract class, needs at least a vfptr
public unsafe partial struct IAllocator {
    [VirtualFunction(0)]
    public partial void Dtor(int flags);

    [VirtualFunction(1)]
    public partial void Cleanup();

    [VirtualFunction(2)]
    public partial nint Allocate(nint size, nint alignment);

    [VirtualFunction(3)]
    public partial nint Reallocate(void* allocation, nint newSize, nint newAlignment);

    [VirtualFunction(4)]
    public partial void Free(void* allocation);
}
