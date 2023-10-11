using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct Map {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 41 8B D4 66 89 44 24", 3)]
    public static partial Map* Instance();

    [FixedSizeArray<MarkerInfo>(30)]
    [FieldOffset(0x98)] public fixed byte QuestData[0x90 * 30];

    [FixedSizeArray<MarkerInfo>(16)]
    [FieldOffset(0x1178)] public fixed byte LevequestData[0x90 * 16];

    [FieldOffset(0x1AF0)] public StdVector<MapMarkerData> ActiveLevequestMarkerData;
    [FieldOffset(0x1B18)] public MapMarkerContainer QuestMarkerData;
    [FieldOffset(0x1B60)] public MapMarkerContainer GuildLeveAssignmentMapMarkerData;
    [FieldOffset(0x1BA8)] public MapMarkerContainer GuildOrderGuideMarkerData;
    [FieldOffset(0x3E98)] public MapMarkerContainer TripleTriadMarkerData;
    [FieldOffset(0x3EA8)] public MapMarkerContainer CustomTalkMarkerData;
    [FieldOffset(0x3F50)] public MapMarkerContainer GemstoneTraderMarkerData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct MarkerInfo {
    [FieldOffset(0x04)] public uint ObjectiveId;
    [FieldOffset(0x08)] public Utf8String Label;
    [FieldOffset(0x70)] public StdVector<MapMarkerData> MarkerData;
    [FieldOffset(0x8B)] public bool ShouldRender;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct MapMarkerData {
    [FieldOffset(0x00)] public uint LevelId;
    [FieldOffset(0x04)] public uint ObjectiveId;
    [FieldOffset(0x08)] public Utf8String* TooltipString;
    [FieldOffset(0x10)] public uint IconId;
    [FieldOffset(0x18)] public float X;
    [FieldOffset(0x1C)] public float Y;
    [FieldOffset(0x20)] public float Z;
    [FieldOffset(0x24)] public float Radius;
    [FieldOffset(0x3C)] public ushort RecommendedLevel;
}

/// <summary>
/// This container uses a linked list internally to contain Map Markers that contain tooltip information.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct MapMarkerContainer {
    public LinkedList* List;
    public int Size;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct LinkedList {
        public MapMarkerNode* First;
        public MapMarkerNode* Last;
    }

    public IEnumerable<MarkerInfo> GetAllMarkers() {
        var result = new List<MarkerInfo>();
        var current = List->First;

        foreach (var _ in Enumerable.Range(0, Size)) {
            result.Add(current->Data);
            current = current->Next;
        }

        return result;
    }
}

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct MapMarkerNode {
    public MapMarkerNode* Next;
    public MapMarkerNode* Previous;

    public MarkerInfo Data;
}
