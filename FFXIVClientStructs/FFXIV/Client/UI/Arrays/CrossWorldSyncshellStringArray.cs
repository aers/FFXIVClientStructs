using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 129 * 8)]
public unsafe partial struct CrossWorldSyncshellStringArray {
    public static CrossWorldSyncshellStringArray* Instance() => (CrossWorldSyncshellStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.CrossWorldLinkShell)->StringArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray1<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray64<CrossWorldSyncshellMemberStringArray> _members;

    [FieldOffset(128 * 8)] public CStringPointer MemberCountText;

    [CExportIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 2 * 8)]
    public partial struct CrossWorldSyncshellMemberStringArray {
        [FieldOffset(0 * 8), FixedSizeArray, CExportIgnore] internal FixedSizeArray2<CStringPointer> _data;

        [FieldOffset(0 * 8)] public CStringPointer PlayerName;
        [FieldOffset(1 * 8)] public CStringPointer Homeworld;
    }
}
