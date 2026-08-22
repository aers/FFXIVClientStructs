namespace FFXIVClientStructs.FFXIV.Application.Network;

// Application::Network::ClientBase
[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public partial struct ClientBase {
    [FieldOffset(0x0)] public Utf8String Host;
    [FieldOffset(0x68)] public ushort Port;
    [FieldOffset(0x6C)] public TransportLayers TransportLayer;
    [FieldOffset(0x70)] public ushort ReconnectDelayMs; // Milliseconds to wait before the next connection attempt.
    [FieldOffset(0x72)] public ushort IdleSendIntervalMs; // Milliseconds of idle time before issuing a send.
    /// <remarks>
    /// Stores the connection ticket. When the login callback supplies a nonzero entity ID, it replaces the ticket with its <c>%u</c>-formatted value.
    /// </remarks>
    [FieldOffset(0x78)] public StdVector<byte> Ticket;
    [FieldOffset(0x78), Obsolete("Renamed to Ticket")] public StdVector<byte> HostFullDetails;
    [FieldOffset(0x90)] public int KeepAlive;
    [FieldOffset(0x90), Obsolete("Renamed to KeepAlive")] public int KeepAliveZone;
    [FieldOffset(0x94)] public int KeepAliveInterval;
    [FieldOffset(0x94), Obsolete("Renamed to KeepAliveInterval")] public int KeepAliveInvervalZone;
}

public enum TransportLayers {
    TCP = 0,
    RUDP = 2,
    RUDP2 = 3
}
