using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 600 * 8)]
public unsafe partial struct BlackListStringArray {
    public static BlackListStringArray* Instance() => (BlackListStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.BlackList)->StringArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray600<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray200<CStringPointer> _playerNames;
    [FieldOffset(200 * 8), FixedSizeArray] internal FixedSizeArray200<CStringPointer> _homeworlds;
    [FieldOffset(400 * 8), FixedSizeArray] internal FixedSizeArray200<CStringPointer> _notes;
}
