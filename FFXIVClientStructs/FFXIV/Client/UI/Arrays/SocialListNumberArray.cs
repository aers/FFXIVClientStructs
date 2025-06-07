using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 2403 * 4)]
public unsafe partial struct SocialListNumberArray {
    public static SocialListNumberArray* Instance() => (SocialListNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.SocialList)->IntArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray2403<int> _data;

    [FieldOffset(0 * 4), FixedSizeArray] internal FixedSizeArray200<SocialListMemberNumberArray> _players;

    [FieldOffset(2400 * 4)] public int SocialListSize;
}
