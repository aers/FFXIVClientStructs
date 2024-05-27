namespace FFXIVClientStructs.FFXIV.Client.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct PacketDispatcher {
    [Obsolete("Invalid signature. This resolves to a member function of FateManager and is scheduled for removal.")]
    [MemberFunction("48 89 5C 24 ?? 56 48 83 EC 20 4C 8B 09")]
    public partial void ReceiveEvent(uint p2, void* p3);

    [MemberFunction("48 89 5C 24 ?? 56 48 83 EC ?? 48 8B 0D ?? ?? ?? ?? 48 8B F2")]
    public partial void HandleSocialPacket(long p2);
}
