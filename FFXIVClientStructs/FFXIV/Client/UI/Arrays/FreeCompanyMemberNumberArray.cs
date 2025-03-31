using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 2806 * 4)]
public unsafe partial struct FreeCompanyMemberNumberArray {
    public static FreeCompanyMemberNumberArray* Instance() => (FreeCompanyMemberNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.FreeCompanyMember)->IntArray;

    [FieldOffset(0 * 4), FixedSizeArray, CExportIgnore] internal FixedSizeArray2806<int> _data;

    [FieldOffset(0 * 4), FixedSizeArray] internal FixedSizeArray200<SocialListMemberNumberArray> _freeCompanyMembers;

    [FieldOffset(2606 * 4), FixedSizeArray] internal FixedSizeArray200<int> _freeCompanyMemberMemoSortIndexes;
}
