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
    GeneralAction = 30,
    CompanionOrder = 31,
    MainCommand = 32,
    ExtraCommand = 33,
    Minion = 34,
    PetOrder = 35,
    Trait = 36,
    CompanionAction = 37,
    Mount = 39,
    SquadronAction = 48,
    Performance = 49,
}

