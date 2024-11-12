using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMap
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Map)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x144C8)]
public unsafe partial struct AgentMap {
    /// <summary> Pointers to markers in <see cref="EventMarkers"/>. </summary>
    [FieldOffset(0xD0)] public StdVector<Pointer<MapMarkerData>> EventMarkersPtrs;
    /// <summary> Includes markers from FateManager, EventFramework and SequentialEvent (whatever that is). </summary>
    [FieldOffset(0xE8)] public StdVector<MapMarkerData> EventMarkers;

    // [MinimapLinkedMarkers] Name could be better, this contains the tooltips and linked locations of minimap MSQ markers that have arrows telling you where to go.
    // These do not contain any of the other arrow markers.
    [FieldOffset(0x130)] public StdVector<LinkedTooltipMarker> MinimapMSQLinkedTooltipMarkers;
    [FieldOffset(0x148)] public StdVector<Pointer<LinkedTooltipMarker>> MinimapMSQLinkedTooltipMarkersList;

    [FieldOffset(0x160)] public StdMap<uint, uint> SymbolMap; // Icon:MapSymbol

    [FieldOffset(0x1B8)] public Utf8String CurrentMapPath;
    [FieldOffset(0x220)] public Utf8String SelectedMapPath;
    [FieldOffset(0x288)] public Utf8String SelectedMapBgPath;
    [FieldOffset(0x2F0)] public Utf8String CurrentMapBgPath;
    [FieldOffset(0x358), FixedSizeArray] internal FixedSizeArray4<Utf8String> _mapSelectionStrings;
    [FieldOffset(0x4F8)] public Utf8String MapTitleString;

    [FieldOffset(0x698), FixedSizeArray] internal FixedSizeArray132<MapMarkerInfo> _mapMarkers;
    [FieldOffset(0x2BB8), FixedSizeArray] internal FixedSizeArray12<TempMapMarker> _tempMapMarkers;
    [FieldOffset(0x38D8)] public FlagMapMarker FlagMapMarker;
    [FieldOffset(0x3920), FixedSizeArray] internal FixedSizeArray12<MapMarkerBase> _warpMarkers;

    /// <remarks>
    /// 0 = mineral deposit and lush vegetation patch<br/>
    /// 1 = legendary mineral deposit<br/>
    /// 2 = unspoiled lush vegetation patch<br/>
    /// </remarks>
    [FieldOffset(0x3BC0), FixedSizeArray] internal FixedSizeArray6<MiniMapGatheringMarker> _miniMapGatheringMarkers;
    [FieldOffset(0x3FB0), FixedSizeArray] internal FixedSizeArray100<MiniMapMarker> _miniMapMarkers;

    [FieldOffset(0x5958)] public float SelectedMapSizeFactorFloat;
    [FieldOffset(0x595C)] public float CurrentMapSizeFactorFloat;
    [FieldOffset(0x5960)] public short SelectedMapSizeFactor;
    [FieldOffset(0x5962)] public short CurrentMapSizeFactor;
    [FieldOffset(0x5964)] public short SelectedOffsetX;
    [FieldOffset(0x5966)] public short SelectedOffsetY;
    [FieldOffset(0x5968)] public short CurrentOffsetX;
    [FieldOffset(0x596A)] public short CurrentOffsetY;

    [FieldOffset(0x5A00)] public uint CurrentTerritoryId;
    [FieldOffset(0x5A04)] public uint CurrentMapId;
    [FieldOffset(0x5A0C)] public uint CurrentMapMarkerRange;
    [FieldOffset(0x5A10)] public uint CurrentMapDiscoveryFlag;
    [FieldOffset(0x5A14)] public uint SelectedTerritoryId;
    [FieldOffset(0x5A18)] public uint SelectedMapId;
    [FieldOffset(0x5A1C)] public uint SelectedMapMarkerRange;
    [FieldOffset(0x5A20)] public uint SelectedMapDiscoveryFlag;
    [FieldOffset(0x5A24)] public uint SelectedMapSub;

    [FieldOffset(0x5A3C)] public uint UpdateFlags;

    [FieldOffset(0x5ADB)] public byte MapMarkerCount;
    [FieldOffset(0x5ADC)] public byte TempMapMarkerCount;
    [FieldOffset(0x5ADE)] public byte IsFlagMarkerSet;
    [FieldOffset(0x5AE0)] public byte MiniMapMarkerCount;
    [FieldOffset(0x5AE8)] public byte IsPlayerMoving;
    [FieldOffset(0x5AF0)] public byte IsControlKeyPressed;

    [FieldOffset(0x5F00)] public QuestLinkContainer MapQuestLinkContainer;
    [FieldOffset(0x6A58)] public QuestLinkContainer MiniMapQuestLinkContainer;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4F 10 48 85 C9")]
    public partial void SetFlagMapMarker(uint territoryId, uint mapId, float x, float y, uint iconId = 0xEC91);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B B4 24 ?? ?? ?? ?? EB 64")]
    public partial void OpenMapByMapId(uint mapId, uint territoryId = 0, bool a4 = false);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 45 28 48 8D 8C 24")]
    public partial void OpenMap(OpenMapInfo* data);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4D 70 E8 ?? ?? ?? ?? 48 8D 54 24 ??")]
    public partial void AddGatheringTempMarker(uint styleFlags, int mapX, int mapY, uint iconId, int radius, Utf8String* tooltip);

    [MemberFunction("40 53 48 83 EC ?? B2 ?? C6 81 ?? ?? ?? ?? ?? 48 8B D9 E8 ?? ?? ?? ?? 33 D2")]
    public partial void ResetMiniMapMarkers();

    [MemberFunction("40 53 48 83 EC ?? 48 8B D9 C6 81 ?? ?? ?? ?? ?? 48 C7 81")]
    public partial void ResetMapMarkers();

    [MemberFunction("E8 ?? ?? ?? ?? 40 B6 01 C7 44 24 ?? ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? 84 C0 74 15")]
    public partial void ShowMap(bool a1, bool a2); // native code calls a1 as true always, a2 is used both true and false

    public bool AddMiniMapMarker(Vector3 position, uint icon, int scale = 0) {
        if (MiniMapMarkerCount >= 100) return false;
        var marker = new MiniMapMarker();
        marker.MapMarker.Index = MiniMapMarkerCount;
        marker.MapMarker.X = (short)(position.X * 16.0f);
        marker.MapMarker.Y = (short)(position.Z * 16.0f);
        marker.MapMarker.Scale = scale;
        marker.MapMarker.IconId = icon;
        MiniMapMarkers[MiniMapMarkerCount++] = marker;
        return true;
    }

    public bool AddMapMarker(Vector3 position, uint icon, int scale = 0, byte* text = null, byte textPosition = 3, byte textStyle = 0) {
        if (MapMarkerCount >= 132) return false;
        if (textPosition is > 0 and < 12)
            position *= SelectedMapSizeFactorFloat;
        var marker = new MapMarkerInfo();
        marker.MapMarker.Index = MapMarkerCount;
        marker.MapMarker.X = (short)(position.X * 16.0f);
        marker.MapMarker.Y = (short)(position.Z * 16.0f);
        marker.MapMarker.Scale = scale;
        marker.MapMarker.IconId = icon;
        marker.MapMarker.Subtext = text;
        marker.MapMarker.SubtextOrientation = textPosition;
        marker.MapMarker.SubtextStyle = textStyle;
        MapMarkers[MapMarkerCount++] = marker;
        return true;
    }

    public void SetFlagMapMarker(uint territoryId, uint mapId, Vector3 worldPosition, uint iconId = 0xEC91) {
        IsFlagMarkerSet = 0;
        var mapX = (int)(MathF.Round(worldPosition.X, 3, MidpointRounding.AwayFromZero) * 1000) * 0.001f;
        var mapY = (int)(MathF.Round(worldPosition.Z, 3, MidpointRounding.AwayFromZero) * 1000) * 0.001f;
        SetFlagMapMarker(territoryId, mapId, mapX, mapY, iconId);
    }

    public void AddGatheringTempMarker(int mapX, int mapY, int radius, uint iconId = 0, uint styleFlags = 4, string? tooltip = null) {
        var toolTip = Utf8String.FromString(tooltip ?? string.Empty);
        AddGatheringTempMarker(styleFlags, mapX, mapY, iconId, radius, toolTip);
        toolTip->Dtor();
    }

    public void OpenMap(uint mapId, uint territoryId = 0, string? windowTitle = null, MapType type = MapType.FlagMarker) {
        var title = Utf8String.FromString(windowTitle ?? string.Empty);
        var info = stackalloc OpenMapInfo[1];
        info->Type = type == MapType.FlagMarker && IsFlagMarkerSet != 1 ? MapType.Centered : type;
        info->MapId = mapId;
        info->TerritoryId = territoryId;
        info->TitleString = *title;
        OpenMap(info);
        title->Dtor();
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct MapMarkerBase {
    [FieldOffset(0x00)] public byte SubtextOrientation;
    [FieldOffset(0x01)] public byte SubtextStyle;
    [FieldOffset(0x02)] public ushort IconFlags;
    [FieldOffset(0x04)] public uint IconId;
    [FieldOffset(0x08)] public uint SecondaryIconId;
    [FieldOffset(0x0C)] public int Scale;
    [FieldOffset(0x10)] public byte* Subtext;
    [FieldOffset(0x18)] public byte Index;

    [FieldOffset(0x2C)] public short X;
    [FieldOffset(0x2E)] public short Y;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public struct FlagMapMarker {
    [FieldOffset(0x00)] public MapMarkerBase MapMarker;
    [FieldOffset(0x38)] public uint TerritoryId;
    [FieldOffset(0x3C)] public uint MapId;
    [FieldOffset(0x40)] public float XFloat;
    [FieldOffset(0x44)] public float YFloat;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public struct MapMarkerInfo {
    [FieldOffset(0x00)] public MapMarkerBase MapMarker;

    [FieldOffset(0x3C)] public ushort DataType;
    [FieldOffset(0x3E)] public ushort DataKey;

    [FieldOffset(0x44)] public byte MapMarkerSubKey;
}

[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public struct MiniMapGatheringMarker {
    [FieldOffset(0x00)] public Utf8String TooltipText;
    [FieldOffset(0x68)] public MapMarkerBase MapMarker;
    [FieldOffset(0xA0)] public ushort RecommendedLevel; // maybe?
    [FieldOffset(0xA2)] public byte ShouldRender;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public struct MiniMapMarker {
    [FieldOffset(0x00)] public ushort DataType;
    [FieldOffset(0x02)] public ushort DataKey;

    [FieldOffset(0x08)] public MapMarkerBase MapMarker;
}

[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public struct TempMapMarker {
    [FieldOffset(0x00)] public Utf8String TooltipText;
    [FieldOffset(0x68)] public MapMarkerBase MapMarker;

    [FieldOffset(0xA8)] public uint StyleFlags;
    [FieldOffset(0xAC)] public uint Type;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8E)]
public struct OpenMapInfo {
    [FieldOffset(0x00)] public MapType Type;
    [FieldOffset(0x04)] public uint AddonId;
    [FieldOffset(0x08)] public uint TerritoryId;
    [FieldOffset(0x0C)] public uint MapId;
    [FieldOffset(0x10)] public uint PlaceNameId;
    [FieldOffset(0x14)] public uint AetheryteId;
    [FieldOffset(0x18)] public uint FateId;
    [FieldOffset(0x1C)] public uint Unk1C;
    [FieldOffset(0x20)] public Utf8String TitleString;
    [FieldOffset(0x88)] public uint Unk88;
    [FieldOffset(0x8C)] public byte Unk8C;
    [FieldOffset(0x8D)] public bool Unk8D; // something for QuestRedoMapMarker
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xB58)]
public unsafe partial struct QuestLinkContainer {
    [FieldOffset(0x08)] public ushort MarkerCount;

    [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray20<QuestLinkMarker> _markers;
}

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public struct QuestLinkMarker {
    [FieldOffset(0x00)] public byte Valid; // possibly a bool, used at sub_140BD40B0+A9 (6.48) 
    [FieldOffset(0x02)] public ushort QuestId;
    [FieldOffset(0x08)] public Utf8String TooltipText;
    [FieldOffset(0x70)] public int RecommendedLevel;
    [FieldOffset(0x74)] public uint IconId;
    [FieldOffset(0x78)] public uint LevelId;
    [FieldOffset(0x7C)] public uint SourceMapId;
    [FieldOffset(0x80)] public uint TargetMapId;
    // [FieldOffset(0x84)] public ushort X; // Not sure, range seems weird
    // [FieldOffset(0x86)] public ushort Y; // Not sure, range seems weird
}

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public struct LinkedTooltipMarker {
    [FieldOffset(0x00)] public Utf8String TooltipText;
    [FieldOffset(0x68)] public uint IconId;
    [FieldOffset(0x6C)] public uint LevelId;
}

public enum MapType : uint {
    SharedFate = 0,
    FlagMarker = 1,
    GatheringLog = 2,
    QuestLog = 3,
    Centered = 4,
    Treasure = 5,
    Teleport = 6,
    MobHunt = 7,
    AetherCurrent = 8,
    Bozja = 9
}
