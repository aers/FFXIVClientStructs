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
    [FieldOffset(0x260), FixedSizeArray] internal FixedSizeArray100<GearsetEntry> _gearsets;
    [FieldOffset(0x3AA5)] public bool ShouldResetPosition;

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public struct GearsetEntry {
        [FieldOffset(0x00)] public int Index; // -1 for empty
        [FieldOffset(0x04)] public uint JobIconId; // icon without background
        /// <remarks> Used for DragDrop and Hotbar slots. </remarks>
        [FieldOffset(0x08)] public uint GearsetIconId;
        [FieldOffset(0x0C)] public byte GlamourPlateId;
        [FieldOffset(0x10)] public Utf8String ItemLevelText;
        [FieldOffset(0x78)] public CStringPointer Name;
        [FieldOffset(0x84)] public GearsetItemFlag Flags;
    }
}
