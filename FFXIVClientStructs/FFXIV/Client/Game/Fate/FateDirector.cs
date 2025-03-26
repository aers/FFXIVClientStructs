using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.Fate;

// Client::Game::Fate::FateDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
// ctor "48 89 5C 24 ?? 57 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0"
[GenerateInterop]
[Inherits<Director>]
[StructLayout(LayoutKind.Explicit, Size = 0x500)]
public partial struct FateDirector {
    [FieldOffset(0x4C0)] public byte FateLevel;
    [FieldOffset(0x4C8)] public uint FateNpcObjectId;
    [FieldOffset(0x4D4)] public ushort FateId;
}
