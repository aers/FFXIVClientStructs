using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonChocoboBreedTraining
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonChocoboBreedTraining {
    [FieldOffset(0x230)] public AtkComponentButton* CommenceButton;
    [FieldOffset(0x238)] public AtkComponentButton* CancelButton;
}
