using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonPartyList;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInventory
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Inventory")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public partial struct AddonInventory {
    [FieldOffset(0x2C0)] public AtkAddonControl AddonControl;

    [FieldOffset(0x334)] public int TabIndex;

    [MemberFunction("E9 ?? ?? ?? ?? 83 FD 11")]
    public partial void SetTab(int tab);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 1351 * 4)]
    public unsafe partial struct InventoryNumberArray {
        public static InventoryNumberArray* Instance() => (InventoryNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.Inventory)->IntArray;

        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray140<InventoryItemNumberArray> _items;

        [StructLayout(LayoutKind.Explicit, Size = 6 * 4)]
        public partial struct InventoryItemNumberArray {
            [FieldOffset(0 * 4)] public uint IconId;
            [FieldOffset(2 * 4)] internal int _stackCount;
            [FieldOffset(3 * 4)] public ItemFlag ItemFlags;
            [FieldOffset(4 * 4)] public ItemDye DyeSlot0;
            [FieldOffset(5 * 4)] public ItemDye DyeSlot1;

            public int StackCount => (_stackCount >> 16) & 0xFFFF;

            [StructLayout(LayoutKind.Explicit, Size = 1 * 4)]
            public partial struct ItemFlag {
                [FieldOffset(0)] public byte ItemType;
                [FieldOffset(2)] public ItemWearableIcon Wearable;
                [FieldOffset(3)] public byte MirageFlag;

                public enum ItemWearableIcon : byte {
                    Wearable = 1,
                    Impossible = 2,
                    Unavailable = 3
                }
            }

            [StructLayout(LayoutKind.Explicit, Size = 1 * 4)]
            public partial struct ItemDye {
                [FieldOffset(3)] public byte R;
                [FieldOffset(2)] public byte G;
                [FieldOffset(1)] public byte B;
                [FieldOffset(0)] public byte DyeFlags;
            }
        }
    }
}
