using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureTextModule
//   Component::Text::TextModule
//     Component::Text::TextModuleInterface
//     Component::Text::MacroDecoder
//   Component::Text::TextChecker::ExecNonMacroFunc
//   Component::Excel::ExcelLanguageEvent
[GenerateInterop]
[Inherits<TextModule>, Inherits<TextChecker.ExecNonMacroFunc>, Inherits<ExcelLanguageEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xE68)]
public unsafe partial struct RaptureTextModule {
    public static RaptureTextModule* Instance() {
        var uiModule = UI.UIModule.Instance();
        return uiModule == null ? null : uiModule->GetRaptureTextModule();
    }

    [FieldOffset(0x520)] public UIModule* UIModule;
    [FieldOffset(0x528)] public TextChecker TextChecker;
    [FieldOffset(0x620)] public ExcelSheet* AddonSheet;

    // [0] = TempLinkString
    // [1] = <edgecolortype(0)><colortype(0)>
    // [2] = LinkTerminator (<link(0xCE,0,0,0,)>)
    [FieldOffset(0x630), FixedSizeArray] internal FixedSizeArray7<Utf8String> _unkStrings0;

    [FieldOffset(0x908)] public StdDeque<TextParameter> LocalTextParameters;
    // [FieldOffset(0x930)] public StdDeque<TextParameter> ItemRarityParameters; // to format Addon#6

    // [3] = TempItemRarity
    // [4] = TempItemNameOutput
    [FieldOffset(0x958), FixedSizeArray] internal FixedSizeArray9<Utf8String> _unkStrings1;

    [FieldOffset(0xD18)] public IExcelRowWrapper** AddonRowCache; // only for the first 4000 Addon rows

    [FieldOffset(0xE18)] internal ExcelSheet* AchievementSheet;
    [FieldOffset(0xE20)] internal ExcelSheet* StatusSheet;
    [FieldOffset(0xE28)] internal ExcelSheet* HowToSheet;
    [FieldOffset(0xE30)] internal ExcelSheet* AkatsukiNoteStringSheet;
    [FieldOffset(0xE38)] public int SoundId;
    [FieldOffset(0xE3C)] public int IsJingle;
    // [FieldOffset(0xE40)] public ExcelSheetWaiter* WeatherReportReplaceIdsLoader;
    /// <remarks> Array of 4 (WeatherReportReplace row count - 1) * 2 ushorts (PlaceNameSub, PlaceNameParent). </remarks>
    [FieldOffset(0xE48)] public ushort* WeatherReportReplaceIds;
    // [FieldOffset(0xE50)] public ExcelSheetWaiter* AkatsukiNoteTitleIdsLoader;
    /// <remarks> Array of 51 (AkatsukiNote row count) ushorts. Mapping AkatsukiNote RowId to AkatsukiNoteString RowId. </remarks>
    [FieldOffset(0xE58)] public ushort* AkatsukiNoteTitleIds;

    [MemberFunction("E9 ?? ?? ?? ?? 80 EA 20")]
    public partial CStringPointer GetAddonText(uint addonId);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 7D FF 45 33 FF")] // FormatAddonText1<int,int,uint>
    public partial CStringPointer FormatAddonText1IntIntUInt(uint addonId, int intParam1, int intParam2, uint uintParam);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 55 0B")] // FormatAddonText2<int>
    public partial CStringPointer FormatAddonText2Int(uint addonId, int value);

    [MemberFunction("E8 ?? ?? ?? ?? EB 51 0F B6 DB")] // FormatAddonText2<int,int>
    public partial CStringPointer FormatAddonText2IntInt(uint addonId, int intParam1, int intParam2);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 EB 38")] // FormatAddonText2<int,int,uint>
    public partial CStringPointer FormatAddonText2IntIntUInt(uint addonId, int value1, int value2, uint value3);

    /// <summary>
    /// Display a timespan as hours, minutes or seconds with only the largest non zero unit.
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="alternativeMinutesGlyph">Use U+E028 for minutes</param>
    /// <returns>string containing one of 23h, 59m, 59s</returns>
    [MemberFunction("48 83 EC 28 45 0F B6 C8 85 D2")]
    public partial CStringPointer FormatTimeSpan(uint seconds, bool alternativeMinutesGlyph = false);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B E8 A8 10")]
    public partial SheetRedirectFlags ResolveSheetRedirect(Utf8String* sheetName, int* outRowId, int* outColIndex);

    [MemberFunction("E8 ?? ?? ?? ?? F6 87 ?? ?? ?? ?? ?? 74 67")]
    public partial void AddSheetRedirectItemDecoration(Utf8String* sheetName, SheetRedirectFlags flags, int rowId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4D 80 48 8D 55 60")]
    public partial void CreateSheetLink(ExcelSheet* sheet, Utf8String* text, int rowId, int colParam);

    [Flags]
    public enum SheetRedirectFlags {
        None = 0,
        Item = 1 << 0,
        EventItem = 1 << 1,
        HighQuality = 1 << 2,
        Collectible = 1 << 3,
        Action = 1 << 4,
        ActionSheet = 1 << 5,
    }
}
