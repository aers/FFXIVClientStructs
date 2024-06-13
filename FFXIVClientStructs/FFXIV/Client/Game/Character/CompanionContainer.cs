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

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 56 68")]
    public partial void SetupCompanion(short companionId, uint param);
}
