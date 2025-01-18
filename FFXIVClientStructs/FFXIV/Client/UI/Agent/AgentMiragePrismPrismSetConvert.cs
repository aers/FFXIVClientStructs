using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMiragePrismPrismSetConvert
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MiragePrismPrismSetConvert)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentMiragePrismPrismSetConvert {
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 28 C6 40 02 0B")]
    public partial void Open(uint itemId, InventoryType inventoryType, int slot, int openerAddonId, bool enableStoring);

    // OpenPreview in data.yml
    public void Open(uint itemId) => Open(itemId, InventoryType.Invalid, 0, 0, false);
}
