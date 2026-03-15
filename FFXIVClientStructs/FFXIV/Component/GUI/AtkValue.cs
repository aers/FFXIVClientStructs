using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

public enum AtkValueType {
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

/// <summary>
/// Values used for other Atk systems sent on the stack. <br/>
/// Only <see cref="AtkValue.Type" /> == <see cref="AtkValueType.Managed"/> has the value pointer located in the heap.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct AtkValue : IDisposable {
    [FieldOffset(0x0)] public AtkValueType Type;

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

    public AtkValue() {
        Type = AtkValueType.Undefined;
        String.Value = null;
    }

    public AtkValue(AtkValue* other) => CtorCopy(other);

    public void Dtor(bool free) => Dispose(free);

    void IDisposable.Dispose() => Dispose(false);

    private void Dispose(bool free) {
        Dtor();
        if (free) IMemorySpace.Free((AtkValue*)Unsafe.AsPointer(ref this));
    }

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 83 CB ?? C7 45")]
    public partial AtkValue* CtorCopy(AtkValue* other);

    [MemberFunction("E8 ?? ?? ?? ?? 83 FF FE")]
    public partial void Dtor();

    [MemberFunction("44 8B 02 4C 8B C9 8B 01")]
    public partial bool EqualTo(AtkValue* other);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 55 2A")]
    public partial void Copy(AtkValue* other);

    [MemberFunction("E8 ?? ?? ?? ?? 41 80 F6")]
    public partial void ChangeType(AtkValueType type);

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

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 8B 8E")]
    public partial bool CopyVectorValue(uint index, AtkValue* outValue);

    [MemberFunction("E8 ?? ?? ?? ?? 89 75 F7")]
    private partial void ReleaseManagedMemoryInternal();

    // The game probably uses a macro for this, because it always
    // checks if the type is managed before calling it.
    public void ReleaseManagedMemory() {
        if (Type.HasFlag(AtkValueType.Managed))
            ReleaseManagedMemoryInternal();
    }

    public void SetBool(bool value) {
        ReleaseManagedMemory();
        Type = AtkValueType.Bool;
        Bool = value;
    }

    public void SetInt(int value) {
        ReleaseManagedMemory();
        Type = AtkValueType.Int;
        Int = value;
    }

    public void SetUInt(uint value) {
        ReleaseManagedMemory();
        Type = AtkValueType.UInt;
        UInt = value;
    }

    public void SetFloat(float value) {
        ReleaseManagedMemory();
        Type = AtkValueType.Float;
        Float = value;
    }

    public override string ToString() {
        return $"Type: {Type}, Value: {GetValueAsString()}";
    }

    public string GetValueAsString() {
        return Type switch {
            AtkValueType.Undefined or AtkValueType.Null => string.Empty,
            AtkValueType.Bool => Bool.ToString(),
            AtkValueType.Int => Int.ToString(),
            AtkValueType.UInt => UInt.ToString(),
            AtkValueType.Float => Float.ToString(),
            AtkValueType.String or AtkValueType.ManagedString => String.ToString(),
            AtkValueType.WideString => Marshal.PtrToStringUni((nint)WideString) ?? string.Empty,
            AtkValueType.String8 => String.ToString(),
            AtkValueType.Vector or AtkValueType.ManagedVector => Vector != null ? Vector->ToString() : "null",
            AtkValueType.Pointer => $"0x{(nint)Pointer:X}",
            AtkValueType.AtkValues => $"0x{(nint)AtkValues:X}",
            _ => BitConverter.ToString(BitConverter.GetBytes((ulong)String.Value)).Replace("-", " ")
        };
    }
}
