using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Map
// ctor "E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 01 E8 ?? ?? ?? ?? 40 88 AB"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4000)]
public unsafe partial struct Map {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 41 8B D4 66 89 44 24", 3)]
    public static partial Map* Instance();

    [FieldOffset(0x98), FixedSizeArray] internal FixedSizeArray30<MarkerInfo> _questMarkers;

    [FieldOffset(0x1178), FixedSizeArray] internal FixedSizeArray16<MarkerInfo> _levequestMarkers;

    [FieldOffset(0x1AF0)] public StdVector<MapMarkerData> ActiveLevequestMarkers; // Markers for active levequest missions, they have to be actually started.
    [FieldOffset(0x1B18)] public StdList<MarkerInfo> UnacceptedQuestMarkers;
    [FieldOffset(0x1B60)] public StdList<MarkerInfo> GuildLeveAssignmentMarkers;
    [FieldOffset(0x1BA8)] public StdList<MarkerInfo> GuildOrderGuideMarkers;
    [FieldOffset(0x1BB8), FixedSizeArray] internal FixedSizeArray62<MarkerInfo> _housingMarkers;// 60 Plots + 2 Apartments
    [FieldOffset(0x3E98)] public StdList<MarkerInfo> TripleTriadMarkers;
    [FieldOffset(0x3EA8)] public StdList<MarkerInfo> CustomTalkMarkers;
    [FieldOffset(0x3F50)] public StdList<MarkerInfo> GemstoneTraderMarkers;
}

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct MarkerInfo {
    [FieldOffset(0x04)] public uint ObjectiveId;
    [FieldOffset(0x08)] public Utf8String Label;
    [FieldOffset(0x70)] public StdVector<MapMarkerData> MarkerData;
    [FieldOffset(0x88)] public ushort RecommendedLevel;

    [FieldOffset(0x8B)] public bool ShouldRender;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct MapMarkerData {
    [FieldOffset(0x00)] public uint LevelId;
    [FieldOffset(0x04)] public uint ObjectiveId;
    [FieldOffset(0x08)] public Utf8String* TooltipString;
    [FieldOffset(0x10)] public uint IconId;

    [FieldOffset(0x1C)] public float X;
    [FieldOffset(0x20)] public float Y;
    [FieldOffset(0x24)] public float Z;
    [FieldOffset(0x28)] public float Radius;

    [FieldOffset(0x30)] public uint MapId;
    [FieldOffset(0x34)] public uint PlaceNameZoneId;
    [FieldOffset(0x38)] public uint PlaceNameId;

    [FieldOffset(0x40)] public ushort RecommendedLevel;
    [FieldOffset(0x42)] public ushort TerritoryTypeId;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 53 ?? 8B 86")]
    public partial MapMarkerData* SetData(
        uint levelId,
        Utf8String* tooltipString,
        uint iconId,
        float x,
        float y,
        float z,
        float radius,
        ushort territoryTypeId,
        uint mapId,
        uint placeNameZoneId,
        uint placeNameId,
        ushort recommendedLevel,
        sbyte a14 = -1);
}
