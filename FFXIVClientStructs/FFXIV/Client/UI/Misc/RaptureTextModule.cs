using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureTextModule
//   Component::Text::TextModule
//     Component::Text::TextModuleInterface
//     Component::Text::MacroDecoder
//   Component::Text::TextChecker::ExecNonMacroFunc
//   Component::Excel::ExcelLanguageEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 9F ?? ?? ?? ?? 4D 8B C5"
[GenerateInterop]
[Inherits<TextModule>, Inherits<TextChecker.ExecNonMacroFunc>, Inherits<ExcelLanguageEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xE60)]
public unsafe partial struct RaptureTextModule {
    public static RaptureTextModule* Instance() => Framework.Instance()->GetUIModule()->GetRaptureTextModule();

    [FieldOffset(0x520)] public UIModule* UIModule;
    [FieldOffset(0x528)] public TextChecker TextChecker;
    [FieldOffset(0x620)] public ExcelSheet* AddonSheet;

    [FieldOffset(0x630), FixedSizeArray] internal FixedSizeArray7<Utf8String> _unkStrings0;

    [FieldOffset(0x908)] public StdDeque<TextParameter> LocalTextParameters;
    //[FieldOffset(0x930)] public StdDeque<TextParameter> ItemColorParameters;

    [FieldOffset(0x958), FixedSizeArray] internal FixedSizeArray9<Utf8String> _unkStrings1;

    // [FieldOffset(0xD18)] public RowWrapper<Addon>* AddonRowCache; // only for the first 4000 Addon rows

    [FieldOffset(0xE18)] internal ExcelSheet* AchievementSheet;
    [FieldOffset(0xE20)] internal ExcelSheet* StatusSheet;
    [FieldOffset(0xE28)] internal ExcelSheet* HowToSheet;
    [FieldOffset(0xE30)] internal ExcelSheet* AkatsukiNoteStringSheet;
    [FieldOffset(0xE38)] public int SoundId;
    [FieldOffset(0xE3C)] public int IsJingle;

    [MemberFunction("E9 ?? ?? ?? ?? 80 EA 20")]
    public partial byte* GetAddonText(uint addonId);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 7D D7")]
    public partial byte* FormatAddonText2(uint addonId, int intParam1, int intParam2);

    [MemberFunction("E8 ?? ?? ?? ?? EB 55 FF 50 30")]
    public partial byte* FormatAddonText3(uint addonId, int intParam1, int intParam2, int intParam3);

    /// <summary>
    /// Display a timespan as hours, minutes or seconds with only the largest non zero unit.
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="alternativeMinutesGlyph">Use U+E028 for minutes</param>
    /// <returns>string containing one of 23h, 59m, 59s</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C0 48 8B 4D 88")]
    public partial byte* FormatTimeSpan(uint seconds, bool alternativeMinutesGlyph = false);

    /// <remarks> Singular only. The usage of intParam2 is unknown. </remarks>
    /// <returns>
    /// A pointer to a null terminated string containing the formatted name.<br/>
    /// It was observed, that it can return a nullptr when the excel page was not loaded. Try calling it again in subsequent frames.
    /// </returns>
    [MemberFunction("E9 ?? ?? ?? ?? 48 8D 47 30")]
    public static partial byte* FormatName(NameFormatterPlaceholder placeholder, int id, NameFormatterIdConverter idConverter, int intParam2 = 1);
}

public enum NameFormatterPlaceholder : int {
    ObjStr = 0,
    Item = 1,   // bypasses IdConverter
    ActStr = 2,
}

public enum NameFormatterIdConverter : uint {
    None = 0,

    // ObjStr
    BNpcName = 2,
    ENpcResident = 3,
    Treasure = 4,
    Aetheryte = 5,
    GatheringPointName = 6,
    EObjName = 7,
    // Mount = 8, // does not work?
    Companion = 9,
    // 10-11 unused
    // Item = 12, // does not work?

    // ActStr
    Trait = 0,
    Action = 1,
    // Item = 2, // does not work?
    // EventItem = 3, // does not work?
    EventAction = 4,
    // EObjName = 5, // does not work?
    GeneralAction = 5,
    BuddyAction = 6,
    MainCommand = 7,
    // Companion = 8, // unresolved, use Companion
    CraftAction = 9,
    Action2 = 10,
    PetAction = 11,
    CompanyAction = 12,
    Mount = 13,
    // 14-18 unused
    BgcArmyAction = 19,
    Ornament = 20,
}
