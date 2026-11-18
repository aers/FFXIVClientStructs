using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.Arrays.InventoryNumberArray;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 840 * 4)]
public unsafe partial struct InventoryBuddyNumberArray {
    public static InventoryBuddyNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.InventoryBuddy);
        return numberArray == null ? null : (InventoryBuddyNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray840<int> _data;

    [FieldOffset(0), FixedSizeArray] internal FixedSizeArray140<InventoryItemNumberArray> _items;
}
