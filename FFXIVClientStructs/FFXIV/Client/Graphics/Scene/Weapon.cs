using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Weapon
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object
// ctor "E8 ?? ?? ?? ?? 48 8D 55 EF 48 89 44 3E"
[StructLayout(LayoutKind.Explicit, Size = 0x920)]
public unsafe struct Weapon {
    [FieldOffset(0x0)] public CharacterBase CharacterBase;

    [FieldOffset(0x8F0)] public ushort ModelSetId;
    [FieldOffset(0x8F2)] public ushort SecondaryId;
    [FieldOffset(0x8F4)] public ushort Variant;
    [FieldOffset(0x8F6)] public ushort ModelUnknown;
    [FieldOffset(0x8FA)] public byte MaterialId;
    [FieldOffset(0x8FB)] public byte DecalId;
    [FieldOffset(0x8FE)] public byte VfxId;

    [FieldOffset(0x900)] public TextureResourceHandle* Decal;
    [FieldOffset(0x908)] public Texture* FreeCompanyCrest;
    [FieldOffset(0x910)] public uint SlotFreeCompanyCrestBitfield; // Only relevant bit is & 0x1
}
