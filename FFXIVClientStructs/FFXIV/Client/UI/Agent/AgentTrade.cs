using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentTrade
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Trade)]
[GenerateInterop]
[Inherits<AgentInterface>, Inherits<AgentInventoryContext.InventoryContextEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x5A0)]
public unsafe partial struct AgentTrade {
    /// <remarks>
    /// 0 -> 4 = Trade Away Items <br/>
    /// 5 -> 9 = Trade Receive Items
    /// </remarks>
    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray10<RaptureAtkModule.ItemCache> _itemCache; // There seems to be space for 20 items in NumberArray and StringArray so maybe at some point SE adds 5 more slots for tradeing on each side to a total of 20

    [UnscopedRef] 
    public Span<RaptureAtkModule.ItemCache> ItemsGive => ItemCache[..5];

    [UnscopedRef] 
    public Span<RaptureAtkModule.ItemCache> ItemsReviece => ItemCache[5..];
}
