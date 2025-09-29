using FFXIVClientStructs.FFXIV.Client.Game.MassivePcContent;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::MassivePcContentTodo
[StructLayout(LayoutKind.Explicit, Size = 0x150)]
public unsafe struct MassivePcContentTodo {
    [FieldOffset(0x00)] public ExcelSheetWaiter* ExcelSheetWaiter;
    [FieldOffset(0x08)] public MassivePcContentDirector* Director;
    [FieldOffset(0x10)] public Utf8String Title;
    [FieldOffset(0x78)] public Utf8String Objective;
    [FieldOffset(0xE0)] public Utf8String ReliefText;
    [FieldOffset(0x148)] public bool FullUpdatePending;
    [FieldOffset(0x149)] public bool Shown;
}
