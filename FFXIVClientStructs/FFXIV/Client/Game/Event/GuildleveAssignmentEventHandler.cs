using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::GuildleveAssignmentEventHandler
//   Client::Game::Event::LuaEventHandler
//     Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<LuaEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x768)]
public unsafe partial struct GuildleveAssignmentEventHandler {
    /// <summary>
    /// Type Column of its GuildleveAssignment Row
    /// </summary>
    [FieldOffset(0x2D8)] public Utf8String Type;
    [FieldOffset(0x340)] public GuildleveType CurrentLeveType;
    [FieldOffset(0x344), FixedSizeArray] internal FixedSizeArray6<int> _categorySelection;
    /// <summary>
    /// Shows the first leveid of the category.
    /// </summary>
    [FieldOffset(0x35C), FixedSizeArray] internal FixedSizeArray6<ushort> _listLeveId;
    [FieldOffset(0x368 + 0x00), CExporterExcelBegin("GuildleveAssignment")] private uint TypeStringOffset;
    [FieldOffset(0x368 + 0x04)] public uint AssignmentTalk;
    [FieldOffset(0x368 + 0x08)] public uint Quest0;
    [FieldOffset(0x368 + 0x0C)] public uint Quest1;
    [FieldOffset(0x368 + 0x10)] private byte Unknown0;
    [FieldOffset(0x368 + 0x11)] private byte RequiredGrandCompanyRank;
    [FieldOffset(0x368 + 0x12), CExporterExcelEnd] private byte PackedBool12;
    [FieldOffset(0x380), CExporterExcel("GuildleveAssignmentTalk")] public nint AssignmentTalkRow;

    [FieldOffset(0x388), CExporterExcel("EventIconType")] public nint EventIconTypeRow;
    [FieldOffset(0x390), CExporterExcel("CraftLeve")] public nint SelectedCraftLeveRow;
    [FieldOffset(0x398)] private int Unk398;

    [FieldOffset(0x3A0), FixedSizeArray] internal FixedSizeArray4<RewardItem> _rewardItems;
    [FieldOffset(0x6A0)] private int Unk6A0;

    [FieldOffset(0x6A8), CExporterExcel("GatheringLeve")] public nint SelectedGatheringLeveRow;
    [FieldOffset(0x6B0)] public ushort SelectedGatheringLeveId;
    [FieldOffset(0x6B2)] public ushort SelectedLeveId;
    [FieldOffset(0x6B4)] private ushort Unk6B4;

    [FieldOffset(0x6B8)] public GuildleveAssignmentLeve* SelectedLeveEntry;
    [FieldOffset(0x6C0)] public StdVector<GuildleveAssignmentCategoryList> AssignmentLists;
    // No idea about this one. Showed ids (probably leve ids)
    //[FieldOffset(0x6D8)] private StdMap<ushort, GuildleveLeveInfo> LeveInfoMap;
    // No idea if the following three are correct. They temporarily get set when you open a new tab when it is loaded. 
    [FieldOffset(0x6E8)] private StdVector<ushort> PendingLeveIds;
    [FieldOffset(0x700)] private long PendingLeveCursor;
    [FieldOffset(0x708)] private ExcelSheet* PendingSheet;
    [FieldOffset(0x710)] public ExcelSheetWaiter* SheetWaiter;
    [FieldOffset(0x718)] public StdVector<uint> RewardLeveIds;
    [FieldOffset(0x730)] public StdMap<ushort, uint> RewardItemMap;
    [FieldOffset(0x740)] public StdVector<Utf8String> DifficultyLabels;
    [FieldOffset(0x758)] private int Unk758;
    [FieldOffset(0x75C)] private bool Unk75C;
    [FieldOffset(0x75D)] private bool Unk75D; // Something about the HowTo window

    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public struct RewardItem {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public InventoryItem Item;
        [FieldOffset(0xB0)] private ushort Unk0B0;
        [FieldOffset(0xB4)] private uint Unk0B4;
        [FieldOffset(0xB8)] private bool Unk0B8;
        [FieldOffset(0xBC)] private uint Unk0BC;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct GuildleveAssignmentCategoryList {
        [FieldOffset(0x00)] public StdVector<GuildleveAssignmentGroup> Groups;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct GuildleveAssignmentGroup {
        [FieldOffset(0x00)] public StdVector<GuildleveAssignmentSubList> SubLists;
        [FieldOffset(0x18)] public uint Flags;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct GuildleveAssignmentSubList {
        [FieldOffset(0x00)] public StdVector<GuildleveAssignmentLeve> Leves;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xE8)]
    public struct GuildleveAssignmentLeve {
        [FieldOffset(0x00)] public ushort LeveId;
        [FieldOffset(0x08)] public Utf8String Name;
        [FieldOffset(0x70)] public Utf8String ClientName;
        [FieldOffset(0xD8)] public ushort ClassJobLevel;
        [FieldOffset(0xDA)] private byte Unk0DA;
        [FieldOffset(0xDC)] public uint GenreIcon;
        [FieldOffset(0xE0)] private int Unk0E0;
    }

    public enum GuildleveType {
        Battlecraft,
        Fieldcraft,
        Tradecraft,
        Maelstrom,
        OrderOfTheTwinAdder,
        ImmortalFlames
    }
}
