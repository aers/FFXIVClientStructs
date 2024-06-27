using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFriendlist
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Friendlist)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct AgentFriendlist {
    [FieldOffset(0x28)] public InfoProxyFriendList* InfoProxy;
    [FieldOffset(0x30)] public Utf8String SelectedPlayerName;
    [FieldOffset(0xA0)] public ulong SelectedContentId;
    [FieldOffset(0xA8)] public ulong StatusRequestContentId;
    [FieldOffset(0xB0)] public int SelectedIndex;
    [FieldOffset(0xB4)] public uint SelectYesNoAddonId;
    [FieldOffset(0xB8)] public uint FriendGroupEditAddonId;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 D2 48 8B CB")]
    public partial void OpenFriendEstateTeleportation(ulong contentId);
}
