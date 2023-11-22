using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureTextModule
// ctor "E8 ?? ?? ?? ?? 48 8D 9F ?? ?? ?? ?? 4D 8B C5"
[StructLayout(LayoutKind.Explicit, Size = 0xE60)]
public unsafe partial struct RaptureTextModule {
    public static RaptureTextModule* Instance() => Framework.Instance()->GetUiModule()->GetRaptureTextModule();

    [FieldOffset(0x00)] public TextModule TextModule;
    [FieldOffset(0x510)] public void** ExecNonMacroFunc; // only a vtable
    [FieldOffset(0x518)] public void** ExcelLanguageEvent; // only a vtable
    [FieldOffset(0x520)] public UIModule* UiModule;
    [FieldOffset(0x528)] public TextChecker TextChecker;
    [FieldOffset(0x620)] public ExcelSheet* AddonSheet;

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
}
