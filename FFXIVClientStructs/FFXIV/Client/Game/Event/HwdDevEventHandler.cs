using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::HwdDevEventHandler
//   Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x320)]
public unsafe partial struct HwdDevEventHandler {
    [FieldOffset(0x210)] public byte DevelopmentLevel;

    [FieldOffset(0x218)] public int NextTimestamp;
    [FieldOffset(0x21C)] public bool IsInProgress;
    [FieldOffset(0x21D)] public bool IsComplete;

    [FieldOffset(0x220)] public StdVector<EventHandlerObjective> Objectives;

    [FieldOffset(0x240)] public Utf8String ToDoDescription2; // this is appended to ToDoDescription
    [FieldOffset(0x2A8)] public Utf8String ToDoDescription;
}
