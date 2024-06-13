using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCharacter
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Character")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C00)]
public unsafe partial struct AddonCharacter {
    [FieldOffset(0x228), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentRadioButton>> _radioButtons;

    [FieldOffset(0x488)] public int TabIndex;
    [FieldOffset(0x48C)] public int TabCount;

    [FieldOffset(0x490)] public AtkAddonControl AddonControl;

    [FieldOffset(0xBA8)] public AtkCollisionNode* CharacterPreviewCollisionNode;

    [MemberFunction("E8 ?? ?? ?? ?? 3B AB ?? ?? ?? ?? 74 27")]
    public partial void SetTab(int tab);
}
