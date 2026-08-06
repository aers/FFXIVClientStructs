using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFishGuide
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.FishGuide)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe partial struct AgentFishGuide {
    [FieldOffset(0x28)] public uint SelectedItemId;
    [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray2<TabSelection> _tabSelections; // indexed with Mode
    [FieldOffset(0x30)] public bool IsSearchTab;
    [FieldOffset(0x31)] public AgentFishGuideMode Mode;
    [FieldOffset(0x32)] public bool IsSpearfishingUnlocked; // checks quest 2922

    [FieldOffset(0x40)] public uint FilterSettingAddonId; // FishGuideFilterSetting
    [FieldOffset(0x44)] public ushort SelectedIndex;
    /// <remarks> Depending on Mode either <see cref="FishGuideData"/>* or <see cref="SpearfishGuideData"/>* </remarks>
    [FieldOffset(0x48)] public FishGuideDataBase* Data;
    [FieldOffset(0x50)] public ushort FilterPlaceNameRegion;
    [FieldOffset(0x52)] public ushort FilterGatheringSubCategory;
    [FieldOffset(0x54)] public bool FilterBigFishEnabled;
    [FieldOffset(0x55)] public bool FilterCollectibleEnabled;
    [FieldOffset(0x56)] public bool FilterAquariumEnabled;
    [FieldOffset(0x57)] public byte FilterAquariumSize;
    [FieldOffset(0x58)] public byte FilterAquariumWater;

    [FieldOffset(0x60)] public FishGuideSearchData* SearchData;

    [FieldOffset(0x70)] public Utf8String SearchTerm;
    [FieldOffset(0xD8)] public Utf8String DetailsCategoryTitle1; // Addon#3823, lnum1 is Mode
    [FieldOffset(0x140)] public Utf8String DetailsCategoryTitle2; // Addon#14367, lnum1 is Mode

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 44 0F B6 C3 33 D2")]
    public partial void OpenForItemId(uint itemId, bool isSpearfishing); // TODO: use AgentFishGuideMode instead of bool

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4B 48")]
    public partial void UpdateFishList(); // sets entries to NumberArray #67 and then refreshes the icons

    [StructLayout(LayoutKind.Explicit, Size = 0x02)]
    public struct TabSelection {
        [FieldOffset(0x00)] public byte PageIndex;
        [FieldOffset(0x01)] public sbyte SelectedIndex;
    }

    // Client::UI::Agent::AgentFishGuide::FishGuideDataBase
    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x458)]
    public unsafe partial struct FishGuideDataBase {
        [FieldOffset(0x08)] public AgentFishGuide* Agent;
        [FieldOffset(0x10)] public StdVector<FishGuideListEntry> Entries;
        [FieldOffset(0x28)] public StdVector<Pointer<FishGuideListEntry>> FilteredEntries;
        [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray100<int> _pageIcons;
        [FieldOffset(0x1D0)] public SelectedFishInfo FishInfo;
        [FieldOffset(0x340)] public StdSet<ushort> LoadedGatheringSubCategories;
        [FieldOffset(0x350)] public StdSet<ushort> LoadedPlaceNameRegions;
        [FieldOffset(0x360)] public StdVector<PlaceNameEntry> PlaceNames;
        [FieldOffset(0x378)] public ushort FilterPlaceNameRegion;
        [FieldOffset(0x37A)] public ushort FilterGatheringSubCategory;
        [FieldOffset(0x37C)] public bool FilterBigFishEnabled;
        [FieldOffset(0x37D)] public bool FilterCollectibleEnabled;
        [FieldOffset(0x37E)] public bool FilterAquariumEnabled;
        [FieldOffset(0x37F)] public byte FilterAquariumSize;
        [FieldOffset(0x380)] public byte FilterAquariumWater;

        [FieldOffset(0x382)] public bool IsFilteredEntriesLoaded;
        [FieldOffset(0x383)] public bool HasCaughtBigFish;

        [StructLayout(LayoutKind.Explicit, Size = 0x14)]
        public struct FishGuideListEntry {
            [FieldOffset(0x00)] public uint ItemId;
            /// <remarks> RowId of either FishParameter or SpearfishingItem </remarks>
            [FieldOffset(0x04)] public ushort Id;
            /// <remarks> FishParameter.Unknown1 / SpearfishingItem.Unknown2 </remarks>
            [FieldOffset(0x06)] private ushort Unk6;
            [FieldOffset(0x08)] public ushort GatheringSubCategoryId;
            /// <remarks> RowId of either FishingSpot or SpearfishingNotebook </remarks>
            [FieldOffset(0x0A)] public ushort SpotId;
            [FieldOffset(0x0C)] public byte Size;
            [FieldOffset(0x0D)] public byte AquariumWater;
            [FieldOffset(0x0E)] public bool IsCaught;
            [FieldOffset(0x0F)] public bool IsCollectable;
            /// <remarks> FishParameter.AchievementCredit != 0 </remarks>
            [FieldOffset(0x10)] public bool IsBigFish;
            [FieldOffset(0x11)] public bool IsHidden;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x170)]
        public struct SelectedFishInfo {
            [FieldOffset(0x00)] public FishGuideListEntry Entry;
            [FieldOffset(0x18)] public Utf8String Name;
            [FieldOffset(0x80)] public Utf8String Description;
            [FieldOffset(0xE8)] public Utf8String BaitName;
            [FieldOffset(0x150)] public uint IconId;
            [FieldOffset(0x154)] public uint BaitItemId; // used for an Item ExcelSheetWaiter
            [FieldOffset(0x158)] private uint Unk158;
            [FieldOffset(0x15C)] private ushort Unk15C;
            [FieldOffset(0x15E)] public ushort GatheringItemLevel;
            [FieldOffset(0x160)] private ushort Unk160;
            [FieldOffset(0x162)] private ushort Unk162;
            [FieldOffset(0x164)] public byte OceanStars;
            [FieldOffset(0x165)] public byte FishingRecordType;
            [FieldOffset(0x166)] public bool IsInLog;
            [FieldOffset(0x167)] public bool IsCaught;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x06)]
        public struct PlaceNameEntry {
            [FieldOffset(0x00)] public ushort PlaceName;
            [FieldOffset(0x02)] public ushort TerritoryPlaceNameRegion;
            [FieldOffset(0x04)] public ushort TerritoryPlaceName;
        }
    }

    // Client::UI::Agent::AgentFishGuide::FishGuideSheetWaiter
    //   Common::Component::Excel::ExcelSheetWaiter
    [GenerateInterop]
    [Inherits<ExcelSheetWaiter>]
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct FishGuideSheetWaiter {
        [FieldOffset(0x70)] public void* CallbackFn; // 5 args!?
        [FieldOffset(0x80)] public void* CallbackThisArg;
        [FieldOffset(0x88)] public uint SheetIndex;
    }

    // Client::UI::Agent::AgentFishGuide::FishGuideData
    //   Client::UI::Agent::AgentFishGuide::FishGuideDataBase
    [GenerateInterop]
    [Inherits<FishGuideDataBase>]
    [StructLayout(LayoutKind.Explicit, Size = 0x5A8)]
    public partial struct FishGuideData {
        [FieldOffset(0x458)] private FishGuideSheetWaiter SheetWaiter1;
        [FieldOffset(0x4F8)] private FishGuideSheetWaiter SheetWaiter2;
        [FieldOffset(0x598)] private ExcelSheetWaiter* ItemSheetWaiter;
        [FieldOffset(0x5A0)] private ExcelSheetWaiter* FishParameterSheetWaiter;
    }

    // Client::UI::Agent::AgentFishGuide::SpearfishGuideSheetWaiter
    //   Common::Component::Excel::ExcelSheetWaiter
    [GenerateInterop]
    [Inherits<ExcelSheetWaiter>]
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct SpearfishGuideSheetWaiter {
        [FieldOffset(0x70)] public void* CallbackFn; // 5 args!?
        [FieldOffset(0x80)] public void* CallbackThisArg;
        [FieldOffset(0x88)] public uint SheetIndex;
    }

    // Client::UI::Agent::AgentFishGuide::SpearfishGuideData
    //   Client::UI::Agent::AgentFishGuide::FishGuideDataBase
    [GenerateInterop]
    [Inherits<FishGuideDataBase>]
    [StructLayout(LayoutKind.Explicit, Size = 0x5A0)]
    public partial struct SpearfishGuideData {
        [FieldOffset(0x458)] private SpearfishGuideSheetWaiter SheetWaiter1;
        [FieldOffset(0x4F8)] private SpearfishGuideSheetWaiter SheetWaiter2;
        [FieldOffset(0x598)] private ExcelSheetWaiter* SpearfishingItemSheetWaiter;
    }

    // Client::UI::Agent::AgentFishGuide::FishGuideSearchData
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xB8)]
    public unsafe partial struct FishGuideSearchData {
        [FieldOffset(0x00)] public AgentFishGuide* Agent;
        [FieldOffset(0x08)] public FishGuideDataBase* Data;
        [FieldOffset(0x10)] public Utf8String SearchTerm;
        [FieldOffset(0x78)] public ExcelSheetWaiter* ItemSheetWaiter;
        [FieldOffset(0x80)] private StdVector<ItemEntry> Items; // used by ItemSheetWaiter, whatever
        [FieldOffset(0x98)] private uint UnkItemsOffset;
        [FieldOffset(0xA0)] public StdVector<SearchResult> Results;

        [StructLayout(LayoutKind.Explicit, Size = 0x08)]
        private struct ItemEntry {
            [FieldOffset(0x00)] public uint Index;
            [FieldOffset(0x04)] public uint ItemId;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x78)]
        public struct SearchResult {
            [FieldOffset(0x00)] public uint EntryIndex;
            [FieldOffset(0x04)] public uint ItemId;
            [FieldOffset(0x08)] public uint IconId;
            [FieldOffset(0x10)] public Utf8String Name;
        }
    }
}

public enum AgentFishGuideMode : byte {
    Fishing = 0,
    Spearfishing = 1,
}
