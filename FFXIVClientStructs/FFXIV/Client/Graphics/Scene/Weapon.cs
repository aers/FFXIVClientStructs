using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Weapon
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<CharacterBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xA60)]
public unsafe partial struct Weapon {
    [FieldOffset(0xA20)] public ushort ModelSetId;
    [FieldOffset(0xA22)] public ushort SecondaryId;
    [FieldOffset(0xA24)] public ushort Variant;
    [FieldOffset(0xA26)] public byte Stain0;
    [FieldOffset(0xA27)] public byte Stain1;
    [FieldOffset(0xA2A)] public byte MaterialId;
    [FieldOffset(0xA2B)] public byte DecalId;
    [FieldOffset(0xA2E)] public byte VfxId;

    [FieldOffset(0xA38)] public TextureResourceHandle* Decal;
    [FieldOffset(0xA40)] public Texture* FreeCompanyCrest;
    [FieldOffset(0xA48)] public uint SlotFreeCompanyCrestBitfield; // Only relevant bit is & 0x1
    [FieldOffset(0xA50)] public ChangedWeaponData* ChangedData;

    [StructLayout(LayoutKind.Explicit, Size = 0x06)] // Size unknown
    public struct ChangedWeaponData {
        // No primary ID since this requires a new model to be setup.
        [FieldOffset(0x00)] public ushort SecondaryId;
        [FieldOffset(0x02)] public byte Variant;
        [FieldOffset(0x03)] public byte Stain0;
        [FieldOffset(0x04)] public byte Stain1;
    }
}
