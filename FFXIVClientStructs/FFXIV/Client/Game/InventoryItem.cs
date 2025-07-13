using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::InventoryItem
[GenerateInterop(isInherited: true)]
[VirtualTable("66 89 51 0C 48 8D 05", 7)]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct InventoryItem : ICreatable {
    [FieldOffset(0x08)] public InventoryType Container;
    [FieldOffset(0x0C)] public short Slot;
    /// <summary>
    /// Indicates whether this InventoryItem is symbolic, serving as a link to another InventoryItem<br/>
    /// identified by <see cref="LinkedItemSlot"/> and <see cref="LinkedInventoryType"/>.
    /// </summary>
    [FieldOffset(0x0E)] public bool IsSymbolic;
    /// <remarks> Only used if <see cref="IsSymbolic"/> is <c>false</c>. </remarks>
    [FieldOffset(0x10), CExporterUnion("Id")] public uint ItemId;
    /// <remarks> Only used if <see cref="IsSymbolic"/> is <c>true</c>. </remarks>
    [FieldOffset(0x10), CExporterUnion("Id", "Linked", true)] public ushort LinkedItemSlot;
    /// <remarks> Only used if <see cref="IsSymbolic"/> is <c>true</c>. </remarks>
    [FieldOffset(0x12), CExporterUnion("Id", "Linked", true)] public ushort LinkedInventoryType;
    [FieldOffset(0x14)] public int Quantity;
    [FieldOffset(0x18)] public ushort SpiritbondOrCollectability;
    [FieldOffset(0x1A)] public ushort Condition;
    [FieldOffset(0x1C)] public ItemFlags Flags;
    [FieldOffset(0x20)] public ulong CrafterContentId;
    [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray5<ushort> _materia;
    [FieldOffset(0x32), FixedSizeArray] internal FixedSizeArray5<byte> _materiaGrades;
    [FieldOffset(0x37), FixedSizeArray] internal FixedSizeArray2<byte> _stains;
    [FieldOffset(0x3C)] public uint GlamourId;
    [FieldOffset(0x40)] public EventId EventId;

    [Flags]
    public enum ItemFlags : byte {
        None = 0,
        HighQuality = 1,
        CompanyCrestApplied = 2,
        Relic = 4,
        Collectable = 8
    }

    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 48 8D 4B 58")]
    public partial void Ctor();

    [VirtualFunction(0)]
    public partial void Dtor();

    /// <summary>Copies the values from the other InventoryItem and, if it's symbolic, resolves its linked item.</summary>
    [VirtualFunction(1)]
    public partial void Copy(InventoryItem* other);

    [VirtualFunction(2)]
    public partial bool EqualTo(InventoryItem* other);

    [VirtualFunction(3)]
    public partial bool IsEmpty();

    [VirtualFunction(4)]
    public partial void Clear();

    [VirtualFunction(5)]
    public partial uint GetBaseItemId();

    [VirtualFunction(6)]
    public partial uint GetItemId(); // with flags applied

    [VirtualFunction(7)]
    public partial void SetItemId(uint itemId, bool parseFlags);

    [VirtualFunction(8)]
    public partial InventoryType GetInventoryType();

    [VirtualFunction(9)]
    public partial void SetInventoryType(InventoryType inventoryType);

    [VirtualFunction(10)]
    public partial ushort GetSlot();

    [VirtualFunction(11)]
    public partial void SetSlot(ushort slot);

    [VirtualFunction(12)]
    public partial uint GetQuantity();

    [VirtualFunction(13)]
    public partial void SetQuantity(uint quantity);

    [VirtualFunction(14)]
    public partial ushort GetSpiritbondOrCollectability();

    [VirtualFunction(15)]
    public partial void SetSpiritbondOrCollectability(ushort value);

    [VirtualFunction(16)]
    public partial ItemFlags GetFlags();

    [VirtualFunction(17)]
    public partial void SetFlags(ItemFlags flags);

    [VirtualFunction(18)]
    public partial bool IsHighQuality();

    [VirtualFunction(19)]
    public partial void SetIsHighQuality(bool isHighQuality);

    //[VirtualFunction(20)]
    //public partial bool IsHighQuality2();

    //[VirtualFunction(21)]
    //public partial void SetIsHighQuality2(bool isHighQuality);

    [VirtualFunction(22)]
    public partial bool IsCollectable();

    [VirtualFunction(23)]
    public partial ushort GetCollectability();

    [VirtualFunction(24)]
    public partial void SetCollectability(ushort value);

    /// <remarks> Calculated as: 100 * <see cref="Condition"/> / 30000 </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 C0 41 8D 57")]
    public partial byte GetConditionPercentage();

    [MemberFunction("E8 ?? ?? ?? ?? 80 7D ?? ?? 75 ?? 8B 5D")]
    public partial void SetLinkedItem(InventoryType type, ushort slot);

    /// <summary>
    /// Resolves a symbolic InventoryItem, returning a pointer to the linked InventoryItem or to itself if not symbolic.
    /// </summary>
    /// <remarks>
    /// If the resolved InventoryItem is also symbolic, it will NOT resolve this one too.<br/>
    /// Instead, this function must be called in a loop until the original InventoryItem is found (<see cref="IsSymbolic"/> == <c>false</c>).
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 44 48 8B CB")]
    public partial InventoryItem* GetLinkedItem();

    /// <summary>Gets the condition from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E9 ?? ?? ?? ?? 0F B7 43 1A")]
    public partial ushort GetCondition();

    /// <summary>Gets the crafter's content id from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB 04 49 8B 47 20")]
    public partial ulong GetCrafterContentId();

    /// <summary>Gets the stain from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 38 45 F6")]
    public partial byte GetStain(int index);

    /// <summary>Gets the glamour id from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 3B 47 FB")]
    public partial uint GetGlamourId();

    /// <summary>Gets the materia id from the specified slot of the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB 10 32 C0")]
    public partial ushort GetMateriaId(byte materiaSlot);

    /// <summary>Gets the materia grade from the specified slot of the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E9 ?? ?? ?? ?? 0F B6 44 1F ??")]
    public partial byte GetMateriaGrade(byte materiaSlot);

    /// <summary>Gets the materia count from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 57 67")]
    public partial byte GetMateriaCount();
}
