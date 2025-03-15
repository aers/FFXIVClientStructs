using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonTeleportTown
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("TelepotTown")] // yes, it's misspelled
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 BB ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 BB", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x5C0)]
public unsafe partial struct AddonTeleportTown {
    [FieldOffset(0x238)] public AtkComponentTreeList* List;
}
