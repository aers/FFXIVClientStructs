using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("80 8B ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 80 8B ?? ?? ?? ?? ?? 89 83 ?? ?? ?? ?? 48 89 83", 10)]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonRetainerList;
