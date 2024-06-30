using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentBannerEditor
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 53 30"
[Agent(AgentId.BannerEditor)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentBannerEditor {
    [FieldOffset(0x28)] public AgentBannerEditorState* EditorState;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 48 83 3D ?? ?? ?? ?? ?? 8B FA 48 8B D9 0F 84")]
    public partial void OpenForGearset(int gearsetId);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3F8)]
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

    // Datasets are created here: "E8 ?? ?? ?? ?? 48 8B 4D 28 E8 ?? ?? ?? ?? 48 8B 45 28"
    [FieldOffset(0)] public Dataset Presets;
    [FieldOffset(0x30)] public Dataset Backgrounds;
    [FieldOffset(0x60)] public Dataset Frames;
    [FieldOffset(0x90)] public Dataset Accents;
    [FieldOffset(0xC0)] public Dataset Poses;
    [FieldOffset(0xF0)] public Dataset Expressions;

    // 7.0: new filters here

    [FieldOffset(0x230)] public BannerModuleEntry BannerEntry;

    [FieldOffset(0x350), FixedSizeArray] internal FixedSizeArray14<uint> _itemIds;
    [FieldOffset(0x388), FixedSizeArray] internal FixedSizeArray14<byte> _stain0Ids;
    [FieldOffset(0x396), FixedSizeArray] internal FixedSizeArray14<byte> _stain1Ids;

    [FieldOffset(0x3A8)] public uint Checksum;
    [FieldOffset(0x3AC)] public BannerGearVisibilityFlag GearVisibilityFlag;
    [FieldOffset(0x3B0)] public byte GearsetIndex;
    [FieldOffset(0x3B1)] public byte ClassJobId;

    [FieldOffset(0x3B8)] public AgentBannerEditor* AgentBannerEditor;
    [FieldOffset(0x3C0)] public UIModule* UIModule;
    [FieldOffset(0x3C8)] public CharaViewPortrait* CharaView;

    [FieldOffset(0x3D8)] public EditorOpenType OpenType;

    [FieldOffset(0x3E4)] public float FrameCountdown; // starting at 0.5s on open
    [FieldOffset(0x3E8)] public int GearsetId;

    [FieldOffset(0x3F0)] public int CloseDialogAddonId;
    [FieldOffset(0x3F4)] public bool HasDataChanged;

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 8B CF E8 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 48 8B 01 FF 50 58")]
    public partial void Save();

    [MemberFunction("48 89 5C 24 ?? 48 89 7C 24 ?? 80 79 2C 00")]
    public partial int GetPresetIndex(ushort backgroundIndex, ushort frameIndex, ushort accentIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 74 24 ?? 44 0A F8")]
    public partial void SetFrame(int frameId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 6C 24 ?? 44 0A F8")]
    public partial void SetAccent(int accentId);

    [MemberFunction("E8 ?? ?? ?? ?? 32 C0 EB 3F")]
    public partial void SetHasChanged(bool hasDataChanged);
}
