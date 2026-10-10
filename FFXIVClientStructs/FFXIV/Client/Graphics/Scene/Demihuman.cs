using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Demihuman
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<CharacterBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xAD0)]
public unsafe partial struct Demihuman : ICreatable<Demihuman> {
    [FieldOffset(0xA70), FixedSizeArray, CExporterIgnore] internal FixedSizeArray5<Pointer<TextureResourceHandle>> _slotDecals;
    [FieldOffset(0xA70)] public TextureResourceHandle* HeadDecal;
    [FieldOffset(0xA78)] public TextureResourceHandle* TopDecal;
    [FieldOffset(0xA80)] public TextureResourceHandle* ArmsDecal;
    [FieldOffset(0xA88)] public TextureResourceHandle* LegsDecal;
    [FieldOffset(0xA90)] public TextureResourceHandle* FeetDecal;

    public TextureResourceHandle* SlotDecal(int slot) => SlotDecals[slot].Value;

    [FieldOffset(0xAA0)] public Texture* FreeCompanyCrest;
    [FieldOffset(0xAA8)] public uint SlotFreeCompanyCrestBitfield; // Only relevant bit is & 0x1

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 48 8D 54 24")]
    public partial Demihuman* Ctor();

    // Expects at least 24 bytes of data.
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 41 0F 10 0F")]
    public partial bool SetupFromData(byte* data);
}
