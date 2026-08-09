namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::TargetStatusContainer
//   Client::Game::Character::ContainerInterface
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public partial struct TargetStatusContainer {
    [FieldOffset(0x10)] private byte Unk10Flags;
    [FieldOffset(0x11)] private bool Unk11;
    [FieldOffset(0x12)] private bool Unk12;
}
