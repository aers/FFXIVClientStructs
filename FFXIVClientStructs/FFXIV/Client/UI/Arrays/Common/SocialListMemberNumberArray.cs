namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;

[CExportIgnore]
[StructLayout(LayoutKind.Explicit, Size = 12 * 4)]
public partial struct SocialListMemberNumberArray {
    [FieldOffset(0 * 4), FixedSizeArray, CExportIgnore] internal FixedSizeArray12<int> _data;

    [FieldOffset(0 * 4)] public int StatusIconId;
    [FieldOffset(1 * 4)] public int Level;
    [FieldOffset(2 * 4)] public int JobIconId;
    [FieldOffset(3 * 4)] public int GrandCompanyIconId;

    [FieldOffset(5 * 4)] public byte SelectedLanguages;

    [FieldOffset(6 * 4)] public SocialMemberLanguage ClientLanguage;

    public bool JapaneseSelected => ((SelectedLanguages >> 0) & 1) == 1;
    public bool EnglishSelected => ((SelectedLanguages >> 1) & 1) == 1;
    public bool GermanSelected => ((SelectedLanguages >> 2) & 1) == 1;
    public bool FrenchSelected => ((SelectedLanguages >> 3) & 1) == 1;

    public enum SocialMemberLanguage : byte {
        Japanese = 0,
        English = 1,
        German = 2,
        French = 3,
    }
}
