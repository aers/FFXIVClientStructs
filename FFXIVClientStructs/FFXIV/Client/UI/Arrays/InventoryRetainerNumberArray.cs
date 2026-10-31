using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.Arrays.InventoryNumberArray;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 897 * 4)]
public unsafe partial struct InventoryRetainerNumberArray {
    public static InventoryRetainerNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.InventoryRetainer);
        return numberArray == null ? null : (InventoryRetainerNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray897<int> _data;

    [BitField<byte>(nameof(SelectedTabIndex), 0, 8)]
    [BitField<ushort>(nameof(FirstTabIndex), 8, 16)]
    [FieldOffset(0)] internal uint _tabIndices;

    [FieldOffset(1 * 4), FixedSizeArray] internal FixedSizeArray140<InventoryItemNumberArray> _items;
    [FieldOffset(841 * 4), FixedSizeArray] internal FixedSizeArray18<InventoryRetainerCrystalNumberArray> _crystals;
    [FieldOffset(895 * 4)] public uint Gil;
    [FieldOffset(896 * 4)] public int MarketItemCount;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 3 * 4)]
    public partial struct InventoryRetainerCrystalNumberArray {
        [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray3<int> _data;

        [FieldOffset(0 * 4)] public uint IconId;
        [BitField<int>(nameof(StackCount), 16, 16)]
        [FieldOffset(1 * 4)] internal uint _stackCount;
        [FieldOffset(2 * 4)] public ushort SlotIndex;
    }
}
