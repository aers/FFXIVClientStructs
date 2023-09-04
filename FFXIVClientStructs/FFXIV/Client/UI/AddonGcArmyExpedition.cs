using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GcArmyExpedition")]
[StructLayout(LayoutKind.Explicit, Size = 0x2E8)]
public unsafe struct AddonGcArmyExpedition {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public AtkComponentButton* DeployButton;
    [FieldOffset(0x228)] public AtkComponentList* MissionList;
    [FieldOffset(0x238)] public AtkTextNode* ListHeaderTextNode;
    [FieldOffset(0x240)] public AtkTextNode* ScriptsTextNode;
    [FieldOffset(0x248)] public AtkTextNode* MissionDescriptionTextNode;

    [FieldOffset(0x258)] public AtkComponentBase* SquadronExpRewardComponentNode;
    [FieldOffset(0x260)] public AtkComponentBase* ItemRewardComponentNode;
    [FieldOffset(0x268)] public AtkTextNode* MissionSealCostTextNode;
    [FieldOffset(0x270)] public AtkResNode* MissionLevelResNode;
    [FieldOffset(0x278)] public AtkTextNode* MissionLevelTextNode; // MissionLevelTextNode is contained within MissionLevelResNode as well
    [FieldOffset(0x298)] public AtkComponentBase* RequiredAttributesComponentNode;
    [FieldOffset(0x2A0)] public AtkComponentBase* CurrentAttributesComponentNode;
    [FieldOffset(0x2C0)] public AtkResNode* SquadronSergeantImageResNode;
    [FieldOffset(0x2C8)] public AtkResNode* SquadronSergeantChatMessageResNode;
    [FieldOffset(0x2D0)] public AtkTextNode* SquadronSergeantChatMessageTextNode;

    [FieldOffset(0x2D8)] public int SelectedTab;
}
