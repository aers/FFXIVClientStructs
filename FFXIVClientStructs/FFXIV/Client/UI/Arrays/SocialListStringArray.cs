using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1002 * 8)]
public unsafe partial struct SocialListStringArray {
    public static SocialListStringArray* Instance() => (SocialListStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.SocialList)->StringArray;

    [FieldOffset(0 * 8), FixedSizeArray, CExportIgnore] internal FixedSizeArray1002<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray200<SocialListMemberStringArray> _friends;

    [FieldOffset(1000 * 8)] public CStringPointer NotFoundText;
}
