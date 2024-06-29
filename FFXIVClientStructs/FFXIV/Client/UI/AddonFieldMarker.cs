using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFieldMarker
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("FieldMarker")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x5A8)]
public unsafe partial struct AddonFieldMarker {
    [FieldOffset(0x240)] public int HoveredButtonIndex; // Index 0-8 of the currently moused over button (A-D, 1-4, Clear)

    [FieldOffset(0x248), FixedSizeArray] internal FixedSizeArray8<AddonFieldMarkerInfo> _fieldMarkerInfo;

    [FieldOffset(0x58C)] public int HoveredPresetIndex; // Index 0-4 of the currently moused over slot, -1 if not hovering over a slot
    [FieldOffset(0x590)] public byte SelectedPage;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct AddonFieldMarkerInfo {
    [FieldOffset(0x00)] public uint IconId; // Map IconId
    [FieldOffset(0x04)] public int Active;
    [FieldOffset(0x08)] public byte* TooltipString; //null-terminated cstring
    [FieldOffset(0x10)] public int Slot; // Index 0-7 [A,B,C,D,1,2,3,4] 

    public bool IsActive => Active != 0;
}
