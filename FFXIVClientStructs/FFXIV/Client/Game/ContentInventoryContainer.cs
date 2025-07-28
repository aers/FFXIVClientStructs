namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::ContentInventoryContainer
//   Client::Game::InventoryContainer
[GenerateInterop(isInherited: true)]
[Inherits<InventoryContainer>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct ContentInventoryContainer {
    [FieldOffset(0x20)] public InventoryType InventoryType;

    [VirtualFunction(6)]
    public partial InventoryType GetInventoryType();
}
