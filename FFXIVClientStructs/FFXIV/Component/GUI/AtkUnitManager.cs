using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkUnitManager
//   Component::GUI::AtkEventListener
[GenerateInterop(isInherited: true)]
[Inherits<AtkEventListener>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8B F9 ?? ?? ?? BA", 3, 43)]
[StructLayout(LayoutKind.Explicit, Size = 0x9C90)]
public unsafe partial struct AtkUnitManager {
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
    [FieldOffset(0x9150)] public AtkUnitBase* FocusedAddon;
    [FieldOffset(0x9158)] private AtkUnitBase* FocusedAddon2; // unsure, looks like it's used for pushing it back to the FocusedUnitsList when FocusedAddon changed
    [FieldOffset(0x9160)] public AddonCursor* AddonCursor;
    [FieldOffset(0x9168)] public AddonOperationGuide* AddonOperationGuide;
    [FieldOffset(0x9170)] public AddonFilter* AddonFilter;
    [FieldOffset(0x9178)] public AddonFilter* AddonFilterSystem;
    [FieldOffset(0x9180)] public AddonDragDrop* AddonDragDrop;
    [FieldOffset(0x9188)] public AtkManagedInterface* ManagedScreenFrame;

    [FieldOffset(0x92A0)] private AtkResNode Unk92A0;
    [FieldOffset(0x9350)] public Size LastScreenSize;

    // [FieldOffset(0x9388), FixedSizeArray] internal FixedSizeArray48<Unk9388Struct> Unk9388;
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

    /// <summary>
    /// Gets an AtkUnitBase pointer to the addon that contains the input node.
    /// This function will check all parents to the input node searching
    /// for a node that matches any loaded AtkUnitBase's rootnode address
    /// </summary>
    /// <param name="node">Pointer to a AtkResNode</param>
    /// <returns>Pointer to AtkUnitBase or null</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 3B E8 75 0E")]
    public partial AtkUnitBase* GetAddonByNode(AtkResNode* node);

    [MemberFunction("E8 ?? ?? ?? ?? 40 B5 ?? 48 83 C3")]
    public partial bool SetAddonDepthLayer(ushort id, uint depthLayerIndex);

    public enum AddonStatus {
        NotLoaded = 0,

        Shown = 1 << 2,
        Hidden = 1 << 3,
    }

    // [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    // public struct Unk9388Struct {
    //     [FieldOffset(0x00)] public AtkUnitBase* AtkUnitBase;
    //     [FieldOffset(0x08)] public uint NameHash;
    // }
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
