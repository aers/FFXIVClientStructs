using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct TextParameter {
    [FieldOffset(0)] public int IntValue;
    [FieldOffset(0)] public byte* StringValue;
    [FieldOffset(0)] public Utf8String* Utf8StringValue;
    [FieldOffset(0x8)] public void* ValuePtr; // a pointer to the value
    [FieldOffset(0x10)] public TextParameterType Type;
}

public enum TextParameterType : sbyte {
    Uninitialized = -1,
    Integer = 0,
    Utf8String = 1,
    String = 2
}
