using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using static FFXIVClientStructs.FFXIV.Client.UI.Agent.AgentMiragePrismMiragePlateData;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMiragePrismMiragePlate
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MiragePrismMiragePlate)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
public unsafe partial struct AgentMiragePrismMiragePlate {
    [FieldOffset(0x28)] public AgentMiragePrismMiragePlateData* Data;
    [FieldOffset(0x38)] public InventoryItem UnkInventoryItem;

    [FieldOffset(0x80)] public ushort DialogAddonId;
    [FieldOffset(0x82)] public bool CharaViewInitialized;

    [FieldOffset(0x88)] public MiragePrismMiragePlateCharaView CharaView;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 8B FA 66 44 89 4C 24")]
    public partial void OpenForGearset(int gearsetId, int glamourSetLink, ushort openerAddonId = 0);

    [MemberFunction("40 57 48 83 EC 20 80 79 30 00")]
    public partial void ClearItemData(uint index = uint.MaxValue); // anything >= 12 falls back to SelectedItemIndex

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 46 10")]
    public partial void SetSelectedItemData(ItemSource source, uint sourceId, uint itemId, byte stain0Id, byte stain1Id);

    [MemberFunction("48 89 74 24 ?? 57 48 83 EC 20 80 79 30 00 49 8B F9")]
    public partial void SetItemStain(
        uint itemIndex,
        byte pendingStainId,
        InventoryItem* pendingStainInventoryItem,
        uint pendingStainItemId,
        int pendingStainIndex);

    [MemberFunction("48 89 74 24 ?? 57 48 83 EC 20 48 8B F2 48 8B F9 48 8B 51 28")]
    public partial void SetSelectedItemStains(
        InventoryItem* pendingStain0InventoryItem,
        byte pendingStain0Id,
        uint pendingStain0ItemId,
        InventoryItem* pendingStain1InventoryItem,
        byte pendingStain1Id,
        uint pendingStain1ItemId);

    // Client::UI::Agent::AgentMiragePrismMiragePlate::MiragePrismMiragePlateCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x328)]
    public unsafe partial struct MiragePrismMiragePlateCharaView {
        [FieldOffset(0x318)] public bool IsUpdatePending;

        [FieldOffset(0x31C)] public uint Flags;

        public bool IsOtherEquipmentHidden {
            get => (Flags & 0x01) == 0x01;
            set => Flags = (uint)(value ? Flags | 0x01 : Flags & ~0x01);
        }

        public bool IsHatHidden {
            get => (Flags & 0x02) == 0x02;
            set => Flags = (uint)(value ? Flags | 0x02 : Flags & ~0x02);
        }

        public bool IsWeaponHidden {
            get => (Flags & 0x04) == 0x04;
            set => Flags = (uint)(value ? Flags | 0x04 : Flags & ~0x04);
        }

        public bool IsVisorToggled {
            get => (Flags & 0x08) == 0x08;
            set => Flags = (uint)(value ? Flags | 0x08 : Flags & ~0x08);
        }

        public bool IsWeaponDrawn {
            get => (Flags & 0x10) == 0x10;
            set => Flags = (uint)(value ? Flags | 0x10 : Flags & ~0x10);
        }
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3BD8)]
public unsafe partial struct AgentMiragePrismMiragePlateData {

    [FieldOffset(0x01)] public bool HasChanges;

    [FieldOffset(0x08)] public uint OpenMode; // 0 = Agent.Show(), 1 = GeneralAction, 2 = Gearset

    [FieldOffset(0x10)] public uint GearsetId;
    [FieldOffset(0x14)] public uint SelectedMiragePlateIndex;
    [FieldOffset(0x18)] public uint SelectedItemIndex;
    [FieldOffset(0x1C)] public uint ContextMenuItemIndex;

    [FieldOffset(0x24), FixedSizeArray] internal FixedSizeArray20<GlamourPlate> _glamourPlates;
    [FieldOffset(0x3864), FixedSizeArray] internal FixedSizeArray12<MiragePlateItem> _currentItems;
    [FieldOffset(0x3B34)] public ushort OpenerAddonId;
    [FieldOffset(0x3B38), FixedSizeArray] internal FixedSizeArray12<DispellItem> _dispellItems;

    [FieldOffset(0x3BC8)] public uint DispellItemsSelectedBitmask;
    [FieldOffset(0x3BCC)] public uint DispellItemsBitmask;
    [FieldOffset(0x3BD0)] public uint GlamourDispellerCount;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 12 * 0x3C)]
    public partial struct GlamourPlate {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray12<MiragePlateItem> _items;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x3C)]
    public partial struct MiragePlateItem {
        [FieldOffset(0x00)] public uint ItemId;
        /// <summary> PrismBox index or Cabinet id. Depends on <see cref="Source"/>. </summary>
        [FieldOffset(0x04)] public uint SourceId;
        [FieldOffset(0x08)] public ItemSource Source;
        [FieldOffset(0x0C)] public uint IconId;
        [FieldOffset(0x10)] public ItemFlag Flags;
        [FieldOffset(0x14)] public uint EquipSlotCategory;
        [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray2<byte> _stainIds;
        [FieldOffset(0x1A), FixedSizeArray] internal FixedSizeArray2<byte> _pendingStainIds;
        [FieldOffset(0x1C)] public byte StainState; // 0 = ?, 1 = HasChanged?, 2 = ?

        [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray2<uint> _pendingStainItemIds;
        [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray2<InventoryType> _pendingStainInventoryTypes;
        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray2<ushort> _pendingStainInventorySlots;
        [FieldOffset(0x34), FixedSizeArray] internal FixedSizeArray2<bool> _isPendingStainFromInventoryItem;
        [FieldOffset(0x36), FixedSizeArray] internal FixedSizeArray2<bool> _isPendingStainFromItemId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct DispellItem {
        [FieldOffset(0x00)] public uint ItemId;
    }

    public enum ItemSource {
        None = 0, // unchanged / from GlamourPlate
        PrismBox = 1,
        Cabinet = 2,
    }

    [Flags]
    public enum ItemFlag {
        None = 0,
        HasStain0 = 1 << 0,
        Restricted = 1 << 1, // race or sex not matching EquipRestriction
        CanNotGlamour = 1 << 2, // incorrect EquipSlotCategory, ...?
        CanNotTryOn = 1 << 3, // depends on EquipSlotCategory and FilterGroup
        IsStainLocked = 1 << 4,
        HasStain1 = 1 << 5,
    }
}
