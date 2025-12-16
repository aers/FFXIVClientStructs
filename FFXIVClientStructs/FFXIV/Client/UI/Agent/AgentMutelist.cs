using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMutelist
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Mutelist)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe partial struct AgentMutelist {
    [FieldOffset(0x58)] public ulong SelectedPlayerAccountId;
    [FieldOffset(0x68)] public Utf8String SelectedPlayerFullName; // includes cross world icon

    [MemberFunction("40 53 55 56 57 41 56 B8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 2B E0 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 0F B7 AC 24"), GenerateStringOverloads]
    public partial bool Add(ulong accountId, ulong contentId, CStringPointer name, short worldId);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 54 24 50 48 8B CF E8")]
    public partial bool Remove(ulong accountId, bool showInLog = true);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 E8 48 85 DB")]
    public partial bool IsMuted(ulong accountId);
}
