using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.Completion;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct TextModuleInterface {
    [VirtualFunction(1)]
    public partial StdDeque<TextParameter>* GetGlobalParameters();

    [VirtualFunction(3)]
    public partial Utf8String* FormatUtf8String(Utf8String* input, StdDeque<TextParameter>* localParameters, Utf8String* output);

    [VirtualFunction(7)]
    public partial Utf8String* EncodeString(Utf8String* ouput, Utf8String* input);

    [VirtualFunction(8), GenerateStringOverloads]
    public partial int EncodeMacro(byte* input, Utf8String* output);

    [VirtualFunction(9), GenerateStringOverloads]
    public partial Utf8String* ProcessMacroCode(Utf8String* output, byte* input);

    [VirtualFunction(13)]
    public partial void SetCompletionModule(CompletionModule* completionModule);
}
