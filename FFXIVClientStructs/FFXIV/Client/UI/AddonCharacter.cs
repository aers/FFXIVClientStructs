using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCharacter
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Character")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xF28)]
public unsafe partial struct AddonCharacter {
    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentRadioButton>> _tabs;

    [FieldOffset(0x4A8)] public int TabIndex;
    [FieldOffset(0x4AC)] public int TabCount;
    [FieldOffset(0x4B0)] public AtkAddonControl AddonControl;

    [FieldOffset(0xBD0)] public AtkCollisionNode* CharacterPreviewCollisionNode;

    [MemberFunction("E8 ?? ?? ?? ?? 3B AB ?? ?? ?? ?? 74 27")]
    public partial void SetTab(int tab);
}
