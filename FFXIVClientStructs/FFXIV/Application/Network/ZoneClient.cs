namespace FFXIVClientStructs.FFXIV.Application.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct ZoneClient {
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 4C 89 64 24 ?? 55 41 56 41 57 48 8B EC 48 83 EC 70")]
    public partial bool SendPacket(nint packet, uint a3, uint a4, bool a5);
}
