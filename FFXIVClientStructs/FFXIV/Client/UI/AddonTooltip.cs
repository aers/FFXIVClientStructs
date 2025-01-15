using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonTooltip
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
//   Component::GUI::AtkManagedInterface
[Addon("Tooltip")]
[GenerateInterop]
[Inherits<AtkUnitBase>, Inherits<AtkManagedInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonTooltip;
