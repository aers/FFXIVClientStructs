using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::AllocatorLowLevel
//   Client::Graphics::IAllocator
[GenerateInterop]
[Inherits<IAllocator>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct AllocatorLowLevel {
    [FieldOffset(0x08)] public IMemorySpace* MemorySpace;
    [FieldOffset(0x10)] public CStringPointer Name;
}
