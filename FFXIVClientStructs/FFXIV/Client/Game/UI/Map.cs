using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Map
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4000)]
public unsafe partial struct Map {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 41 8B D4 66 89 44 24", 3)]
    public static partial Map* Instance();

    [FieldOffset(0xA8), FixedSizeArray] internal FixedSizeArray30<MarkerInfo> _questMarkers;
    [FieldOffset(0x1188), FixedSizeArray] internal FixedSizeArray16<MarkerInfo> _levequestMarkers;

    [FieldOffset(0x1A90)] public MarkerInfo ActiveLevequestMarker; // Marker for active levequest mission, it has to be actually started.

    [FieldOffset(0x1B28)] public StdList<MarkerInfo> UnacceptedQuestMarkers;

    [FieldOffset(0x1B70)] public StdList<MarkerInfo> GuildLeveAssignmentMarkers;

    [FieldOffset(0x1BB8)] public StdList<MarkerInfo> GuildOrderGuideMarkers;
    [FieldOffset(0x1BC8), FixedSizeArray] internal FixedSizeArray62<MarkerInfo> _housingMarkers;// 60 Plots + 2 Apartments
    [FieldOffset(0x3EA8)] public StdList<MarkerInfo> TripleTriadMarkers;
    [FieldOffset(0x3EB8)] public StdList<MarkerInfo> CustomTalkMarkers;

    [FieldOffset(0x3F60)] public StdList<MarkerInfo> GemstoneTraderMarkers;

    [MemberFunction("83 FA 3E 0F 83")]
    public partial void AddHousingMarker(uint index, uint levelId, Vector3* pos, ushort territoryTypeId, int iconId);
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

    [FieldOffset(0x1C)] public global::System.Numerics.Vector3 Position;
    [FieldOffset(0x1C), Obsolete("Use Position.X")] public float X;
    [FieldOffset(0x20), Obsolete("Use Position.Y")] public float Y;
    [FieldOffset(0x24), Obsolete("Use Position.Z")] public float Z;
    [FieldOffset(0x28)] public float Radius;

    [FieldOffset(0x30)] public uint MapId;
    [FieldOffset(0x34)] public uint PlaceNameZoneId;
    [FieldOffset(0x38)] public uint PlaceNameId;
    [FieldOffset(0x3C)] public int EndTimestamp;

    [FieldOffset(0x40)] public ushort RecommendedLevel;
    [FieldOffset(0x42)] public ushort TerritoryTypeId;
    [FieldOffset(0x44)] public ushort DataId;
    [FieldOffset(0x46)] public byte MarkerType;
    [FieldOffset(0x47)] public sbyte EventState;
    [FieldOffset(0x48)] public byte Flags; // & 1 == IsHidden?

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
        sbyte eventState = -1);
}
