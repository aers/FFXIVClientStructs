using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::SqPackIndexHeader
//https://github.com/NotAdam/Lumina/blob/12d0e8d418d8dc49f04e6bee1d06bae2905232c6/src/Lumina/Data/Structs/SqPackIndexHeader.cs
[StructLayout(LayoutKind.Explicit, Size = 0x400)]
public unsafe struct SqPackIndexHeader {
    [FieldOffset(0x00)] public uint Size;
    [FieldOffset(0x04)] public uint Version;
    [FieldOffset(0x08)] public uint IndexDataOffset;
    [FieldOffset(0x0C)] public uint IndexDataSize;
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray64<byte> _indexDataHash;
    [FieldOffset(0x50)] public uint NumberOfDataFile;
    [FieldOffset(0x54)] public uint SynonymDataOffset;
    [FieldOffset(0x58)] public uint SynonymDataSize;
    [FieldOffset(0x5C), FixedSizeArray] internal FixedSizeArray64<byte> _synonymDataHash;
    [FieldOffset(0x9C)] public uint EmptyBlockDataOffset;
    [FieldOffset(0xA0)] public uint EmptyBlockDataSize;
    [FieldOffset(0xA4), FixedSizeArray] internal FixedSizeArray64<byte> _emptyBlockDataHash;
    [FieldOffset(0xE4)] public uint DirIndexDataOffset;
    [FieldOffset(0xE8)] public uint DirIndexDataSize;
    [FieldOffset(0xEC), FixedSizeArray] internal FixedSizeArray64<byte> _dirIndexDataHash;
    [FieldOffset(0x12C)] public uint IndexType;
    [FieldOffset(0x130)] private fixed byte Reserved[656];
    [FieldOffset(0x3C0), FixedSizeArray] internal FixedSizeArray64<byte> _selfHash;
}
