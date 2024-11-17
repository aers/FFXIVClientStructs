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
[StructLayout(LayoutKind.Explicit, Size = 0x2310)]
public unsafe partial struct Ornament {
    [FieldOffset(0x22F0)] public uint OrnamentId;
    [FieldOffset(0x22F4)] public byte AttachmentPoint;

    // Inlined in E8 ?? ?? ?? ?? F3 0F 10 4D ?? 0F 57 D2 with 7.1
    // [MemberFunction("E8 ?? ?? ?? ?? 44 8B 84 24 ?? ?? ?? ?? 4C 8D 4C 24")]
    // public partial void SetupOrnament(uint* unk1, float* unk2);
}
