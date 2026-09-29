namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::InstanceContentCrucible
//   Client::Game::InstanceContent::InstanceContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<InstanceContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x25A0)]
public partial struct InstanceContentCrucible {
    [FieldOffset(0x2380), FixedSizeArray] internal FixedSizeArray10<InventorySlot> _inventory;

    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct InventorySlot {
        [FieldOffset(4)] public ushort ItemId;
    }

    /// <summary>
    /// Uses a Crucible item.
    /// </summary>
    /// <remarks>If applicable, the item action will be used on the player's current soft or hard target.</remarks>
    /// <param name="slot">Crucible inventory index (0-9).</param>
    /// <param name="unk3"></param>
    [MemberFunction("E8 ?? ?? ?? ?? 83 7F 44 00 48 8D 57 44")]
    public partial void UseItem(uint slot, int unk3);
}

