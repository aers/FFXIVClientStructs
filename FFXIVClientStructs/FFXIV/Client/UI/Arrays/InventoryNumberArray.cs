using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExporterIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1351 * 4)]
public unsafe partial struct InventoryNumberArray {
    public static InventoryNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.Inventory);
        return numberArray == null ? null : (InventoryNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray1351<int> _data;

    [FieldOffset(0 * 4), FixedSizeArray] internal FixedSizeArray140<InventoryItemNumberArray> _items;

    [FieldOffset(840 * 4), FixedSizeArray] internal FixedSizeArray124<InventoryKeyItemNumberArray> _keyItems;

    [FieldOffset(1292 * 4), FixedSizeArray] internal FixedSizeArray18<InventoryCrystalNumberArray> _crystals;

    [CExporterIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 6 * 4)]
    public partial struct InventoryItemNumberArray {
        [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray6<int> _data;

        [FieldOffset(0 * 4)] public uint IconId;
        [FieldOffset(2 * 4)] internal int _stackCount;
        [FieldOffset(3 * 4)] public ItemFlag ItemFlags;
        [FieldOffset(4 * 4)] public ItemDye DyeSlot0;
        [FieldOffset(5 * 4)] public ItemDye DyeSlot1;

        public int StackCount => (_stackCount >> 16) & 0xFFFF;

        [CExporterIgnore]
        [StructLayout(LayoutKind.Explicit, Size = 1 * 4)]
        public partial struct ItemFlag {
            [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray1<int> _data;

            [FieldOffset(0)] public byte ItemType;
            [FieldOffset(2)] public ItemWearableIcon Wearable;
            [FieldOffset(3)] public byte MirageFlag;

            public enum ItemWearableIcon : byte {
                Wearable = 1,
                Impossible = 2,
                Unavailable = 3
            }
        }

        [CExporterIgnore]
        [StructLayout(LayoutKind.Explicit, Size = 1 * 4)]
        public partial struct ItemDye {
            [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray1<int> _data;

            [FieldOffset(3)] public byte R;
            [FieldOffset(2)] public byte G;
            [FieldOffset(1)] public byte B;
            [FieldOffset(0)] public byte DyeFlags;
        }
    }

    [CExporterIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 3 * 4)]
    public partial struct InventoryKeyItemNumberArray {
        [FieldOffset(0 * 4)] public uint IconId;
        [FieldOffset(1 * 4)] public InventoryKeyItemFlagsNumberArray KeyItemFlags;
        [FieldOffset(2 * 4)] public uint UnkFlags;

        [CExporterIgnore]
        [StructLayout(LayoutKind.Explicit, Size = 1 * 4)]
        public partial struct InventoryKeyItemFlagsNumberArray {
            [FieldOffset(3)] public byte UnkFlags1;
            [FieldOffset(2)] public byte TooltipIndex;
            [FieldOffset(1)] public byte UnkFlags3;
            [FieldOffset(0)] public byte StackCount;
        }
    }

    [CExporterIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 3 * 4)]
    public partial struct InventoryCrystalNumberArray {
        [FieldOffset(0 * 4)] public uint IconId;
        [FieldOffset(1 * 4)] internal int _stackCount;
        [FieldOffset(2 * 4)] public uint CrystalIndex;

        public int StackCount => (_stackCount >> 16) & 0xFFFF;
    }
}
