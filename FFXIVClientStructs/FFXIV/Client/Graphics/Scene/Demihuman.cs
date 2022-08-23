namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Demihuman
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object

// ctor 40 53 48 83 EC ?? 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 45 33 C0 48 89 03 BA
[StructLayout(LayoutKind.Explicit, Size = 0x978)]
public unsafe partial struct Demihuman
{
    [FieldOffset(0x0)] public CharacterBase CharacterBase;

    // Expects at least 24 bytes of data.
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 41 0F 10 07")]
    public partial bool SetupFromData(byte* data);
}
