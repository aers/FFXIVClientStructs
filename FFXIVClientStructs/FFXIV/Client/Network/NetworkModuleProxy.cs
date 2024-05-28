namespace FFXIVClientStructs.FFXIV.Client.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
[GenerateInterop]
public unsafe partial struct NetworkModuleProxy {
    [FieldOffset(0x08)] public NetworkModule* NetworkModule;

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 49 8B 85")]
    public partial bool IsInCrossWorldDuty();

    /// <summary>
    /// Gets current instance<br/>
    /// Does NOT invoke network request
    /// </summary>
    /// <returns>Current instance or 0 for non instanced zones</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 0F B7 F0 E8 ?? ?? ?? ?? 8B D8")]
    public partial short GetCurrentInstance();
}
