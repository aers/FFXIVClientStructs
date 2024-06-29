using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSynthesis
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x8B8)]
public unsafe partial struct AddonSynthesis {
    [FieldOffset(0x248)] public AtkComponentButton* QuitButton;
    [FieldOffset(0x250)] public AtkComponentButton* CalculationsButton;
    [FieldOffset(0x258)] public AtkComponentIcon* ItemIcon;

    [FieldOffset(0x268)] public AtkTextNode* ItemName;
    [FieldOffset(0x270)] public AtkResNode* DiamondImageNodeContainer;

    [FieldOffset(0x280)] public AtkTextNode* Condition;      // "Normal"

    [FieldOffset(0x298)] public AtkTextNode* CurrentQuality; // "100"
    [FieldOffset(0x2A0)] public AtkTextNode* MaxQuality;     // "200" 

    [FieldOffset(0x2C8)] public AtkTextNode* HQLiteral; // "HQ" or "Collectability"
    [FieldOffset(0x2D0)] public AtkTextNode* HQPercentage; // "0" -> "100", also collectability
    [FieldOffset(0x2D8)] public AtkTextNode* StepNumber; // "5"

    [FieldOffset(0x2F0)] public AtkTextNode* CurrentProgress; // "100"
    [FieldOffset(0x2F8)] public AtkTextNode* MaxProgress; // "200"

    [FieldOffset(0x308)] public AtkTextNode* CurrentDurability; // "50"
    [FieldOffset(0x310)] public AtkTextNode* StartingDurability; // "80"

    [FieldOffset(0x380)] public AtkTextNode* CollectabilityLow; // "100～" <- This is not a ~
    [FieldOffset(0x388)] public AtkTextNode* CollectabilityMid; // "200～"
    [FieldOffset(0x390)] public AtkTextNode* CollectabilityHigh; // "300～"
    [FieldOffset(0x398)] public AtkComponentCheckBox* ToggleCraftEffectPane;

    [FieldOffset(0x3B8)] public AtkTextNode* CraftEffectOverflow;
    [FieldOffset(0x3C0)] public CraftEffect CraftEffect1;
    [FieldOffset(0x3E0)] public CraftEffect CraftEffect2;
    [FieldOffset(0x400)] public CraftEffect CraftEffect3;
    [FieldOffset(0x420)] public CraftEffect CraftEffect4;
    [FieldOffset(0x440)] public CraftEffect CraftEffect5;
    [FieldOffset(0x460)] public CraftEffect CraftEffect6;
    [FieldOffset(0x480)] public CraftEffect CraftEffect7;
    [FieldOffset(0x4A0)] public CraftEffect CraftEffect8;
    [FieldOffset(0x4C0)] public CraftEffect CraftEffect9;

    [FieldOffset(0x500)] public Utf8String CraftEffect1HoverText;
    [FieldOffset(0x568)] public Utf8String CraftEffect2HoverText;
    [FieldOffset(0x5D0)] public Utf8String CraftEffect3HoverText;
    [FieldOffset(0x638)] public Utf8String CraftEffect4HoverText;
    [FieldOffset(0x6A0)] public Utf8String CraftEffect5HoverText;
    [FieldOffset(0x708)] public Utf8String CraftEffect6HoverText;
    [FieldOffset(0x770)] public Utf8String CraftEffect7HoverText;
    [FieldOffset(0x7D8)] public Utf8String CraftEffect8HoverText;
    [FieldOffset(0x840)] public Utf8String CraftEffect9HoverText;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct CraftEffect {
        // Manipulation, Innovation, etc.
        [FieldOffset(0x0)] public AtkComponentBase* Container;
        [FieldOffset(0x8)] public AtkImageNode* Image;
        [FieldOffset(0x10)] public AtkTextNode* StepsRemaining;
        [FieldOffset(0x18)] public AtkTextNode* Name;
    }
}
