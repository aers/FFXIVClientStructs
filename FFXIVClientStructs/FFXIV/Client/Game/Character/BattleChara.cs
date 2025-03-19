namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::BattleChara
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
//     Client::Game::Character::CharacterData
// ctor "E8 ?? ?? ?? ?? 48 8B F0 8D 14 3F"
// characters that fight (players, monsters, etc)
[GenerateInterop]
[Inherits<Character>]
[VirtualTable("E8 ?? ?? ?? ?? 48 8B F0 8D 14 3F", [1, 0x23])]
[StructLayout(LayoutKind.Explicit, Size = 0x36A0)]
public unsafe partial struct BattleChara {
    [FieldOffset(0x2330)] public StatusManager StatusManager;
    [FieldOffset(0x2620)] public CastInfo CastInfo;
    [FieldOffset(0x2790)] public ActionEffectHandler ActionEffectHandler;
    [FieldOffset(0x3690)] public ForayInfo ForayInfo;
}
