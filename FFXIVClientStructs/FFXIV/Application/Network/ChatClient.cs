namespace FFXIVClientStructs.FFXIV.Application.Network;

// Application::Network::ChatClient
//   Application::Network::ClientBase
[GenerateInterop]
[Inherits<ClientBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct ChatClient {
    [FieldOffset(0x98)] private byte Unk98; // Initialized to 0 and copied into the channel's internal connection configuration; no consumer has been identified.
    [FieldOffset(0xA0)] public RaptureChannelManager* ChannelManager;
}
