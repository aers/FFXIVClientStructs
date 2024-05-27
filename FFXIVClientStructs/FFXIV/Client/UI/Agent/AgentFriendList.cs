using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.SocialFriendList)]
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
[GenerateInterop]
[Inherits<AgentInterface>]
// inlined ctor
public unsafe partial struct AgentFriendList {
    [FieldOffset(0x28)] public InfoProxyFriendList* InfoProxy;
    [FieldOffset(0x30)] public Utf8String SelectedPlayerName;
    [FieldOffset(0xA0)] public ulong SelectedContentId;
    [FieldOffset(0xB0)] public byte SelectedIndex;

    public uint Count => InfoProxy->GetEntryCount();
    public InfoProxyCommonList.CharacterData* GetFriend(uint index) => InfoProxy->InfoProxyCommonList.GetEntry(index);
    public InfoProxyCommonList.CharacterData* this[uint index] => GetFriend(index);
}
