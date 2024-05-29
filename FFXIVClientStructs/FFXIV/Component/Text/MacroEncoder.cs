using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[GenerateInterop]
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
        using var us = new Utf8String();
        us.Ctor();
        us.SetString(code);
        return MacroCodeMap.TryGetValuePointer(us, out var ptr) ? ptr : null;
    }

    public string? GetMacroString(byte code) {
        foreach (ref var node in MacroCodeMap) {
            if (node.Item2.Id == code)
                return node.Item1.ToString();
        }

        return null;
    }

    [MemberFunction("E8 ?? ?? ?? ?? FF CF 89 7C 24 ?? EB")]
    public partial int EncodeParameter(Utf8String* output, Utf8String* param, byte type, int* outExtraParams);

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 83 F8 ?? 0F 8C"), GenerateStringOverloads]
    public partial int EncodeMacro(Utf8String* output, byte* input, int* outNumCharsRead);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 83 F8 ?? 7C ?? 49 8D 8E"), GenerateStringOverloads]
    public partial void EncodeString(Utf8String* output, byte* input);

    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    [GenerateInterop]
    public partial struct MacroCodeDescription {
        [FieldOffset(0x00)] public byte Id;
        /* 
         * n N = numeric
         * s S = string
         *   x = null byte/terminator (any params passed here and after are ignored/encoded to garbage)
         *   . = can be anything, will auto-detect if its a string/number/conditional etc
         *   * = repeat last param type (if param before * was string this needs to be a string too etc.)
         */
        [FieldOffset(0x01), FixedSizeArray] internal FixedSizeArray7<byte> _paramTypes;

        [FieldOffset(0x44)] public int TotalParamCount;
        [FieldOffset(0x48)] public int ParamCount;
        [FieldOffset(0x4C)] public bool IsTerminated;
    }
}
