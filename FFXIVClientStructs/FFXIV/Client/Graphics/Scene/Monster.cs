using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Monster
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<CharacterBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xA50)]
public unsafe partial struct Monster {
    [FieldOffset(0xA20)] public ushort ModelSetId;
    [FieldOffset(0xA22)] public ushort SecondaryId;
    [FieldOffset(0xA24)] public ushort Variant;

    [FieldOffset(0xA30)] public TextureResourceHandle* Decal;

    // Expects at least 8 bytes of data.
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F 57 C0 48 8D 4C 24 ??")]
    public partial bool SetupFromData(byte* data);
}
