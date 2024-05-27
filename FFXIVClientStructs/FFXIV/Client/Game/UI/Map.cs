using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Map
// ctor "E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 01 E8 ?? ?? ?? ?? 40 88 AB"
[StructLayout(LayoutKind.Explicit, Size = 0x4000)]
[GenerateInterop]
public unsafe partial struct Map {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 41 8B D4 66 89 44 24", 3)]
    public static partial Map* Instance();

    [FieldOffset(0x98)] [FixedSizeArray] internal FixedSizeArray30<MarkerInfo> _questData;

    [FieldOffset(0x1178)] [FixedSizeArray] internal FixedSizeArray16<MarkerInfo> _levequestData;

    [FieldOffset(0x1AF0)] public StdVector<MapMarkerData> ActiveLevequest; // Markers for active levequest missions, they have to be actually started.
    [FieldOffset(0x1B18)] public StdList<MarkerInfo> UnacceptedQuests;
    [FieldOffset(0x1B60)] public StdList<MarkerInfo> GuildLeveAssignments;
    [FieldOffset(0x1BA8)] public StdList<MarkerInfo> GuildOrderGuides;
    [FieldOffset(0x1BB8)] [FixedSizeArray] internal FixedSizeArray62<MarkerInfo> _housingData;// 60 Plots + 2 Apartments
    [FieldOffset(0x3E98)] public StdList<MarkerInfo> TripleTriad;
    [FieldOffset(0x3EA8)] public StdList<MarkerInfo> CustomTalk;
    [FieldOffset(0x3F50)] public StdList<MarkerInfo> GemstoneTraders;
}

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct MarkerInfo {
    [FieldOffset(0x04)] public uint ObjectiveId;
    [FieldOffset(0x08)] public Utf8String Label;
    [FieldOffset(0x70)] public StdVector<MapMarkerData> MarkerData;
    [FieldOffset(0x8B)] public bool ShouldRender;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
[GenerateInterop]
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
