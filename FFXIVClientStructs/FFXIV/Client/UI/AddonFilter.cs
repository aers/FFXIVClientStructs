using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFilter
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
//   Component::GUI::AtkManagedInterface
[Addon("Filter", "FilterSystem")]
[GenerateInterop]
[Inherits<AtkUnitBase>, Inherits<AtkManagedInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct AddonFilter;
