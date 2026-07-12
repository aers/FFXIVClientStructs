using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::SqPackHeader
// https://github.com/NotAdam/Lumina/blob/12d0e8d418d8dc49f04e6bee1d06bae2905232c6/src/Lumina/Data/Structs/SqPackHeader.cs
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x400)]
public partial struct SqPackHeader {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray8<byte> _magic;
    [FieldOffset(0x08)] public PlatformId Platform;
    //[FieldOffset(0x09)] internal byte[] Unknown;
    [FieldOffset(0x0C)] public uint Size;
    [FieldOffset(0x10)] public uint Version;
    [FieldOffset(0x14)] public uint Type;

    public enum PlatformId : byte {
        Win32,
        PS3,
        PS4,
        PS5,
        Lys // Xbox
    }
}
