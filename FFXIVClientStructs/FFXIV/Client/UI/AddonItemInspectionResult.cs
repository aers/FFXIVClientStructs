using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemInspectionResult
//   Client::UI::AddonItemDetailBase
//     Component::GUI::AtkUnitBase
//       Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkUnitBase>] // TODO: inherit from AddonItemDetailBase
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public partial struct AddonItemInspectionResult;
