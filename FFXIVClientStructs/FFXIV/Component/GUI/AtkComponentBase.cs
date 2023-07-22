namespace FFXIVClientStructs.FFXIV.Component.GUI;

public enum ComponentType : byte
{
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

// Component::GUI::AtkComponentBase
//   Component::GUI::AtkEventListener

// base class for UI components that are more complicated than a single node

// size = 0xC0
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 0
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct AtkComponentBase
{
    [FieldOffset(0x00)] public AtkEventListener AtkEventListener;
    [FieldOffset(0x08)] public AtkUldManager UldManager;
    [FieldOffset(0xA0)] public AtkResNode* AtkResNode;
    [FieldOffset(0xA8)] public AtkComponentNode* OwnerNode;

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B F0 BF")]
    public partial AtkResNode* GetTextNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 56 9C")]
    public partial AtkResNode* GetImageNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 53 FC")]
    public partial AtkResNode* GetScrollBarNodeById(uint id);
    
    [VirtualFunction(10)] 
    public partial void* SetEnabledState(bool enabled);
}