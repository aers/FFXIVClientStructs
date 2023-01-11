namespace FFXIVClientStructs.FFXIV.Client.Game.Character;
// Client::Game::Character::Companion
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
// companion = minion

// size = 0x19C0
// ctor E8 ?? ?? ?? ?? EB 02 33 C0 0F B7 93 ?? ?? ?? ?? 45 33 C9 FF C2 48 89 83 ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 48 8B D3 
[StructLayout(LayoutKind.Explicit, Size = 0x1BE0)]
public struct Companion
{
    [FieldOffset(0x0)] public Character Character;
}