using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::GoldSaucerEventHandler
//   Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C8)]
public unsafe partial struct GoldSaucerEventHandler {
    [FieldOffset(0x1B8)] public EventContext* Context;
    [FieldOffset(0x1C0)] public uint ContextScene;

    [StructLayout(LayoutKind.Explicit, Size = 0x110)]
    public struct EventContext {
        [FieldOffset(0x00)] public StdDeque<TextParameter> TextParameters;
        [FieldOffset(0x28)] public ExcelSheetWaiter ExcelSheetWaiter;
        [FieldOffset(0x70)] public ExcelSheet* ExcelSheet;
        [FieldOffset(0x78)] public EventHandler* EventHandler;
        [FieldOffset(0x84)] public int SelectedOption;
        [FieldOffset(0x88)] public int ValueCount;
        [FieldOffset(0x8C), FixedSizeArray] internal FixedSizeArray10<uint> _values;
    }
}
