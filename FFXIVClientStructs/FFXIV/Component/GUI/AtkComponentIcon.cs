using FFXIVClientStructs.FFXIV.Client.Graphics;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentIcon
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 15
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x138)]
public unsafe partial struct AtkComponentIcon : ICreatable {
    [FieldOffset(0xC0)] public uint IconId;
    [FieldOffset(0xC4)] public IconSubFolder IconSubFolder;
    [FieldOffset(0xC8)] public AtkUldAsset* Texture;
    [FieldOffset(0xD0)] public AtkResNode* FrameContainer;
    [FieldOffset(0xD0), Obsolete("Renamed to FrameContainer")] public AtkResNode* IconAdditionsContainer;
    [FieldOffset(0xD8)] public AtkResNode* ComboBorder;
    [FieldOffset(0xE0)] public AtkResNode* Frame;
    [FieldOffset(0xE8)] public AtkResNode* OuterResNode; // seems to be used for showing tooltips and mouse click to open a window
    [FieldOffset(0xF0)] public AtkImageNode* IconImage;
    [FieldOffset(0xF8)] public AtkImageNode* FrameIcon;
    [FieldOffset(0x100)] public AtkTextNode* QuantityText;
    [FieldOffset(0x108), FixedSizeArray] internal FixedSizeArray2<ByteColor> _dyeColors;
    [FieldOffset(0x110), FixedSizeArray] internal FixedSizeArray2<IndicatorNodesEntry> _indicatorNodes;
    [FieldOffset(0x130)] public IconComponentFlags Flags;

    [MemberFunction("33 D2 C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 51 08 48 8D 05 ?? ?? ?? ?? 48 89 51 10 48 89 51 18 48 89 51 20 48 89 51 28 48 89 51 30 48 89 51 38 48 89 51 40 89 51 48 48 89 51 50 48 89 51 58 48 89 51 60 48 89 51 68 89 51 70 48 89 51 78 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 66 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 88 91 ?? ?? ?? ?? 48 89 01 48 8B C1 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ??")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 8D 4D 12")]
    public partial bool LoadIcon(uint iconId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 4D 12")]
    public partial bool LoadLocalizedIcon(LocalizedIconInfo* info);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 03 F6 D0")]
    public partial void UnloadIcon();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 08 49 8B CD")]
    public partial bool IsIconLoaded();

    // as seen in AtkComponentDragDrop.ReceiveEvent:
    // 2 = MouseOver
    // 3 = MouseDown
    // 4 = MouseOut
    // 6 = MouseUp
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 84 DF")]
    public partial void SetTimelineState(ushort keyframeValue);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8B C4 40 0F B6 D6")]
    public partial void SetFrameLabelId(byte timelineId);

    [MemberFunction("E9 ?? ?? ?? ?? 83 F9 64")]
    public partial void SetCooldownProgress(float progress);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 47 08")]
    public partial void SetDyeColor(ByteColor color, int channel);

    [MemberFunction("E8 ?? ?? ?? ?? 66 41 89 AF")]
    public partial void SetIconImageDisableState(bool disabled); // if true, sets MultiplyRed/Green/Blue to 50. 100 otherwise

    [MemberFunction("48 8B 81 ?? ?? ?? ?? 48 85 C0 74 15 48 8B 40 10")]
    public partial byte GetFrameLabelId();

    [MemberFunction("E8 ?? ?? ?? ?? C1 EB 02 49 8B CE")]
    public partial void SetHasFirstDyeChannel(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 0F 41 C1 EC 06")]
    public partial void SetIsDyeLocked(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? 41 F6 C7 10 74 5C")]
    public partial void SetHasSecondDyeChannel(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? 32 D2 45 8B C4")]
    public partial void SetIsMacro(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? C1 EF 08 45 33 C0")]
    public partial void SetIsGlamoured(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? 41 83 FD 45")]
    public partial void SetIsRecipe(bool enabled);

    [MemberFunction("44 8B 89 ?? ?? ?? ?? 4C 8B D1 41 8B C1")]
    public partial void SetComboLevel(bool enable, byte level = 0);

    // [MemberFunction("E8 ?? ?? ?? ?? 48 8B 06 80 88")]
    // public partial void SetUnk8192(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 F6 FF C6")]
    public partial void SetOuterResNode(AtkResNode* node);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 87 ?? ?? ?? ?? 84 C0")]
    public partial void UpdateIndicator();

    [MemberFunction("48 83 EC 38 41 83 F9 02")]
    public partial void SetIndicatorVisuals(byte labelId, ByteColor color, uint index);

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct IndicatorNodesEntry {
        [FieldOffset(0x00)] public AtkResNode* ResNode;
        [FieldOffset(0x08)] public AtkImageNode* ImageNode;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct LocalizedIconInfo {
        [FieldOffset(0x00)] public uint Id;
        [FieldOffset(0x04)] public IconSubFolder SubFolder;
        [FieldOffset(0x08)] public bool CheckLoadedIconFirst;
    }
}

[Flags]
public enum IconComponentFlags : uint {
    None = 0,
    ComboLevel2 = 1 << 0,
    ComboLevel3 = 1 << 1,
    ComboLevel1 = 1 << 2, // always set when ComboLevel is shown
    HasFirstDyeChannel = 1 << 3,
    IsDyeLocked = 1 << 4,
    HasSecondDyeChannel = 1 << 5,
    IsMacro = 1 << 6,
    IsGlamoured = 1 << 7,
    IsRecipe = 1 << 8,
    IsIconLoading = 1 << 9,
    IsBeingDragged = 1 << 10,
    Unk2048 = 1 << 11,
    IsDisabled = 1 << 12, // for example due to casting or having a window open that disables actions
    Unk8192 = 1 << 13,
}
