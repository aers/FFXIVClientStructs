using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe partial struct MacroEncoder {
    [FieldOffset(0x08)] public StdMap<Utf8String, MacroCodeDescription> MacroCodeMap;
    [FieldOffset(0x20)] public Utf8String EncoderError;
    [FieldOffset(0x88)] public Utf8String Str2;
    [FieldOffset(0xF0)] public Utf8String Str3;
    [FieldOffset(0x158)] public StdVector<Utf8String> MacroParams;
    [FieldOffset(0x170)] public Utf8String Str4;
    [FieldOffset(0x1D8)] public Utf8String ConditionalOp;
    [FieldOffset(0x240)] public Utf8String Str6;
    [FieldOffset(0x2A8)] public Utf8String Str7;

    [StructLayout(LayoutKind.Explicit, Size = 0x100)]
    public struct MacroCodeDescription {
        [FieldOffset(0x00)] public byte Id;

        [FieldOffset(0x48)] public int ParameterCount;
        [FieldOffset(0x4C)] public bool HasParameter;
    }
}
