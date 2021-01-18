using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.System.String
{
    // Client::System::String::Utf8String

    // size = 0x68
    // ctor E8 ? ? ? ? 44 2B F7 
    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public unsafe struct Utf8String
    {
        [FieldOffset(0x0)] public byte* StringPtr; // pointer to null-terminated string
        [FieldOffset(0x8)] public long BufSize; // default buffer = 0x40
        [FieldOffset(0x10)] public long BufUsed;
        [FieldOffset(0x18)] public long StringLength; // string length not including null terminator
        [FieldOffset(0x20)] public ushort Unk; // default: 0x101
        [FieldOffset(0x22)] public fixed byte InlineBuffer[0x40]; // inline buffer used until strlen > 0x40
    }
}
