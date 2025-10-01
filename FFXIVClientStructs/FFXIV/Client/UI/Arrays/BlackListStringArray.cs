using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 600 * 8)]
public unsafe partial struct BlackListStringArray {
    public static BlackListStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.BlackList);
        return stringArray == null ? null : (BlackListStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray600<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray200<CStringPointer> _playerNames;
    [FieldOffset(200 * 8), FixedSizeArray] internal FixedSizeArray200<CStringPointer> _homeworlds;
    [FieldOffset(400 * 8), FixedSizeArray] internal FixedSizeArray200<CStringPointer> _notes;
}
