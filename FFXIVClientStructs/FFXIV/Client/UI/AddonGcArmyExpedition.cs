using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGcArmyExpedition
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GcArmyExpedition")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x300)]
public unsafe partial struct AddonGcArmyExpedition {
    [FieldOffset(0x238)] public AtkComponentButton* DeployButton;
    [FieldOffset(0x240)] public AtkComponentList* MissionList;
    [FieldOffset(0x250)] public AtkTextNode* ListHeaderTextNode;
    [FieldOffset(0x258)] public AtkTextNode* ScriptsTextNode;
    [FieldOffset(0x260)] public AtkTextNode* MissionDescriptionTextNode;

    [FieldOffset(0x270)] public AtkComponentBase* SquadronExpRewardComponentNode;
    [FieldOffset(0x278)] public AtkComponentBase* ItemRewardComponentNode;
    [FieldOffset(0x280)] public AtkTextNode* MissionSealCostTextNode;
    [FieldOffset(0x288)] public AtkResNode* MissionLevelResNode;
    [FieldOffset(0x290)] public AtkTextNode* MissionLevelTextNode; // MissionLevelTextNode is contained within MissionLevelResNode as well
    [FieldOffset(0x2B0)] public AtkComponentBase* RequiredAttributesComponentNode;
    [FieldOffset(0x2B8)] public AtkComponentBase* CurrentAttributesComponentNode;
    [FieldOffset(0x2D8)] public AtkResNode* SquadronSergeantImageResNode;
    [FieldOffset(0x2E0)] public AtkResNode* SquadronSergeantChatMessageResNode;
    [FieldOffset(0x2E8)] public AtkTextNode* SquadronSergeantChatMessageTextNode;

    [FieldOffset(0x2F0)] public int SelectedTab;
}
