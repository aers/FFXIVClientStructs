using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMiragePrismPrismSetConvertC
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
// No button is not cached; looked up by id in OnSetup for AddEvent only.
[Addon("MiragePrismPrismSetConvertC")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonMiragePrismPrismSetConvertC {
    [FieldOffset(0x238)] public AtkComponentButton* YesButton;
    [FieldOffset(0x240)] public AtkComponentCheckBox* StoreAsOutfitGlamourCheckBox;
}
