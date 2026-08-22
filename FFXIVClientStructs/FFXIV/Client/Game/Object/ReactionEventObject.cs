using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::ReactionEventObject
//   Client::Game::Object::GameObject
[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x240)]
public unsafe partial struct ReactionEventObject {
    [FieldOffset(0x1A0), CExporterExcel("EObj")] public nint EObjRowPtr;
    [FieldOffset(0x1A8), CExporterExcel("ExportedSG")] public nint ExportedSGRowPtr;

    [FieldOffset(0x1B4)] private byte Unk1B4;
    [FieldOffset(0x1B8)] public Utf8String SgbPath;
    [FieldOffset(0x220)] public Quaternion RotationQuaternion;
    [FieldOffset(0x230)] private byte Unk230;
    [FieldOffset(0x234)] private float Unk234;
    [FieldOffset(0x238)] private float Unk238;
    [FieldOffset(0x23C)] public uint EObjNameId;
}
