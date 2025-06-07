using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 25 * 4)]
public unsafe partial struct ConfigSystemNumberArray {
    public static ConfigSystemNumberArray* Instance() => (ConfigSystemNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.ConfigSystem)->IntArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray25<int> _data;

    [FieldOffset(0 * 4)] public int FPS;
}
