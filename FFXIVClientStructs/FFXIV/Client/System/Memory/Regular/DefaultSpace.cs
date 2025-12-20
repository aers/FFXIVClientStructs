namespace FFXIVClientStructs.FFXIV.Client.System.Memory.Regular;

// Client::System::Memory::Regular::DefaultSpace
//   Client::System::Memory::IMemorySpace
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
[Inherits<IMemorySpace>]
[VirtualTable("4C 89 78 D8 48 8D 05 ?? ?? ?? ??", 7, 16)]
public unsafe partial struct DefaultSpace {
    public static DefaultSpace* GetInstance() => (DefaultSpace*)IMemorySpace.GetDefaultSpace();

    [FieldOffset(0x8)] public IMemoryModule MemoryModule;
    [FieldOffset(0x10)] public ulong MinAlignment;
    [FieldOffset(0x20)] private byte Unk20; // set with vf13 and get with vf14
    [FieldOffset(0x21)] private byte Unk21; // set if Malloc or AlignedMalloc was called to create the memory for this and another DefaultSpace exists?
}
