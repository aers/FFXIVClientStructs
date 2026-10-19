using FFXIVClientStructs.FFXIV.Client.Game.Emj;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::EmjEngineCore
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4E0)]
public unsafe partial struct EmjEngineCore {
    [FieldOffset(0x468)] public ClientTable* Table;
}
