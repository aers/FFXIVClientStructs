using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 6 * 4)]
public unsafe partial struct AreaMapNumberArray {
    public static AreaMapNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.AreaMap);
        return numberArray == null ? null : (AreaMapNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray6<int> _data;

    [FieldOffset(0 * 4)] public int X;
    [FieldOffset(1 * 4)] public int Y;
    [FieldOffset(2 * 4)] public int PlayerRotation; // 0 is South, -90 is West, -180/+180 is North, 90 is East
    [FieldOffset(3 * 4)] public int ConeRotation; // 0 is North, -90 is East, -180/+180 is South, 90 is West
    // [FieldOffset(4 * 4)] private int UnkInt; // Always a zero it seems
    // [FieldOffset(5 * 4)] private int UnkInt; // Always a zero it seems
}
