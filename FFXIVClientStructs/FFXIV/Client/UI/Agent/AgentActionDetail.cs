namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ActionDetail)]
[GenerateInterop]
[Inherits<AgentInterface>]
[VirtualTable("83 79 5C 00 48 8D 05 ?? ?? ?? ?? 48 89 01 8B FA", 7)]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct AgentActionDetail {
    [FieldOffset(0x38)] public ActionKind ActionKind;
    [FieldOffset(0x3C)] public uint ActionId;
    [FieldOffset(0x40)] public uint OriginalId; // Example: Summon Topaz
    [FieldOffset(0x44)] public uint AdjustedId; // Example: Summon Titan II

    // flag & 1 = get AdjustedActionId
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 7C 24 ?? E9 ?? ?? ?? ?? 83 F8 0F")]
    public partial void HandleActionHover(ActionKind actionKind, uint actionId, int flag, byte isLovmActionDetail);
}

/// Keep in sync with <see cref="Enums.DetailKind"/>
public enum ActionKind {
    Action = 28,
    CraftingAction = 29,
    GeneralAction = 30,
    BuddyOrder = 31,
    MainCommand = 32,
    ExtraCommand = 33,
    Companion = 34,
    PetOrder = 35,
    Trait = 36,
    BuddyAction = 37,
    CompanyAction = 38,
    Mount = 39,
    ChocoboRaceAction = 40,
    ChocoboRaceItem = 41,
    DeepDungeonEquipment = 42,
    DeepDungeonEquipment2 = 43,
    DeepDungeonItem = 44,
    QuickChat = 45,
    ActionComboRoute = 46,
    PvPSelectTrait = 47,
    BgcArmyAction = 48,
    Perform = 49,
    DeepDungeonMagicStone = 50,
    DeepDungeonDemiclone = 51,
    EurekaMagiaAction = 52,
    MYCTemporaryItem = 53,
    Ornament = 54,
    Glasses = 55,
    Unk56 = 56,
    MKDTrait = 57,
    Unk58 = 58,
}
