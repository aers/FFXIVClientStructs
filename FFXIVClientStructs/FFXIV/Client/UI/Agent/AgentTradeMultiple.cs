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
    [MemberFunction("40 53 48 83 EC 70 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 48 8B D9 E8 ?? ?? ?? ?? 85 C0 74 ?? 80 7B 44 01")]
    public partial bool Confirm();

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC ?? 48 8B 01 49 8B E9 45 8B F0 0F B6 FA 48 8B D9")]
    public partial void Open(bool showErrorMessages, uint maxQuantity, AtkEventInterface* handler);

    [MemberFunction("48 89 5C 24 ?? 56 57 41 56 48 83 EC ?? 41 0F BF F8 8B DA 48 8B F1 E8 ?? ?? ?? ?? 44 8B F0 85 C0 75 ?? 80 7E 44 01")]
    public partial void AddItem(InventoryType inventoryType, short slot);

    /// <summary>Commit <paramref name="quantity"/> of <paramref name="item"/> into the next free slot.</summary>
    [MemberFunction("48 85 D2 0F 84 ?? ?? ?? ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC ?? 45 8B F0 48 8B F2 48 8B F9 45 85 C0")]
    public partial void AddItemQuantity(InventoryItem* item, uint quantity);

    [MemberFunction("40 53 55 48 83 EC ?? 48 89 74 24 ?? 48 8B E9 8B F2 83 FA 05 0F 83 ?? ?? ?? ?? 48 89 7C 24 ?? 48 8D 7E 05")]
    public partial void RemoveSlot(uint slotIndex);

    [MemberFunction("81 79 50 0F 27 00 00 8B 41 48")]
    public partial uint GetSlotsRemaining();

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 54 41 55 41 56 41 57 48 81 EC 80 01 00 00")]
    public partial void RefreshAddon();
}
