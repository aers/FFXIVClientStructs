using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using static FFXIVClientStructs.FFXIV.Client.UI.Arrays.ActionBarNumberArray.ActionBarBarNumberArray;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 2403 * 4)]
public unsafe partial struct SocialListNumberArray {
    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray2403<int> _data;

    [FieldOffset(0 * 4), FixedSizeArray] internal FixedSizeArray200<SocialListMemberNumberArray> _players;

    [FieldOffset(2400 * 4)] public int SocialListSize;
}
