using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::ChatLog
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ChatLog)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xB30)]
public unsafe partial struct AgentChatLog {

    [FieldOffset(0x40)] public ChatChannel CurrentChannel;
    [FieldOffset(0x48)] public Utf8String ChannelLabel; // ie, "Say", "Party" that displays above the text input

    [FieldOffset(0xB8)] public Utf8String TellPlayerName;
    [FieldOffset(0x120)] public ushort TellWorldId;

    [FieldOffset(0x138)] public Utf8String ChannelSelectorFirstLSName;
    [FieldOffset(0x1A0)] public Utf8String ChannelSelectorSecondLSName;
    [FieldOffset(0x208)] public Utf8String ChannelSelectorThirdLSName;
    [FieldOffset(0x270)] public Utf8String ChannelSelectorFourthLSName;
    [FieldOffset(0x2D8)] public Utf8String ChannelSelectorFifthLSName;
    [FieldOffset(0x340)] public Utf8String ChannelSelectorSixthLSName;
    [FieldOffset(0x3A8)] public Utf8String ChannelSelectorSeventhLSName;
    [FieldOffset(0x410)] public Utf8String ChannelSelectorEighthLSName;

    [FieldOffset(0x478)] public Utf8String ChannelSelectorFirstCWLSName;
    [FieldOffset(0x4E0)] public Utf8String ChannelSelectorSecondCWLSName;
    [FieldOffset(0x548)] public Utf8String ChannelSelectorThirdCWLSName;
    [FieldOffset(0x5B0)] public Utf8String ChannelSelectorFourthCWLSName;
    [FieldOffset(0x618)] public Utf8String ChannelSelectorFifthCWLSName;
    [FieldOffset(0x680)] public Utf8String ChannelSelectorSixthCWLSName;
    [FieldOffset(0x6E8)] public Utf8String ChannelSelectorSeventhCWLSName;
    [FieldOffset(0x750)] public Utf8String ChannelSelectorEighthCWLSName;

    [FieldOffset(0x8A0)] public InventoryItem LinkedItem;
    [FieldOffset(0x8E0)] public byte LinkedItemQuality;
    [FieldOffset(0x8E8)] public Utf8String LinkedItemName;

    [FieldOffset(0x950)] public uint ContextItemId;

    [FieldOffset(0x960)] public ulong LinkedPartyFinderId;
    // [FieldOffset(0x960)] public byte LinkedPartyFinderUnkByte;
    [FieldOffset(0x970)] public Utf8String LinkedPartyFinderLeaderName;

    [FieldOffset(0x9D8)] public uint LinkedQuestId;
    [FieldOffset(0x9E0)] public Utf8String LinkedQuestName;

    [FieldOffset(0xA48)] public uint ContextStatusId; // also used for the <status> link?
    [FieldOffset(0xA50)] public Utf8String ContextStatusName;

    [FieldOffset(0xB24)] public int ReplyChannel;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B F0")]
    public partial bool InsertTextCommandParam(uint textParamId, bool unk);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 89 77")]
    public partial void LinkItem(uint itemId);

    [MemberFunction("E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8D 4D B0 48 8B F8 E8 ?? ?? ?? ?? 41 8B D6")]
    public partial byte* ChangeChannelName();
}

// There are definitely more channels than just these, these were all the ones I could find quickly.
public enum ChatChannel {
    Say = 1,
    Party = 2,
    Alliance = 3,
}
