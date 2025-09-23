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

    [StructLayout(LayoutKind.Explicit, Size = 0x1650)]
    public partial struct ComparedItemData {
        [FieldOffset(0), CExporterIgnore] public ComparedInventoryItem SelectedItem;
        [FieldOffset(0x50), CExporterIgnore] public ComparedInventoryItem SelectedItemAlternateQuality;
        [FieldOffset(0xA0), CExporterIgnore] public ComparedInventoryItem EquippedItem;
        // If SelectedItem is a Ring, this will contain the left ring and EquippedItem will contain the right
        [FieldOffset(0xF0), CExporterIgnore] public ComparedInventoryItem LeftRingItem;
        // The game accesses these as an array
        [FieldOffset(0), FixedSizeArray] internal FixedSizeArray4<ComparedInventoryItem> _items;

        [FieldOffset(0x140), CExporterIgnore] public ComparedInventoryItemData SelectedItemData;
        [FieldOffset(0x680), CExporterIgnore] public ComparedInventoryItemData SelectedItemAlternateQualityData;
        [FieldOffset(0xBC0), CExporterIgnore] public ComparedInventoryItemData EquippedItemData;
        [FieldOffset(0x1100), CExporterIgnore] public ComparedInventoryItemData LeftRingItemData;
        // The game accesses these as an array
        [FieldOffset(0x140), FixedSizeArray] internal FixedSizeArray4<ComparedInventoryItemData> _itemData;

        // 0 = No update needed
        // 1 = Open
        // 2 = Refresh
        [FieldOffset(0x1640)] public int UpdateState;

        // Counts up across frames as the agent loads the necessary data
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
            /*
                0- Error
                1- OK
                2- Different Job can equip, but generally only for weapons?
                3- Level Restricted
                4- Class/Race/Gender/GC Restricted
             */
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
            // Second values used when comparing against Left Ring
            public int PhysicalDefense2;
            public int MagicDefense2;
            public int PhysicalDefenseDelta2;
            public int MagicDefenseDelta2;
        }
    }
}
