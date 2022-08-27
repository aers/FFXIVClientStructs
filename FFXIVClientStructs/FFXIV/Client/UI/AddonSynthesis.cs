using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSynthesis
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x8A8)]
public unsafe struct AddonSynthesis
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x238)] public AtkComponentButton* QuitButton;
    [FieldOffset(0x240)] public AtkComponentButton* CalculationsButton;
    [FieldOffset(0x248)] public AtkComponentIcon* ItemIcon;

    [FieldOffset(0x258)] public AtkTextNode* ItemName;
    [FieldOffset(0x260)] public AtkResNode* DiamondImageNodeContainer;

    [FieldOffset(0x270)] public AtkTextNode* Condition;      // "Normal"

    [FieldOffset(0x288)] public AtkTextNode* CurrentQuality; // "100"
    [FieldOffset(0x290)] public AtkTextNode* MaxQuality;     // "200" 

    [FieldOffset(0x2B8)] public AtkTextNode* HQLiteral; // "HQ" or "Collectability"
    [FieldOffset(0x2C0)] public AtkTextNode* HQPercentage; // "0" -> "100", also collectability
    [FieldOffset(0x2C8)] public AtkTextNode* StepNumber; // "5"

    [FieldOffset(0x2E0)] public AtkTextNode* CurrentProgress; // "100"
    [FieldOffset(0x2E8)] public AtkTextNode* MaxProgress; // "200"

    [FieldOffset(0x2F8)] public AtkTextNode* CurrentDurability; // "50"
    [FieldOffset(0x300)] public AtkTextNode* StartingDurability; // "80"

    [FieldOffset(0x370)] public AtkTextNode* CollectabilityLow; // "100～" <- This is not a ~
    [FieldOffset(0x378)] public AtkTextNode* CollectabilityMid; // "200～"
    [FieldOffset(0x380)] public AtkTextNode* CollectabilityHigh; // "300～"
    [FieldOffset(0x388)] public AtkComponentCheckBox* ToggleCraftEffectPane;

    [FieldOffset(0x3A8)] public AtkTextNode* CraftEffectOverflow;
    [FieldOffset(0x3B0)] public CraftEffect CraftEffect1;
    [FieldOffset(0x3D0)] public CraftEffect CraftEffect2;
    [FieldOffset(0x3F0)] public CraftEffect CraftEffect3;
    [FieldOffset(0x410)] public CraftEffect CraftEffect4;
    [FieldOffset(0x430)] public CraftEffect CraftEffect5;
    [FieldOffset(0x450)] public CraftEffect CraftEffect6;
    [FieldOffset(0x470)] public CraftEffect CraftEffect7;
    [FieldOffset(0x490)] public CraftEffect CraftEffect8;
    [FieldOffset(0x4B0)] public CraftEffect CraftEffect9;

    [FieldOffset(0x4F0)] public Utf8String CraftEffect1HoverText;
    [FieldOffset(0x558)] public Utf8String CraftEffect2HoverText;
    [FieldOffset(0x5C0)] public Utf8String CraftEffect3HoverText;
    [FieldOffset(0x628)] public Utf8String CraftEffect4HoverText;
    [FieldOffset(0x690)] public Utf8String CraftEffect5HoverText;
    [FieldOffset(0x6F8)] public Utf8String CraftEffect6HoverText;
    [FieldOffset(0x760)] public Utf8String CraftEffect7HoverText;
    [FieldOffset(0x7C8)] public Utf8String CraftEffect8HoverText;
    [FieldOffset(0x830)] public Utf8String CraftEffect9HoverText;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct CraftEffect
    {
        // Manipulation, Innovation, etc.
        [FieldOffset(0x0)] public AtkComponentBase* Container;
        [FieldOffset(0x8)] public AtkImageNode* Image;
        [FieldOffset(0x10)] public AtkTextNode* StepsRemaining;
        [FieldOffset(0x18)] public AtkTextNode* Name;
    }
}