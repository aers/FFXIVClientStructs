using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentBase
//   Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 0
// base class for UI components that are more complicated than a single node
[GenerateInterop(isInherited: true)]
[Inherits<AtkEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct AtkComponentBase : ICreatable {
    [FieldOffset(0x08)] public AtkUldManager UldManager;
    [FieldOffset(0xA0)] public AtkResNode* AtkResNode;
    [FieldOffset(0xA8)] public AtkComponentNode* OwnerNode;

    [MemberFunction("48 8D 05 ?? ?? ?? ?? C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 01 33 C0 48 89 41 08")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 49 63 D7")]
    public partial AtkResNode* GetTextNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 53 47")]
    public partial AtkResNode* GetImageNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 53 F8")]
    public partial AtkResNode* GetScrollBarNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 41 3A C6 74 22")]
    public partial bool IsAnimated();

    [VirtualFunction(5)]
    public partial void OnUldUpdate();

    [VirtualFunction(10)]
    public partial void SetEnabledState(bool enabled);
}

public enum ComponentType : byte {
    Base = 0,
    Button = 1,
    Window = 2,
    CheckBox = 3,
    RadioButton = 4,
    GaugeBar = 5,
    Slider = 6,
    TextInput = 7,
    NumericInput = 8,
    List = 9,
    DropDownList = 10,
    Tab = 11,
    TreeList = 12,
    ScrollBar = 13,
    ListItemRenderer = 14,
    Icon = 15,
    IconText = 16,
    DragDrop = 17,
    GuildLeveCard = 18,
    TextNineGrid = 19,
    JournalCanvas = 20,
    Multipurpose = 21,
    Map = 22,
    Preview = 23,
    HoldButton = 24,
    Portrait = 25,
}
