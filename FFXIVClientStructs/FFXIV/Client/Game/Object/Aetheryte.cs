using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::Aetheryte
//   Client::Game::Object::GameObject
[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
public unsafe partial struct Aetheryte {
    [FieldOffset(0x190)] public AetheryteEventHandler* AetheryteEventHandler;
}
