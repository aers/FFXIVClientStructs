using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonAllianceListX
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_AllianceList1", "_AllianceList2")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x478)]
public unsafe partial struct AddonAllianceListX {
    [FieldOffset(0x238)] public AtkTextNode* HeaderText;
    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray8<AllianceMemberStruct> _allianceMembers;
    [FieldOffset(0x440), FixedSizeArray] internal FixedSizeArray8<ushort> _uIFlags;
    [FieldOffset(0x450), FixedSizeArray] internal FixedSizeArray8<uint> _allianceClassJobIconIds;
    [FieldOffset(0x470)] public sbyte HoveredSlot;
    [FieldOffset(0x471)] public sbyte TargetedSlot;
    [FieldOffset(0x472)] public byte Slots;
    [FieldOffset(0x473)] public byte SlotsFilled;


    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe partial struct AllianceMemberStruct {
        [FieldOffset(0x00)] public AtkComponentBase* ComponentBase;
        [FieldOffset(0x08)] public AtkResNode* DebuffContainer;
        [FieldOffset(0x10)] public AtkImageNode* ClassJobImageNode;
        [FieldOffset(0x20)] public AtkComponentGaugeBar* HealthBar;
        [FieldOffset(0x28)] public AtkResNode* AggroContainer;
        [FieldOffset(0x30)] public AtkResNode* TargetGlowContainer;
        [FieldOffset(0x38)] public AtkCollisionNode* AtkCollisionNode;
    }
}
