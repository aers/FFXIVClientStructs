using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVClientStructs.FFXIV.Client.System.Timer;

[StructLayout(LayoutKind.Explicit)]
public struct ClientTime {
    [FieldOffset(0x8)] public uint Time; //Timestamp
    [FieldOffset(0xC)] public uint UnkC;
}
