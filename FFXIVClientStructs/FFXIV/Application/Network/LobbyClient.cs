using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFXIVClientStructs.FFXIV.Client.Network;

namespace FFXIVClientStructs.FFXIV.Application.Network;

public unsafe struct LobbyClient {

    [StructLayout(LayoutKind.Explicit)]
    public struct LobbyRequestCallback {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x8)] public NetworkModule* NetworkModule;

    }
}
