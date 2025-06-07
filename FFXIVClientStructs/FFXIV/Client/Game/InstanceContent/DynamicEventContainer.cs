using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::DynamicEventContainer
//   Client::Game::InstanceContent::ContentSheetWaiterInterface
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1D80)]
public unsafe partial struct DynamicEventContainer {
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray16<DynamicEvent> _events;

    [FieldOffset(0x1D78)] private float Unk1D78;
    [FieldOffset(0x1D7C)] public ushort CurrentEventId;
    [FieldOffset(0x1D7E)] public sbyte CurrentEventIndex;
    [FieldOffset(0x1D7F)] private byte ContentMemberLimit; // ContentMemberType.Unknown3

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B E8 48 85 C0 74 ?? 0F B7 56")]
    public static partial DynamicEventContainer* GetInstance();

    [MemberFunction("48 0F BE 81 ?? ?? ?? ?? 48 8B D1 84 C0 79")]
    public partial DynamicEvent* GetCurrentEvent();
}

// Client::Game::InstanceContent::DynamicEvent
//   Common::Component::Excel::ExcelSheetWaiter
[GenerateInterop]
[Inherits<ExcelSheetWaiter>]
[StructLayout(LayoutKind.Explicit, Size = 0x1D0)]
public unsafe partial struct DynamicEvent {
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
    [FieldOffset(0x6C)] private uint SecondsRegistrationTime;
    [FieldOffset(0x70)] private uint SecondsWarmupTime;
    [FieldOffset(0x74)] public ushort DynamicEventId;
    [FieldOffset(0x76)] public byte DynamicEventType;
    [FieldOffset(0x77)] private bool Unk77; // ?? true if DynamicEventContainer+0x1D7F (ContentMemberType.Unknown3) == MaxParticipants
    [FieldOffset(0x78)] public DynamicEventState State;

    [FieldOffset(0x7A)] public byte Participants;
    [FieldOffset(0x7B)] public byte Progress;

    [FieldOffset(0x80)] public Utf8String Name;
    [FieldOffset(0xE8)] public Utf8String Description;
    [FieldOffset(0x150)] public uint IconObjective0;
    [FieldOffset(0x154)] public byte MaxParticipants2;
    [FieldOffset(0x170)] public MapMarkerData MapMarker;
    [FieldOffset(0x1C0)] public DynamicEventContainer* EventContainer;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 44 0F B7 03")]
    public partial bool IsActive();
}

public enum DynamicEventState : byte {
    Inactive = 0,
    Register = 1,
    Warmup = 2,
    Battle = 3
}
