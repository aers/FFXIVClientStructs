using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 428 * 4)]
public unsafe partial struct QuickPanelNumberArray {
    public static QuickPanelNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.QuickPanel);
        return numberArray == null ? null : (QuickPanelNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray428<int> _data;

    [FieldOffset(0 * 4)] public MouseRestrictionFlags MouseRestrictions;
    [FieldOffset(1 * 4)] public int CommandPanelTint;
    [FieldOffset(2 * 4)] public int ActiveTab;

    [FieldOffset(3 * 4), FixedSizeArray] internal FixedSizeArray25<ActionBarSlotNumberArray> _slots;

    public enum MouseRestrictionFlags : byte {
        NoRestriction = 0,
        OpenPanelAtMouseCursorPosition = 1,
        DisableDraggingWithinCommandPanel = 2,
    }
}
