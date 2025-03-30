using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1002 * 8)]
public unsafe partial struct FriendListStringArray {
    public static FriendListStringArray* Instance() => (FriendListStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.FriendList)->StringArray;

    [FieldOffset(0 * 8), FixedSizeArray, CExportIgnore] internal FixedSizeArray1002<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray, CExportIgnore] internal FixedSizeArray200<FriendListFriendStringArray> _friends;

    [FieldOffset(1000 * 8)] public CStringPointer FriendsWithMarkFoundText;
    [FieldOffset(1001 * 8)] public CStringPointer FriendsInGroupText;

    [CExportIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 5 * 8)]
    public partial struct FriendListFriendStringArray {
        [FieldOffset(0 * 8), FixedSizeArray, CExportIgnore] internal FixedSizeArray5<CStringPointer> _data;

        [FieldOffset(0 * 8)] public CStringPointer PlayerName;
        [FieldOffset(1 * 8)] public CStringPointer ZoneName;
        [FieldOffset(2 * 8)] public CStringPointer FcName;
        [FieldOffset(3 * 8)] public CStringPointer OnlineStatus;
        [FieldOffset(4 * 8)] public CStringPointer GrandCompanyName;
    }
}
