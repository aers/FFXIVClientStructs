namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::BattleChara
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
//     Client::Game::Character::CharacterData
// ctor "E8 ?? ?? ?? ?? 48 8B F0 8B 87"
// characters that fight (players, monsters, etc)
[StructLayout(LayoutKind.Explicit, Size = 0x2F80)]
public unsafe partial struct BattleChara {
    [FieldOffset(0x0)] public Character Character;

    //[FieldOffset(0x1E60)] public fixed byte UnkBattleCharaStruct[0xF00];

    public StatusManager* GetStatusManager => Character.GetStatusManager();
    public Character.CastInfo* GetCastInfo => Character.GetCastInfo();
    public Character.ForayInfo* GetForayInfo => Character.GetForayInfo();
}
