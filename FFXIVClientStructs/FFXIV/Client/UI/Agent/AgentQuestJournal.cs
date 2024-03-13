using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentQuestJournal
//   Client::UI::Agent::AgentInterface
// ctor "48 89 5C 24 ?? 57 48 83 EC 30 48 8B FA 48 8B D9 E8 ?? ?? ?? ?? 33 D2"
[Agent(AgentId.QuestJournal)]
[StructLayout(LayoutKind.Explicit, Size = 0x280)]
public unsafe partial struct AgentQuestJournal {
    [FieldOffset(0)] public AgentInterface AgentInterface;

    [FieldOffset(0x56)] public fixed byte JournalCategoryIds[52];
    [FieldOffset(0x8A)] public bool IsDisplayingCompletedQuests;

    [FieldOffset(0x90)] public byte SelectedSection;
    [FieldOffset(0x91)] public byte SelectedGenreIndex;
    [FieldOffset(0x92)] public byte NumSelectableGenres;

    [FieldOffset(0xA0)] public uint SelectedQuestId;
    [FieldOffset(0xA4)] public uint SelectedQuestType; // 0 = Completed Quest, 1 = Quest, 2 = LeveQuest
    [FieldOffset(0xA8)] public uint SelectedCompletedQuestId;

    [FieldOffset(0xF4)] public uint SearchFlag; // bit 2 is set when "Title Only" checkbox is unticked
    [FieldOffset(0xF8)] public Utf8String SearchTerm;

    [FieldOffset(0x180)] public Utf8String SearchTerm2;

    [FieldOffset(0x238)] public ExcelSheet* QuestSheet;

    [FieldOffset(0x248)] public ExcelSheet* LeveSheet;

    /// <summary>
    /// Opens the Journal for a given quest id.
    /// </summary>
    /// <param name="questId">The quest id to select.</param>
    /// <param name="type">The type of the quest. 1 = Quest, 2 = LeveQuest</param>
    /// <param name="a4"></param>
    /// <param name="keepOpen">When viewing completed quests, this will keep the window open, even if this function is called multiple times.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 74 24 ?? 48 8B 7C 24 ?? 48 83 C4 30 5B C3 48 8B CB")]
    public partial void OpenForQuest(uint questId, uint type, ushort a4 = 0, bool keepOpen = true);

    /// <summary>
    /// Opens the map for the currently selected quest.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB 24 8B 56 20")]
    public partial void ShowOnMap(int a2 = 0);
}
