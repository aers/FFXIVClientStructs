namespace FFXIVClientStructs.FFXIV.Client.System.Memory.Regular;

// Client::System::Memory::Regular::DefaultSpace
//   Client::System::Memory::IMemorySpace
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
[Inherits<IMemorySpace>]
[VirtualTable("48 89 05 ?? ?? ?? ?? 48 8B CE", 3, 16)]
public unsafe partial struct DefaultSpace {
    [MemberFunction("E8 ?? ?? ?? ?? 48 89 44 24 ?? 48 8D B3")]
    public static partial DefaultSpace* GetInstance();

    [FieldOffset(0x8)] public IMemoryModule MemoryModule;
    [FieldOffset(0x10)] public ulong MinAlignment;
    [FieldOffset(0x20)] private byte Unk20; // set with vf13 and get with vf14
    [FieldOffset(0x21)] private byte Unk21; // set if Malloc or AlignedMalloc was called to create the memory for this and another DefaultSpace exists?
}
