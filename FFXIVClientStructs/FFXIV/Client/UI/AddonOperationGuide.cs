using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonOperationGuide
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
//   Component::GUI::AtkManagedInterface
[Addon("OperationGuide")]
[GenerateInterop]
[Inherits<AtkUnitBase>, Inherits<AtkManagedInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x268)]
public unsafe partial struct AddonOperationGuide;
