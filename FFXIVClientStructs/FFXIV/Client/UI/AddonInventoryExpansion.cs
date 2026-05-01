using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInventoryExpansion
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("InventoryExpansion")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x348)]
public unsafe partial struct AddonInventoryExpansion {
    [FieldOffset(0x240)] public int OpenerAddonId;

    [FieldOffset(0x250)] public AtkTextNode* SlotCountText;
    [FieldOffset(0x258)] public AtkResNode* TargetInventoryHeaderGroup;
    [FieldOffset(0x260)] public AtkTextNode* TargetInventoryHeaderName; // e.g. "Chocobo Saddlebag"
    [FieldOffset(0x268)] public AtkTextNode* TargetInventoryHeaderHint; // e.g. "Select an item to add to the saddlebag."
    [FieldOffset(0x270)] public AtkTextNode* GilText;
    [FieldOffset(0x278), FixedSizeArray] internal FixedSizeArray2<Pointer<AtkComponentRadioButton>> _tabButtons;
    [FieldOffset(0x288)] public AtkResNode* FooterGroup;
    [FieldOffset(0x290)] public AtkComponentButton* ArmouryChestButton;
    [FieldOffset(0x298)] public AtkAddonControl AddonControl;
    [FieldOffset(0x2F8), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkAddonControl.ChildAddonInfo>> _gridChildInfo;
    [FieldOffset(0x318), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkAddonControl.ChildAddonInfo>> _eventGridChildInfo;
    [FieldOffset(0x330)] public AtkAddonControl.ChildAddonInfo* CrystalGridChildInfo;
    [FieldOffset(0x338)] private int Unk338; // array of 2
    [FieldOffset(0x33C)] private int Unk34C;
    [FieldOffset(0x340)] public int TabIndex;

    [MemberFunction("E8 ?? ?? ?? ?? BB ?? ?? ?? ?? 83 EB 01")]
    public partial void SetTab(int tab, bool force);
}
