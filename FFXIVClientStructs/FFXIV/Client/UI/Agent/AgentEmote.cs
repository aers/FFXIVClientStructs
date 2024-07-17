using FFXIVClientStructs.FFXIV.Client.Game.Control;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentEmote
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Emote)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct AgentEmote {
    [MemberFunction("E9 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B 10 48 8B C8 FF 52 70")]
    public partial bool CanUseEmote(ushort emoteId);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8B 8A ?? ?? ?? ?? 8B C1 C1 E8 08")]
    public partial void ExecuteEmote(ushort emoteId, EmoteController.PlayEmoteOption* playEmoteOption = null, bool addToHistory = true, bool liveUpdateHistory = true);
}
