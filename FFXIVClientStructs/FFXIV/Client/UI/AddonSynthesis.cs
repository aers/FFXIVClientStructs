using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSynthesis
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x898)]
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
    
    [FieldOffset(0x2B0)] public AtkTextNode* HQLiteral; // "HQ" or "Collectability"
    [FieldOffset(0x2B8)] public AtkTextNode* HQPercentage; // "0" -> "100", also collectability
    [FieldOffset(0x2C0)] public AtkTextNode* StepNumber; // "5"
    
    [FieldOffset(0x2D8)] public AtkTextNode* CurrentProgress; // "100"
    [FieldOffset(0x2E0)] public AtkTextNode* MaxProgress; // "200"
    
    [FieldOffset(0x2F0)] public AtkTextNode* CurrentDurability; // "50"
    [FieldOffset(0x2F8)] public AtkTextNode* StartingDurability; // "80"

    [FieldOffset(0x368)] public AtkTextNode* CollectabilityLow; // "100～" <- This is not a ~
    [FieldOffset(0x370)] public AtkTextNode* CollectabilityMid; // "200～"
    [FieldOffset(0x378)] public AtkTextNode* CollectabilityHigh; // "300～"
    [FieldOffset(0x380)] public AtkComponentCheckBox* ToggleCraftEffectPane;

    [FieldOffset(0x3A0)] public AtkTextNode* CraftEffectOverflow;
    [FieldOffset(0x3A8)] public CraftEffect CraftEffect1;
    [FieldOffset(0x3C8)] public CraftEffect CraftEffect2;
    [FieldOffset(0x3E8)] public CraftEffect CraftEffect3;
    [FieldOffset(0x408)] public CraftEffect CraftEffect4;
    [FieldOffset(0x428)] public CraftEffect CraftEffect5;
    [FieldOffset(0x448)] public CraftEffect CraftEffect6;
    [FieldOffset(0x468)] public CraftEffect CraftEffect7;
    [FieldOffset(0x488)] public CraftEffect CraftEffect8;
    [FieldOffset(0x4A8)] public CraftEffect CraftEffect9;

    [FieldOffset(0x4E8)] public Utf8String CraftEffect1HoverText;
    [FieldOffset(0x550)] public Utf8String CraftEffect2HoverText;
    [FieldOffset(0x5B8)] public Utf8String CraftEffect3HoverText;
    [FieldOffset(0x620)] public Utf8String CraftEffect4HoverText;
    [FieldOffset(0x688)] public Utf8String CraftEffect5HoverText;
    [FieldOffset(0x6F0)] public Utf8String CraftEffect6HoverText;
    [FieldOffset(0x758)] public Utf8String CraftEffect7HoverText;
    [FieldOffset(0x7C0)] public Utf8String CraftEffect8HoverText;
    [FieldOffset(0x828)] public Utf8String CraftEffect9HoverText;

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