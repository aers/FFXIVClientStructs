using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.InventoryContext)]
[StructLayout(LayoutKind.Explicit, Size = 0x678)]
public unsafe partial struct AgentInventoryContext
{
    public static AgentInventoryContext* Instance()
    {
        return (AgentInventoryContext*) Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(
            AgentId.InventoryContext);
    }

    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public uint BlockingAddonId;

    [FieldOffset(0x2C)] public int ContexItemStartIndex;

    [FieldOffset(0x30)] public int ContextItemCount;

    //TODO check if this is actually correct
    [FieldOffset(0x38)] public fixed byte EventParams[0x10 * 82];
    [FieldOffset(0x558)] public fixed byte EventIdArray[80];
    [FieldOffset(0x5A8)] public uint ContextItemDisabledMask;
    [FieldOffset(0x5AC)] public uint ContextItemSubmenuMask;

    public Span<AtkValue> EventParamsSpan
    {
        get
        {
            fixed (byte* ptr = EventParams)
            {
                return new Span<AtkValue>(ptr, 82);
            }
        }
    }

    public Span<byte> EventIdSpan
    {
        get
        {
            fixed (byte* ptr = EventIdArray)
            {
                return new Span<byte>(ptr, 80);
            }
        }
    }

    [FieldOffset(0x5B0)] public int PositionX;
    [FieldOffset(0x5B4)] public int PositionY;

    [FieldOffset(0x5C8)] public uint OwnerAddonId;

    [FieldOffset(0x5D0)] public InventoryType TargetInventoryId;
    [FieldOffset(0x5D4)] public int TargetInventorySlotId;

    [FieldOffset(0x5DC)] public uint DummyInventoryId;

    [FieldOffset(0x5E8)] public InventoryItem* TargetInventorySlot;
    [FieldOffset(0x5F0)] public InventoryItem TargetDummyItem;
    [FieldOffset(0x5D0)] public InventoryType BlockedInventoryId;
    [FieldOffset(0x5D4)] public int BlockedInventorySlotId;

    [FieldOffset(0x638)] public InventoryItem DiscardDummyItem;

    [MemberFunction("83 B9 ?? ?? ?? ?? ?? 7E ?? 39 91")]
    public partial void OpenForItemSlot(uint inventory, int slot, int a4, uint addonId);

    public void OpenForItemSlot(InventoryType inventory, int slot, uint addonId) {
        OpenForItemSlot((uint)inventory, slot, 0, addonId);
    }

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 89 7C 24 ??")]
    public partial long UseItem(uint itemId, uint inventoryType = 9999, uint itemSlot = 0, short a5 = 0);

    public bool IsContextItemDisabled(int index)
    {
        return index >= 0 && (ContextItemDisabledMask & (1 << index)) != 0;
    }
}