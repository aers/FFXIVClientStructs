using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectString
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SelectString")]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 8b f9 48 89 01 8b da 48 81 c1 20 02 00 00 48 8d 05 ?? ?? ?? ?? 48 89 01 e8 ?? ?? ?? ?? 48 8b cf e8 ?? ?? ?? ?? f6 c3 01 74 0d ba a8 02 00 00", 3)]
public unsafe partial struct AddonSelectString {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public PopupMenuDerive PopupMenu;

    [VirtualFunction(48), Obsolete("Use AtkUnitBase.OnSetup")]
    public partial void OnSetup(uint a2, AtkValue* atkValues);

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct PopupMenuDerive {
        [FieldOffset(0x0)] public PopupMenu PopupMenu;
    }
}
