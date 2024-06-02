using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[GenerateInterop(isInherited: true)]
[Inherits<MacroDecoder>(parentOffset: 8)]
[StructLayout(LayoutKind.Explicit, Size = 0x510)]
public unsafe partial struct TextModule {
    [FieldOffset(0x68)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0x70)] public Localize Localize;
    [FieldOffset(0x98)] public MacroEncoder MacroEncoder;

    //[FieldOffset(0x3A8)] public Utf8String UnkStr; // DecoderResult?
    [FieldOffset(0x410)] public Utf8String MacroEncoderResult;

    [VirtualFunction(7)]
    public partial Utf8String* EncodeString(Utf8String* ouput, Utf8String* input);

    [VirtualFunction(8), GenerateStringOverloads]
    public partial int EncodeMacro(byte* input, Utf8String* output);

    [VirtualFunction(9), GenerateStringOverloads]
    public partial Utf8String* ProcessMacroCode(Utf8String* output, byte* input);

    [VirtualFunction(16), GenerateStringOverloads]
    public partial bool FormatString(byte* input, StdDeque<TextParameter>* localParameters, Utf8String* output);
}
