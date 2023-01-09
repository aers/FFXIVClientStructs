namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkUnitManager
//   Component::GUI::AtkEventListener

// size = 0x9C80 (may be a bit bigger, unimportant)
// ctor E8 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 
[StructLayout(LayoutKind.Explicit, Size = 0x9C88)]
public struct AtkUnitManager
{
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
}