using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Common.Configuration;

public enum ConfigType
{
    Unused = 0,
    Category = 1,
    UInt = 2,
    Float = 3,
    String = 4
}

// union type for uint/float/string
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct ConfigProperties
{
    [FieldOffset(0x0)] public UIntProperties UInt;
    [FieldOffset(0x0)] public FloatProperties Float;
    [FieldOffset(0x0)] public StringProperties String;

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct UIntProperties
    {
        [FieldOffset(0x0)] public uint DefaultValue;
        [FieldOffset(0x4)] public uint MinValue;
        [FieldOffset(0x8)] public uint MaxValue;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct FloatProperties
    {
        [FieldOffset(0x0)] public float DefaultValue;
        [FieldOffset(0x4)] public float MinValue;
        [FieldOffset(0x8)] public float MaxValue;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct StringProperties
    {
        [FieldOffset(0x0)] public Utf8String* DefaultValue;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct ConfigValue
{
    [FieldOffset(0x0)] public uint UInt;
    [FieldOffset(0x0)] public float Float;
    [FieldOffset(0x0)] public Utf8String* String;
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct ConfigEntry
{
    [FieldOffset(0x0)] public ConfigProperties Properties;
    [FieldOffset(0x10)] public byte* Name; // null-terminated string
    [FieldOffset(0x18)] public int Type;
    [FieldOffset(0x20)] public ConfigValue Value;
    [FieldOffset(0x28)] public ConfigBase* Owner;
    [FieldOffset(0x30)] public uint Index;
    [FieldOffset(0x34)] public uint _Padding; // pad to 0x38 to align pointers in array
    
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 5E 73")]
    public partial bool SetValueUInt(uint value, uint unk = 1);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 33 DB 38 9F")]
    public partial bool SetValueFloat(float value);
    
    // This will destroy the Utf8String
    [MemberFunction("E8 ?? ?? ?? ?? EB 46 F3 0F 10 0B")]
    public partial bool SetValueString(Utf8String* value);

    public bool SetValueString(string value) {
        var utf8Str = Utf8String.FromString(value);
        return SetValueString(utf8Str);
    }
    
    public bool SetValue(uint value, uint unk = 1) => SetValueUInt(value, unk);
    public bool SetValue(float value) => SetValueFloat(value);
    public bool SetValue(string value) => SetValueString(value);
}

// implemented by objects that want to listen for config changes - rapture atk module, etc
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct ChangeEventInterface
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x8)] public ChangeEventInterface* Next;
    [FieldOffset(0x10)] public ConfigBase* Owner;
}

// Common::Configuration::ConfigBase
//  Client::System::Common::NonCopyable

// size = 0x110
// ctor E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? C6 86 ?? ?? ?? ?? ?? 4C 8D B6 ?? ?? ?? ?? 
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe struct ConfigBase
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x8)] public ChangeEventInterface* Listener;
    [FieldOffset(0x14)] public uint ConfigCount;
    [FieldOffset(0x18)] public ConfigEntry* ConfigEntry; // array
    [FieldOffset(0x50)] public Utf8String UnkString;
}