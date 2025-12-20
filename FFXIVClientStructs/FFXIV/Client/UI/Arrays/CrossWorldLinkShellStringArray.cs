using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 129 * 8)]
public unsafe partial struct CrossWorldLinkShellStringArray {
    public static CrossWorldLinkShellStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.CrossWorldLinkShell);
        return stringArray == null ? null : (CrossWorldLinkShellStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray1<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray64<CrossWorldSyncshellMemberStringArray> _members;

    [FieldOffset(128 * 8)] public CStringPointer MemberCountText;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 2 * 8)]
    public partial struct CrossWorldSyncshellMemberStringArray {
        [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray2<CStringPointer> _data;

        [FieldOffset(0 * 8)] public CStringPointer PlayerName;
        [FieldOffset(1 * 8)] public CStringPointer Homeworld;
    }
}
