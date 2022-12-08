using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonAOZNotebook
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0xCD0)]
public unsafe struct AddonAOZNotebook
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x308)] public SpellbookBlock SpellbookBlock01;
    [FieldOffset(0x350)] public SpellbookBlock SpellbookBlock02;
    [FieldOffset(0x398)] public SpellbookBlock SpellbookBlock03;
    [FieldOffset(0x3E0)] public SpellbookBlock SpellbookBlock04;
    [FieldOffset(0x428)] public SpellbookBlock SpellbookBlock05;
    [FieldOffset(0x470)] public SpellbookBlock SpellbookBlock06;
    [FieldOffset(0x4B8)] public SpellbookBlock SpellbookBlock07;
    [FieldOffset(0x500)] public SpellbookBlock SpellbookBlock08;
    [FieldOffset(0x548)] public SpellbookBlock SpellbookBlock09;
    [FieldOffset(0x590)] public SpellbookBlock SpellbookBlock10;
    [FieldOffset(0x5D8)] public SpellbookBlock SpellbookBlock11;
    [FieldOffset(0x620)] public SpellbookBlock SpellbookBlock12;
    [FieldOffset(0x668)] public SpellbookBlock SpellbookBlock13;
    [FieldOffset(0x6B0)] public SpellbookBlock SpellbookBlock14;
    [FieldOffset(0x6F8)] public SpellbookBlock SpellbookBlock15;
    [FieldOffset(0x740)] public SpellbookBlock SpellbookBlock16;

    [FieldOffset(0x820)] public ActiveActions ActiveActions01;
    [FieldOffset(0x840)] public ActiveActions ActiveActions02;
    [FieldOffset(0x860)] public ActiveActions ActiveActions03;
    [FieldOffset(0x880)] public ActiveActions ActiveActions04;
    [FieldOffset(0x8A0)] public ActiveActions ActiveActions05;
    [FieldOffset(0x8C0)] public ActiveActions ActiveActions06;
    [FieldOffset(0x8E0)] public ActiveActions ActiveActions07;
    [FieldOffset(0x900)] public ActiveActions ActiveActions08;
    [FieldOffset(0x920)] public ActiveActions ActiveActions09;
    [FieldOffset(0x940)] public ActiveActions ActiveActions10;
    [FieldOffset(0x960)] public ActiveActions ActiveActions11;
    [FieldOffset(0x980)] public ActiveActions ActiveActions12;
    [FieldOffset(0x9A0)] public ActiveActions ActiveActions13;
    [FieldOffset(0x9C0)] public ActiveActions ActiveActions14;
    [FieldOffset(0x9E0)] public ActiveActions ActiveActions15;
    [FieldOffset(0xA00)] public ActiveActions ActiveActions16;
    [FieldOffset(0xA20)] public ActiveActions ActiveActions17;
    [FieldOffset(0xA40)] public ActiveActions ActiveActions18;
    [FieldOffset(0xA60)] public ActiveActions ActiveActions19;
    [FieldOffset(0xA80)] public ActiveActions ActiveActions20;
    [FieldOffset(0xAA0)] public ActiveActions ActiveActions21;
    [FieldOffset(0xAC0)] public ActiveActions ActiveActions22;
    [FieldOffset(0xAE0)] public ActiveActions ActiveActions23;
    [FieldOffset(0xB00)] public ActiveActions ActiveActions24;

    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public struct SpellbookBlock
    {
        [FieldOffset(0x0)] public AtkComponentBase* AtkComponentBase;
        [FieldOffset(0x8)] public AtkCollisionNode* AtkCollisionNode;
        [FieldOffset(0x10)] public AtkComponentCheckBox* AtkComponentCheckBox;
        [FieldOffset(0x18)] public AtkComponentIcon* AtkComponentIcon;
        [FieldOffset(0x20)] public AtkTextNode* AtkTextNode;
        [FieldOffset(0x28)] public AtkResNode* AtkResNode1;
        [FieldOffset(0x30)] public AtkResNode* AtkResNode2;
        [FieldOffset(0x38)] public char* Name;
        [FieldOffset(0x40)] public uint ActionID;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct ActiveActions
    {
        [FieldOffset(0x0)] public AtkComponentDragDrop* AtkComponentDragDrop;
        [FieldOffset(0x8)] public AtkTextNode* AtkTextNode;
        [FieldOffset(0x10)] public char* Name;
        [FieldOffset(0x18)] public int ActionID;
    }

    public SpellbookBlock GetSpellbookBlock(int index)
    {
        return index switch
        {
            0 => SpellbookBlock01,
            1 => SpellbookBlock02,
            2 => SpellbookBlock03,
            3 => SpellbookBlock04,
            4 => SpellbookBlock05,
            5 => SpellbookBlock06,
            6 => SpellbookBlock07,
            7 => SpellbookBlock08,
            8 => SpellbookBlock09,
            9 => SpellbookBlock10,
            10 => SpellbookBlock11,
            11 => SpellbookBlock12,
            12 => SpellbookBlock13,
            13 => SpellbookBlock14,
            14 => SpellbookBlock15,
            15 => SpellbookBlock16,
            _ => throw new IndexOutOfRangeException("Valid values are 0 through 15 inclusive")
        };
    }

    public ActiveActions GetActiveActions(int index)
    {
        return index switch
        {
            0 => ActiveActions01,
            1 => ActiveActions02,
            2 => ActiveActions03,
            3 => ActiveActions04,
            4 => ActiveActions05,
            5 => ActiveActions06,
            6 => ActiveActions07,
            7 => ActiveActions08,
            8 => ActiveActions09,
            9 => ActiveActions10,
            10 => ActiveActions11,
            11 => ActiveActions12,
            12 => ActiveActions13,
            13 => ActiveActions14,
            14 => ActiveActions15,
            15 => ActiveActions16,
            16 => ActiveActions17,
            17 => ActiveActions18,
            18 => ActiveActions19,
            19 => ActiveActions20,
            20 => ActiveActions21,
            21 => ActiveActions22,
            22 => ActiveActions23,
            23 => ActiveActions24,
            _ => throw new IndexOutOfRangeException("Valid values are 0 through 23 inclusive")
        };
    }
}