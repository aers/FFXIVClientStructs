namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::Companion
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
//     Client::Game::Character::CharacterData
// companion = minion
[GenerateInterop]
[Inherits<Character>]
[VirtualTable("E8 ?? ?? ?? ?? 0F B7 56 68", [1, 0xDE])]
[StructLayout(LayoutKind.Explicit, Size = 0x23B0)]
public unsafe partial struct Companion {
    [FieldOffset(0x2350)] public BattleChara* Owner;

    /// <summary> Used when the companion places itself on its owner's shoulder or head. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F B6 87")]
    public partial void PlaceCompanion();
}
