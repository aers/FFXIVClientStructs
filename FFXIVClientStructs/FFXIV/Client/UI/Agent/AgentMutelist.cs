using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMutelist
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Mutelist)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct AgentMutelist {
    [FieldOffset(0x58)] public ulong SelectedPlayerAccountId;
    [FieldOffset(0x68)] public Utf8String SelectedPlayerFullName; // includes cross world icon

    [MemberFunction("E8 ?? ?? ?? ?? EB 32 E8 ?? ?? ?? ?? 84 C0"), GenerateStringOverloads]
    public partial bool Add(ulong accountId, ulong contentId, CStringPointer name, short worldId);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 54 24 50 48 8B CB E8 ?? ?? ?? ?? 48 8B 5C 24")]
    public partial bool Remove(ulong accountId);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 4E ?? 4C 8D 66 32")]
    public partial bool IsMuted(ulong accountId);
}
