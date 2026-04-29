using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::Director
//   Client::Game::Event::LuaEventHandler
//     Client::Game::Event::EventHandler
// ctor "E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 07 0F B7 03"
[GenerateInterop(isInherited: true)]
[Inherits<LuaEventHandler>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8D 47 ?? 48 89 87 ?? ?? ?? ?? ?? ?? 89 87 ?? ?? ?? ?? 8B 43 ?? 89 87 ?? ?? ?? ?? 66 C7 87 ?? ?? ?? ?? 00 00 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 C0", 3, 300)]
[StructLayout(LayoutKind.Explicit, Size = 0x460)]
public unsafe partial struct Director {
    [FieldOffset(0x2D8)] public EventHandlerInfo* EventHandlerInfo;
    [FieldOffset(0x2E0)] public uint ContentId;
    [FieldOffset(0x2E4)] public byte ContentFlags; // 1 = Tourism (Explorer Mode)
    [FieldOffset(0x2E8)] public byte Sequence;
    [FieldOffset(0x2EA), FixedSizeArray] internal FixedSizeArray10<byte> _unionData; // I8A-I8J, UI8A-UI8J, Branch etc.
    [FieldOffset(0x2F8)] public Utf8String Title;
    [FieldOffset(0x360)] public Utf8String Objective; // name based on the Lua function "SetDirectorObjective"
    [FieldOffset(0x3C8)] public Utf8String ReliefText;
    // So far, the Content*Timestamps have been seen in Leves.
    // Dungeons and Frontlines do not use these.
    [FieldOffset(0x430)] public long DirectorStartTimestamp;
    [FieldOffset(0x438)] public long DirectorEndTimestamp;
    [FieldOffset(0x440)] public StdVector<DirectorTodo> DirectorTodos; // name based on the Lua function "SetDirectorTodo", 10 objectives max
    [FieldOffset(0x458)] public uint EventItemId;

    [VirtualFunction(278)]
    public partial void PopulateMapMarkers(ushort territoryTypeId, StdVector<MapMarkerData>* markerVector);
}
