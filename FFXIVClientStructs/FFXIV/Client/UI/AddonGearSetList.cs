using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.Misc.RaptureGearsetModule;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGearSetList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GearSetList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3AA8)]
public partial struct AddonGearSetList {
    [FieldOffset(0x260), FixedSizeArray] internal FixedSizeArray100<GearSet> _gearsets;
    [FieldOffset(0x3AA5)] public bool ShouldResetPosition;
}

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public partial struct GearSet {
    [FieldOffset(0x0)] public int Index; // -1 for empty
    [FieldOffset(0x4)] public uint JobIconId; // icon without background
    [FieldOffset(0x8)] public uint JobIconId2; // icon with background
    [FieldOffset(0xC)] public byte GlamourPlateId;
    [FieldOffset(0x10)] public Utf8String ItemLevelText;
    [FieldOffset(0x78)] public CStringPointer Name;
    [FieldOffset(0x84)] public GearsetItemFlag Flag;
}
