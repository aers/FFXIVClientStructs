using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    public enum NodeType
    {
        Res = 1,
        Image = 2,
        Text = 3,
        NineGrid = 4,
        Counter = 5,
        Collision = 8,
        ComponentBase = 1000, // C0
        ComponentButton = 1001, // F0
        ComponentWindow = 1002, // 108
        ComponentCheckBox = 1003, // 110
        ComponentRadioButton = 1004, // F8
        ComponentGaugeBar = 1005, // 1A8
        ComponentSlider = 1006, // 100
        ComponentTextInput = 1007, // 600
        ComponentNumericInput = 1008, // 338
        ComponentList = 1009, // 1A8
        ComponentDropDownList = 1010, // E0
        ComponentTab = 1011, // 168
        ComponentTreeList = 1012, // 220
        ComponentScrollBar = 1013, // 140
        ComponentListItemRenderer = 1014, // 1A8
        ComponentIcon = 1015, // 118
        ComponentIconText = 1016, // E8
        ComponentDragDrop = 1017, // 110
        ComponentGuildLeveCard = 1018, // F0
        ComponentTextNineGrid = 1019, // D8
        ComponentJournalCanvas = 1020, // 510
        ComponentMultipurpose = 1021, // D8
        ComponentMap = 1022, // 410
        ComponentPreview = 1023, // D8
        // added since 2.3, no rtti, but derives from Button
        ComponentUnknownButton = 1024 // 120
    }

    // Component::GUI::AtkResNode
    //   Component::GUI::AtkEventTarget

    // base class for all UI "nodes" which represent elements of the UI

    // size = 0xA8
    // ctor E9 ? ? ? ? 33 C0 48 83 C4 20 5B C3 66 90 
    [StructLayout(LayoutKind.Explicit, Size = 0xA8)]
    public unsafe struct AtkResNode
    {
        [FieldOffset(0x0)] public AtkEventTarget AtkEventTarget;
        [FieldOffset(0x40)] public ushort Type;
    }
}
