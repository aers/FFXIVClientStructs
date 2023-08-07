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

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct GenericDropdownItem {
        [FieldOffset(0)] public nint Data;
        [FieldOffset(0x10)] public ushort Id;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct ExpressionDropdownItem {
        [FieldOffset(0x08)] public nint Data;
        [FieldOffset(0x10)] public ushort Id;
    }

    [FieldOffset(0x20)] public nint PresetItems;
    [FieldOffset(0x28)] public uint PresetItemsCount;

    [FieldOffset(0x40)] public GenericDropdownItem** BackgroundItems;
    [FieldOffset(0x48)] public uint BackgroundItemsCount;

    [FieldOffset(0x70)] public GenericDropdownItem** FrameItems;
    [FieldOffset(0x78)] public uint FrameItemsCount;

    [FieldOffset(0xA0)] public GenericDropdownItem** AccentItems;
    [FieldOffset(0xA8)] public uint AccentItemsCount;

    [FieldOffset(0xD0)] public GenericDropdownItem** BannerTimelineItems;
    [FieldOffset(0xD8)] public uint BannerTimelineItemsCount;

    [FieldOffset(0x100)] public ExpressionDropdownItem** ExpressionItems;
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
