using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 2404 * 4)]
public unsafe partial struct FriendListNumberArray {
    public static FriendListNumberArray* Instance() => (FriendListNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.FriendList)->IntArray;

    [FieldOffset(0 * 4), FixedSizeArray, CExportIgnore] internal FixedSizeArray2404<int> _data;

    [FieldOffset(0 * 4), FixedSizeArray] internal FixedSizeArray200<SocialListMemberNumberArray> _friends;

    [FieldOffset(2400 * 4)] public int TotalFriendCount;
    [FieldOffset(2401 * 4)] public int FriendCountInGroup;

    [FieldOffset(2403 * 4)] public bool UnkBool2403;
}
