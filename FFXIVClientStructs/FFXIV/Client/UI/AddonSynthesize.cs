using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::AddonSynthesize
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x838)]
    public unsafe struct AddonSynthesize
    {
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
        [FieldOffset(0x220)] public AtkCollisionNode* RootCollisionNode;
        [FieldOffset(0x228)] public AtkComponentButton* QuitButton;
        [FieldOffset(0x230)] public AtkComponentButton* CalculationsButton;
        [FieldOffset(0x238)] public AtkComponentIcon* AtkComponentIcon238;
        [FieldOffset(0x240)] public AtkCollisionNode* AtkCollisionNode240;
        [FieldOffset(0x248)] public AtkTextNode* CraftedItemName;
        [FieldOffset(0x250)] public AtkResNode* AtkResNode250;
        [FieldOffset(0x258)] public AtkComponentBase* AtkComponentBase258;
        [FieldOffset(0x260)] public AtkTextNode* Condition; // "Normal"
        [FieldOffset(0x268)] public AtkResNode* ConditionResNode; // ImageNode as a child
        [FieldOffset(0x270)] public AtkTextNode* CurrentQuality; // "100"
        [FieldOffset(0x278)] public AtkTextNode* MaxQuality; // "200" 
        [FieldOffset(0x280)] public AtkResNode* AtkResNode280;
        [FieldOffset(0x288)] public AtkTextNode* HQLiteral; // "HQ"
        [FieldOffset(0x290)] public AtkTextNode* HQPercentage; // "0" -> "100"
        [FieldOffset(0x298)] public AtkTextNode* StepNumber; // "5"
        [FieldOffset(0x2A0)] public AtkComponentGaugeBar* ProgressGauge;
        [FieldOffset(0x2A8)] public AtkComponentGaugeBar* QualityGauge;
        [FieldOffset(0x2B0)] public AtkTextNode* CurrentProgress; // "100"
        [FieldOffset(0x2B8)] public AtkTextNode* MaxProgress; // "200"
        [FieldOffset(0x2C0)] public AtkResNode* AtkResNode2C0;
        [FieldOffset(0x2C8)] public AtkTextNode* CurrentDurability; // "50"
        [FieldOffset(0x2D0)] public AtkTextNode* StartingDurability; // "80"
        [FieldOffset(0x2D8)] public AtkComponentBase* AtkComponentBase2D8;
        [FieldOffset(0x2E0)] public AtkComponentBase* AtkComponentBase2E0;
        [FieldOffset(0x2E8)] public AtkComponentBase* AtkComponentBase2E8;
        [FieldOffset(0x2F0)] public AtkComponentBase* AtkComponentBase2F0;
        [FieldOffset(0x2F8)] public AtkComponentBase* AtkComponentBase2F8;
        [FieldOffset(0x300)] public AtkComponentBase* AtkComponentBase300;
        [FieldOffset(0x308)] public AtkComponentBase* AtkComponentBase308;
        [FieldOffset(0x310)] public AtkComponentBase* AtkComponentBase310;
        [FieldOffset(0x318)] public AtkComponentCheckBox* AtkComponentCheckBox318;
        [FieldOffset(0x320)] public AtkResNode* AtkResNode320;
        [FieldOffset(0x328)] public AtkResNode* AtkResNode328;
        [FieldOffset(0x330)] public AtkResNode* AtkResNode330;
        [FieldOffset(0x338)] public AtkTextNode* AtkTextNode338;
        [FieldOffset(0x340)] public CraftEffect CraftEffect1;
        [FieldOffset(0x360)] public CraftEffect CraftEffect2;
        [FieldOffset(0x380)] public CraftEffect CraftEffect3;
        [FieldOffset(0x3A0)] public CraftEffect CraftEffect4;
        [FieldOffset(0x3C0)] public CraftEffect CraftEffect5;
        [FieldOffset(0x3E0)] public CraftEffect CraftEffect6;
        [FieldOffset(0x400)] public CraftEffect CraftEffect7;
        [FieldOffset(0x420)] public CraftEffect CraftEffect8;
        [FieldOffset(0x440)] public CraftEffect CraftEffect9;
        [FieldOffset(0x478)] public AtkComponentTextNineGrid* AtkComponentTextNineGrid478;
        [FieldOffset(0x480)] public AtkResNode* AtkResNode480;
        [FieldOffset(0x488)] public Utf8String CraftEffect1HoverText;
        [FieldOffset(0x4F0)] public Utf8String CraftEffect2HoverText;
        [FieldOffset(0x558)] public Utf8String CraftEffect3HoverText;
        [FieldOffset(0x5C0)] public Utf8String CraftEffect4HoverText;
        [FieldOffset(0x628)] public Utf8String CraftEffect5HoverText;
        [FieldOffset(0x690)] public Utf8String CraftEffect6HoverText;
        [FieldOffset(0x6F8)] public Utf8String CraftEffect7HoverText;
        [FieldOffset(0x760)] public Utf8String CraftEffect8HoverText;
        [FieldOffset(0x7C8)] public Utf8String CraftEffect9HoverText;

        [StructLayout(LayoutKind.Explicit, Size=0x20)]
        public struct CraftEffect
        {
            // Manipulation, Innovation, etc.
            [FieldOffset(0x0)] public AtkComponentBase* Container;
            [FieldOffset(0x8)] public AtkImageNode* Image;
            [FieldOffset(0x10)] public AtkTextNode* StepsRemaining;
            [FieldOffset(0x18)] public AtkTextNode* Name;
        }
    }
}