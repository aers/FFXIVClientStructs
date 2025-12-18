using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 2404 * 4)]
public unsafe partial struct FriendListNumberArray {
    public static FriendListNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.FriendList);
        return numberArray == null ? null : (FriendListNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0 * 4), FixedSizeArray, CExporterIgnore] internal FixedSizeArray2404<int> _data;

    [FieldOffset(0 * 4), FixedSizeArray] internal FixedSizeArray200<SocialListMemberNumberArray> _friends;

    [FieldOffset(2400 * 4)] public int TotalFriendCount;
    [FieldOffset(2401 * 4)] public int FriendCountInGroup;

    [FieldOffset(2403 * 4)] private bool UnkBool2403;
}
