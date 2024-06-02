namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRecipeItemContext
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.RecipeItemContext)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct AgentRecipeItemContext {
    [FieldOffset(0x28)] public uint ResultItemId;

    [MemberFunction("E8 ?? ?? ?? ?? 45 8B C4 41 8B D7")]
    public partial void AddItemContextMenuEntries(uint itemId, byte flags, byte* itemName);
}
