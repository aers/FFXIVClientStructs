using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentItemComp
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ItemComp)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct AgentItemComp {
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 53 ?? 0F B7 4B")]
    public partial void CompareItem(ushort parentAddonId, uint itemId, byte stain0Id, byte stain1Id);

    [FieldOffset(0x50)] public ComparedItemData* ItemData;
    [FieldOffset(0x58)] public bool ShowLeftRing;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1650)]
    public partial struct ComparedItemData {
        /// <remarks>
        /// These items are, in order: the selected item, the alternate quality (HQ/NQ) of the selected item, the currently equipped item, and the left ring slot (if the SelectedItem is a ring)
        /// Any item that doesn't exist is retained as an empty item in the array
        /// </remarks>
        [FieldOffset(0), FixedSizeArray] internal FixedSizeArray4<ComparedInventoryItem> _items;

        /// <remarks>
        /// This array has the same layout as the one for Items
        /// </remarks>
        [FieldOffset(0x140), FixedSizeArray] internal FixedSizeArray4<ComparedInventoryItemData> _itemData;

        /// <summary>
        /// This is set on any frame that the Agent will be updating the addon's UI
        /// </summary>
        /// <remarks>
        /// 0 = No update needed
        /// 1 = Open
        /// 2 = Refresh
        /// </remarks>
        [FieldOffset(0x1640)] public int UpdateState;

        /// <remarks>
        /// Counts up across frames as the agent loads the necessary data
        /// </remarks>
        [FieldOffset(0x1644)] public int LoadState;
        [FieldOffset(0x1648)] public int ParentAddonId;
        [FieldOffset(0x164C)] public bool ShowAlternateQuality;

        [StructLayout(LayoutKind.Explicit, Size = 0x50)]
        public struct ComparedInventoryItem {
            [FieldOffset(0)] public InventoryItem Item;
            [FieldOffset(0x48)] public byte CurrentSyncedJobLevel;
            [FieldOffset(0x49)] public byte CurrentJobLevel;
            [FieldOffset(0x4A)] public byte CurrentClassJobId;
        }

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x540)]
        public partial struct ComparedInventoryItemData {
            [FieldOffset(0)] public Utf8String GlamouredItemName;
            [FieldOffset(0x68)] public Utf8String CrafterName;
            [FieldOffset(0xD0)] public Utf8String DyeNames;
            [FieldOffset(0x138), FixedSizeArray] internal FixedSizeArray5<Utf8String> _materiaNames;
            [FieldOffset(0x340)] public Utf8String RepairItemName;
            [FieldOffset(0x3A8)] public Utf8String Marketability;
            [FieldOffset(0x410)] private Utf8String Unk410;
            // [0x478 ~ 0x518) - Exd::Sheet::Item
            // [0x518 ~ 0x51C) - Exd::Sheet::GilShopInfo
            [FieldOffset(0x51C), CExporterUnion("Delta")] public WeaponDataDelta Weapon;
            [FieldOffset(0x51C), CExporterUnion("Delta")] public ShieldDataDelta Shield;
            [FieldOffset(0x51C), CExporterUnion("Delta")] public GearDataDelta Gear;
            [FieldOffset(0x53C)] public ushort ItemLevelRowId;

            /// <remarks>
            /// 0- Error
            /// 1- OK
            /// 2- Different Job can equip, but generally only for weapons?
            /// 3- Level Restricted
            /// 4- Class/Race/Gender/GC Restricted
            /// </remarks>
            [FieldOffset(0x53E)] public byte EquippableState;
            [FieldOffset(0x53F)] public byte DyeCount;
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x14)]
        public struct WeaponDataDelta {
            public int PhysicalDamage;
            public int MagicDamage;
            public int Delay;
            public int PhysicalDamageDelta;
            public int MagicDamageDelta;
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x8)]
        public struct ShieldDataDelta {
            public int Block;
            public int BlockDelta;
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x20)]
        public struct GearDataDelta {
            public int PhysicalDefense;
            public int MagicDefense;
            public int PhysicalDefenseDelta;
            public int MagicDefenseDelta;
            /// <remarks>
            /// This is always the same as PhysicalDefense, but the game sets it separately
            /// </remarks>
            public int LeftRingSlotPhysicalDefense;
            /// <remarks>
            /// This is always the same as MagicDefense, but the game sets it separately
            /// </remarks>
            public int LeftRingSlotMagicDefense;
            public int LeftRingSlotPhysicalDefenseDelta;
            public int LeftRingSlotMagicDefenseDelta;
        }
    }
}
