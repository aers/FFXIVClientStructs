using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventState
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct EventState {
    [FieldOffset(0x08)] public EventId EventId;
    [FieldOffset(0x10)] public GameObjectId ObjectId;
    [FieldOffset(0x18)] private byte Unk18;
    [FieldOffset(0x1C)] private int Unk1C;
    [FieldOffset(0x20)] private byte Unk20;
    [FieldOffset(0x24)] public int OccupiedConditionId;
    [FieldOffset(0x28)] private byte Unk28;
    [FieldOffset(0x2C)] public byte Flags;
}
