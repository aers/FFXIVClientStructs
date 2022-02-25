using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.RecipeNote)]
[StructLayout(LayoutKind.Explicit, Size = 0x560)]
public unsafe struct AgentRecipeNote {
    public static AgentRecipeNote* Instance() => (AgentRecipeNote*)Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.RecipeNote);
    
    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0x3BC)] public int SelectedRecipeIndex;
}
