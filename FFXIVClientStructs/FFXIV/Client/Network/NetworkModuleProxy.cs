namespace FFXIVClientStructs.FFXIV.Client.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct NetworkModuleProxy {
    [FieldOffset(0x00)] public void* Vtbl;
    [FieldOffset(0x08)] public NetworkModule* NetworkModule;
    [FieldOffset(0x10), Obsolete("Wrongly defined overflows struct size")] public NetworkModulePacketReceiverCallback PacketReceiverCallback;

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 49 8B 85")]
    public partial bool IsInCrossWorldDuty();

    [Obsolete("Renamed to IsInCrossWorldDuty")]
    public bool IsInCrossWorlDuty() => IsInCrossWorldDuty();

    /// <summary>
    /// Gets current instance<br/>
    /// Does NOT invoke network request
    /// </summary>
    /// <returns>Current instance or 0 for non instanced zones</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 0F B7 F0 E8 ?? ?? ?? ?? 8B D8")]
    public partial short GetCurrentInstance();
}
