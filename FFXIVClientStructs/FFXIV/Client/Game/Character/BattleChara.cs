namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::BattleChara
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
//     Client::Game::Character::CharacterData
// characters that fight (players, monsters, etc)
[GenerateInterop]
[Inherits<Character>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? 48 8D 05", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x3800)]
public unsafe partial struct BattleChara {
    [FieldOffset(0x23A0)] public StatusManager StatusManager;
    [FieldOffset(0x2780)] public CastInfo CastInfo;
    [FieldOffset(0x28F0)] public ActionEffectHandler ActionEffectHandler;
    [FieldOffset(0x37F0)] public ForayInfo ForayInfo;

    [MemberFunction("48 85 C9 0F 84 ?? ?? ?? ?? 48 89 6C 24 ?? 56 48 83 EC 30")]
    public partial void RidePillion(uint seatIndex);
}
