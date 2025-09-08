using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonArmouryBoard
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ArmouryBoard")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x6D8)]
public unsafe partial struct AddonArmouryBoard {

    [FieldOffset(0x358), FixedSizeArray] internal FixedSizeArray50<Pointer<AtkComponentDragDrop>> _slots;
    
    [FieldOffset(0x678)] public AtkResNode* HeaderContainerNode; // Container node for following header nodes
    [FieldOffset(0x680)] public AtkTextNode* HeaderMajorTextNode; // Ex. "Chocobo Saddlebag" using above example
    [FieldOffset(0x688)] public AtkTextNode* HeaderMinorTextNode; // Ex. "Select an item to add to the saddlebag."
    [FieldOffset(0x690)] public AtkResNode* InventoryButtonContainerNode;
    [FieldOffset(0x698)] public AtkComponentButton* InventoryButtonComponent;
    [FieldOffset(0x6A0)] public AtkTextNode* CategoryLabelNode; // "Head" "Main Hand" "Hands" etc
    [FieldOffset(0x6A8)] public int TabIndex;

    [MemberFunction("40 53 48 83 EC 20 80 B9 ?? ?? ?? ?? ?? 48 8B D9 75 10")]
    public partial void NextTab(byte a2); // 7.0: inlined

    [MemberFunction("40 53 48 83 EC 20 80 B9 ?? ?? ?? ?? ?? 48 8B D9 0F 85 ?? ?? ?? ?? 8B 81")]
    public partial void PreviousTab(byte a2); // 7.0: inlined
}
