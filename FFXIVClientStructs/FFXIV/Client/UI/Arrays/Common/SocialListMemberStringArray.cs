namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;

[CExporterIgnore]
[StructLayout(LayoutKind.Explicit, Size = 5 * 8)]
public partial struct SocialListMemberStringArray {
    [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray5<CStringPointer> _data;

    [FieldOffset(0 * 8)] public CStringPointer PlayerName;
    [FieldOffset(1 * 8)] public CStringPointer Activity;
    [FieldOffset(2 * 8)] public CStringPointer FcName;
    [FieldOffset(3 * 8)] public CStringPointer Status;
    [FieldOffset(4 * 8)] public CStringPointer GrandCompanyName;
}
