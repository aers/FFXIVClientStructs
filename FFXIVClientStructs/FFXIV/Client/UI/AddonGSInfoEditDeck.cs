using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGSInfoEditDeck
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GSInfoEditDeck")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xDA0)]
public partial struct AddonGSInfoEditDeck {
    [FieldOffset(0x238)] public TabController TabController;
    [FieldOffset(0xD90)] public byte PageIndex; // non-writable
    [FieldOffset(0xD94)] public byte PageIndex2; // non-writable
    [FieldOffset(0xD98)] public byte CardIndex; // non-writable

    [MemberFunction("E8 ?? ?? ?? ?? BE ?? ?? ?? ?? 40 84 FF")]
    public partial void SetSelectedCard(int cellIdx);
}
