using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.System.File;

//https://github.com/NotAdam/Lumina/blob/12d0e8d418d8dc49f04e6bee1d06bae2905232c6/src/Lumina/Data/Structs/SqPackIndexHeader.cs
[StructLayout(LayoutKind.Explicit, Size = 0x400)]
public unsafe struct SqPackIndexHeader {
    [FieldOffset(0x000)] public uint Size;
    [FieldOffset(0x004)] public uint Version;
    [FieldOffset(0x008)] public uint IndexDataOffset;
    [FieldOffset(0x00C)] public uint IndexDataSize;
    [FieldOffset(0x010)] public fixed byte IndexDataHash[64];
    [FieldOffset(0x050)] public uint NumberOfDataFile;
    [FieldOffset(0x054)] public uint SynonymDataOffset;
    [FieldOffset(0x058)] public uint SynonymDataSize;
    [FieldOffset(0x05C)] public fixed byte SynonymDataHash[64];
    [FieldOffset(0x09C)] public uint EmptyBlockDataOffset;
    [FieldOffset(0x0A0)] public uint EmptyBlockDataSize;
    [FieldOffset(0x0A4)] public fixed byte EmptyBlockDataHash[64];
    [FieldOffset(0x0E4)] public uint DirIndexDataOffset;
    [FieldOffset(0x0E8)] public uint DirIndexDataSize;
    [FieldOffset(0x0EC)] public fixed byte DirIndexDataHash[64];
    [FieldOffset(0x12C)] public uint IndexType;
    [FieldOffset(0x130)] internal fixed byte Reserved[656];
    [FieldOffset(0x3C0)] public fixed byte SelfHash[64];
}
