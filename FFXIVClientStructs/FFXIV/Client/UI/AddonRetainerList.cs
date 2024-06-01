using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 48 89 83 20 02 00 00 48 89 83 28 02 00 00 48 89 83 30 02 00 00 48 89 83 38 02 00 00 48 89 83 40 02 00 00 48 89 83 48 02 00 00 48 89 83 50 02 00 00 80 8B 8B 01 00 00 08", 3)]
public unsafe partial struct AddonRetainerList;
