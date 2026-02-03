namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Journal
//   Client::Game::UI::ScenarioTextReader
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4768)]
public unsafe partial struct Journal {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 66 89 83", 3)]
    public static partial Journal* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 35 41 8B CE")]
    public partial bool IsQuestAccepted(ushort questId);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 41 8B F8 8B DA 48 8B F1 E8 ?? ?? ?? ?? 48 8B C8")]
    public partial void AbandonQuest(QuestType type, uint questId);

    public enum QuestType {
        NormalQuest = 1,
        LeveQuest
    }
}
