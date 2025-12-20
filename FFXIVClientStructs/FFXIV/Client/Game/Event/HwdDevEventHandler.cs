using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::HwdDevEventHandler
//   Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
public unsafe partial struct HwdDevEventHandler {
    [FieldOffset(0x1B8)] public byte DevelopmentLevel;

    [FieldOffset(0x1C0)] public int NextTimestamp;
    [FieldOffset(0x1C4)] public bool IsInProgress;
    [FieldOffset(0x1C5)] public bool IsComplete;

    [FieldOffset(0x1C8)] public StdVector<EventHandlerObjective> Objectives;

    [FieldOffset(0x1E8)] public Utf8String ToDoDescription2; // this is appended to ToDoDescription
    [FieldOffset(0x250)] public Utf8String ToDoDescription;
}
