using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// this type is used to store data of a bunch of different kinds
// the enum is not exhaustive, just the ones I care about so far
public enum ValueType {
    Int = 0x3,
    Bool = 0x2,
    UInt = 0x4,
    Float = 0x5,
    String = 0x6,
    String8 = 0x8,
    Vector = 0x9,
    Texture = 0xA,
    AtkValues = 0xB,
    AllocatedString = 0x26,
    AllocatedVector = 0x29
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct AtkValue {
    [FieldOffset(0x0)] public ValueType Type;

    // union field
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public int Int;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public uint UInt;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public byte* String; // char*
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public float Float;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public byte Byte;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public StdVector<AtkValue>* Vector;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public Texture* Texture;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public AtkValue* AtkValues;

    [MemberFunction("E8 ?? ?? ?? ?? 41 03 ED")]
    [GenerateCStrOverloads]
    public partial void SetString(byte* value);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 06 4C 8D 4C 24 ?? 44 8B C3")]
    public partial void ChangeType(ValueType type);

    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 89 7C 24")]
    public partial void CreateArray(int size);
}
