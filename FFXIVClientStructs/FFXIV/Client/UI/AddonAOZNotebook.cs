using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonAOZNotebook
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("AOZNotebook")]
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xCC8)]
public unsafe partial struct AddonAOZNotebook {
    [FieldOffset(0x308), FixedSizeArray] internal FixedSizeArray16<SpellbookBlock> _spellbookBlocks;
    [FieldOffset(0x820), FixedSizeArray] internal FixedSizeArray24<ActiveAction> _activeActions;
    
    [FieldOffset(0xCB0)] public int TabIndex;
    [FieldOffset(0xCB4)] public int TabCount;

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 8B CD E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 41 8D 40 F7")]
    public partial void SetTab(int tab, bool a3);

    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public struct SpellbookBlock {
        [FieldOffset(0x0)] public AtkComponentBase* AtkComponentBase;
        [FieldOffset(0x8)] public AtkCollisionNode* AtkCollisionNode;
        [FieldOffset(0x10)] public AtkComponentCheckBox* AtkComponentCheckBox;
        [FieldOffset(0x18)] public AtkComponentIcon* AtkComponentIcon;
        [FieldOffset(0x20)] public AtkTextNode* AtkTextNode;
        [FieldOffset(0x28)] public AtkResNode* AtkResNode1;
        [FieldOffset(0x30)] public AtkResNode* AtkResNode2;
        [FieldOffset(0x38)] public byte* Name;
        [FieldOffset(0x40)] public uint ActionId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct ActiveAction {
        [FieldOffset(0x0)] public AtkComponentDragDrop* AtkComponentDragDrop;
        [FieldOffset(0x8)] public AtkTextNode* AtkTextNode;
        [FieldOffset(0x10)] public byte* Name;
        [FieldOffset(0x18)] public uint ActionId;
    }
}
