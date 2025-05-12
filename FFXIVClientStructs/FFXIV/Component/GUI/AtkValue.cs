using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

public enum ValueType {
    Undefined = 0,
    Null = 0x1,
    Bool = 0x2,
    Int = 0x3,
    Int64 = 0x4,
    UInt = 0x5,
    UInt64 = 0x6,
    Float = 0x7,
    String = 0x8, // 1 byte per character (ASCII/UTF-8)
    WideString = 0x9, // 2 bytes per character (UTF-16)
    String8 = 0xA, // assumed to be a const char*
    Vector = 0xB,
    Pointer = 0xC,
    AtkValues = 0xD,

    TypeMask = 0xF,

    Managed = 0x20,
    ManagedString = Managed | String,
    ManagedVector = Managed | Vector,
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct AtkValue : ICreatable, IDisposable {
    [FieldOffset(0x0)] public ValueType Type;

    // union field
    [FieldOffset(0x8), CExporterUnion("Value")] public bool Bool;
    [FieldOffset(0x8), CExporterUnion("Value")] public byte Byte;
    [FieldOffset(0x8), CExporterUnion("Value")] public int Int;
    [FieldOffset(0x8), CExporterUnion("Value")] public long Int64;
    [FieldOffset(0x8), CExporterUnion("Value")] public uint UInt;
    [FieldOffset(0x8), CExporterUnion("Value")] public ulong UInt64;
    [FieldOffset(0x8), CExporterUnion("Value")] public float Float;
    [FieldOffset(0x8), CExporterUnion("Value")] public CStringPointer String;
    [FieldOffset(0x8), CExporterUnion("Value")] public char* WideString; // C# uses UTF-16 for char, which makes it easy for us to use it here
    [FieldOffset(0x8), CExporterUnion("Value")] public StdVector<AtkValue>* Vector;
    [FieldOffset(0x8), CExporterUnion("Value")] public void* Pointer;
    [FieldOffset(0x8), CExporterUnion("Value")] public AtkValue* AtkValues;

    public AtkValue() => Ctor();
    public AtkValue(AtkValue* other) => Ctor(other);

    public void Ctor() {
        Type = ValueType.Undefined;
        String.Value = null;
    }

    public void Dtor(bool free) => Dispose(free);

    void IDisposable.Dispose() => Dispose(false);

    private void Dispose(bool free) {
        Dtor();
        if (free) IMemorySpace.Free((AtkValue*)Unsafe.AsPointer(ref this));
    }

    [MemberFunction("E8 ?? ?? ?? ?? 0F BA E6 11")]
    public partial void Ctor(AtkValue* other);

    [MemberFunction("E8 ?? ?? ?? ?? 83 FF FE")]
    public partial void Dtor();

    [MemberFunction("44 8B 02 4C 8B C9 8B 01")]
    public partial bool EqualTo(AtkValue* other);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 55 2A")]
    public partial void Copy(AtkValue* other);

    [MemberFunction("E8 ?? ?? ?? ?? 42 88 B4")]
    public partial void ChangeType(ValueType type);

    /// <summary>
    /// Set this AtkValue to reference the specified pointer to a cstring.
    /// The pointer *must* remain valid for the lifetime of this AtkValue!
    /// Type is set to ValueType.String.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 41 83 4D")]
    public partial void SetString(byte* stringPtr);

    /// <summary>
    /// Set this AtkValue to hold the specified string. The string value
    /// is copied and stored locally for this object.
    /// Type is set to ValueType.ManagedString.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 41 03 ED"), GenerateStringOverloads]
    public partial void SetManagedString(CStringPointer value);

    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 89 7C 24")]
    public partial void CreateVector(uint size);

    [MemberFunction("E8 ?? ?? ?? ?? 3B D8 73 17")]
    public partial uint GetVectorSize();

    [MemberFunction("48 83 EC 28 48 8B 49 08 48 85 C9 74 0C")]
    public partial void SetVectorSize(uint size);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 08 80 E1 0F")]
    public partial AtkValue* GetVectorValue(uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? EB 5C")]
    public partial bool SetVectorValue(uint index, AtkValue* value);

    [MemberFunction("E8 ?? ?? ?? ?? 83 C6 02 FF C7"), GenerateStringOverloads]
    public partial bool SetVectorString(uint index, CStringPointer value);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 44 24 60 4E 8D 24 3E")]
    public partial bool CopyVectorValue(uint index, AtkValue* outValue);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 55 9C ?? ?? ?? ?? ?? ?? ?? ??")]
    private partial void ReleaseManagedMemoryInternal();

    // The game probably uses a macro for this, because it always
    // checks if the type is managed before calling it.
    public void ReleaseManagedMemory() {
        if (Type.HasFlag(ValueType.Managed))
            ReleaseManagedMemoryInternal();
    }

    public void SetBool(bool value) {
        ReleaseManagedMemory();
        Type = ValueType.Bool;
        Bool = value;
    }

    public void SetInt(int value) {
        ReleaseManagedMemory();
        Type = ValueType.Int;
        Int = value;
    }

    public void SetUInt(uint value) {
        ReleaseManagedMemory();
        Type = ValueType.UInt;
        UInt = value;
    }

    public void SetFloat(float value) {
        ReleaseManagedMemory();
        Type = ValueType.Float;
        Float = value;
    }

    public override string ToString() {
        return $"Type: {Type}, Value: {GetValueAsString()}";
    }

    public string GetValueAsString() {
        return Type switch {
            ValueType.Undefined or ValueType.Null => string.Empty,
            ValueType.Bool => Bool.ToString(),
            ValueType.Int => Int.ToString(),
            ValueType.UInt => UInt.ToString(),
            ValueType.Float => Float.ToString(),
            ValueType.String or ValueType.ManagedString => String.ToString(),
            ValueType.WideString => Marshal.PtrToStringUni((nint)WideString) ?? string.Empty,
            ValueType.String8 => String.ToString(),
            ValueType.Vector or ValueType.ManagedVector => Vector != null ? Vector->ToString() : "null",
            ValueType.Pointer => $"0x{(nint)Pointer:X}",
            ValueType.AtkValues => $"0x{(nint)AtkValues:X}",
            _ => BitConverter.ToString(BitConverter.GetBytes((ulong)String.Value)).Replace("-", " ")
        };
    }
}
