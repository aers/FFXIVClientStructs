using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

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

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 83 C6 EE")]
    public partial void SetTab(int tab);
}
