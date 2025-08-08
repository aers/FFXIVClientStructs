using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCharacter
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Character")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xF38)]
public unsafe partial struct AddonCharacter {
    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentRadioButton>> _tabs;

    [FieldOffset(0x4B0)] public int TabIndex;
    [FieldOffset(0x4B4)] public int TabCount;
    [FieldOffset(0x4C0)] public AtkAddonControl AddonControl;

    [FieldOffset(0xBB8)] public PreviewController PreviewController;
    [Obsolete("Moved to PreviewController.CollisionNode", true)]
    [FieldOffset(0xBD8)] public AtkCollisionNode* CharacterPreviewCollisionNode;

    [MemberFunction("E8 ?? ?? ?? ?? 3B AB ?? ?? ?? ?? 74 27")]
    public partial void SetTab(int tab);
}
