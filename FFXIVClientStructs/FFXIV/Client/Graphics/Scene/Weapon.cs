using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Weapon
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object
// ctor "E8 ?? ?? ?? ?? 48 8D 55 EF 48 89 44 3E"
[GenerateInterop]
[Inherits<CharacterBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xA10)]
public unsafe partial struct Weapon {
    [FieldOffset(0x9D0)] public ushort ModelSetId;
    [FieldOffset(0x9D2)] public ushort SecondaryId;
    [FieldOffset(0x9D4)] public ushort Variant;
    [FieldOffset(0x9D5)] public byte Stain0;
    [FieldOffset(0x9D6)] public byte Stain1;
    [FieldOffset(0x9DA)] public byte MaterialId;
    [FieldOffset(0x9DB)] public byte DecalId;
    [FieldOffset(0x9DE)] public byte VfxId;

    [FieldOffset(0x9E8)] public TextureResourceHandle* Decal;
    [FieldOffset(0x9F0)] public Texture* FreeCompanyCrest;
    [FieldOffset(0x9F8)] public uint SlotFreeCompanyCrestBitfield; // Only relevant bit is & 0x1
}
