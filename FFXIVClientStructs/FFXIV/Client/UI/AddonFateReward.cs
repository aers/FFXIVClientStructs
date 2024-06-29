using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFateReward
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("FateReward")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x580)]
public unsafe partial struct AddonFateReward {
    [FieldOffset(0x230)] public AtkResNode* AtkResNode220;
    [FieldOffset(0x238)] public AtkImageNode* AtkImageNode228;
    [FieldOffset(0x240)] public AtkImageNode* AtkImageNode230;
    [FieldOffset(0x248)] public AtkResNode* AtkResNode238;
    [FieldOffset(0x250)] public AtkTextNode* AtkTextNode240; // FAILED
    [FieldOffset(0x258)] public AtkTextNode* AtkTextNode248; // SUCCESSFUL
    [FieldOffset(0x260)] public AtkTextNode* AtkTextNode250; // SUCCESSFUL
    [FieldOffset(0x268)] public AtkImageNode* AtkImageNode258;

    // Reward 1
    [FieldOffset(0x2D8)] public AtkComponentTextNineGrid* AtkComponentTextNineGrid2C8;
    [FieldOffset(0x2E0)] public AtkImageNode* AtkImageNode2D0;
    [FieldOffset(0x2E8)] public AtkResNode* AtkResNode2D8;

    // Reward 2
    [FieldOffset(0x358)] public AtkComponentTextNineGrid* AtkComponentTextNineGrid348;
    [FieldOffset(0x360)] public AtkImageNode* AtkImageNode350;
    [FieldOffset(0x368)] public AtkResNode* AtkResNode358;

    [FieldOffset(0x570)] public AtkResNode* AtkResNode560;
    [FieldOffset(0x578)] public float ElapsedSeconds;   // Elapsed time since the addon was displayed. Closes after 7 seconds. (hard coded)
}
