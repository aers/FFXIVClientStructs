using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 2404 * 4)]
public unsafe partial struct FriendListNumberArray {
    public static FriendListNumberArray* Instance() => (FriendListNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.FriendList)->IntArray;

    [FieldOffset(0 * 4), FixedSizeArray, CExportIgnore] internal FixedSizeArray2404<int> _data;

    [FieldOffset(0 * 4), FixedSizeArray, CExportIgnore] internal FixedSizeArray200<FriendListFriendNumberArray> _friends;

    [FieldOffset(2400 * 4)] public int TotalFriendCount;
    [FieldOffset(2401 * 4)] public int FriendCountInGroup;

    [FieldOffset(2403 * 4)] public bool UnkBool2403;

    [CExportIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 12 * 4)]
    public partial struct FriendListFriendNumberArray {
        [FieldOffset(0 * 4), FixedSizeArray, CExportIgnore] internal FixedSizeArray12<int> _data;

        [FieldOffset(0 * 4)] public int StatusIconId;
        [FieldOffset(1 * 4)] public int Level;
        [FieldOffset(2 * 4)] public int JobIconId;
        [FieldOffset(3 * 4)] public int GrandCompanyIconId;
        
        [FieldOffset(5 * 4)] public byte SelectedLanguages;

        [FieldOffset(6 * 4)] public FriendListLanguage ClientLanguage;

        public bool JapaneseSelected => ((SelectedLanguages >> 0) & 1) == 1;
        public bool EnglishSelected => ((SelectedLanguages >> 1) & 1) == 1;
        public bool GermanSelected => ((SelectedLanguages >> 2) & 1) == 1;
        public bool FrenchSelected => ((SelectedLanguages >> 3) & 1) == 1;
    }

    public enum FriendListLanguage : byte {
        Japanese = 0,
        English = 1,
        German = 2,
        French = 3,
    }
}
