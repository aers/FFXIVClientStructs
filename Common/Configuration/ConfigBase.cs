using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Common.Configuration
{
    enum ConfigType
    {
        Unknown = 0,
        Category = 1,
        UInt = 2,
        Float = 3,
        String = 4
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public unsafe struct ConfigEntry
    {
        [FieldOffset(0x10)] public byte* Name; // null-terminated string
        [FieldOffset(0x18)] public int Type;
        [FieldOffset(0x28)] public ConfigBase* Owner;
        [FieldOffset(0x30)] public uint Index;
        [FieldOffset(0x34)] public uint _Padding; // pad to 0x38 to align pointers in array
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
    // ctor E8 ? ? ? ? 48 8D 05 ? ? ? ? C6 86 ? ? ? ? ? 4C 8D B6 ? ? ? ? 
    [StructLayout(LayoutKind.Explicit, Size = 0x110)]
    public unsafe struct ConfigBase
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x8)] public ChangeEventInterface* Listener;
        [FieldOffset(0x14)] public uint ConfigCount;
        [FieldOffset(0x18)] public ConfigEntry* ConfigEntry; // array
        [FieldOffset(0x50)] public FFXIVString UnkString;
    }
}
