using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonBank
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Bank")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x298)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 48 89 83 20 02 00 00 48 89 83 28 02 00 00 48 89 83 30 02 00 00 48 89 83 38 02 00 00 48 89 83 40 02 00 00 48 89 83 48 02 00 00 48 89 83 50 02 00 00 48 89 83 58 02 00 00 48 89 83 60 02 00 00 48 89 83 68 02 00 00 48 89 83 70 02 00 00 48 89 83 78 02 00 00 48 89 83 80 02 00 00 48 89 83 88 02 00 00 80 8B 8B 01 00 00 08 80 8B 8A", 3)]
public unsafe partial struct AddonBank;
