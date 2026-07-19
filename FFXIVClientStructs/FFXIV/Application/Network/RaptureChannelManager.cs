namespace FFXIVClientStructs.FFXIV.Application.Network;

// Application::Network::ZoneClient::RaptureChannelManager
// Application::Network::ChatClient::RaptureChannelManager
// The Zone and Chat protocol specializations have distinct virtual tables, but share this ABI layout.
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe partial struct RaptureChannelManager {
    [FieldOffset(0x08)] private uint Unk08;
    [FieldOffset(0x10)] public ServiceConsumerConnectionManager* ConnectionManager;
    [FieldOffset(0x18)] private StdVector<uint> PendingPacketIds;
    [FieldOffset(0x30)] private StdMap<uint, nint> PrimaryEntityMap;
    [FieldOffset(0x40)] private StdMap<uint, nint> UnkMap40;
    [FieldOffset(0x50)] private nint PrimaryEntity;
    [FieldOffset(0x58)] private bool Unk58;
    [FieldOffset(0x60)] private nint PrimaryEntityFactory;
    [FieldOffset(0x68)] private bool OwnsPrimaryEntityFactory;
    [FieldOffset(0x70)] private nint TargetEntityFactory;
    [FieldOffset(0x78)] private bool OwnsTargetEntityFactory;
    [FieldOffset(0x80)] private StdList<nint> Unk80;
    [FieldOffset(0x90)] private nint Unk90;
    [FieldOffset(0x98)] public NetBufferFactory UpBufferFactory;
    [FieldOffset(0xC8)] public NetBufferFactory DownBufferFactory;
    [FieldOffset(0xF8)] private NetBufferFactory* UpBufferFactoryOverride;
    [FieldOffset(0x100)] private NetBufferFactory* DownBufferFactoryOverride;
    [FieldOffset(0x108)] private int Unk108;
    [FieldOffset(0x110)] public int LifecycleState;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public partial struct NetBufferFactory {
        [FieldOffset(0x08)] private uint Unk08;
        [FieldOffset(0x10)] private StdMap<uint, nint> FreeBuffers;
        [FieldOffset(0x20)] private StdMap<uint, nint> InUseBuffers;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x270)]
    public partial struct ServiceConsumerConnectionManager;
}
