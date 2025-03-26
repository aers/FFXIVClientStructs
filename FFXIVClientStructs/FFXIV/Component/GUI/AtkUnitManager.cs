using FFXIVClientStructs.FFXIV.Client.UI;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkUnitManager
//   Component::GUI::AtkEventListener
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x9C90)]
public unsafe partial struct AtkUnitManager {
    [FieldOffset(0x0)] public AtkEventListener AtkEventListener;
    [FieldOffset(0x30), FixedSizeArray, CExportIgnore] internal FixedSizeArray13<AtkUnitList> _depthLayers;
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
    [FieldOffset(0x9150)] private AtkUnitBase* UnkOperationGuideAddon1; // used by AtkOperationGuide in AtkStage
    [FieldOffset(0x9158)] private AtkUnitBase* UnkOperationGuideAddon2; // used by AtkOperationGuide in AtkStage
    [FieldOffset(0x9160)] public AddonCursor* AddonCursor;
    [FieldOffset(0x9168)] public AddonOperationGuide* AddonOperationGuide;
    [FieldOffset(0x9170)] public AddonFilter* AddonFilter;
    [FieldOffset(0x9178)] public AddonFilter* AddonFilterSystem;
    [FieldOffset(0x9180)] public AddonDragDrop* AddonDragDrop;
    [FieldOffset(0x9188)] public AtkManagedInterface* ManagedScreenFrame;

    [FieldOffset(0x9C88)] public AtkUnitManagerFlags Flags;

    [VirtualFunction(8)]
    public partial bool SetAddonVisibility(ushort addonId, bool visible);

    [VirtualFunction(9)]
    public partial AddonStatus GetAddonStatus(ushort addonId);

    [VirtualFunction(10)]
    public partial bool RefreshAddon(AtkUnitBase* addon, uint valueCount, AtkValue* values);

    [VirtualFunction(11)]
    public partial void AddonRequestUpdateById(ushort addonId, NumberArrayData** numberArrayData, StringArrayData** stringArrayData, bool forced);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 41 B0 01"), GenerateStringOverloads]
    public partial AtkUnitBase* GetAddonByName(CStringPointer name, int index = 1);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 6B 20")]
    public partial AtkUnitBase* GetAddonById(ushort id);

    public enum AddonStatus {
        NotLoaded = 0,

        Shown = 1 << 2,
        Hidden = 1 << 3,
    }
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
