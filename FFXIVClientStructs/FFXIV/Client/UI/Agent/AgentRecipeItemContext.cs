namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRecipeItemContext
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.RecipeItemContext)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct AgentRecipeItemContext {
    [FieldOffset(0x28)] public uint ResultItemId;

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 84 24 ?? ?? ?? ?? 48 8B CF")]
    public partial void AddItemContextMenuEntries(uint itemId, byte flags, byte* itemName, byte unk5 = 0, byte unk6 = 0);

    public void AddItemContextMenuEntries(uint itemId, byte flags, byte* itemName) => AddItemContextMenuEntries(itemId, flags, itemName, 0, 0);
}
