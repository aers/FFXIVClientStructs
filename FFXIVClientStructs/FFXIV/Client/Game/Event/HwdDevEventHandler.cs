using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::HwdDevEventHandler
//   Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct HwdDevEventHandler {
    [FieldOffset(0x218)] public byte DevelopmentLevel;

    [FieldOffset(0x220)] public int NextTimestamp;
    [FieldOffset(0x224)] public bool IsInProgress;
    [FieldOffset(0x225)] public bool IsComplete;

    [FieldOffset(0x228)] public StdVector<EventHandlerObjective> Objectives;

    [FieldOffset(0x248)] public Utf8String ToDoDescription2; // this is appended to ToDoDescription
    [FieldOffset(0x2B0)] public Utf8String ToDoDescription;
}
