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
[VirtualTable("48 8D 05 ?? ?? ?? ?? 33 D2 48 89 07 41 B8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 33", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x3780)]
public unsafe partial struct BattleChara {
    [FieldOffset(0x2320)] public StatusManager StatusManager;
    [FieldOffset(0x2700)] public CastInfo CastInfo;
    [FieldOffset(0x2870)] public ActionEffectHandler ActionEffectHandler;
    [FieldOffset(0x3770)] public ForayInfo ForayInfo;
}
