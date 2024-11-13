using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonActionBar
//   Client::UI::AddonActionBarX
//     Client::UI::AddonActionBarBase
//       Component::GUI::AtkUnitBase
//         Component::GUI::AtkEventListener
[Addon("_ActionBar")]
[GenerateInterop]
[Inherits<AddonActionBarX>]
[StructLayout(LayoutKind.Explicit, Size = 0x2D0)]
public unsafe partial struct AddonActionBar {
    [FieldOffset(0x2B0)] public AtkComponentBase* CycleUpArrow;
    [FieldOffset(0x2B8)] public AtkComponentBase* CycleDownArrow;
    [FieldOffset(0x2C0)] public AtkComponentCheckBox* PadlockCheckbox;

    [FieldOffset(0x2C9)] public byte HotbarIdPet; // usually both the same value, only difference is that this one changes to 18 when cycled to the pet bar
    [FieldOffset(0x2CB)] public byte HotbarId;
    [FieldOffset(0x2CD)] public bool IncludePetBarWhenCycling;
}
