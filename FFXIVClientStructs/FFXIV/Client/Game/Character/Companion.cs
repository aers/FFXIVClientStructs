namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::Companion
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
//     Client::Game::Character::CharacterData
// companion = minion
[GenerateInterop]
[Inherits<Character>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 33 C0 48 89 83 ?? ?? ?? ?? 48 C7 83", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x23E0)]
public unsafe partial struct Companion {
    [FieldOffset(0x2370)] public BattleChara* Owner;

    /// <summary> Used when the companion places itself on its owner's shoulder or head. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F B6 87")]
    public partial void PlaceCompanion();
}
