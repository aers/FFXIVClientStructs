using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectYesno
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SelectYesno")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2E8)]
public unsafe partial struct AddonSelectYesno {
    [FieldOffset(0x238)] public AtkTextNode* PromptText;
    [FieldOffset(0x240)] public AtkComponentButton* YesButton;
    [FieldOffset(0x248)] public AtkComponentButton* NoButton;
    [FieldOffset(0x250)] public AtkComponentButton* AtkComponentButton238;
    [FieldOffset(0x258)] public AtkResNode* AtkResNode240;
    [FieldOffset(0x260)] public AtkResNode* AtkResNode248;
    [FieldOffset(0x270)] public AtkResNode* AtkResNode258;
    [FieldOffset(0x278)] public AtkComponentButton* AtkComponentButton260; // repeat 228
    [FieldOffset(0x280)] public AtkComponentButton* AtkComponentButton268; // repeat 230
    [FieldOffset(0x288)] public AtkComponentButton* AtkComponentButton270; // repeat 238
    [FieldOffset(0x290)] public AtkComponentHoldButton* AtkComponentHoldButton278;
    [FieldOffset(0x298)] public AtkComponentHoldButton* AtkComponentHoldButton280;
    [FieldOffset(0x2A0)] public AtkComponentHoldButton* AtkComponentHoldButton288;
    [FieldOffset(0x2A8)] public AtkComponentCheckBox* ConfirmCheckBox;
    [FieldOffset(0x2B0)] public AtkTextNode* AtkTextNode298;
    [FieldOffset(0x2B8)] public AtkComponentBase* AtkComponentBase2A0;

    public StandardAtkValues* StandardTypedAtkValues => (StandardAtkValues*)AtkValues;

    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 13)]
    public struct StandardAtkValues {
        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 0)] public AtkValue PromptText;
        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 1)] public AtkValue Button1Text;
        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 2)] public AtkValue Button2Text;
        /// <remarks><see cref="AtkValueType.String"/>. Will be null if no third button</remarks>
        [FieldOffset(AtkValue.StructSize * 3)] public AtkValue Button3Text;
    }

    public bool CollectibleAtkValuesAvailable => AtkValuesCount > 15 && AtkValues[12].Int > 0;

    /// <remarks>Check <see cref="CollectibleAtkValuesAvailable"/> before using. Non-collectible SelectYesno only has 12 atkvalues</remarks>
    public CollectibleAtkValues* CollectibleTypedAtkValues => (CollectibleAtkValues*)AtkValues;

    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 16)]
    public struct CollectibleAtkValues {
        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 0)] public AtkValue PromptText;
        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 1)] public AtkValue Button1Text;
        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 2)] public AtkValue Button2Text;
        /// <remarks><see cref="AtkValueType.Int"/></remarks>
        [FieldOffset(AtkValue.StructSize * 13)] public AtkValue IconId;
        /// <remarks><see cref="AtkValueType.UInt"/></remarks>
        [FieldOffset(AtkValue.StructSize * 14)] public AtkValue ItemId; // collectable so it's +500k
        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 15)] public AtkValue ItemName; // has the collectible symbol in it
    }
}
