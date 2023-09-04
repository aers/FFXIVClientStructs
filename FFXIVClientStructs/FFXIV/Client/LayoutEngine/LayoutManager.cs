
namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine;

[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct LayoutManager {
    [FieldOffset(0x20)] public uint TerritoryTypeId;
    [FieldOffset(0x38)] public uint FestivalStatus; // SetActiveFestivals will not allow a change when not 5 or 0
    [FieldOffset(0x40)] public fixed uint ActiveFestivals[4];
    [FieldOffset(0x80)] public void* HousingController;
    [FieldOffset(0x90)] public IndoorAreaLayoutData* IndoorAreaData;


    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 48 83 C4 38 C3 33 C0")]
    public partial void SetInteriorFixture(int floor, int part, int fixtureId, byte unk = 255);

    [MemberFunction("E8 ?? ?? ?? ?? 8B C5 EB 6A")]
    public partial void SetActiveFestivals(uint* festivalArray); // Array of exactly 4 festivals. Use 0 for none.
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IndoorAreaLayoutData {
    [FieldOffset(0x28)] public IndoorFloorLayoutData Floor0;
    [FieldOffset(0x3C)] public IndoorFloorLayoutData Floor1;
    [FieldOffset(0x50)] public IndoorFloorLayoutData Floor2;
    [FieldOffset(0x80)] public float LightLevel;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IndoorFloorLayoutData {
    [FieldOffset(0x00)] public int Part0;
    [FieldOffset(0x04)] public int Part1;
    [FieldOffset(0x08)] public int Part2;
    [FieldOffset(0x0C)] public int Part3;
    [FieldOffset(0x10)] public int Part4;
}
