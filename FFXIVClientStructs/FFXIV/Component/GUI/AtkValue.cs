using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// TODO: In Dawntrail 2 new types were introduced. TypeMask and Managed are still the same.
[Flags]
public enum ValueType {
    Undefined = 0,
    Null = 0x1,
    Bool = 0x2,
    Int = 0x3,
    // Dawntrail adds Int64 = 0x4 here, everything afterwards +1
    UInt = 0x4,
    // Dawntrail adds UInt64 = 0x6 here, everything afterwards +1 again
    Float = 0x5,
    String = 0x6, // 1 byte per character (ASCII/UTF-8)
    WideString = 0x7, // 2 bytes per character (UTF-16)
    String8 = 0x8, // assumed to be a const char*
    Vector = 0x9,
    Texture = 0xA,
    AtkValues = 0xB,

    TypeMask = 0xF,

    Managed = 0x20,
    ManagedString = Managed | String,
    ManagedVector = Managed | Vector,

    [Obsolete("Renamed to ManagedString")]
    AllocatedString = 0x26,
    [Obsolete("Renamed to ManagedVector")]
    AllocatedVector = 0x29
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct AtkValue : ICreatable, IDisposable {
    [FieldOffset(0x0)] public ValueType Type;

    // union field
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public bool Bool;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public byte Byte;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public int Int;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public long Int64;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public uint UInt;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public ulong UInt64;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public float Float;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public byte* String;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public char* WideString; // C# uses UTF-16 for char, which makes it easy for us to use it here
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public StdVector<AtkValue>* Vector;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public Texture* Texture;
    [FieldOffset(0x8), CExporterUnion("Union.Value")] public AtkValue* AtkValues;

    public AtkValue() => Ctor();
    public AtkValue(AtkValue* other) => Ctor(other);

    public void Ctor() {
        Type = ValueType.Undefined;
        String = null;
    }

    public void Dtor(bool free) => Dispose(free);

    void IDisposable.Dispose() => Dispose(false);

    private void Dispose(bool free) {
        Dtor();
        if (free) IMemorySpace.Free((AtkValue*)Unsafe.AsPointer(ref this));
    }

    [MemberFunction("E8 ?? ?? ?? ?? 0F BA E3 0F")]
    public partial void Ctor(AtkValue* other);

    [MemberFunction("E8 ?? ?? ?? ?? 83 FF FE")]
    public partial void Dtor();

    [MemberFunction("44 8B 02 4C 8B C9 8B 01")]
    public partial bool EqualTo(AtkValue* other);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 55 2A")]
    public partial void Copy(AtkValue* other);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 06 4C 8D 4C 24 ?? 44 8B C3")]
    public partial void ChangeType(ValueType type);

    [MemberFunction("E8 ?? ?? ?? ?? 41 03 ED")] // TODO: replace sig with unmanaged variant "E8 ?? ?? ?? ?? 83 0E 20" and remove ObsoleteAttribute
    [GenerateCStrOverloads]
    [Obsolete("Use SetManagedString instead. This will be replaced by the unmanaged function in Dawntrail.")]
    public partial void SetString(byte* value);

    [MemberFunction("E8 ?? ?? ?? ?? 41 03 ED")]
    [GenerateCStrOverloads]
    public partial void SetManagedString(byte* value);

    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 89 7C 24")]
    [Obsolete("Renamed to CreateVector")]
    public partial void CreateArray(int size); // TODO: remove this, it was renamed

    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 89 7C 24")]
    public partial void CreateVector(uint size);

    [MemberFunction("48 8B 51 08 48 85 D2 74 0C")]
    public partial uint GetVectorSize();

    [MemberFunction("48 8B 49 08 48 85 C9 74 07 8B D2")]
    public partial void SetVectorSize(uint size);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? 40 FE C5")]
    public partial AtkValue* GetVectorValue(uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? EB 64")]
    public partial bool SetVectorValue(uint index, AtkValue* value);

    [MemberFunction("E8 ?? ?? ?? ?? 41 83 C6 02 FF C7")]
    [GenerateCStrOverloads]
    public partial bool SetVectorString(uint index, byte* value);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 44 24 48 83 E0 0F")]
    public partial bool CopyVectorValue(uint index, AtkValue* outValue);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 45 E0")]
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
}
