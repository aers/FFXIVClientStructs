using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Fate;

// Client::Game::Fate::FateContext
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 66 89 51 18"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2820)]
public unsafe partial struct FateContext {
    [FieldOffset(0x18)] public ushort FateId;
    [FieldOffset(0x1A)] public byte EurekaFate;
    [FieldOffset(0x20)] public int StartTimeEpoch;
    [FieldOffset(0x28)] public short Duration;

    [FieldOffset(0xC0)] public Utf8String Name;
    [FieldOffset(0x128)] public Utf8String Description;
    [FieldOffset(0x190)] public Utf8String Objective;

    [FieldOffset(0x3AC)] public FateState State;
    [FieldOffset(0x3AE)] public byte HandInCount;
    [FieldOffset(0x3B7)] public byte Progress;
    /// <summary>
    /// If true grants extra experience and bicolor gemstones (ShB and up)
    /// </summary>
    [FieldOffset(0x3C1)] public bool IsBonus;

    [FieldOffset(0x3D0), FixedSizeArray] internal FixedSizeArray32<FateObjective> _objectives;
    [FieldOffset(0x7D4)] public uint IconId;
    [FieldOffset(0x7D8)] public uint MapIconId;
    [FieldOffset(0x7DC)] public uint InactiveMapIcon;
    [FieldOffset(0x7E0)] public uint EventItem;
    [FieldOffset(0x7E8)] public ushort Music;
    [FieldOffset(0x7EA)] public ushort GivenStatus;
    [FieldOffset(0x7EC)] internal ushort Unknown4;
    [FieldOffset(0x7EE)] public byte Rule;
    [FieldOffset(0x7F0)] public ushort FateRuleEx;
    [FieldOffset(0x7F3)] public byte Level;
    [FieldOffset(0x7F4)] public byte MaxLevel;
    [FieldOffset(0x7F5)] internal byte Unknown7;
    [FieldOffset(0x7F6)] internal ushort Unknown13;
    [FieldOffset(0x7F8)] public ushort ScreenImageAccept;
    [FieldOffset(0x7FA)] public ushort ScreenImageComplete;
    [FieldOffset(0x7FC)] public ushort ScreenImageFailed;
    [FieldOffset(0x800)] internal uint Unknown0;
    [FieldOffset(0x806)] public ushort FATEChain;
    [FieldOffset(0x80C)] internal uint Unknown1;
    [FieldOffset(0x810)] public uint ReqEventItem;
    [FieldOffset(0x814)] public uint TurnInEventItem;
    [FieldOffset(0x818)] internal uint Unknown20;
    [FieldOffset(0x81C)] internal ushort Unknown21;
    [FieldOffset(0x820)] internal uint Unknown22;
    [FieldOffset(0x824)] internal uint Unknown10;
    [FieldOffset(0x828)] internal uint Unknown11;
    [FieldOffset(0x82C)] internal uint Unknown12;
    [FieldOffset(0x830)] internal ushort Unknown5;
    [FieldOffset(0x834)] internal byte Unknown6;
    [FieldOffset(0x838)] public uint RequiredQuest;
    [FieldOffset(0x83C), CExporterExcelBegin("FateMode")] internal uint FateModeUnknown0;
    [FieldOffset(0x840)] public uint FateModeMotivationIcon;
    [FieldOffset(0x844)] public uint FateModeMotivationMapMarker;
    [FieldOffset(0x848)] public uint FateModeObjectiveIcon;
    [FieldOffset(0x84C), CExporterExcelEnd] public uint FateModeObjectiveMapMarker;
    [FieldOffset(0x850)] public Vector3 Location;
    [FieldOffset(0x864)] public float Radius;
    [FieldOffset(0xA10), FixedSizeArray] internal FixedSizeArray37<FateMapMarker> _mapMarkers;

    [FieldOffset(0xACA), Obsolete("Use MapMarkers instead", true)] public ushort TerritoryId;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B FA 49 8B F0 8B 91")]
    public partial bool TryGetPositionAndRadius(Vector3* position, Vector3* radius);

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct FateObjective {
        [FieldOffset(0x00)] public uint IconId;
        [FieldOffset(0x04)] public uint TargetMarkerLayoutId;
        [FieldOffset(0x10)] public Vector3 Position;
        [FieldOffset(0x1C)] public uint Flags;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xD0)]
    public struct FateMapMarker {
        [FieldOffset(0x10)] public Utf8String Name;
        [FieldOffset(0x78)] public MapMarkerData MapMarkerData;
        [FieldOffset(0x88), Obsolete("Use MapMarkerData.IconId")] public uint IconId;
        [FieldOffset(0x94), Obsolete("Use MapMarkerData.Position")] public Vector3 Position;
        [FieldOffset(0xA0), Obsolete("Use MapMarkerData.Radius")] public float Radius;
        [FieldOffset(0xBA), Obsolete("Use MapMarkerData.TerritoryTypeId")] public ushort TerritoryId;
    }
}

public enum FateState : byte {
    Running = 4,
    Ended = 7,
    Failed = 8,
    Preparing = 3,
    Ending = 5,
    // missing one was 9, now 6
}
