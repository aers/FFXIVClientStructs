using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Application.Network;

[GenerateInterop]
[Inherits<ClientBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct ZoneClient {

    [MemberFunction("48 83 EC ?? 48 8B 89 ?? ?? ?? ?? 48 85 C9 74 ?? 44 89 44 24 ?? 4C 8D 44 24 ?? 44 89 4C 24 ?? 44 0F B6 4C 24")]
    public partial bool SendPacket(nint packet, uint a3, uint a4, bool a5);
}
