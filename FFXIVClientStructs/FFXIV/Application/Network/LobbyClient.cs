using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFXIVClientStructs.FFXIV.Client.Network;

namespace FFXIVClientStructs.FFXIV.Application.Network;

public unsafe partial struct LobbyClient {

    [StructLayout(LayoutKind.Explicit)]
    public partial struct LobbyRequestCallback {
        [FieldOffset(0x00)] public void* vtbl;
        [FieldOffset(0x08)] public NetworkModuleProxy* NetworkModule;
        [FieldOffset(0x10)] public void* Unk10;

        [MemberFunction("40 55 56 57 48 83 EC 60 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 48 83 79 ?? 00")]
        public partial void RequestCharacterData(byte idx, long contentId);
    }

    [MemberFunction("40 53 56 41 57 48 83 EC ?? 33 DB")]
    public partial void GetCharacterEntryFromServer(byte idx, long p3);
}
