namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::CompanionContainer
//   Client::Game::Character::ContainerInterface
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct CompanionContainer {
    [FieldOffset(0x10)] public Companion* CompanionObject;
    //used if minion is summoned but the object slot is taken by a mount
    [FieldOffset(0x18)] public ushort CompanionId;
    [FieldOffset(0x1A)] public ushort FollowMountId;
    [FieldOffset(0x1C)] private ushort UnkFollowMountId2;
    [FieldOffset(0x1E)] private byte Unk1E;

    [MemberFunction("E8 ?? ?? ?? ?? B3 ?? 41 0F BA E6")]
    public partial void SetupCompanion(short companionId, uint param);
}
