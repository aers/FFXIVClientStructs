namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::OrnamentContainer
//   Client::Game::Character::ContainerInterface
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe partial struct OrnamentContainer {
    [FieldOffset(0x10)] public Ornament* OrnamentObject;
    [FieldOffset(0x18)] public ushort OrnamentId;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 7B ?? 48 8B 74 24")]
    public partial void SetupOrnament(short ornamentId, uint param);
}
