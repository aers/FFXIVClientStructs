namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkUnitManager
//   Component::GUI::AtkEventListener
// ctor "E8 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 8D 05"
[StructLayout(LayoutKind.Explicit, Size = 0x9C90)]
public struct AtkUnitManager {
    [FieldOffset(0x0)] public AtkEventListener AtkEventListener;
    [FieldOffset(0x30)] public AtkUnitList DepthLayerOneList;
    [FieldOffset(0x840)] public AtkUnitList DepthLayerTwoList;
    [FieldOffset(0x1050)] public AtkUnitList DepthLayerThreeList;
    [FieldOffset(0x1860)] public AtkUnitList DepthLayerFourList;
    [FieldOffset(0x2070)] public AtkUnitList DepthLayerFiveList;
    [FieldOffset(0x2880)] public AtkUnitList DepthLayerSixList;
    [FieldOffset(0x3090)] public AtkUnitList DepthLayerSevenList;
    [FieldOffset(0x38A0)] public AtkUnitList DepthLayerEightList;
    [FieldOffset(0x40B0)] public AtkUnitList DepthLayerNineList;
    [FieldOffset(0x48C0)] public AtkUnitList DepthLayerTenList;
    [FieldOffset(0x50D0)] public AtkUnitList DepthLayerElevenList;
    [FieldOffset(0x58E0)] public AtkUnitList DepthLayerTwelveList;
    [FieldOffset(0x60F0)] public AtkUnitList DepthLayerThirteenList;
    [FieldOffset(0x6900)] public AtkUnitList AllLoadedUnitsList;
    [FieldOffset(0x7110)] public AtkUnitList FocusedUnitsList;
    [FieldOffset(0x7920)] public AtkUnitList UnitList16;
    [FieldOffset(0x8130)] public AtkUnitList UnitList17;
    [FieldOffset(0x8940)] public AtkUnitList UnitList18;
    [FieldOffset(0x9C88)] public AtkUnitManagerFlags Flags;
}

[Flags]
public enum AtkUnitManagerFlags : byte {
    None = 0x00,
    Unk01 = 0x01,
    Unk02 = 0x02,
    UiHidden = 0x04,
    Unk08 = 0x08,
    Unk10 = 0x10,
    Unk20 = 0x20,
    Unk40 = 0x40,
    Unk80 = 0x80,
}
