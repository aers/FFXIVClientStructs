namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::ContainerInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ContainerInterface {
    [FieldOffset(0x08)] public Character* OwnerObject;
}
