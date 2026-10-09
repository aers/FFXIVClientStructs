namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::AllocatorManager
//   Client::Graphics::Singleton<Client::Graphics::AllocatorManager>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1B0)]
public unsafe partial struct AllocatorManager {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? 8B D7 48 8B 48 ?? 48 8B 01 FF 50 ?? 48 89 83", 3, isPointer: true)]
    public static partial AllocatorManager* Instance();

    /// <remarks> [0] is used by every JobSystem, [1] for dynamic buffer staging during draw building. </remarks>
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray13<Pointer<IAllocator>> _allocators;
}
