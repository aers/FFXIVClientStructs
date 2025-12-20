using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1401 * 8)]
public unsafe partial struct FreeCompanyMemberStringArray {
    public static FreeCompanyMemberStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.FreeCompanyMember);
        return stringArray == null ? null : (FreeCompanyMemberStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray1401<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray200<SocialListMemberStringArray> _members;

    [FieldOffset(1000 * 8)] public CStringPointer YourMemo;

    [FieldOffset(1001 * 8), FixedSizeArray] internal FixedSizeArray200<FreeCompanyMemoStringArray> _memos;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 2 * 8)]
    public partial struct FreeCompanyMemoStringArray {
        [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray2<CStringPointer> _data;

        [FieldOffset(0 * 8)] public CStringPointer Memo;
        [FieldOffset(1 * 8)] public CStringPointer Since;
    }
}
