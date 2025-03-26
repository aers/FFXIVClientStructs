using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonHudLayoutScreen
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_HudLayoutScreen")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x970)]
public unsafe partial struct AddonHudLayoutScreen {
    [FieldOffset(0x2E0)] public AddonHudLayoutWindow* HudLayoutWindow;

    [FieldOffset(0x558)] public AtkComponentNode* SelectedOverlayNode; // actually an array of active overlay nodes here, but this should be the selected one in theory

    [FieldOffset(0x7C8)] public MoveableAddonInfoStruct* SelectedAddon;
}

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe struct MoveableAddonInfoStruct {
    [FieldOffset(0x20)] public AddonHudLayoutScreen* hudLayoutScreen;
    [FieldOffset(0x28)] public AtkUnitBase* SelectedAtkUnit;
    [FieldOffset(0x3C)] public int Flags;
    [FieldOffset(0x44)] public short XOffset;
    [FieldOffset(0x46)] public short YOffset;
    [FieldOffset(0x48)] public short OverlayWidth;
    [FieldOffset(0x4A)] public short OverlayHeight;
    [FieldOffset(0x4D)] public byte Slot;
    [FieldOffset(0x4F)] public byte PositionHasChanged;
}
