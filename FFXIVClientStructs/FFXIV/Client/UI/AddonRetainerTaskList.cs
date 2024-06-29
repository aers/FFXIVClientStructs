using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerTaskList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 80 8B ?? ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 88 83", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonRetainerTaskList;
