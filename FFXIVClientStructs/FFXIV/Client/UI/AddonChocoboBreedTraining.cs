using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonChocoboBreedTraining
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe partial struct AddonChocoboBreedTraining {
    [FieldOffset(0x220)] public AtkComponentButton* CommenceButton;
    [FieldOffset(0x228)] public AtkComponentButton* CancelButton;
}
