using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMap
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Map)]
[StructLayout(LayoutKind.Explicit, Size = 0x68A8)]
public unsafe partial struct AgentMap
{
    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0x158)] public Utf8String CurrentMapPath;
    [FieldOffset(0x1C0)] public Utf8String SelectedMapPath;
    [FieldOffset(0x228)] public Utf8String SelectedMapBgPath;
    [FieldOffset(0x290)] public Utf8String CurrentMapBgPath;

    [FieldOffset(0x638)] public fixed byte MapMarkerInfoArray[0x48 * 132]; // 132 * MapMarkerInfo
    [FieldOffset(0x2B58)] public fixed byte TempMapMarkerArray[0x108 * 12]; // 12 * TempMapMarker

    [FieldOffset(0x37B8)] public FlagMapMarker FlagMapMarker;

    [FieldOffset(0x3800)] public fixed byte WarpMarkerArray[0x38 * 12]; // 12 * MapMarkerBase
    [FieldOffset(0x3AA0)] public fixed byte UnkArray2[0xA8 * 6];
    [FieldOffset(0x3E90)] public fixed byte MiniMapMarkerArray[0x40 * 100]; // 100 * MiniMapMarker

    [FieldOffset(0x5838)] public float SelectedMapSizeFactorFloat;
    [FieldOffset(0x583C)] public float CurrentMapSizeFactorFloat;
    [FieldOffset(0x5840)] public short SelectedMapSizeFactor;
    [FieldOffset(0x5842)] public short CurrentMapSizeFactor;
    [FieldOffset(0x5844)] public short SelectedOffsetX;
    [FieldOffset(0x5846)] public short SelectedOffsetY;
    [FieldOffset(0x5848)] public short CurrentOffsetX;
    [FieldOffset(0x584A)] public short CurrentOffsetY;

    [FieldOffset(0x58E0)] public uint CurrentTerritoryId;
    [FieldOffset(0x58E4)] public uint CurrentMapId;
    [FieldOffset(0x58EC)] public uint CurrentMapMarkerRange;
    [FieldOffset(0x58F0)] public uint CurrentMapDiscoveryFlag;

    [FieldOffset(0x58F4)] public uint SelectedTerritoryId;
    [FieldOffset(0x58F8)] public uint SelectedMapId;
    [FieldOffset(0x58FC)] public uint SelectedMapMarkerRange;
    [FieldOffset(0x5900)] public uint SelectedMapDiscoveryFlag;
    [FieldOffset(0x5904)] public uint SelectedMapSub;

    [FieldOffset(0x5914)] public uint UpdateFlags;

    [FieldOffset(0x59B0)] public byte MapMarkerCount;
    [FieldOffset(0x59B1)] public byte TempMapMarkerCount;
    [FieldOffset(0x59B5)] public byte IsFlagMarkerSet;
    [FieldOffset(0x59B7)] public byte MiniMapMarkerCount;
    [FieldOffset(0x59BF)] public byte IsPlayerMoving;
    [FieldOffset(0x59C7)] public byte IsControlKeyPressed;

    public static AgentMap* Instance() => Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentMap();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 33 ED 48 8D 15")]
    public partial void SetFlagMapMarker(uint territoryId, uint mapId, float mapX, float mapY, uint iconId = 0xEC91);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? B0 ?? 48 8B B4 24")]
    public partial void OpenMapByMapId(uint mapId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8C 24 ?? ?? ?? ?? 48 8B 41 28")]
    public partial void OpenMap(OpenMapInfo* data);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 7C 24 ?? 41 54 41 55 41 56 48 83 EC 20")]
    public partial void AddGatheringTempMarker(uint styleFlags, int mapX, int mapY, uint iconId, int radius,
        Utf8String* tooltip);


    public void SetFlagMapMarker(uint territoryId, uint mapId, Vector3 worldPosition, uint iconId = 0xEC91)
    {
        IsFlagMarkerSet = 0;
        var mapX = (int) (MathF.Round(worldPosition.X, 3, MidpointRounding.AwayFromZero) * 1000) * 0.001f;
        var mapY = (int) (MathF.Round(worldPosition.Z, 3, MidpointRounding.AwayFromZero) * 1000) * 0.001f;
        SetFlagMapMarker(territoryId, mapId, mapX, mapY, iconId);
    }

    public void AddGatheringTempMarker(int mapX, int mapY, int radius, uint iconId = 0, uint styleFlags = 4,
        string? tooltip = null)
    {
        var toolTip = Utf8String.FromString(tooltip ?? string.Empty);
        AddGatheringTempMarker(styleFlags, mapX, mapY, iconId, radius, toolTip);
        toolTip->Dtor();
    }

    public void OpenMap(uint mapId, uint territoryId = 0, string? windowTitle = null, MapType type = MapType.FlagMarker)
    {
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
public unsafe struct MapMarkerBase
{
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
public struct FlagMapMarker
{
    [FieldOffset(0x00)] public MapMarkerBase MapMarker;
    [FieldOffset(0x38)] public uint TerritoryId;
    [FieldOffset(0x3C)] public uint MapId;
    [FieldOffset(0x40)] public float XFloat;
    [FieldOffset(0x44)] public float YFloat;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public struct MapMarkerInfo
{
    [FieldOffset(0x00)] public MapMarkerBase MapMarker;

    [FieldOffset(0x3C)] public ushort DataType;
    [FieldOffset(0x3E)] public ushort DataKey;

    [FieldOffset(0x44)] public byte MapMarkerSubKey;
}

[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public struct TempMapMarker
{
    [FieldOffset(0x00)] public Utf8String TooltipText;
    [FieldOffset(0x68)] public MapMarkerBase MapMarker;

    [FieldOffset(0xA8)] public uint StyleFlags;
    [FieldOffset(0xAC)] public uint Type;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public struct MiniMapMarker
{
    [FieldOffset(0x00)] public ushort DataType;
    [FieldOffset(0x02)] public ushort DataKey;

    [FieldOffset(0x08)] public MapMarkerBase MapMarker;
}

[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public struct OpenMapInfo
{
    [FieldOffset(0x00)] public MapType Type;
    [FieldOffset(0x08)] public uint TerritoryId;
    [FieldOffset(0x0C)] public uint MapId;

    [FieldOffset(0x20)] public Utf8String TitleString;
    // there is a lot more stuff in here depending on what type of map it's used for
}

public enum MapType : uint
{
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