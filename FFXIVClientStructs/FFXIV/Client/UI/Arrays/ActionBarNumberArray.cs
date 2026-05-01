using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 5564 * 4)]
public unsafe partial struct ActionBarNumberArray {
    public static ActionBarNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.ActionBar);
        return numberArray == null ? null : (ActionBarNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray5564<int> _data;

    [FieldOffset(0 * 4)] public bool HotBarLocked;
    [FieldOffset(15 * 4), FixedSizeArray] internal FixedSizeArray20<ActionBarBarNumberArray> _bars;
    [FieldOffset(5482 * 4)] public bool DisplayPetBar;
    [FieldOffset(5473 * 4)] public int PulseDotForBar;
    [FieldOffset(5474 * 4)] public int PulseDotForSlot;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 272 * 4)]
    public partial struct ActionBarBarNumberArray {
        [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray272<int> _data;

        [FieldOffset(0 * 4), FixedSizeArray] internal FixedSizeArray12<ActionBarSlotNumberArray> _slots;
    }
}
