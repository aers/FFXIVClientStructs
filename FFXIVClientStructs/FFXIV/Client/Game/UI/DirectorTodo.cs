using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::DirectorTodo
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe struct DirectorTodo {
    [FieldOffset(0x00)] public Director* Director;
    [FieldOffset(0x08)] public Utf8String Title;
    [FieldOffset(0x70)] public Utf8String Description;
    [FieldOffset(0xD8)] public Utf8String ReliefText;
    [FieldOffset(0x140)] public bool IsFullUpdatePending;
    [FieldOffset(0x141)] public bool IsShown;
}
