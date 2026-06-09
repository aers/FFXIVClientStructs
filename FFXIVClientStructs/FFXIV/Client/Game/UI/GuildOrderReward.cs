using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::GuildOrderReward
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe struct GuildOrderReward {
    [FieldOffset(0x50)] public ExcelSheet* GuildOrderSheet;
    [FieldOffset(0x58)] public ExcelSheetWaiter* GuildOrderSheetWaiter;
}
