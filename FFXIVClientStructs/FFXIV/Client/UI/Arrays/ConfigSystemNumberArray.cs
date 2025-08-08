using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 25 * 4)]
public unsafe partial struct ConfigSystemNumberArray {
    public static ConfigSystemNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.ConfigSystem);
        return numberArray == null ? null : (ConfigSystemNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray25<int> _data;

    [FieldOffset(0 * 4)] public int FPS;
}
