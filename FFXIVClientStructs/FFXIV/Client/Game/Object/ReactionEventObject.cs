namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::ReactionEventObject
//   Client::Game::Object::GameObject
[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x240)]
public unsafe partial struct ReactionEventObject {
    [FieldOffset(0x1B8)] public Utf8String SgbPath;
    [FieldOffset(0x23C)] public uint EObjNameId;
}
