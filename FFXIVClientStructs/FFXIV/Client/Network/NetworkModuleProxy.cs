using FFXIVClientStructs.FFXIV.Application.Network;

namespace FFXIVClientStructs.FFXIV.Client.Network;

// Client::Network::NetworkModuleProxy
//   Client::System::Common::NonCopyable
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct NetworkModuleProxy {
    [FieldOffset(0x08)] public NetworkModule* NetworkModule;
    [FieldOffset(0x10)] public NetworkModulePacketReceiverCallback* ReceiverCallback;

    [MemberFunction("E8 ?? ?? ?? ?? EB 0D 49 8B 87 ?? ?? ?? ??")]
    public partial bool IsInCrossWorldDuty();

    /// <summary>
    /// Gets current instance<br/>
    /// Does NOT invoke network request
    /// </summary>
    /// <returns>Current instance or 0 for non instanced zones</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 C0 33 D2 C1 E0")]
    public partial short GetCurrentInstance();
}
