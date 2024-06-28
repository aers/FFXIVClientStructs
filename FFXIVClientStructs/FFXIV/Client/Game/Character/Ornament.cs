namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::Ornament
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
//     Client::Game::Character::CharacterData
// ctor "40 53 48 83 EC ? 48 8B D9 E8 ? ? ? ? 48 8D 05 ? ? ? ? 48 89 03 48 8D 05 ? ? ? ? 48 89 83 ? ? ? ? 33 C0 89 83"
// ornament = accessory
[GenerateInterop]
[Inherits<Character>]
[StructLayout(LayoutKind.Explicit, Size = 0x22A0)]
public unsafe partial struct Ornament {
    [FieldOffset(0x2280)] public uint OrnamentId;
    [FieldOffset(0x2284)] public byte AttachmentPoint;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 7B 24")]
    public partial void SetupOrnament(uint* unk1, float* unk2);
}
