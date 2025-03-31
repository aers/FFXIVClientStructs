using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1401 * 8)]
public unsafe partial struct FreeCompanyMemberStringArray {
    public static FreeCompanyMemberStringArray* Instance() => (FreeCompanyMemberStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.FreeCompanyMember)->StringArray;

    [FieldOffset(0 * 8), FixedSizeArray, CExportIgnore] internal FixedSizeArray1401<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray200<SocialListMemberStringArray> _members;

    [FieldOffset(1000 * 8)] public CStringPointer YourMemo;

    [FieldOffset(1001 * 8), FixedSizeArray] internal FixedSizeArray200<FreeCompanyMemoStringArray> _memos;

    [CExportIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 2 * 8)]
    public partial struct FreeCompanyMemoStringArray {
        [FieldOffset(0 * 8), FixedSizeArray, CExportIgnore] internal FixedSizeArray2<CStringPointer> _data;

        [FieldOffset(0 * 8)] public CStringPointer Memo;
        [FieldOffset(1 * 8)] public CStringPointer Since;
    }
}
