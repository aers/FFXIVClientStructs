using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMJICraftScheduleSetting
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MJICraftScheduleSetting")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 0F 57 C0 48 89 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 0F 11 83", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct AddonMJICraftScheduleSetting {
    [FieldOffset(0x238)] public AtkComponentTreeList* TreeList;
}
