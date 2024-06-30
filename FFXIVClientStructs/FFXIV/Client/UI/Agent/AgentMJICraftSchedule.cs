using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMJICraftSchedule
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MJICraftSchedule)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentMJICraftSchedule {
    [FieldOffset(0x28)] public ScheduleData* Data;
    [FieldOffset(0x30)] public int CurReviewMaterialsTab;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xB60)]
    public unsafe partial struct ScheduleData {
        [FieldOffset(0x000)] public int UpdateState; // 0 initial, 1 request sent, 2 response received
        [FieldOffset(0x004)] public int OpenedModalAddonHandle;
        [FieldOffset(0x008)] public int OpenedModalAddonId;
        [FieldOffset(0x00C)] public int ReviewMaterialsAddonHandle;
        [FieldOffset(0x010)] public int ConfirmAddonHandle;
        // 0x018: substructure of size 0xA0, responsible for reading excel sheets
        [FieldOffset(0x0B8)] public StdVector<Utf8String> ThemeNames;
        [FieldOffset(0x0D0)] public StdVector<CraftData> Crafts; // [i] = MJICraftworksObject row i+1

        [FieldOffset(0x0E8), FixedSizeArray] internal FixedSizeArray32<StdVector<Pointer<CraftData>>> _unlockedObjectsPerTheme; // [i] = list of objects (filtered by level) for theme i+1

        [FieldOffset(0x3E8)] public StdVector<Pointer<CraftData>> CraftsSortedByName;

        [FieldOffset(0x400), FixedSizeArray] internal FixedSizeArray4<WorkshopData> _workshopSchedules;

        [FieldOffset(0x550)] public WorkshopData CopiedSchedule;

        // these fields are updated while user is selecting new crafts in the modal, before commiting them to the schedule, it might be a substructure (due to padding)
        [FieldOffset(0x5A8)] public uint CurScheduleSettingCraftIndex; // index into Crafts vector; updated when user selects different item in 'add' dialog
        [FieldOffset(0x5AC)] public int CurScheduleSettingWorkshop; // set when '+' is clicked
        [FieldOffset(0x5B0)] public int CurScheduleSettingStartingSlot; // set when '+' is clicked

        [FieldOffset(0x5B8), FixedSizeArray] internal FixedSizeArray5<MaterialData> _curScheduleSettingMaterials;

        [FieldOffset(0x7E8)] public byte CurScheduleSettingNumMaterials;
        [FieldOffset(0x7E9)] public byte CurScheduleSettingMaterialsInitializedMask;
        [FieldOffset(0x7EA)] public byte CurScheduleSettingThisWeekPopularity;
        [FieldOffset(0x7EB)] public byte CurScheduleSettingNextWeekPopularity;
        [FieldOffset(0x7EC)] public byte CurScheduleSettingSupply;
        [FieldOffset(0x7ED)] public byte CurScheduleSettingDemandShift;


        // these fields control supply/demand window state
        [FieldOffset(0x7F0)] public int CurSupplyDemandSort; // low byte = column, | 0x100 if reversed
        [FieldOffset(0x7F4)] public byte CurSupplyDemandFilterTime;
        [FieldOffset(0x7F5)] public byte CurSupplyDemandFilterCategory;
        [FieldOffset(0x7F6)] public byte CurSupplyDemandFilterThisWeekPopularity;
        [FieldOffset(0x7F7)] public byte CurSupplyDemandFilterNextWeekPopularity;
        [FieldOffset(0x7F8)] public byte CurSupplyDemandFilterSupply;
        [FieldOffset(0x7F9)] public byte CurSupplyDemandFilterDemandShift;
        [FieldOffset(0x7FA)] public byte CurSupplyDemandFilterFavors;

        [FieldOffset(0x7FC)] public int CurContextMenuScheduleEntryWorkshop;
        [FieldOffset(0x800)] public int CurContextMenuScheduleEntrySlot;
        [FieldOffset(0x804)] public int CurContextMenuSupplyDemandRow;
        [FieldOffset(0x808)] public int CurContextMenuPresetIndex;

        [FieldOffset(0x80C)] public uint Groove;
        [FieldOffset(0x810)] public uint RestCycles;
        [FieldOffset(0x814)] public uint NewRestCycles; // updated while user changes settings in the modal dialog
        [FieldOffset(0x818)] public Utf8String ConfirmPrompt;
        [FieldOffset(0x880)] public MaterialAllocation MaterialUse;
        [FieldOffset(0xB58)] public byte CycleDisplayed;
        [FieldOffset(0xB59)] public byte CycleInProgress;
        [FieldOffset(0xB5A)] public byte HourSinceCycleStart;
        [FieldOffset(0xB5B)] public byte IslandLevel;
        [FieldOffset(0xB5C)] public DataFlags1 Flags1;
        [FieldOffset(0xB5D)] public DataFlags2 Flags2;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x98)]
    public unsafe partial struct CraftData {
        // 0x0: first 0x20 bytes is a copy of MJICraftworksObject row data
        [FieldOffset(0x00)] public ushort ItemId;
        [FieldOffset(0x02), FixedSizeArray] internal FixedSizeArray3<ushort> _themeIds; // that's right, the game supports 3 themes, there are no such items though
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray4<ushort> _materialItemPouchRowIds;
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray4<ushort> _materialCosts;
        [FieldOffset(0x18)] public ushort LevelReq;
        [FieldOffset(0x1A)] public ushort CraftingTime;
        [FieldOffset(0x1C)] public ushort Value;

        [FieldOffset(0x20)] public ushort CraftObjectId; // MJICraftworksObject sheet
        [FieldOffset(0x22)] public ushort CraftIndex; // in Crafts vector
        [FieldOffset(0x24)] public uint IconId;
        [FieldOffset(0x28)] public ushort SortedByNameIndex; // in CraftsSortedByName vector
        [FieldOffset(0x2A)] public byte NumThemes;
        [FieldOffset(0x2B)] public bool Favor; // 0 = none, 1 = this week, 2 = next week
        [FieldOffset(0x2C)] public byte ThisWeekPopularity;
        [FieldOffset(0x2D)] public byte NextWeekPopularity;
        [FieldOffset(0x2E)] public byte Supply;
        [FieldOffset(0x2F)] public byte DemandShift;
        [FieldOffset(0x30)] public Utf8String Name;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x54)]
    public unsafe partial struct WorkshopData {
        [FieldOffset(0x00)] public byte NumScheduleEntries;
        [FieldOffset(0x01)] public byte NumEfficientCrafts;
        // 0x06: byte[6], [i] == i, not sure what is it's purpose

        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray6<EntryData> _entryData;

        [FieldOffset(0x50)] public uint UsedTimeSlots; // bit mask
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public unsafe partial struct EntryData {
        [FieldOffset(0x0)] public uint CraftObjectId;
        [FieldOffset(0x4)] public EntryFlags Flags;
        [FieldOffset(0x8)] public byte StartingSlot;
        [FieldOffset(0x9)] public byte Duration;
        [FieldOffset(0xA)] public bool Started;
        [FieldOffset(0xB)] public bool Efficient;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public unsafe partial struct MaterialData {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public uint IconRowId;
        [FieldOffset(0x6C)] public uint ItemRowId;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
    public unsafe partial struct MaterialAllocation {
        [FieldOffset(0x000), FixedSizeArray] internal FixedSizeArray3<MaterialAllocationEntry> _entries; // [0] = current cycle, [1] = current week, [2] = current + next week

        [FieldOffset(0x2A0)] public byte Cycle;
        [FieldOffset(0x2A1), FixedSizeArray] internal FixedSizeArray24<byte> _startingHours;
        [FieldOffset(0x2B9), FixedSizeArray] internal FixedSizeArray24<byte> _craftIds;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xE0)]
    public unsafe partial struct MaterialAllocationEntry {
        [FieldOffset(0x00)] public ushort EntryIndex;
        [FieldOffset(0x02), FixedSizeArray] internal FixedSizeArray109<ushort> _usedAmounts; // [i] = num allocated materials of type corresponding to i'th row of MJIItemPouch sheet
        [FieldOffset(0xDC)] public uint uDC;
    }

    [Flags]
    public enum DataFlags1 : byte {
        DataInitialized = 0x01, // set when the initial init process finishes
        MainAddonDirty = 0x02, // retry main addon updates during agent update until it succeeds
        MaterialsUpdated = 0x04, // set when schedule changes happen, if set updates MJIPouch agent on hide
        ScheduleSettingAddonDirty = 0x08, // retry schedule setting addon updates during agent update until it succeeds
        SelectedItemDirty = 0x10, // popularity/supply/demand for currently selected items are dirty, waiting for updated data
        RequisiteMaterialsAddonDirty = 0x20, // retry requisite materials addon updates during agent update until it succeeds
        ShowHelp = 0x40, // show help asap
        ReviewMaterialsAddonDirty = 0x80, // retry review materials addon updates during agent update until it succeeds (only in 'ReviewMaterialsOnly' mode?)
    }

    [Flags]
    public enum DataFlags2 : byte {
        PlayScheduleUpdateSFX = 0x01, // schedule update initiated, play sfx when response is received
        ReviewMaterialsOnly = 0x02, // do not show main addon, show only 'review materials' (initiated by button in main hud)
        DerivedDataDirty = 0x04, // derived data for workshop schedules (flags, etc) dirty
        ScheduleDataAvailable = 0x08,
        DisableInteraction = 0x10, // ui interaction disabled while schedule data is dirty
    }

    [Flags]
    public enum EntryFlags : uint {
        InPresent = 0x01, // current time is between slot start and end (craft could be in progress or it could fail to start due to lack of materials)
        Linked = 0x02, // either this craft or next craft is efficient
        Failed = 0x04, // craft failed to start due to lack of materials
        Succeeded = 0x08, // craft is successful
        InPast = 0x10, // current time is after slot end (craft could be completed or failed)
        LinkedToPrev = 0x20, // this craft is going be efficient
        InProgress = 0x40, // this craft is in progress
        Efficient = 0x80, // this craft is confirmed to be efficient
        ThisWeekFavor = 0x100, // this is this week's favor
        NextWeekFavor = 0x200, // this is next week's favor
    }

    /// <summary>
    /// Activate specified cycle.
    /// Note that game often reactivates same cycle to refresh data, e.g. after scheduling new craft.
    /// </summary>
    /// <param name="cycle">0-13 range, this/next week in order.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 45 28 48 8B 7C 24")]
    public partial void SetDisplayedCycle(int cycle);
}
