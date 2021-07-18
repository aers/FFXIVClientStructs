using System;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.STD
{
    // std::string aka std::basic_string from msvc
    [StructLayout(LayoutKind.Explicit, Size=0x20)]
    public unsafe struct String
    {
        [FieldOffset(0x0)] public byte* Ptr;
        [FieldOffset(0x0)] public fixed byte Buf[16];
        [FieldOffset(0x10)] public ulong Length;
        [FieldOffset(0x18)] public ulong BufLength;
    }
}