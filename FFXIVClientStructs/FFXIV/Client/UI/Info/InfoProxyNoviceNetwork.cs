namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct InfoProxyNoviceNetwork {
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 45 33 C9")]
    public partial byte InviteToNoviceNetwork(ulong contentId, ushort worldId, byte* name);
}
