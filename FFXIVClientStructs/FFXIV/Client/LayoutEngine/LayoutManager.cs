using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine;

// Client::LayoutEngine::LayoutManager
//   Client::LayoutEngine::IManagerBase
//     Client::System::Common::NonCopyable
/// <summary>
/// An instance of a loaded level.
/// Ultimately describes a set of 'instances' (pieces of static geometry, lights, vfx, etc), organized in layers.
/// </summary>
[GenerateInterop]
[Inherits<IManagerBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xC30)]
public unsafe partial struct LayoutManager {
    [FieldOffset(0x018)] public int InitState; // 7 is fully loaded and ready, <7 are various stages of init
    [FieldOffset(0x01C)] public int Type; // 2 for normal levels, 3 ???
    [FieldOffset(0x020)] public uint TerritoryTypeId; // TerritoryType row id
    [FieldOffset(0x024)] public uint CfcId; // ContentFinderCondition row id
    [FieldOffset(0x028)] public uint LayerFilterKey; // used for finding correct layer filter if TerritoryTypeId == 0
    [FieldOffset(0x038)] public uint FestivalStatus; // SetActiveFestivals will not allow a change when not 5 or 0
    [FieldOffset(0x03D)] public bool InsideFestivalTransitionLayerUpdate; // when festival changes, layers are added/removed over 1s
    [FieldOffset(0x040), FixedSizeArray] internal FixedSizeArray8<GameMain.Festival> _activeFestivals;
    [FieldOffset(0x060), FixedSizeArray] internal FixedSizeArray8<GameMain.Festival> _newFestivals; // festival (de)activation is not immedate
    [FieldOffset(0x080)] public float FestivalLayersAddTimer; // dt * 30
    [FieldOffset(0x084)] public float FestivalLayersRemoveTimer; // dt * 30
    [FieldOffset(0x088)] public void* StreamingManager;
    [FieldOffset(0x090)] public void* Environment;
    [FieldOffset(0x098)] public void* OBSetManager;
    [FieldOffset(0x0A0)] public OutdoorAreaLayoutData* OutdoorAreaData;
    [FieldOffset(0x0A8)] public OutdoorExteriorLayoutData* OutdoorExteriorData;
    [FieldOffset(0x0B0)] public IndoorAreaLayoutData* IndoorAreaData;
    [FieldOffset(0x0E8)] public void* PVPData;
    [FieldOffset(0x0FC)] public int ForceUpdateAllStreaming;
    [FieldOffset(0x102)] public bool SkipAddingTerrainCollider;
    //[FieldOffset(0x103)] public bool uE3;
    [FieldOffset(0x104)] public bool HousingLayoutDataUpdatePending;
    [FieldOffset(0x105)] public bool OutdoorAreaDataUpdated;
    [FieldOffset(0x10A)] public byte LayerEntryType;
    [FieldOffset(0x10C)] public uint LevelId;
    [FieldOffset(0x110)] public int StreamingOriginType;
    [FieldOffset(0x120)] public Vector3 ForcedStreamingOrigin;
    //[FieldOffset(0x130)] public Vector3 u110_streamingType5Origin;
    [FieldOffset(0x140)] public Vector3 LastUpdatedStreamingOrigin;
    [FieldOffset(0x190)] public int HousingType;
    [FieldOffset(0x1A4)] public float LastUpdateDT; // set to dt on update
    [FieldOffset(0x1A8)] public int LastUpdateOdd; // flips between 0 and 1 on update, presumably for some double buffering somewhere
    [FieldOffset(0x1C0)] public StringTable ResourcePaths;
    [FieldOffset(0x1E0)] public ResourceHandle* LvbResourceHandle;
    [FieldOffset(0x1E8)] public StdVector<Pointer<ResourceHandle>> LayerGroupResourceHandles;
    [FieldOffset(0x218)] public StdMap<uint, Pointer<Terrain.TerrainManager>> Terrains;
    [FieldOffset(0x228)] public StdMap<ushort, Pointer<Layer.LayerManager>> Layers;
    [FieldOffset(0x238)] public StdVector<Pointer<Layer.LayerManager>> FestivalLayersToRemove;
    [FieldOffset(0x250)] public StdVector<Pointer<Layer.LayerManager>> FestivalLayersToAdd;
    [FieldOffset(0x268)] public StdMap<InstanceType, Pointer<StdMap<ulong, Pointer<ILayoutInstance>>>> InstancesByType; // key in nested map is InstanceId << 32 | SubId
    [FieldOffset(0x278)] public StdMap<uint, Pointer<RefCountedString>> CrcToPath;
    [FieldOffset(0x288)] public StdMap<AnalyticShapeDataKey, AnalyticShapeData> CrcToAnalyticShapeData; // Value is aligned to 16 bytes, so key has tons of padding
    [FieldOffset(0x298)] public StdMap<uint, Pointer<Filter>> Filters;
    // 0x2C0: some map
    // 0x2D0: vector<LayoutU3*> streamingoriginupdatelisteners
    [FieldOffset(0x308)] public ResourceHandle* SvbResourceHandle;
    [FieldOffset(0x310)] public ResourceHandle* LcbResourceHandle;
    [FieldOffset(0x318)] public ResourceHandle* UwbResourceHandle;
    // 0x320: instance pools
    // 0xB90: gfx bg object pool ptr

    // 7.0: inlined in E8 ?? ?? ?? ?? 41 8B 4E 20
    // [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 4C 8B 91 ?? ?? ?? ?? 41 8B F9")]
    // public partial void SetInteriorFixture(int floor, int part, int fixtureId, byte unk = 255);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 4C 8B 91 ?? ?? ?? ?? 49 8B F9")]
    public partial void SetOutdoorPlotExterior(int plotIndex, OutdoorPlotExteriorData* data, delegate* unmanaged<uint, void> loadedCallback = null);

    [MemberFunction("40 53 45 33 D2 4C 8D 41 40")]
    public partial void SetActiveFestivals(GameMain.Festival* festivals); // Array of exactly 8 festivals. Use 0 for none.

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public unsafe struct Filter {
        [FieldOffset(0)] public uint Key;
        [FieldOffset(4)] public uint TerritoryTypeId;
        [FieldOffset(8)] public uint CfcId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x14)]
    public unsafe struct AnalyticShapeDataKey {
        //[FieldOffset(0)] private uint _alignment; // Hack to get StdMap to be alligned correctly with padding
        [FieldOffset(4)] public uint Key;

        public int CompareTo(AnalyticShapeDataKey other) => Key.CompareTo(other.Key);
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x7080)]
public unsafe partial struct OutdoorAreaLayoutData {
    [FieldOffset(0x1F0), FixedSizeArray] internal FixedSizeArray60<OutdoorPlotLayoutData> _plots;

    [MemberFunction("40 55 41 56 48 83 EC 38 49 63 E8")]
    public partial void SetFixture(uint plot, uint part, uint fixtureId);

    [MemberFunction("40 55 48 83 EC 20 41 0F B6 E9")]
    public partial void SetFixtureStain(uint plot, uint part, byte stain);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1D0)]
public unsafe partial struct OutdoorPlotLayoutData {
    [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray8<OutdoorPlotFixtureData> _fixture;
    /// <remarks>
    /// Position of the entrance vfx object
    /// </remarks>
    [FieldOffset(0x190)] public Vector3 EntrancePosition;

    [MemberFunction("E9 ?? ?? ?? ?? 48 89 5C 24 ?? 48 8D 0C AD")]
    public partial void SetFixture(uint part, uint fixture, uint a4 = 0xFFFFFFFF);

    [MemberFunction("E8 ?? ?? ?? ?? EB 27 48 81 C3 ?? ?? ?? ??")]
    public partial void SetFixtureStain(uint part, byte stain);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x970)] // 60 * 0x28 + 0x08 + 0x04 (+0x04 alignment)
public unsafe partial struct OutdoorExteriorLayoutData {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray60<OutdoorPlotExteriorData> _plots;
    [FieldOffset(0x960)] public delegate* unmanaged<uint, void> LoadedCallback; // LoadedCallback((uint)(LoadedCallbackPlotIndex + 1));
    [FieldOffset(0x968)] public uint LoadedCallbackPlotIndex;
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

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct OutdoorPlotExteriorData {
    [FieldOffset(0x00)] public PlotSize Size;
    /// <remarks>
    /// Stain RowIds<br/>
    /// <br/>
    /// 0 = Roof<br/>
    /// 1 = Walls<br/>
    /// 2 = Windows<br/>
    /// 3 = Door<br/>
    /// 4 = OptionalRoof<br/>
    /// 5 = OptionalWall<br/>
    /// 6 = OptionalSignboard<br/>
    /// 7 = Fence
    /// </remarks>
    [FieldOffset(0x01), FixedSizeArray] internal FixedSizeArray8<sbyte> _stainIds;

    /// <remarks>
    /// HousingExterior RowIds<br/>
    /// <br/>
    /// 0 = Roof<br/>
    /// 1 = Walls<br/>
    /// 2 = Windows<br/>
    /// 3 = Door<br/>
    /// 4 = OptionalRoof<br/>
    /// 5 = OptionalWall<br/>
    /// 6 = OptionalSignboard<br/>
    /// 7 = Fence
    /// </remarks>
    [FieldOffset(0x0A), FixedSizeArray] internal FixedSizeArray8<short> _housingExteriorIds;
}
