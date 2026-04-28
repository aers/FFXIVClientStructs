namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::MapRangeLayoutInstance
//   Client::LayoutEngine::Layer::TriggerBoxLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public partial struct MapRangeLayoutInstance {
    [FieldOffset(0x80)] public uint Map;
    [FieldOffset(0x84)] public uint PlaceNameBlock;
    [FieldOffset(0x88)] public uint PlaceNameSpot;
    [FieldOffset(0x8C)] public uint BGM;
    [FieldOffset(0x90)] public uint Weather;
    [FieldOffset(0x94)] public byte DiscoveryId;
    [FieldOffset(0x95)] public byte HousingBlockId;
    [FieldOffset(0x96)] public MapRangeFlag1 MapRangeFlags1;
    [FieldOffset(0x97)] public MapRangeFlag2 MapRangeFlags2;
    [FieldOffset(0x98)] public MapRangeFlag3 MapRangeFlags3;
}

[Flags]
public enum MapRangeFlag1 : byte {
    None = 0,
    Unk0 = 1 << 0,
    Unk1 = 1 << 1,
    Unk2 = 1 << 2,
    Unk3 = 1 << 3,
    RestBonusEffective = 1 << 4,
    MapEnabled = 1 << 5,
    PlaceNameEnabled = 1 << 6,
    DiscoveryEnabled = 1 << 7,
}

[Flags]
public enum MapRangeFlag2 : byte {
    None = 0,
    BGMEnabled = 1 << 0,
    BGMPlayZoneInOnly = 1 << 1,
    WeatherEnabled = 1 << 2,
    RestBonusEnabled = 1 << 3,
    LiftEnabled = 1 << 4,
    HousingEnabled = 1 << 5,
    Unk7 = 1 << 6,
    Unk8 = 1 << 7,
}

[Flags]
public enum MapRangeFlag3 : byte {
    None = 0,
    Unk0 = 1 << 0,
    Unk1 = 1 << 1,
    Unk2 = 1 << 2,
    Unk3 = 1 << 3,
    Unk4 = 1 << 4,
    Unk5 = 1 << 5,
    Unk7 = 1 << 6,
    Unk8 = 1 << 7,
}
