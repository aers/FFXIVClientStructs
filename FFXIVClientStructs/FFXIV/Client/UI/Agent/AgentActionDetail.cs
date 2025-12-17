namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ActionDetail)]
[GenerateInterop]
[Inherits<AgentInterface>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 01 8B FA 48 8B D9 74 ?? 0F B6 41", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct AgentActionDetail {
    [FieldOffset(0x38)] public ActionKind ActionKind;
    [FieldOffset(0x3C)] public uint ActionId;
    [FieldOffset(0x40)] public uint OriginalId; // Example: Summon Topaz
    [FieldOffset(0x44)] public uint AdjustedId; // Example: Summon Titan II

    // flag & 1 = get AdjustedActionId
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 83 F8 0F")]
    public partial void HandleActionHover(ActionKind actionKind, uint actionId, int flag, bool isLovmActionDetail, int a5, int a6);
}

/// Keep in sync with <see cref="Enums.DetailKind"/>
public enum ActionKind {
    Action = 29,
    CraftingAction = 30,
    GeneralAction = 31,
    BuddyOrder = 32,
    MainCommand = 33,
    ExtraCommand = 34,
    Companion = 35,
    PetOrder = 36,
    Trait = 37,
    BuddyAction = 38,
    CompanyAction = 39,
    Mount = 40,
    ChocoboRaceAction = 41,
    ChocoboRaceItem = 42,
    DeepDungeonEquipment = 43,
    DeepDungeonEquipment2 = 44,
    DeepDungeonItem = 45,
    QuickChat = 46,
    ActionComboRoute = 47,
    PvPSelectTrait = 48,
    BgcArmyAction = 49,
    Perform = 50,
    DeepDungeonMagicStone = 51,
    DeepDungeonDemiclone = 52,
    EurekaMagiaAction = 53,
    MYCTemporaryItem = 54,
    Ornament = 55,
    Glasses = 56,
    Unk57 = 57,
    MKDTrait = 58,
    Unk59 = 59,
}
