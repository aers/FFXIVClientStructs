using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Application.Network;

[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct ClientBase
{
    [FieldOffset(0x0)] public Utf8String Host;
    [FieldOffset(0x68)] public ushort Port;
    [FieldOffset(0x6C)] public TransportLayers TransportLayer;
    [FieldOffset(0x72)] private short Unk72; // value set to 333 in function E8 ?? ?? ?? ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 48 8D 8C 24 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? (7.41)
    /// <remarks>
    /// Contains the string bytes %u of LocalPlayer.EntityId
    /// </remarks>
    [FieldOffset(0x78)] public StdVector<byte> HostFullDetails;
    [FieldOffset(0x90)] public int KeepAliveZone;
    [FieldOffset(0x94)] public int KeepAliveInvervalZone;
}

public enum TransportLayers
{
    TCP = 0,
    // why does it seem like UDP should be in here
    RUDP = 2,
    RUDP2 = 3
}
