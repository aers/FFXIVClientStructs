using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::Director
//   Client::Game::Event::LuaEventHandler
//     Client::Game::Event::EventHandler
// ctor "E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 07 0F B7 03"
[GenerateInterop(isInherited: true)]
[Inherits<LuaEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x4B8)]
public unsafe partial struct Director {
    [FieldOffset(0x330)] public EventHandlerInfo* EventHandlerInfo;
    [FieldOffset(0x338)] public uint ContentId;
    [FieldOffset(0x33C)] public byte ContentFlags; // 1 = Tourism (Explorer Mode)
    [FieldOffset(0x340)] public byte Sequence;
    [FieldOffset(0x342), FixedSizeArray] internal FixedSizeArray10<byte> _unionData; // I8A-I8J, UI8A-UI8J, Branch etc.
    [FieldOffset(0x350)] public Utf8String Title;
    [FieldOffset(0x3B8)] public Utf8String Description;
    [FieldOffset(0x420)] public Utf8String ReliefText;
    [FieldOffset(0x498)] public StdVector<EventHandlerObjective> Objectives; // 10 objectives max
    [FieldOffset(0x4B0)] public uint EventItemId;

    [VirtualFunction(272)]
    public partial void PopulateMapMarkers(ushort territoryTypeId, StdVector<MapMarkerData>* markerVector);
}
