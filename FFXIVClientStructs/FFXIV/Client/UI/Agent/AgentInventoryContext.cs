using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.InventoryContext)]
[StructLayout(LayoutKind.Explicit, Size = 0x778)]
public unsafe partial struct AgentInventoryContext {
    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public uint BlockingAddonId;
    [FieldOffset(0x2C)] public int ContexItemStartIndex;
    [FieldOffset(0x30)] public int ContextItemCount;

    [FieldOffset(0x38)] public fixed byte EventParams[0x10 * 98];
    [FieldOffset(0x658)] public fixed byte EventIdArray[84];
    [FieldOffset(0x6AC)] public uint ContextItemDisabledMask;
    [FieldOffset(0x6B0)] public uint ContextItemSubmenuMask;

    public Span<AtkValue> EventParamsSpan => new(Unsafe.AsPointer(ref EventParams[0]), 98);
    public Span<byte> EventIdSpan => new(Unsafe.AsPointer(ref EventIdArray[0]), 84);

    [FieldOffset(0x6B4)] public int PositionX;
    [FieldOffset(0x6B8)] public int PositionY;

    [FieldOffset(0x6C8)] public uint OwnerAddonId;
    [FieldOffset(0x6CC), CExportIgnore] public int YesNoPosition; // 2 shorts combined, gets passed as int arg, default = -1
    [FieldOffset(0x6CC)] public short YesNoX;
    [FieldOffset(0x6CE)] public short YesNoY;
    [FieldOffset(0x6D0)] public InventoryType TargetInventoryId;
    [FieldOffset(0x6D4)] public int TargetInventorySlotId;

    [FieldOffset(0x6DC)] public uint DummyInventoryId;

    [FieldOffset(0x6E8)] public InventoryItem* TargetInventorySlot;
    [FieldOffset(0x6F0)] public InventoryItem TargetDummyItem;
    [FieldOffset(0x728)] public InventoryType BlockedInventoryId;
    [FieldOffset(0x72C)] public int BlockedInventorySlotId;

    [FieldOffset(0x738)] public InventoryItem DiscardDummyItem;
    [FieldOffset(0x770)] public int DialogType; // ?? 1 = Discard, 2 = LowerQuality

    [MemberFunction("83 B9 ?? ?? ?? ?? ?? 7E ?? 39 91")]
    public partial void OpenForItemSlot(uint inventory, int slot, int a4, uint addonId);

    public void OpenForItemSlot(InventoryType inventory, int slot, uint addonId) {
        OpenForItemSlot((uint)inventory, slot, 0, addonId);
    }

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 89 7C 24 ??")]
    public partial long UseItem(uint itemId, uint inventoryType = 9999, uint itemSlot = 0, short a5 = 0);

    public bool IsContextItemDisabled(int index) {
        return index >= 0 && (ContextItemDisabledMask & (1 << index)) != 0;
    }

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 ?? 0F B7 48")]
    public partial void DiscardItem(InventoryItem* itemSlot, InventoryType inventory, int slot, uint addonId, int position = -1); //position = YesNoPosition

    [MemberFunction("E8 ?? ?? ?? ?? 48 83 C4 ?? 5B C3 8B 83")]
    public partial void LowerItemQuality(InventoryItem* itemSlot, InventoryType inventory, int slot, uint addonId);
}
