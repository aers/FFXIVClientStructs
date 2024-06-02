using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventState
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct EventState {
    [FieldOffset(0x10)] public GameObjectId ObjectId;
}
