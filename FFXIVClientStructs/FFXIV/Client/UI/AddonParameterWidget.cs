using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonParameterWidget
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_ParameterWidget")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x280)]
public unsafe partial struct AddonParameterWidget {
    [FieldOffset(0x238)] public AtkComponentGaugeBar* HealthGaugeBar;
    [FieldOffset(0x240)] public AtkComponentGaugeBar* ManaGaugeBar;
    [FieldOffset(0x248)] public AtkTextNode* HealthText;
    [FieldOffset(0x250)] public AtkTextNode* ManaText;
    [FieldOffset(0x258)] public AtkTextNode* HealthAmount;
    [FieldOffset(0x260)] public AtkTextNode* ManaAmount;
    [FieldOffset(0x268)] public AtkTextNode* WeaponSheatedText;
    [FieldOffset(0x270)] public uint EntityId;
    [FieldOffset(0x274)] public uint ClassJobId;
    [FieldOffset(0x278)] public uint ClassJobLevel;
}
