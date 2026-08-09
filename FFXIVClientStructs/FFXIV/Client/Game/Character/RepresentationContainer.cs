namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::RepresentationContainer
//   Client::Game::Character::ContainerInterface
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct RepresentationContainer {
    // not 100% on these
    // 1 = Normal
    // 2 = (Skips everything??)
    // 3 = Blacklisted (using NameOverride)
    // 4 = Alliance Member, Friend, in Custom Match or in Duel
    // 5 = Cross-realm Party Member
    [FieldOffset(0x10)] public byte NameType;

    [FieldOffset(0x18)] public Utf8String* NameOverride; // "Unknown"
    [FieldOffset(0x20)] public float UpdateTimer;
    [FieldOffset(0x24)] private byte Unk24;
    [FieldOffset(0x25)] private ushort Unk25; // some flags based on Status
    [FieldOffset(0x28)] private byte Unk28; // some flags for Scheduler
}
