using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("Character")]
[StructLayout(LayoutKind.Explicit, Size = 0x1C00)]
public unsafe partial struct AddonCharacter {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FixedSizeArray<Pointer<AtkComponentRadioButton>>(4)]
    [FieldOffset(0x228)] public fixed byte RadioButtons[8 * 4];

    [FieldOffset(0x488)] public int TabIndex;
    [FieldOffset(0x48C)] public int TabCount;

    [FieldOffset(0x4ED)] public bool EmbeddedAddonLoaded;

    [FieldOffset(0xBA8)] public AtkCollisionNode* CharacterPreviewCollisionNode;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 83 C6 EE")]
    public partial void SetTab(int tab);
}
