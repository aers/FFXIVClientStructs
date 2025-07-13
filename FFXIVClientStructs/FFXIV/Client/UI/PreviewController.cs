using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[GenerateInterop]
[Inherits<AtkEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct PreviewController {
    [FieldOffset(0x08)] public AtkStage* AtkStagePtr;
    /// <remarks> Either <see cref="AtkComponentPreview"/> or <see cref="AtkComponentPortrait"/> </remarks>
    [FieldOffset(0x10)] public AtkComponentBase* Component;
    [FieldOffset(0x18)] public AtkComponentButton* ResetButton;
    [FieldOffset(0x20)] public AtkComponentCheckBox* CharacterDisplayModeCheckBox;
    [FieldOffset(0x28)] public AtkCollisionNode* CollisionNode;
    [FieldOffset(0x30)] public AtkUnitBase* OwnerAddon;
    [FieldOffset(0x38)] public AtkUnitBase* Unk38Addon;
    [FieldOffset(0x40)] public int CallbackBaseId;
    [FieldOffset(0x44)] public DragButtonType DragButton;
    [FieldOffset(0x48)] public short DragStartPosX;
    [FieldOffset(0x4A)] public short DragStartPosY;

    [FieldOffset(0x50)] public Utf8String CharacterDisplayModeTooltipText;

    [MemberFunction("E8 ?? ?? ?? ?? 80 A6 ?? ?? ?? ?? ?? B8")]
    public partial void Ctor(AtkStage* atkStage);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CD E8 ?? ?? ?? ?? 48 8B F0")]
    public partial void Detach();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 45 33 FF 48 85 C9 75")]
    public partial void SetOwnerAddon(AtkUnitBase* addon, int callbackBaseId);

    [MemberFunction("E8 ?? ?? ?? ?? 45 8D 47 ?? 48 8B D7")]
    public partial void SetPreviewComponent(AtkResNode* component);

    [MemberFunction("48 85 D2 0F 84 ?? ?? ?? ?? 53 48 83 EC ?? 48 8B D9 48 8B CA")]
    public partial void SetPortraitComponent(AtkResNode* component);

    [MemberFunction("E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? 41 B8")]
    public partial void SetResetButton(AtkComponentButton* button, uint addonId = 3270);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 FF 48 85 F6")]
    public partial void SetCharacterDisplayModeCheckBox(AtkComponentCheckBox* checkbox, uint addonId = 3271);

    [MemberFunction("E8 ?? ?? ?? ?? 66 0F 6F 05 ?? ?? ?? ?? 48 8D BB")]
    public partial void SetPreviewTexture(Texture* texture);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 F6 48 8D 8B"), GenerateStringOverloads]
    public partial void SetPreviewErrorText(CStringPointer text);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 8E ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 85 C0")]
    public partial void SetPreviewErrorVisibility(bool visible);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 E4 41 8B CC 48 85 F6")]
    public partial void SetCharacterDisplayMode(bool enabled);

    public enum DragButtonType {
        None = 0,
        LeftClick = 1,
        RightClick = 2,
    }
}
