namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ActionDetail)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct AgentActionDetail {
    [FieldOffset(0x38)] public ActionKind ActionKind;
    [FieldOffset(0x3C)] public uint ActionId;
    [FieldOffset(0x40)] public uint OriginalId; // Example: Summon Topaz
    [FieldOffset(0x44)] public uint AdjustedId; // Example: Summon Titan II

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 83 F8 0F")]
    public partial void HandleActionHover(ActionKind actionKind, uint actionId, int flag, byte unk);
}

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
    DeepDungeonEquipment = 42, // with extra param 0x2A
    DeepDungeonEquipment2 = 43, // with extra param 0x2B
    DeepDungeonItem = 44,
    QuickChat = 45,
    ActionComboRoute = 46,
    PvPSelectTrait = 47,
    SquadronAction = 48,
    Performance = 49,
    DeepDungeonMagicStone = 50,
    DeepDungeonDemiclone = 51,
    EurekaMagiaAction = 52,
    MYCTemporaryItem = 53,
    Ornament = 54,
    Glasses = 55,
}

