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

    // FormatAddonText1
    [MemberFunction("E8 ?? ?? ?? ?? 8D 4D 2B")]
    public partial CStringPointer FormatAddonText1String(uint addonId, CStringPointer strParam);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 4D 20")]
    public partial CStringPointer FormatAddonText1StringInt(uint addonId, CStringPointer strParam, int intParam);

    [MemberFunction("E8 ?? ?? ?? ?? EB 67 B8 ?? ?? ?? ??")]
    public partial CStringPointer FormatAddonText1StringIntUInt(uint addonId, CStringPointer strParam, int intParam, uint uintParam);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 4B 20 48 8B D0 33 C0")]
    public partial CStringPointer FormatAddonText1StringString(uint addonId, CStringPointer strParam1, CStringPointer strParam2);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B B4 24 ?? ?? ?? ?? 49 8D B7 ?? ?? ?? ??")]
    public partial CStringPointer FormatAddonText1StringStringString(uint addonId, CStringPointer strParam1, CStringPointer strParam2, CStringPointer strParam3);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 7D FF 45 33 FF")]
    public partial CStringPointer FormatAddonText1Int(uint addonId, int intParam);

    [MemberFunction("E8 ?? ?? ?? ?? 80 7E 4E 00")]
    public partial CStringPointer FormatAddonText1IntInt(uint addonId, int intParam1, int intParam2);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 7D FF 45 33 FF")]
    public partial CStringPointer FormatAddonText1IntIntUInt(uint addonId, int intParam1, int intParam2, uint uintParam);

    [MemberFunction("E8 ?? ?? ?? ?? EB 38 49 8B D2")]
    public partial CStringPointer FormatAddonText1IntIntUIntUInt(uint addonId, int intParam1, int intParam2, uint uintParam1, uint uintParam2);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 5C 24 44 48 8B D0")]
    public partial CStringPointer FormatAddonText1IntString(uint addonId, int intParam, CStringPointer strParam);

    // FormatAddonText2
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C5 48 89 44 24 ??")]
    public partial CStringPointer FormatAddonText2String(uint addonId, CStringPointer strParam);

    [MemberFunction("E8 ?? ?? ?? ?? EB 67 48 8B 7E 10")]
    public partial CStringPointer FormatAddonText2StringInt(uint addonId, CStringPointer strParam, int intParam);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7C 24 ?? EB 14")]
    public partial CStringPointer FormatAddonText2StringIntUInt(uint addonId, CStringPointer strParam, int intParam, uint uintParam);

    [MemberFunction("40 55 53 56 57 41 54 41 56 41 57 48 8B EC 48 83 EC 50 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 F8 48 8D B9 ?? ?? ?? ?? 48 8B F1 48 8B CF 45 8B F9 49 8B D8 44 8B E2 E8 ?? ?? ?? ?? 48 85 DB 48 8D 15 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 48 0F 45 D3 E8 ?? ?? ?? ?? 33 D2 45 33 C0 8D 4A 70 E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 74 18 48 8D 96 ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? C7 43 ?? ?? ?? ?? ?? EB 02 33 DB 48 8D 45 E0 48 89 5D E0 48 8D 55 E0 48 89 45 E8 48 8B CF C6 45 F0 01 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 48 8D 45 E0 44 89 7D E0 48 8B CF 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 8B 45 60 48 8B CF 89 45 E0 48 8D 45 E0 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 8B 45 68 48 8B CF 89 45 E0 48 8D 45 E0 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 4C 8D 86 ?? ?? ?? ??")]
    public partial CStringPointer FormatAddonText2StringIntUIntUInt(uint addonId, CStringPointer strParam, int intParam, uint uintParam1, uint uintParam2);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 8D 4D E0 E8 ?? ?? ?? ?? 49 8B 9D ?? ?? ?? ??")]
    public partial CStringPointer FormatAddonText2StringIntUIntUIntUInt(uint addonId, CStringPointer strParam, int intParam, uint uintParam1, uint uintParam2, uint uintParam3);

    [MemberFunction("40 55 53 56 57 41 54 41 56 41 57 48 8B EC 48 83 EC 50 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 F8 48 8D B9 ?? ?? ?? ?? 48 8B F1 48 8B CF 45 8B F9 49 8B D8 44 8B E2 E8 ?? ?? ?? ?? 48 85 DB 48 8D 15 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 48 0F 45 D3 E8 ?? ?? ?? ?? 33 D2 45 33 C0 8D 4A 70 E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 74 18 48 8D 96 ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? C7 43 ?? ?? ?? ?? ?? EB 02 33 DB 48 8D 45 E0 48 89 5D E0 48 8D 55 E0 48 89 45 E8 48 8B CF C6 45 F0 01 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 48 8D 45 E0 44 89 7D E0 48 8B CF 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 8B 45 60 48 8B CF 89 45 E0 48 8D 45 E0 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 8B 45 68 48 8B CF 89 45 E0 48 8D 45 E0 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 8B 45 70 48 8B CF 89 45 E0 48 8D 45 E0 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 8B 45 78 48 8B CF 89 45 E0 48 8D 45 E0 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 4C 8D 86 ?? ?? ?? ??")]
    public partial CStringPointer FormatAddonText2StringIntUIntUIntUIntUInt(uint addonId, CStringPointer strParam, int intParam, uint uintParam1, uint uintParam2, uint uintParam3, uint uintParam4);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8C 24 ?? ?? ?? ?? 45 33 C9 4C 8B C0 C6 44 24 ?? ??")]
    public partial CStringPointer FormatAddonText2StringIntUIntUIntUIntUIntUInt(uint addonId, CStringPointer strParam, int intParam, uint uintParam1, uint uintParam2, uint uintParam3, uint uintParam4, uint uintParam5);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 8B 8F ?? ?? ?? ??")]
    public partial CStringPointer FormatAddonText2StringString(uint addonId, CStringPointer strParam1, CStringPointer strParam2);

    [MemberFunction("40 53 55 56 57 41 54 41 56 41 57 48 83 EC 50 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 4C 8B BC 24 ?? ?? ?? ?? 48 8B F9 48 81 C1 ?? ?? ?? ?? 4D 8B F1 49 8B D8 44 8B E2 E8 ?? ?? ?? ?? 48 85 DB 48 8D 15 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 0F 45 D3 E8 ?? ?? ?? ?? 33 D2 45 33 C0 8D 4A 70 E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 74 18 48 8D 97 ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? C7 43 ?? ?? ?? ?? ?? EB 02 33 DB 48 8D 44 24 ?? 48 89 5C 24 ?? 48 8D 54 24 ?? 48 89 44 24 ?? 48 8D 8F ?? ?? ?? ?? C6 44 24 ?? ?? E8 ?? ?? ?? ?? 48 8B 5C 24 ?? 48 85 DB 74 28 80 7C 24 ?? ?? 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 4D 85 F6 48 8D 15 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 0F 45 D6 E8 ?? ?? ?? ?? 33 D2 45 33 C0 8D 4A 70 E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 74 18 48 8D 97 ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? C7 43 ?? ?? ?? ?? ?? EB 02 33 DB 48 8D 44 24 ?? 48 89 5C 24 ?? 48 8D 54 24 ?? 48 89 44 24 ?? 48 8D 8F ?? ?? ?? ?? C6 44 24 ?? ?? E8 ?? ?? ?? ?? 48 8B 5C 24 ?? 48 85 DB 74 28 80 7C 24 ?? ?? 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 4D 85 FF 48 8D 15 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 0F 45 D7 E8 ?? ?? ?? ?? 33 D2 45 33 C0 8D 4A 70 E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 74 18 48 8D 97 ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? C7 43 ?? ?? ?? ?? ?? EB 02 33 DB 48 8D 44 24 ?? 48 89 5C 24 ?? 48 8D 54 24 ?? 48 89 44 24 ?? 48 8D 8F ?? ?? ?? ?? C6 44 24 ?? ?? E8 ?? ?? ?? ?? 48 8B 5C 24 ?? 48 85 DB 74 28 80 7C 24 ?? ?? 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 4C 8D 87 ?? ?? ?? ??")]
    public partial CStringPointer FormatAddonText2StringStringString(uint addonId, CStringPointer strParam1, CStringPointer strParam2, CStringPointer strParam3);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 41 0F B6 44 24 ?? 3C 01")]
    public partial CStringPointer FormatAddonText2StringStringUInt(uint addonId, CStringPointer strParam1, CStringPointer strParam2, uint uintParam);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 8D 4C 24 ?? 41 8B C7")]
    public partial CStringPointer FormatAddonText2StringStringUIntUInt(uint addonId, CStringPointer strParam1, CStringPointer strParam2, uint uintParam1, uint uintParam2);

    [MemberFunction("E8 ?? ?? ?? ?? 41 39 7E 08")]
    public partial CStringPointer FormatAddonText2StringStringUIntUIntUInt(uint addonId, CStringPointer strParam1, CStringPointer strParam2, uint uintParam1, uint uintParam2, uint uintParam3);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 65 80 4C 8B C0")]
    public partial CStringPointer FormatAddonText2StringStringStringUIntUInt(uint addonId, CStringPointer strParam1, CStringPointer strParam2, CStringPointer strParam3, uint uintParam1, uint uintParam2);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 55 0B")]
    public partial CStringPointer FormatAddonText2Int(uint addonId, int intParam);

    [MemberFunction("E8 ?? ?? ?? ?? EB 51 0F B6 DB")]
    public partial CStringPointer FormatAddonText2IntInt(uint addonId, int intParam1, int intParam2);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 EB 38")]
    public partial CStringPointer FormatAddonText2IntIntUInt(uint addonId, int intParam1, int intParam2, uint uintParam);

    [MemberFunction("E8 ?? ?? ?? ?? EB 72 4C 8B 42 30")]
    public partial CStringPointer FormatAddonText2IntIntUIntUInt(uint addonId, int intParam1, int intParam2, uint uintParam1, uint uintParam2);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 4D 64")]
    public partial CStringPointer FormatAddonText2IntIntUIntUIntUInt(uint addonId, int intParam1, int intParam2, uint uintParam1, uint uintParam2, uint uintParam3);

    [MemberFunction("48 89 5C 24 ?? 55 56 57 41 56 41 57 48 8B EC 48 83 EC 50 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 F8 48 8D B9 ?? ?? ?? ?? 48 8B F1 48 8B CF 45 8B F1 41 8B D8 44 8B FA E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 48 8D 45 E0 89 5D E0 48 8B CF 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 48 8D 45 E0 44 89 75 E0 48 8B CF 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 8B 45 50 48 8B CF 89 45 E0 48 8D 45 E0 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 8B 45 58 48 8B CF 89 45 E0 48 8D 45 E0 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 8B 45 60 48 8B CF 89 45 E0 48 8D 45 E0 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 C0 C6 45 F0 00 48 89 45 E0 48 8D 55 E0 8B 45 68 48 8B CF 89 45 E0 48 8D 45 E0 48 89 45 E8 E8 ?? ?? ?? ?? 48 8B 5D E8 48 85 DB 74 27 80 7D F0 01 75 21 48 8B 1B FF 4B 68 83 7B 68 00 7F 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 4C 8D 86 ?? ?? ?? ??")]
    public partial CStringPointer FormatAddonText2IntIntUIntUIntUIntUInt(uint addonId, int intParam1, int intParam2, uint uintParam1, uint uintParam2, uint uintParam3, uint uintParam4);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 64 24 ?? 4C 8B 74 24 ?? 48 8B 9C 24 ?? ?? ?? ??")]
    public partial CStringPointer FormatAddonText2IntIntUIntUIntUIntUInt(uint addonId, int intParam1, int intParam2, uint uintParam1, uint uintParam2, uint uintParam3, uint uintParam4, uint uintParam5);

    [MemberFunction("E8 ?? ?? ?? ?? EB 41 41 8B F7")]
    public partial CStringPointer FormatAddonText2IntString(uint addonId, int intParam, CStringPointer strParam);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8D ?? ?? ?? ?? 45 0F B7 C6")]
    public partial CStringPointer FormatAddonText2IntIntString(uint addonId, int intParam1, int intParam2, CStringPointer strParam);

    [MemberFunction("48 89 5C 24 ?? 55 56 57 41 56 41 57 48 83 EC 50 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 48 8B F1 4D 8B F1")]
    public partial CStringPointer FormatAddonText2IntStringUInt(uint addonId, int intParam, CStringPointer strParam, uint uintParam);

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
