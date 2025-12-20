using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::Director
//   Client::Game::Event::LuaEventHandler
//     Client::Game::Event::EventHandler
// ctor "E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 07 0F B7 03"
[GenerateInterop(isInherited: true)]
[Inherits<LuaEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x460)]
public unsafe partial struct Director {
    [FieldOffset(0x2D8)] public EventHandlerInfo* EventHandlerInfo;
    [FieldOffset(0x2E0)] public uint ContentId;
    [FieldOffset(0x2E4)] public byte ContentFlags; // 1 = Tourism (Explorer Mode)
    [FieldOffset(0x2E8)] public byte Sequence;
    [FieldOffset(0x2EA), FixedSizeArray] internal FixedSizeArray10<byte> _unionData; // I8A-I8J, UI8A-UI8J, Branch etc.
    [FieldOffset(0x2F8)] public Utf8String Title;
    [FieldOffset(0x360), Obsolete("Renamed to Objective", true)] public Utf8String Description;
    [FieldOffset(0x360)] public Utf8String Objective; // name based on the Lua function "SetDirectorObjective"
    [FieldOffset(0x3C8)] public Utf8String ReliefText;
    // So far, the Content*Timestamps have been seen in Leves.
    // Dungeons and Frontlines do not use these.
    [FieldOffset(0x430)] public long DirectorStartTimestamp;
    [FieldOffset(0x438)] public long DirectorEndTimestamp;
    [FieldOffset(0x440), Obsolete($"Use {nameof(DirectorTodos)}, or {nameof(GetDirectorTodos)}", true)] public StdVector<EventHandlerObjective> Objectives;
    [FieldOffset(0x440)] public StdVector<DirectorTodo> DirectorTodos; // name based on the Lua function "SetDirectorTodo", 10 objectives max
    [FieldOffset(0x458)] public uint EventItemId;

    [VirtualFunction(277)]
    public partial void PopulateMapMarkers(ushort territoryTypeId, StdVector<MapMarkerData>* markerVector);
}
