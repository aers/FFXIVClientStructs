using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FixedSheetInterface = FFXIVClientStructs.FFXIV.Component.Text.TextModuleInterface.FixedSheetInterface;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[GenerateInterop(isInherited: true)]
[Inherits<TextModuleInterface>, Inherits<MacroDecoder>(parentOffset: 8)]
[StructLayout(LayoutKind.Explicit, Size = 0x510)]
public unsafe partial struct TextModule {
    [FieldOffset(0x68)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0x70)] public Localize Localize;
    [FieldOffset(0x98)] public MacroEncoder MacroEncoder;

    //[FieldOffset(0x3A8)] public Utf8String UnkStr; // DecoderResult?
    [FieldOffset(0x410)] public Utf8String MacroEncoderResult;

    [FieldOffset(0x478)] public FixedSheetInterface* CompletionFixedSheetInterface;

    [VirtualFunction(16), GenerateStringOverloads]
    public partial bool FormatString(byte* input, StdDeque<TextParameter>* localParameters, Utf8String* output);
}
