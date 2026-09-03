using FFXIVClientStructs.FFXIV.Client.Game;
using AtkEventInterface = FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface.AtkEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentTradeMultiple
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
//   Client::UI::Agent::AgentInventoryContext::InventoryContextEvent
[Agent(AgentId.TradeMultiple)]
[GenerateInterop]
[Inherits<AgentInterface>, Inherits<AgentInventoryContext.InventoryContextEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct AgentTradeMultiple {
    [FieldOffset(0x30)] public AtkEventInterface* Handler;
    [FieldOffset(0x38)] public uint InputNumericAddonId;
    [FieldOffset(0x3C)] public uint SelectYesnoAddonId;
    /// <remarks>When set to 1, <see cref="AgentInterface.Update"/> retries <see cref="AddItem"/> for <see cref="PendingItem"/>.</remarks>
    [FieldOffset(0x40)] public uint PendingAdd;
    [FieldOffset(0x44)] public bool ShowErrorMessages;
    [FieldOffset(0x48)] public uint MaxQuantity;
    [FieldOffset(0x4C)] public int InventoryFilterIndex; // passed to AgentInventory as 16
    /// <remarks><see cref="InventoryItemRef.Quantity"/> holds the committed stack amount per slot. Empty slots use <see cref="InventoryType.Invalid"/>.</remarks>
    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray5<InventoryItemRef> _slots;
    /// <remarks>Slot staging for the InputNumeric quantity prompt.</remarks>
    [FieldOffset(0xA0)] public InventoryItemRef PendingItem;

    public bool IsFull => GetSlotsRemaining() == 0;

    /// <remarks>Writes current slots to <c>UIState.MateriaTrade</c></remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? ?? ?? ?? 48 8B CB FF 50 ?? B1")]
    public partial bool Confirm();

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC ?? 48 8B 01 49 8B E9 45 8B F0 0F B6 FA 48 8B D9")]
    public partial void Open(bool showErrorMessages, uint maxQuantity, AtkEventInterface* handler);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 4E ?? E8 ?? ?? ?? ?? 8B E8")]
    public partial void AddItem(InventoryType inventoryType, short slot);

    /// <summary>Commit <paramref name="quantity"/> of <paramref name="item"/> into the next free slot.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 81 FA ?? ?? ?? ?? 74 ?? 44 0F B7 83 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 39 73")]
    public partial void AddItemQuantity(InventoryItem* item, uint quantity);

    [MemberFunction("40 53 55 48 83 EC ?? 48 89 74 24 ?? 48 8B E9 8B F2 83 FA 05 0F 83 ?? ?? ?? ?? 48 89 7C 24 ?? 48 8D 7E 05")]
    public partial void RemoveSlot(uint slotIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 48 8D 54 24")]
    public partial uint GetSlotsRemaining();

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 FF 74 ?? 39 73")]
    public partial void RefreshAddon();
}
