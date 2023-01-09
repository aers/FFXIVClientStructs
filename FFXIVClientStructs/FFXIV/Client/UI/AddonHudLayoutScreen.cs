using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct MoveableAddonInfoStruct
{
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

// Client::UI::AddonHudLayoutScreen
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
// size = 0x7E8
// ctor 48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 89 03 E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 
[StructLayout(LayoutKind.Explicit, Size = 0x8A8)]
public unsafe struct AddonHudLayoutScreen
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x2C8)] public AddonHudLayoutWindow* HudLayoutWindow;

    [FieldOffset(0x540)] public AtkComponentNode*
        SelectedOverlayNode; // actually an array of active overlay nodes here, but this should be the selected one in theory

    [FieldOffset(0x7B0)] public MoveableAddonInfoStruct* SelectedAddon;
}