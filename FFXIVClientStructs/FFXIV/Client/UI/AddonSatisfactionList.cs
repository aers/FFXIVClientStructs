using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSatisfactionList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SatisfactionList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
public unsafe partial struct AddonSatisfactionList {
    [FieldOffset(0x238)] public AtkResNode* TabBar;
    [FieldOffset(0x240)] public AtkTextNode* AllowancesText;
    [FieldOffset(0x248)] public AtkComponentButton* CloseButton;
    [FieldOffset(0x250)] public AtkComponentList* List;
    [FieldOffset(0x258), FixedSizeArray] internal FixedSizeArray10<uint> _npcIds;
    [FieldOffset(0x280), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkComponentRadioButton>> _tabs;
    [FieldOffset(0x2C8)] public int NpcCount;
    [FieldOffset(0x2CC)] public int TabIndex;
    [FieldOffset(0x2D0)] public int TabCount;

    [MemberFunction("40 56 48 83 EC ?? 48 8B F1 45 84 C0 75 ?? 3B 91 ?? ?? ?? ?? 0F 84 ?? ?? ?? ?? 8B 81")]
    public partial void SetTab(int tabIndex, bool force = false);
}
