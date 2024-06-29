using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGcArmyCapture
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GcArmyCapture")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x278)]
public unsafe partial struct AddonGcArmyCapture {
    [FieldOffset(0x230)] public AtkComponentButton* DeployButton;
    [FieldOffset(0x238)] public AtkComponentList* MissionList;
    [FieldOffset(0x240)] public AtkComponentList* ChosenRecruitList;
    [FieldOffset(0x248)] public AtkTextNode* ScriptsTextNode;
    [FieldOffset(0x250)] public AtkTextNode* ExpRewardTextNode;
    [FieldOffset(0x258)] public AtkComponentBase* ExpRewardComponent;
    [FieldOffset(0x260)] public AtkTextNode* ExpendituresTextNode;
    [FieldOffset(0x268)] public AtkTextNode* MissionLevelTextNode;
    [FieldOffset(0x270)] public AtkTextNode* MissionRequirementsTextNode;
}
