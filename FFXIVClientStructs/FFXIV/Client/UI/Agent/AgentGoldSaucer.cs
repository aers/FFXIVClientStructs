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
    [FieldOffset(0x120)] public ushort FilterDeckTypeRarity;
    [FieldOffset(0x122)] public ushort FilterDeckSides;
    [FieldOffset(0x124)] public byte FilterDeckSorting;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 94 C0 88 43 58")]
    public partial void RefreshDeckEdit();
}

public enum CardListFilterMode : byte {
    All = 0,
    OwnedOnly = 1,
    MissingOnly = 2,
}
