using FFXIVClientStructs.FFXIV.Application.Network;

namespace FFXIVClientStructs.FFXIV.Client.Network;

[GenerateInterop]
[Inherits<PacketReceiverCallbackInterface>, Inherits<PacketDispatcher>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public partial struct NetworkModulePacketReceiverCallback;
