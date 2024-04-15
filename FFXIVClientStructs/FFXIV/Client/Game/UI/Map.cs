using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Map
// ctor "E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 01 E8 ?? ?? ?? ?? 40 88 AB"
[StructLayout(LayoutKind.Explicit, Size = 0x4000)]
public unsafe partial struct Map {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 41 8B D4 66 89 44 24", 3)]
    public static partial Map* Instance();

    [FixedSizeArray<MarkerInfo>(30)]
    [FieldOffset(0x98)] public fixed byte QuestData[0x90 * 30];

    [FixedSizeArray<MarkerInfo>(16)]
    [FieldOffset(0x1178)] public fixed byte LevequestData[0x90 * 16];

    [FieldOffset(0x1AF0)] public StdVector<MapMarkerData> ActiveLevequest; // Markers for active levequest missions, they have to be actually started.
    [FieldOffset(0x1B18)] public StdList<MarkerInfo> UnacceptedQuests;
    [FieldOffset(0x1B60)] public StdList<MarkerInfo> GuildLeveAssignments;
    [FieldOffset(0x1BA8)] public StdList<MarkerInfo> GuildOrderGuides;
    [FixedSizeArray<MarkerInfo>(62)]
    [FieldOffset(0x1BB8)] public fixed byte HousingData[0x90 * 62]; // 60 Plots + 2 Apartments
    [FieldOffset(0x3E98)] public StdList<MarkerInfo> TripleTriad;
    [FieldOffset(0x3EA8)] public StdList<MarkerInfo> CustomTalk;
    [FieldOffset(0x3F50)] public StdList<MarkerInfo> GemstoneTraders;

    [FieldOffset(0x1AF0), Obsolete("Use ActiveLevequest")] public StdVector<MapMarkerData> ActiveLevequestMarkerData;
    [FieldOffset(0x1B18), Obsolete("Use List<T> UnacceptedQuests")] public MapMarkerContainer QuestMarkerData;
    [FieldOffset(0x1B60), Obsolete("Use List<T> GuildLeveAssignments")] public MapMarkerContainer GuildLeveAssignmentMapMarkerData;
    [FieldOffset(0x1BA8), Obsolete("Use List<T> GuildOrderGuides")] public MapMarkerContainer GuildOrderGuideMarkerData;
    [FieldOffset(0x3E98), Obsolete("Use List<T> TripleTriad")] public MapMarkerContainer TripleTriadMarkerData;
    [FieldOffset(0x3EA8), Obsolete("Use List<T> CustomTalk")] public MapMarkerContainer CustomTalkMarkerData;
    [FieldOffset(0x3F50), Obsolete("Use List<T> GemstoneTraders")] public MapMarkerContainer GemstoneTraderMarkerData;
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

    [FieldOffset(0x2C)] public uint MapId;
    [FieldOffset(0x30)] public uint PlaceNameZoneId;
    [FieldOffset(0x34)] public uint PlaceNameId;

    [FieldOffset(0x3C)] public ushort RecommendedLevel;
    [FieldOffset(0x3E)] public ushort TerritoryTypeId;

    [MemberFunction("E8 ?? ?? ?? ?? 80 7B 42 02 75 06")]
    public partial MapMarkerData* SetData(
        uint levelId,
        Utf8String* tooltipString,
        uint iconId,
        float x,
        float y,
        float z,
        uint radius,
        ushort territoryTypeId,
        uint mapId,
        uint placeNameZoneId,
        uint placeNameId,
        ushort recommendedLevel,
        sbyte a14 = -1);
}

/// <summary>
/// This container uses a linked list internally to contain Map Markers that contain tooltip information.
/// </summary>
[Obsolete("Use StdList<T> instead.")]
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct MapMarkerContainer {
    public LinkedList* List;
    public int Size;

    [Obsolete("Use StdList<T> instead.")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct LinkedList {
        public MapMarkerNode* First;
        public MapMarkerNode* Last;
    }

    [Obsolete("Use StdList<T> instead.")]
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

[Obsolete("Use StdList<T> instead.")]
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct MapMarkerNode {
    public MapMarkerNode* Next;
    public MapMarkerNode* Previous;

    public MarkerInfo Data;
}
