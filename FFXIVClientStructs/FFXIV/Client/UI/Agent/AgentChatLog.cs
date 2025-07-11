using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;
using static FFXIVClientStructs.FFXIV.Common.Configuration.ConfigBase;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::ChatLog
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
//   Common::Configuration::ConfigBase::ChangeEventInterface
[Agent(AgentId.ChatLog)]
[GenerateInterop]
[Inherits<AgentInterface>, Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xB38)]
public unsafe partial struct AgentChatLog {

    [FieldOffset(0x40)] public ChatChannel CurrentChannel;
    [FieldOffset(0x48)] public Utf8String ChannelLabel; // ie, "Say", "Party" that displays above the text input

    [FieldOffset(0xB8)] public Utf8String TellPlayerName;
    [FieldOffset(0x120)] public ushort TellWorldId;

    [FieldOffset(0x138), FixedSizeArray] internal FixedSizeArray8<Utf8String> _channelSelectorLSNames;
    [FieldOffset(0x478), FixedSizeArray] internal FixedSizeArray8<Utf8String> _channelSelectorCWLSNames;

    [FieldOffset(0x8A0)] public InventoryItem LinkedItem; // TODO: use LinkedInventoryItem as type, obsolete LinkedItemQuality below
    [FieldOffset(0x8E8)] public byte LinkedItemQuality;
    [FieldOffset(0x8F0)] public Utf8String LinkedItemName;

    [FieldOffset(0x958)] public uint ContextItemId;

    [FieldOffset(0x968)] public ulong LinkedPartyFinderId;
    // [FieldOffset(0x960)] public byte LinkedPartyFinderUnkByte;
    [FieldOffset(0x978)] public Utf8String LinkedPartyFinderLeaderName;

    [FieldOffset(0x9E0)] public uint LinkedQuestId;
    [FieldOffset(0x9E8)] public Utf8String LinkedQuestName;

    [FieldOffset(0xA50)] public uint ContextStatusId; // also used for the <status> link?
    [FieldOffset(0xA58)] public Utf8String ContextStatusName;

    [FieldOffset(0xB2C)] public int ReplyChannel;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8D 4D 20")]
    public partial void HideLogWindow();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B F0")]
    public partial bool InsertTextCommandParam(uint textParamId, bool unk);

    [MemberFunction("E8 ?? ?? ?? ?? C6 43 08 01 EB 7D")]
    public partial void LinkItem(uint itemId);

    [MemberFunction("E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8D 4D B0 48 8B F8 E8 ?? ?? ?? ?? 41 8B D6")]
    public partial CStringPointer ChangeChannelName();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8D ?? ?? ?? ?? 48 33 CC E8 ?? ?? ?? ?? 48 81 C4 ?? ?? ?? ?? 41 5F 41 5D 41 5C 5F")]
    public partial void SetTabName(int tabIndex, Utf8String* tabName);

    [GenerateInterop]
    [Inherits<InventoryItem>]
    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public partial struct LinkedInventoryItem {
        [FieldOffset(0x48)] public byte Quality;
    }
}

// There are definitely more channels than just these, these were all the ones I could find quickly.
public enum ChatChannel {
    Say = 1,
    Party = 2,
    Alliance = 3,
}
