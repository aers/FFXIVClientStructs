using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xCA8)]
public unsafe partial struct HousingObjectManager {
    [FieldOffset(0x00)] public StdMap<ushort, HousingObjectData> DataMap;
    [FieldOffset(0x10)] public HousingObjectArray ObjectArray;
    [FieldOffset(0x18), FixedSizeArray, Obsolete("Use ObjectArray.Objects", true)] internal FixedSizeArray400<Pointer<GameObject>> _objects;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xC98)]
    public unsafe partial struct HousingObjectArray {
        [FieldOffset(0x00)] public GameObject* ObjectMemory; // 0x1D0 * ObjectCount
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray400<Pointer<GameObject>> _objects;
        [FieldOffset(0xC88)] public GameObject* TempObject;
        [FieldOffset(0xC90)] public ushort ObjectCount; // 200 for OutdoorTerritory, 400 for IndoorTerritory
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 8 * 0x06)]
    public partial struct HousingObjectData {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray8<HousingObjectDataValueSet> _valueSets;

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x06)]
        public partial struct HousingObjectDataValueSet {
            [FieldOffset(0x00)] public ushort Value1;
            [FieldOffset(0x02)] public byte Value2;
            [FieldOffset(0x03)] public byte Value3;
            [FieldOffset(0x04)] public byte Value4;
            [FieldOffset(0x05)] public byte Value5; // padding?
        }
    }
}
