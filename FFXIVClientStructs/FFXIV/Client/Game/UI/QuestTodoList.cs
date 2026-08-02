using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::QuestTodoList
//   Client::Game::UI::ScenarioTextReader
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x440)]
public unsafe partial struct QuestTodoList {
    [FieldOffset(0xA8)] public TodoStruct Todo;

    // [FieldOffset(0x308)] public uint NumQuestRowsToLoad;
    // [FieldOffset(0x320)] public uint NumLeveRowsToLoad;

    // [FieldOffset(0x32C)] public uint PendingItemRowIdIndex;

    [FieldOffset(0x33C)] public int PendingGatheringLeveRowIdIndex;
    [FieldOffset(0x340)] public ExcelSheet* QuestSheet;
    [FieldOffset(0x348)] public ExcelSheetWaiter* QuestSheetWaiter;
    [FieldOffset(0x350)] public ExcelSheet* LeveSheet;
    [FieldOffset(0x358)] public ExcelSheetWaiter* LeveSheetWaiter;
    [FieldOffset(0x360)] public ExcelSheet* CraftLeveSheet;
    [FieldOffset(0x368)] public ExcelSheetWaiter* CraftLeveSheetWaiter;
    [FieldOffset(0x370)] public ExcelSheet* ItemSheet;
    [FieldOffset(0x378)] public ExcelSheetWaiter* ItemSheetWaiter;
    [FieldOffset(0x380)] public ExcelSheet* GatheringLeveSheet;
    [FieldOffset(0x388)] public ExcelSheetWaiter* GatheringLeveSheetWaiter;
    [FieldOffset(0x390)] public ExcelSheet* FishingSpotSheet;
    [FieldOffset(0x398), FixedSizeArray] internal FixedSizeArray10<Pointer<ExcelSheetWaiter>> _fishingSpotSheetWaiters;
    [FieldOffset(0x3E8)] public ExcelSheet* SpearfishingNotebookSheet;
    [FieldOffset(0x3F0), FixedSizeArray] internal FixedSizeArray10<Pointer<ExcelSheetWaiter>> _spearfishingNotebookSheetWaiters;

    // [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x228)]
    public partial struct TodoStruct {
        // ExcelSheetWaiter stuff here, but not sure how it works or if correct
        // [FieldOffset(0x00)] public ushort NumQuestRowsLoaded;
        // [FieldOffset(0x02)] public ushort NumLeveRowsLoaded;
        // [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray10<uint> _pendingQuestRowIds;
        // [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray10<uint> _pendingLeveRowIds;
        // [FieldOffset(0x54), FixedSizeArray] internal FixedSizeArray10<uint> _pendingItemRowIds;
        // [FieldOffset(0x54), FixedSizeArray] internal FixedSizeArray10<uint> _pendingGatheringLeveRowIds;
        // more unknown arrays at 0xA4
        [FieldOffset(0x20C)] private byte Unk20C;
        [FieldOffset(0x210)] public StdVector<TrackedQuest> TrackedQuests;

        /*
        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x28)]
        public partial struct PendingRowIdsArray {
            [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray10<int> _values;
        }

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x24)]
        public partial struct SubStructA4 {
            [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray9<uint> _values;
        }
        */
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x2FC8)]
    public partial struct TrackedQuest {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public Utf8String Id;
        [FieldOffset(0xD0)] public byte Sequence;

        [FieldOffset(0xD2)] public ushort QuestId;
        [FieldOffset(0xD4)] private int UnkD4;
        [FieldOffset(0xD8)] public uint IconId;

        [FieldOffset(0xE0)] public int ObjectivesCount;

        [FieldOffset(0xE8), FixedSizeArray] internal FixedSizeArray24<QuestObjective> _objectives;

        [FieldOffset(0x2F78)] public int CurrentObjective;
        [FieldOffset(0x2F7C)] private int Unk2F7C; // ObjectivesCount2?
        [FieldOffset(0x2F80)] public int LeveDataId; // Level.DataId
        [FieldOffset(0x2F84)] public int LeveAssignmentType; // Level.AssignmentType
        [FieldOffset(0x2F88)] public int LeveFishingSpot; // Level.FishingSpot
        [FieldOffset(0x2F8C)] public int LeveSpearfishingNotebook; // Level.SpearfishingNotebook
        [FieldOffset(0x2F90), FixedSizeArray] internal FixedSizeArray8<uint> _itemIds;
        // [FieldOffset(0x2FB0), FixedSizeArray] internal FixedSizeArray4<byte> _itemUnks;
        [FieldOffset(0x2FB4)] public int ItemCount;
        [FieldOffset(0x2FB8)] public uint LeveLevemeteLevel; // Level.LevelLevemete
        [FieldOffset(0x2FBC)] public int LevelPlaceNameStartZone; // Level.PlaceNameStartZone
        [FieldOffset(0x2FC0)] public ushort ClassJobLevel;

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
        public partial struct QuestObjective {
            [FieldOffset(0x00)] public bool IsTodoChecked;

            [FieldOffset(0x08)] public Utf8String Objective;
            [FieldOffset(0x70)] public uint Sequence; // byte? int?

            [FieldOffset(0x78)] public Utf8String ProgressText;
            [FieldOffset(0xE0)] public int TodoArg0;
            [FieldOffset(0xE4)] public int TodoArg1;
            [FieldOffset(0xE8)] public uint TerritoryTypeId;
            [FieldOffset(0xEC)] public uint MapId;
            [FieldOffset(0xF0)] public uint PlaceNameZoneId;
            [FieldOffset(0xF4), FixedSizeArray] internal FixedSizeArray8<LevelEntry> _levelEntries;

            [FieldOffset(0x1E0)] public uint QuestClassJob;
            [FieldOffset(0x1E4)] public int TodoArg2;
            [FieldOffset(0x1E8)] public byte ToDoParamCountableNum;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
        public struct LevelEntry {
            [FieldOffset(0x00)] public uint PlaceNameId;
            [FieldOffset(0x04)] public uint LevelId;
            [FieldOffset(0x08)] public float X;
            [FieldOffset(0x0C)] public float Y;
            [FieldOffset(0x10)] public float Z;
            [FieldOffset(0x14)] public float Radius;
            [FieldOffset(0x18)] public uint Icon;
        }
    }
}
