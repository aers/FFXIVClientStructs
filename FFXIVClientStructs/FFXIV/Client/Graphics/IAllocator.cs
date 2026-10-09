namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::IAllocator
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct IAllocator {
    [VirtualFunction(0)]
    public partial IAllocator* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void Terminate();

    [VirtualFunction(2)]
    public partial void* Alloc(ulong size, ulong alignment);

    [VirtualFunction(3)]
    public partial void* Realloc(void* ptr, ulong size, ulong alignment);

    [VirtualFunction(4)]
    public partial void Free(void* ptr);

    /// <summary> Usable size of a block from this allocator. </summary>
    [VirtualFunction(9)]
    public partial ulong GetSize(void* ptr);
}
