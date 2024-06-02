using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerTaskList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 80 8B 88 01 00 00 20 48 89 83 20 02 00 00 48 89 83 28 02 00 00 88", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x238)]
public unsafe partial struct AddonRetainerTaskList;
