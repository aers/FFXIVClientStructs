
namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine;

[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct LayoutManager {
    [FieldOffset(0x20)] public uint TerritoryTypeId;
    [FieldOffset(0x38)] public uint FestivalStatus; // SetActiveFestivals will not allow a change when not 5 or 0
    [FieldOffset(0x40)] public fixed uint ActiveFestivals[4];
    [FieldOffset(0x80), Obsolete("Use OutdoorAreaData")] public void* HousingController;
    [FieldOffset(0x80)] public OutdoorAreaLayoutData* OutdoorAreaData;
    [FieldOffset(0x90)] public IndoorAreaLayoutData* IndoorAreaData;

    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 48 83 C4 38 C3 33 C0")]
    public partial void SetInteriorFixture(int floor, int part, int fixtureId, byte unk = 255);

    [MemberFunction("E8 ?? ?? ?? ?? 8B C5 EB 6A")]
    public partial void SetActiveFestivals(uint* festivalArray); // Array of exactly 4 festivals. Use 0 for none.
}

[StructLayout(LayoutKind.Explicit, Size = 0x7080)]
public unsafe partial struct OutdoorAreaLayoutData {
    [FixedSizeArray<OutdoorPlotLayoutData>(60)]
    [FieldOffset(0x1F0)] public fixed byte Plot[60 * 0x1D0];

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 0E 41 80 F9 FF")]
    public partial void SetFixture(uint plot, uint part, uint fixtureId);

    [MemberFunction("40 55 48 83 EC 30 41 0F B6 E9")]
    public partial void SetFixtureStain(uint plot, uint part, byte stain);
}

[StructLayout(LayoutKind.Explicit, Size = 0x1D0)]
public unsafe partial struct OutdoorPlotLayoutData {
    [FixedSizeArray<OutdoorPlotFixtureData>(8)]
    [FieldOffset(0x28)] public fixed byte Fixture[8 * 0x28];

    [MemberFunction("E9 ?? ?? ?? ?? 48 89 5C 24 ?? 48 8D 0C AD")]
    public partial void SetFixture(uint part, uint fixture, uint a4 = 0xFFFFFFFF);

    [MemberFunction("E9 ?? ?? ?? ?? 48 89 5C 24 ?? 48 89 74 24 ?? 4A 8D 34 8D")]
    public partial void SetFixtureStain(uint part, byte stain);
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public struct OutdoorPlotFixtureData {
    [FieldOffset(0x00)] public ushort FixtureId;
    [FieldOffset(0x02)] public byte StainId;
}

[StructLayout(LayoutKind.Explicit, Size = 0x84)]
public unsafe struct IndoorAreaLayoutData {
    [FieldOffset(0x28)] public IndoorFloorLayoutData Floor0;
    [FieldOffset(0x3C)] public IndoorFloorLayoutData Floor1;
    [FieldOffset(0x50)] public IndoorFloorLayoutData Floor2;
    [FieldOffset(0x80)] public float LightLevel;
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public unsafe struct IndoorFloorLayoutData {
    [FieldOffset(0x00)] public int Part0;
    [FieldOffset(0x04)] public int Part1;
    [FieldOffset(0x08)] public int Part2;
    [FieldOffset(0x0C)] public int Part3;
    [FieldOffset(0x10)] public int Part4;
}
