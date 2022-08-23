using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentCharaCard
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.CharaCard)]
[StructLayout(LayoutKind.Explicit, Size = 0x920)]
public unsafe partial struct AgentCharaCard
{
    public static AgentCharaCard* Instance() => (AgentCharaCard*)Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.CharaCard);
    
    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4B 10 48 8D BB", IsPrivate = true)]
    private partial void OpenCharaCardForContentId(ulong contentId);

    public void OpenCharaCard(ulong contentId) => OpenCharaCardForContentId(contentId);

    [MemberFunction("48 85 D2 74 6D 48 89 5C 24", IsPrivate = true)]
    private partial void OpenCharaCardForObject(GameObject* gameObject);
    public void OpenCharaCard(GameObject* gameObject) => OpenCharaCardForObject(gameObject);
}
