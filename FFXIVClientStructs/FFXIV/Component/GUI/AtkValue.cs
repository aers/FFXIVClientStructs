using System.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// this type is used to store data of a bunch of different kinds
// the enum is not exhaustive, just the ones I care about so far
public enum ValueType
{
    Int = 0x3,
    Bool = 0x2,
    UInt = 0x4,
    Float = 0x5,
    String = 0x6,
    String8 = 0x8,
    Vector = 0x9,
    AllocatedString = 0x26,
    AllocatedVector = 0x29
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct AtkValue
{
    [FieldOffset(0x0)] public ValueType Type;

    // union field
    [FieldOffset(0x8)] public int Int;
    [FieldOffset(0x8)] public uint UInt;
    [FieldOffset(0x8)] public byte* String; // char*
    [FieldOffset(0x8)] public float Float;
    [FieldOffset(0x8)] public byte Byte;
    [FieldOffset(0x8)] public StdVector<AtkValue>* Vector;

    [MemberFunction("E8 ?? ?? ?? ?? 41 03 ED")]
    public partial void SetString(byte* value);

    [MemberFunction("E8 ?? ?? ?? ?? F7 DE")]
    public partial void ChangeType(ValueType type);

    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 89 7C 24")]
    public partial void CreateArray(int size);

    public void SetString(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value + '\0');
        fixed (byte* bp = bytes)
        {
            SetString(bp);
        }
    }
}
