namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Monster
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object

// ctor E8 ?? ?? ?? ?? 4C 8B F0 4C 89 B7 
[StructLayout(LayoutKind.Explicit, Size = 0x900)]
public unsafe partial struct Monster
{
    [FieldOffset(0x0)] public CharacterBase CharacterBase;

    // Expects at least 8 bytes of data.
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 33 C0 48 8D 4D")]
    public partial bool SetupFromData(byte* data);
}
