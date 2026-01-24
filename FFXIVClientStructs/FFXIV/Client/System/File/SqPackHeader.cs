using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.System.File;
// https://github.com/NotAdam/Lumina/blob/12d0e8d418d8dc49f04e6bee1d06bae2905232c6/src/Lumina/Data/Structs/SqPackHeader.cs
public enum PlatformId : byte {
    Win32,
    PS3,
    PS4,
    PS5,
    Lys // Xbox
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x400)]
public partial struct SqPackHeader {
    [FieldOffset(0x000)] internal FixedSizeArray8<byte> Magic;
    [FieldOffset(0x008)] public PlatformId PlatformId;
    //[FieldOffset(0x009)] internal byte[] Unknown;
    [FieldOffset(0x00C)] public uint Size;
    [FieldOffset(0x010)] public uint Version;
    [FieldOffset(0x014)] public uint Type;
}
