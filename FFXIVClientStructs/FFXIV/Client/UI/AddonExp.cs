using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonExp
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_Exp")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public unsafe partial struct AddonExp {
    [FieldOffset(0x268)] public AtkComponentGaugeBar* ExperienceBarComponent;
    [FieldOffset(0x270)] public AtkTextNode* ChainTextNode;
    [FieldOffset(0x278)] public AtkImageNode* MoonIconNode;
    [FieldOffset(0x280)] public AtkImageNode* SwordsIconNode;
    [FieldOffset(0x288)] public byte ClassJob;
    [FieldOffset(0x290)] public uint CurrentExp;
    [FieldOffset(0x294)] public uint RequiredExp;
    [FieldOffset(0x298)] public uint RestedExp;

    public float CurrentExpPercent => (float)CurrentExp / RequiredExp * 100;
}
