using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<MacroDecoder>]
[StructLayout(LayoutKind.Explicit, Size = 0x1580)]
public unsafe partial struct AtkFontCodeModule {
    [FieldOffset(0x60)] public ExcelModule* ExcelModule;

    /// <summary>Maximum number of "units" (character, icon, or 1 visible macro) in a line before wrapping.</summary>
    [FieldOffset(0x150)] public int MaxUnits;
    [FieldOffset(0x154)] public int UsedUnits;

    /// <summary>Number of units of the word being placed that its earlier breaks consumed. 0 while it's not broken.</summary>
    [FieldOffset(0x1578)] public int ConsumedUnits;

    /// <summary>Calculates the number of units of a word that should stay in the same line, in regard to word wrapping.</summary>
    [MemberFunction("48 89 5C 24 20 56 57 41 57 48 83 EC 30 49 8B F1 44 8B C2 44 8B 89 50 01 00 00")]
    public partial uint SplitWord(int width, int unused, byte* word, byte* measuredWord, bool lineStart);

    /// <summary>Calculates the number of units of a word that fit, given a width.</summary>
    [MemberFunction("48 8B C4 53 41 56 48 83 EC 68 48 89 68 08 33 ED 48 89 70 10")]
    public partial int FitUnits(byte* measuredWord, int width, int maxUnits, int* bytes);
}
