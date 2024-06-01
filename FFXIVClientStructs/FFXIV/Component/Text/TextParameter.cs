namespace FFXIVClientStructs.FFXIV.Component.Text;

// TODO: implement as Client::System::Data::Variant<> and Client::System::Data::VariantPtr<>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct TextParameter {
    [FieldOffset(0), CExporterUnion("Value")] public int IntValue;
    [FieldOffset(0), CExporterUnion("Value")] public byte* StringValue;
    [FieldOffset(0), CExporterUnion("Value")] public ReferencedUtf8String* ReferencedUtf8StringValue;
    [FieldOffset(0x8)] public void* ValuePtr; // a pointer to the value
    [FieldOffset(0x10)] public TextParameterType Type;

    [MemberFunction("E8 ?? ?? ?? ?? EB 11 48 83 F8 02")]
    public partial void SetReferencedUtf8String(ReferencedUtf8String** ptr);

    [MemberFunction("E8 ?? ?? ?? ?? 48 FF 45 1F")]
    public partial void SetString(byte** ptr);

    [MemberFunction("E8 ?? ?? ?? ?? EB 31 85 D2")]
    public partial void SetInteger(int* ptr);
}

public enum TextParameterType : sbyte {
    Uninitialized = -1,
    Integer = 0,
    ReferencedUtf8String = 1,
    String = 2
}
