using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe partial struct MacroEncoder {
    [FieldOffset(0x08)] public StdMap<Utf8String, MacroCodeDescription> MacroCodeMap;
    [FieldOffset(0x18)] public int ClientLanguage; //set before calling EncodeString
    [FieldOffset(0x20)] public Utf8String EncoderError;
    [FieldOffset(0x88)] public Utf8String Str2;
    [FieldOffset(0xF0)] public Utf8String Str3;
    [FieldOffset(0x158)] public StdVector<Utf8String> MacroTokens;
    [FieldOffset(0x170)] public Utf8String Str4;
    [FieldOffset(0x1D8)] public Utf8String ConditionalOp;
    [FieldOffset(0x240)] public Utf8String Str6;
    [FieldOffset(0x2A8)] public Utf8String Str7;

    public MacroCodeDescription* GetMacroCode(string code) {
        var currentNode = MacroCodeMap.SmallestValue;
        while (currentNode != null && currentNode != MacroCodeMap.Head) {
            if (currentNode->KeyValuePair.Item1.EqualsString(code))
                return &currentNode->KeyValuePair.Item2;
            currentNode = currentNode->Next();
        }
        return null;
    }

    public string? GetMacroString(byte code) {
        var currentNode = MacroCodeMap.SmallestValue;
        while (currentNode != null && currentNode != MacroCodeMap.Head) {
            if (currentNode->KeyValuePair.Item2.Id == code)
                return currentNode->KeyValuePair.Item1.ToString();
            currentNode = currentNode->Next();
        }
        return null;
    }

    [MemberFunction("E8 ?? ?? ?? ?? FF CF 89 7C 24 ?? EB")]
    public partial int EncodeParameter(Utf8String* output, Utf8String* param, byte type, int* outExtraParams);

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 83 F8 ?? 0F 8C"), GenerateCStrOverloads]
    public partial int EncodeMacro(Utf8String* output, byte* input, int* outNumCharsRead);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 83 F8 ?? 7C ?? 49 8D 8E"), GenerateCStrOverloads]
    public partial void EncodeString(Utf8String* output, byte* input);

    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public struct MacroCodeDescription {
        [FieldOffset(0x00)] public byte Id;
        /* 
         * n N = numeric
         * s S = string
         *   x = null byte/terminator (any params passed here and after are ignored/encoded to garbage)
         *   . = can be anything, will auto-detect if its a string/number/conditional etc
         *   * = repeat last param type (if param before * was string this needs to be a string too etc.)
         */
        [FieldOffset(0x01)] public fixed byte ParamTypes[7];

        [FieldOffset(0x44)] public int TotalParamCount;
        [FieldOffset(0x48)] public int ParamCount;
        [FieldOffset(0x4C)] public bool IsTerminated;
    }
}
