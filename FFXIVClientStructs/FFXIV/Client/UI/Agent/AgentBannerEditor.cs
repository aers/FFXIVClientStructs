using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// ctor "40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 53 30"
[Agent(AgentId.BannerEditor)]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentBannerEditor {
    [FieldOffset(0)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public AgentBannerEditorState* EditorState;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 48 83 3D ?? ?? ?? ?? ?? 8B FA 48 8B D9 0F 84")]
    public readonly partial void OpenForGearset(int gearsetId);
}

[StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
public unsafe partial struct AgentBannerEditorState {
    public enum EditorOpenType : int {
        Portrait = 0,
        Gearset = 1,
        AdventurerPlate = 2,
    }

    /// <remarks>
    /// <code>
    /// |---------------|---------------|--------------------|-----------------------|
    /// | Dataset Index | Dataset Usage | Row Sheet          | SupplementalRow Sheet |
    /// |---------------|---------------|--------------------|-----------------------|
    /// | 0             | Presets       | BannerDesignPreset |                       |
    /// | 1             | Backgrounds   | BannerBg           |                       |
    /// | 2             | Frames        | BannerFrame        |                       |
    /// | 3             | Accents       | BannerDecoration   |                       |
    /// | 4             | Poses         | BannerTimeline     | Action                |
    /// | 5             | Expressions   | BannerFacial       | Emote                 |
    /// |---------------|---------------|--------------------|-----------------------|
    /// </code>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct DatasetEntry {
        [FieldOffset(0)] public nint Row;
        [FieldOffset(0x8)] public nint SupplementalRow;
        [FieldOffset(0x10)] public ushort RowId;
        [FieldOffset(0x12)] public ushort SortKey;
        [FieldOffset(0x14)] public byte BannerConditionUnlockState; // return value of GetBannerConditionUnlockState
        [FieldOffset(0x15)] public bool ClassJobMatches; // only for Poses
        // 2 unused bytes?!
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct Dataset {
        [FieldOffset(0)] public DatasetEntry** SortedEntries; // sorted array of pointers to entries (ordered by SortKey)
        [FieldOffset(0x8)] public uint SortedEntriesCount; // the amount of entries in the sorted array
        [FieldOffset(0xC)] public uint MaxSortedEntriesCount; // the length of the sorted array
        [FieldOffset(0x10)] public DatasetEntry** UnlockedEntries; // sorted array of entries where BannerConditionUnlockState is 0 and ClassJobMatches is true
        [FieldOffset(0x18)] public uint UnlockedEntriesCount;
        [FieldOffset(0x1C)] public uint MaxUnlockedEntriesCount;
        [FieldOffset(0x20)] public DatasetEntry* UnsortedEntries; // unsorted array of entries
        [FieldOffset(0x28)] public uint UnsortedEntriesCount;
        [FieldOffset(0x2C)] public byte DatasetIndex;
        // 3 unused bytes?!
    }

    [Obsolete("Use DatasetEntry", true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct GenericDropdownItem {
        [FieldOffset(0)] public nint Data;
        [FieldOffset(0x10)] public ushort Id;
    }

    [Obsolete("Use DatasetEntry", true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct ExpressionDropdownItem {
        [FieldOffset(0x08)] public nint Data;
        [FieldOffset(0x10)] public ushort Id;
    }

    // Datasets are created here: "E8 ?? ?? ?? ?? 48 8B 4D 28 E8"
    [FieldOffset(0)] public Dataset Presets;
    [FieldOffset(0x30)] public Dataset Backgrounds;
    [FieldOffset(0x60)] public Dataset Frames;
    [FieldOffset(0x90)] public Dataset Accents;
    [FieldOffset(0xC0)] public Dataset Poses;
    [FieldOffset(0xF0)] public Dataset Expressions;

    [Obsolete("Use Presets.UnsortedEntries", true)]
    [FieldOffset(0x20)] public nint PresetItems;
    [Obsolete("Use Presets.UnsortedEntriesCount", true)]
    [FieldOffset(0x28)] public uint PresetItemsCount;

    [Obsolete("Use Backgrounds.UnlockedEntries", true)]
    [FieldOffset(0x40)] public GenericDropdownItem** BackgroundItems;
    [Obsolete("Use Backgrounds.UnlockedEntriesCount", true)]
    [FieldOffset(0x48)] public uint BackgroundItemsCount;

    [Obsolete("Use Frames.UnlockedEntries", true)]
    [FieldOffset(0x70)] public GenericDropdownItem** FrameItems;
    [Obsolete("Use Frames.UnlockedEntriesCount", true)]
    [FieldOffset(0x78)] public uint FrameItemsCount;

    [Obsolete("Use Accents.UnlockedEntries", true)]
    [FieldOffset(0xA0)] public GenericDropdownItem** AccentItems;
    [Obsolete("Use Accents.UnlockedEntriesCount", true)]
    [FieldOffset(0xA8)] public uint AccentItemsCount;

    [Obsolete("Use Poses.UnlockedEntries", true)]
    [FieldOffset(0xD0)] public GenericDropdownItem** BannerTimelineItems;
    [Obsolete("Use Poses.UnlockedEntriesCount", true)]
    [FieldOffset(0xD8)] public uint BannerTimelineItemsCount;

    [Obsolete("Use Expressions.UnlockedEntries", true)]
    [FieldOffset(0x100)] public ExpressionDropdownItem** ExpressionItems;
    [Obsolete("Use Expressions.UnlockedEntriesCount", true)]
    [FieldOffset(0x108)] public uint ExpressionItemsCount;

    [FieldOffset(0x120)] public BannerModuleEntry BannerEntry;

    [FieldOffset(0x240)] public fixed uint ItemIds[14];
    [FieldOffset(0x278)] public fixed byte StainIds[14];

    [FieldOffset(0x288)] public uint Checksum;
    [FieldOffset(0x28C)] public BannerGearVisibilityFlag GearVisibilityFlag;
    [FieldOffset(0x290)] public byte GearsetIndex;
    [FieldOffset(0x291)] public byte ClassJobId;

    [FieldOffset(0x298)] public AgentBannerEditor* AgentBannerEditor;
    [FieldOffset(0x2A0)] public UIModule* UIModule;
    [FieldOffset(0x2A8)] public CharaViewPortrait* CharaView;

    [FieldOffset(0x2B8)] public EditorOpenType OpenType;

    [FieldOffset(0x2C4)] public uint FrameCountdown; // starting at 0.5s on open
    [FieldOffset(0x2C8)] public int GearsetId;

    [FieldOffset(0x2D0)] public int CloseDialogAddonId;
    [FieldOffset(0x2D4)] public bool HasDataChanged;

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 8B CE E8 ?? ?? ?? ?? 48 8B 8E")]
    public readonly partial void Save();

    [MemberFunction("48 89 5C 24 ?? 48 89 7C 24 ?? 80 79 2C 00")]
    public readonly partial int GetPresetIndex(ushort backgroundIndex, ushort frameIndex, ushort accentIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0A E8 45 8B C7")]
    public readonly partial void SetFrame(int frameId);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 64 24 ?? 44 0A E8")]
    public readonly partial void SetAccent(int accentId);

    [MemberFunction("E8 ?? ?? ?? ?? 32 C0 48 8B 4D 37")]
    public readonly partial void SetHasChanged(bool hasDataChanged);
}
