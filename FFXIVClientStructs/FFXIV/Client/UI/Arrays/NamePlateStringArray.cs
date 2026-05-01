using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 300 * 8)]
public unsafe partial struct NamePlateStringArray {
    public static NamePlateStringArray* Instance() {
        var numberArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.NamePlate);
        return numberArray == null ? null : (NamePlateStringArray*)numberArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray300<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray50<CStringPointer> _name;
    [FieldOffset(50 * 8), FixedSizeArray] internal FixedSizeArray50<CStringPointer> _title;
    [FieldOffset(100 * 8), FixedSizeArray] internal FixedSizeArray50<CStringPointer> _fc;
    [FieldOffset(150 * 8), FixedSizeArray] internal FixedSizeArray50<CStringPointer> _letter; // letters A-Z
    [FieldOffset(200 * 8), FixedSizeArray] internal FixedSizeArray50<CStringPointer> _target;
    [FieldOffset(250 * 8), FixedSizeArray] internal FixedSizeArray50<CStringPointer> _level;
}
