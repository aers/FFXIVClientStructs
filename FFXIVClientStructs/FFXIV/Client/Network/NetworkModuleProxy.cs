using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFXIVClientStructs.FFXIV.Common.Configuration;

namespace FFXIVClientStructs.FFXIV.Client.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct NetworkModuleProxy {
    [FieldOffset(0x00)] public void* Vtbl;
    [FieldOffset(0x08)] public NetworkModule* NetworkModule;
    [FieldOffset(0x10)] public NetworkModulePacketReceiverCallback PacketReceiverCallback;

    //[MemberFunction("")] Not siggable
    //public partial void* FUN_140213c40(int[] p2, uint p3, uint p4);
    //Calls NetworkModule.FUN_14157f880(p2,p3,p4);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 9C 24 ?? ?? ?? ?? 0F B6 C8")]
    public partial void RequestCharacterData(byte idx, long contentId, long p4, long p5);
}
