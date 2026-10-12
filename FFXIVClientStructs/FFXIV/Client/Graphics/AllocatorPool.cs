namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::AllocatorPool
//   Client::Graphics::IAllocator
/// <summary>
/// Small blocks from 16 KB chunks of <see cref="Backing"/>, split into 1 KB pages of one size class; anything else
/// goes to <see cref="Backing"/>. Free takes <see cref="Lock"/> before checking which of the two a block came from.
/// </summary>
[GenerateInterop]
[Inherits<IAllocator>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8B D9 48 89 01 33 C0 48 89 81", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x180)]
public unsafe partial struct AllocatorPool {
    [FieldOffset(0x108)] public IAllocator* Backing;
    [FieldOffset(0x110)] public void* Chunks; // 0x30 bytes each, block at +0x10
    [FieldOffset(0x130)] public uint ChunkCount;
    [FieldOffset(0x138)] public ulong ReservedBytes;
    [FieldOffset(0x140)] public ulong UsedBytes;
    [FieldOffset(0x158)] private fixed byte Lock[0x28]; // CRITICAL_SECTION
}
