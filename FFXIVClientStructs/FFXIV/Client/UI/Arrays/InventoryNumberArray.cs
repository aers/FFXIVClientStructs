using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1351 * 4)]
public unsafe partial struct InventoryNumberArray {
    public static InventoryNumberArray* Instance() => (InventoryNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.Inventory)->IntArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray1351<int> _data;

    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray140<InventoryItemNumberArray> _items;

    [CExportIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 6 * 4)]
    public partial struct InventoryItemNumberArray {
        [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray6<int> _data;

        [FieldOffset(0 * 4)] public uint IconId;
        [FieldOffset(2 * 4)] internal int _stackCount;
        [FieldOffset(3 * 4)] public ItemFlag ItemFlags;
        [FieldOffset(4 * 4)] public ItemDye DyeSlot0;
        [FieldOffset(5 * 4)] public ItemDye DyeSlot1;

        public int StackCount => (_stackCount >> 16) & 0xFFFF;

        [CExportIgnore]
        [StructLayout(LayoutKind.Explicit, Size = 1 * 4)]
        public partial struct ItemFlag {
            [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray1<int> _data;

            [FieldOffset(0)] public byte ItemType;
            [FieldOffset(2)] public ItemWearableIcon Wearable;
            [FieldOffset(3)] public byte MirageFlag;

            public enum ItemWearableIcon : byte {
                Wearable = 1,
                Impossible = 2,
                Unavailable = 3
            }
        }

        [CExportIgnore]
        [StructLayout(LayoutKind.Explicit, Size = 1 * 4)]
        public partial struct ItemDye {
            [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray1<int> _data;

            [FieldOffset(3)] public byte R;
            [FieldOffset(2)] public byte G;
            [FieldOffset(1)] public byte B;
            [FieldOffset(0)] public byte DyeFlags;
        }
    }
}
