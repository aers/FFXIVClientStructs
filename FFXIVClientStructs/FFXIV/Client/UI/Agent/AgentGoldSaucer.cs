namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentGoldSaucer
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.GoldSaucer)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe partial struct AgentGoldSaucer {
    [FieldOffset(0x5A)] public short GoldSaucerSelectedTab;
    [FieldOffset(0x5C)] public short ChocoboSeletedTab;
    [FieldOffset(0x100)] public int EditDeckSelectedPage;
    [FieldOffset(0x108)] public int EditDeckSelectedCardIndex;
    [FieldOffset(0x10C)] public CardListFilterMode CardListFilterMode;
    [FieldOffset(0x120)] public byte FilterDeckCardRarity;
    [FieldOffset(0x121)] public byte FilterDeckCardType;
    [FieldOffset(0x122)] public ushort FilterDeckSides;
    [FieldOffset(0x124)] public byte FilterDeckSorting;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 33 C0 C6 83")]
    public partial void RefreshDeckEdit();
}

public enum CardListFilterMode : byte {
    All = 0,
    OwnedOnly = 1,
    MissingOnly = 2,
}
