using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.SocialFriendList)]
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
// inlined ctor
public unsafe struct AgentFriendList {
    public static AgentFriendList* Instance() => (AgentFriendList*)AgentModule.Instance()->GetAgentByInternalId(AgentId.SocialFriendList);

    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public InfoProxyFriendList* InfoProxy;

    public uint Count => InfoProxy->InfoProxyCommonList.InfoProxyPageInterface.InfoProxyInterface.GetEntryCount();
    public InfoProxyCommonList.CharacterData* GetFriend(uint index) => InfoProxy->InfoProxyCommonList.GetEntry(index);
    public InfoProxyCommonList.CharacterData* this[uint index] => GetFriend(index);
}
