using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::PublicContentBozja
//   Client::Game::InstanceContent::PublicContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
[StructLayout(LayoutKind.Explicit, Size = 0x2CB8)]
public struct PublicContentBozja {
    [FieldOffset(0x00)] public PublicContentDirector PublicContentDirector;

    [FieldOffset(0x1098)] public DynamicEventContainer DynamicEventContainer;

    [FieldOffset(0x2BC0)] public uint CurrentExperience; // Mettle
    [FieldOffset(0x2BC4)] public uint NeededExperience;
}

// Client::Game::InstanceContent::DynamicEventContainer
//   Client::Game::InstanceContent::ContentSheetWaiterInterface
[StructLayout(LayoutKind.Explicit, Size = 0x1B28)]
public unsafe partial struct DynamicEventContainer {
    [FixedSizeArray<DynamicEvent>(16)]
    [FieldOffset(0x08)] public fixed byte Events[0x1B0 * 16];
}

// Client::Game::InstanceContent::DynamicEvent
//   Common::Component::Excel::ExcelSheetWaiter
[StructLayout(LayoutKind.Explicit, Size = 0x1B0)]
public unsafe partial struct DynamicEvent {
    // [FieldOffset(0)] public ExcelSheetWaiter ExcelSheetWaiter;
    [FieldOffset(0x38)] public uint LGBEventObject;
    [FieldOffset(0x3C)] public uint LGBMapRange;
    [FieldOffset(0x40)] public uint Quest; // RowId of Quest Sheet
    [FieldOffset(0x44)] public uint Announce; // RowId of LogMessage Sheet
    [FieldOffset(0x48)] public ushort Unknown0;
    [FieldOffset(0x4A)] public ushort Unknown1;
    [FieldOffset(0x4C)] public ushort Unknown2;
    [FieldOffset(0x4E)] public byte EventType; // RowId of DynamicEventType Sheet
    [FieldOffset(0x4F)] public byte EnemyType; // RowId of DynamicEventEnemyType Sheet
    [FieldOffset(0x50)] public byte MaxParticipants;
    [FieldOffset(0x51)] public byte Unknown4;
    [FieldOffset(0x52)] public byte Unknown5;
    [FieldOffset(0x54)] public uint StartTimestamp;
    [FieldOffset(0x58)] public uint SecondsLeft;
    [FieldOffset(0x5C)] public uint SecondsDuration;

    [FieldOffset(0x63)] public DynamicEventState State;

    [FieldOffset(0x65)] public byte Participants;
    [FieldOffset(0x66)] public byte Progress;

    [FieldOffset(0x53)] public byte SingleBattle; // RowId of DynamicEventSingleBattle Sheet
    [FieldOffset(0x68)] public Utf8String Name;
    [FieldOffset(0xD0)] public Utf8String Description;
    [FieldOffset(0x138)] public uint IconObjective0;
    [FieldOffset(0x13C)] public byte MaxParticipants2;
    [FieldOffset(0x158)] public MapMarkerData MapMarker;
}

public enum DynamicEventState : byte {
    Inactive = 0,
    Register = 1,
    Warmup = 2,
    Battle = 3
}
