using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 06 48 8D 9E ?? ?? ?? ?? 0F 11 86", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonRetainerList;
