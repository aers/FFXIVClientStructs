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
[StructLayout(LayoutKind.Explicit, Size = 0x3258)]
public unsafe partial struct PublicContentBozja {
    [FieldOffset(0x13E0)] public DynamicEventContainer DynamicEventContainer;
    [FieldOffset(0x3160)] public BozjaState State;
    [FieldOffset(0x3250)] public bool StateInitialized;

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
    [MemberFunction("40 53 55 57 48 83 EC 40 8B FA")]
    public partial bool UseFromHolster(uint holsterIndex, uint slot);
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
[StructLayout(LayoutKind.Explicit, Size = 0x1D80)]
public unsafe partial struct DynamicEventContainer {
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray16<DynamicEvent> _events;
}

// Client::Game::InstanceContent::DynamicEvent
//   Common::Component::Excel::ExcelSheetWaiter
[StructLayout(LayoutKind.Explicit, Size = 0x1D0)]
public unsafe partial struct DynamicEvent {
    // [FieldOffset(0)] public ExcelSheetWaiter ExcelSheetWaiter;
    [FieldOffset(0x30 + 0x00), CExporterExcelBegin("DynamicEvent")] public uint NameOffset;
    [FieldOffset(0x30 + 0x04)] public uint DescriptionOffset;
    [FieldOffset(0x30 + 0x08)] public uint LGBEventObject;
    [FieldOffset(0x30 + 0x0C)] public uint LGBMapRange;
    /// <remarks>RowId of Quest Sheet</remarks>
    [FieldOffset(0x30 + 0x10)] public uint Quest;
    /// <remarks>RowId of LogMessage Sheet</remarks>
    [FieldOffset(0x30 + 0x14)] public uint Announce;
    [FieldOffset(0x30 + 0x18)] public uint Unknown0;
    [FieldOffset(0x30 + 0x1C)] public uint Unknown1;
    [FieldOffset(0x30 + 0x20)] public ushort Unknown6;
    [FieldOffset(0x30 + 0x22)] public ushort Unknown7;
    [FieldOffset(0x30 + 0x24)] public ushort Unknown2;
    /// <remarks>RowId of DynamicEventType Sheet</remarks>
    [FieldOffset(0x30 + 0x26)] public byte EventType;
    /// <remarks>RowId of DynamicEventEnemyType Sheet</remarks>
    [FieldOffset(0x30 + 0x27)] public byte EnemyType;
    [FieldOffset(0x30 + 0x28)] public byte MaxParticipants;
    [FieldOffset(0x30 + 0x29)] public byte Unknown4;
    [FieldOffset(0x30 + 0x2A)] public byte Unknown5;
    /// <remarks>RowId of DynamicEventSingleBattle Sheet</remarks>
    [FieldOffset(0x30 + 0x2B)] public byte SingleBattle;
    [FieldOffset(0x30 + 0x2C), CExporterExcelEnd] public byte Unknown8;
    [FieldOffset(0x60)] public int StartTimestamp;
    [FieldOffset(0x64)] public uint SecondsLeft;
    [FieldOffset(0x68)] public uint SecondsDuration;
    [FieldOffset(0x78)] public DynamicEventState State;
    [FieldOffset(0x7A)] public byte Participants;
    [FieldOffset(0x7B)] public byte Progress;
    // new 1 byte field at 0x70 in 7.1
    [FieldOffset(0x80)] public Utf8String Name;
    [FieldOffset(0xE8)] public Utf8String Description;
    [FieldOffset(0x150)] public uint IconObjective0;
    [FieldOffset(0x154)] public byte MaxParticipants2;
    [FieldOffset(0x170)] public MapMarkerData MapMarker;
}

public enum DynamicEventState : byte {
    Inactive = 0,
    Register = 1,
    Warmup = 2,
    Battle = 3
}
