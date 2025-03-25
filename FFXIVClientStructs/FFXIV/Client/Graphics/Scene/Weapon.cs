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
    [FieldOffset(0xA10)] public ushort ModelSetId;
    [FieldOffset(0xA12)] public ushort SecondaryId;
    [FieldOffset(0xA14)] public ushort Variant;
    [FieldOffset(0xA16)] public byte Stain0;
    [FieldOffset(0xA17)] public byte Stain1;
    [FieldOffset(0xA1A)] public byte MaterialId;
    [FieldOffset(0xA1B)] public byte DecalId;
    [FieldOffset(0xA1E)] public byte VfxId;

    [FieldOffset(0xA28)] public TextureResourceHandle* Decal;
    [FieldOffset(0xA30)] public Texture* FreeCompanyCrest;
    [FieldOffset(0xA38)] public uint SlotFreeCompanyCrestBitfield; // Only relevant bit is & 0x1
    [FieldOffset(0xA40)] public ChangedWeaponData* ChangedData;

    [StructLayout(LayoutKind.Explicit, Size = 0x06)] // Size unknown
    public struct ChangedWeaponData {
        // No primary ID since this requires a new model to be setup.
        [FieldOffset(0x00)] public ushort SecondaryId;
        [FieldOffset(0x02)] public byte Variant;
        [FieldOffset(0x03)] public byte Stain0;
        [FieldOffset(0x04)] public byte Stain1;
    }
}
