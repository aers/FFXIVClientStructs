using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::ReactionEventObject
//   Client::Game::Object::GameObject
[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe partial struct ReactionEventObject {
    [FieldOffset(0x1A8)] public Utf8String SgbPath;
    [FieldOffset(0x22C)] public uint EObjNameId;
}
