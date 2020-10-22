using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    // Component::GUI::AtkUnitManager
    //   Component::GUI::AtkEventListener

    // size = 0x9C80 (may be a bit bigger, unimportant)
    // ctor E8 ? ? ? ? C6 83 ? ? ? ? ? 48 8D 8B ? ? ? ? 48 8D 05 ? ? ? ? 
    [StructLayout(LayoutKind.Explicit, Size = 0x9C80)]
    public unsafe struct AtkUnitManager
    {
        [FieldOffset(0x0)] public AtkEventListener AtkEventListener;
        [FieldOffset(0x30)] public AtkUnitList UnitList1;
        [FieldOffset(0x840)] public AtkUnitList UnitList2;
        [FieldOffset(0x1050)] public AtkUnitList UnitList3;
        [FieldOffset(0x1860)] public AtkUnitList UnitList4;
        [FieldOffset(0x2070)] public AtkUnitList UnitList5;
        [FieldOffset(0x2880)] public AtkUnitList UnitList6;
        [FieldOffset(0x3090)] public AtkUnitList UnitList7;
        [FieldOffset(0x38A0)] public AtkUnitList UnitList8;
        [FieldOffset(0x40B0)] public AtkUnitList UnitList9;
        [FieldOffset(0x48C0)] public AtkUnitList UnitList10;
        [FieldOffset(0x50D0)] public AtkUnitList UnitList11;
        [FieldOffset(0x58E0)] public AtkUnitList UnitList12;
        [FieldOffset(0x60F0)] public AtkUnitList UnitList13;
        [FieldOffset(0x6900)] public AtkUnitList MainUIAddonUnitList;
        [FieldOffset(0x7110)] public AtkUnitList UnitList15;
        [FieldOffset(0x7920)] public AtkUnitList UnitList16;
        [FieldOffset(0x8130)] public AtkUnitList UnitList17;
        [FieldOffset(0x8940)] public AtkUnitList UnitList18;
    }
}
