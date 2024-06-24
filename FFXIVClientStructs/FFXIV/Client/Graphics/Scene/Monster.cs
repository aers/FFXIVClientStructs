using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Monster
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object
// ctor "E8 ?? ?? ?? ?? 4C 8B F0 4C 89 B7"
[GenerateInterop]
[Inherits<CharacterBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x920)]
public unsafe partial struct Monster {
    [FieldOffset(0x8F0)] public ushort ModelSetId;
    [FieldOffset(0x8F2)] public ushort SecondaryId;
    [FieldOffset(0x8F4)] public ushort Variant;

    [FieldOffset(0x900)] public TextureResourceHandle* Decal;

    // Expects at least 8 bytes of data.
    [MemberFunction("48 89 5C 24 ?? 56 48 83 EC 40 0F B7 02")]
    public partial bool SetupFromData(byte* data);
}
