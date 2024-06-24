using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::PublicContentBozja
//   Client::Game::InstanceContent::PublicContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<PublicContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x2DA8)]
public unsafe partial struct PublicContentBozja {
    [FieldOffset(0x1180)] public DynamicEventContainer DynamicEventContainer;
    [FieldOffset(0x2CA8)] public BozjaState State;
    [FieldOffset(0x2D98)] public bool StateInitialized;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 E8 ?? ?? ?? ?? 48 85 FF 74 1D")]
    public static partial PublicContentBozja* GetInstance();

    /// <summary>
    /// Returns pointer to the state, if bozja director is active and state is initialized; otherwise returns null.
    /// </summary>
    /// <returns></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 FF 74 1D")]
    public static partial BozjaState* GetState();

    /// <summary>
    /// Use lost action from holster into specified duty action slot (slot is ignored for items, which are used directly).
    /// </summary>
    /// <param name="holsterIndex">Index of the action in the holster (see HolsterActions array).</param>
    /// <param name="slot">Action slot (has to be 0 or 1).</param>
    /// <returns></returns>
    // Dawntrail: function inlined @ "48 85 C0 0F 84 ?? ?? ?? ?? 80 78 05 02"
    // [MemberFunction("E8 ?? ?? ?? ?? 3C 01 0F 85 ?? ?? ?? ?? BD")]
    // public partial bool UseFromHolster(uint holsterIndex, uint slot);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public partial struct BozjaState {
    [FieldOffset(0x00)] public uint CurrentExperience; // Mettle
    [FieldOffset(0x04)] public uint NeededExperience;
    [FieldOffset(0x6C), FixedSizeArray] internal FixedSizeArray100<byte> _holsterActions; // elements are MYCTemporaryItem row ids
}

// Client::Game::InstanceContent::DynamicEventContainer
//   Client::Game::InstanceContent::ContentSheetWaiterInterface
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1B28)]
public unsafe partial struct DynamicEventContainer {
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray16<DynamicEvent> _events;
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
    [FieldOffset(0x54)] public int StartTimestamp;
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
