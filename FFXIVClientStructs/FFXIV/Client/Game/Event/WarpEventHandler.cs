using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::WarpEventHandler
//   Client::Game::Event::LuaEventHandler
//     Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<LuaEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x4E8)]
public unsafe partial struct WarpEventHandler {
    [FieldOffset(0x2D8)] public EventHandlerInfo* WarpId;
    [FieldOffset(0x2E0)] public uint PopRange;
    [FieldOffset(0x2E4)] public ushort TerritoryType;
    [FieldOffset(0x2E6)] public ushort WarpLogic;
    [FieldOffset(0x2E8)] public ushort WarpCondition;

    [FieldOffset(0x2F0)] public Utf8String Title;
    [FieldOffset(0x358)] public ExcelSheet* Sheet;
    [FieldOffset(0x360)] public ExcelSheetWaiter* SheetWaiter;
    [FieldOffset(0x368)] private StdMap<Utf8String, uint> WarpParams; // unsure, reset when lua definitions are set
    [FieldOffset(0x378)] public bool HasCustomWarpName;

    [FieldOffset(0x37C)] public int ConditionSuccessEvent;
    [FieldOffset(0x380)] public int ConditionFailEvent;
    [FieldOffset(0x384)] public int ConfirmEvent;
    [FieldOffset(0x388)] public ushort StartCutscene;
    [FieldOffset(0x38A)] public ushort EndCutscene;
    [FieldOffset(0x38C)] public bool WarpCanSkipCutscene;

    [FieldOffset(0x390)] public uint WarpLogicIconId;

    [FieldOffset(0x398)] public Utf8String Question;
    [FieldOffset(0x400)] public Utf8String ResponseYes;
    [FieldOffset(0x468)] public Utf8String ResponseNo;
    [FieldOffset(0x4D0)] public ushort Gil;
    [FieldOffset(0x4D2)] public ushort ClassLevel;
    [FieldOffset(0x4D4)] public byte CompleteParam;

    [FieldOffset(0x4D6)] public ushort RequiredQuest1;
    [FieldOffset(0x4D8)] public ushort RequiredQuest2;
    [FieldOffset(0x4DA)] public ushort RequiredQuest3;
    [FieldOffset(0x4DC)] public ushort RequiredQuest4;

    [FieldOffset(0x4E0)] public uint QuestReward;
    [FieldOffset(0x4E4)] public bool WarpLogicCanSkipCutscene;
}
