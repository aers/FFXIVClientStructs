using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.GoldSaucer;

// Client::Game::GoldSaucer::GFateDirector
//   Client::Game::Event::GoldSaucerDirector
//     Client::Game::Event::Director
//       Client::Game::Event::LuaEventHandler
//         Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<GoldSaucerDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x7B0)]
public unsafe partial struct GFateDirector {
    [FieldOffset(0x620)] public Utf8String MapMarkerTooltipText;
    [FieldOffset(0x688)] public uint MapMarkerLevelId;

    [FieldOffset(0x690)] public uint MapMarkerIconId;

    [FieldOffset(0x708), FixedSizeArray] internal FixedSizeArray32<uint> _objectIds;
    [FieldOffset(0x788)] public int EndTimestamp;

    [FieldOffset(0x794)] public ushort BgmId;

    [FieldOffset(0x79E)] public GateType GateType;
    [FieldOffset(0x79F)] public GatePositionType GatePositionType;

    [FieldOffset(0x798)] public ushort ScreenImageId1;
    [FieldOffset(0x79A)] public ushort ScreenImageId2;
    [FieldOffset(0x79C)] public ushort ScreenImageId3;

    [FieldOffset(0x7A4)] public GFateDirectorFlag Flags;

    [VirtualFunction(3)]
    public partial bool IsRunningGate();

    [VirtualFunction(294)]
    public partial bool IsAcceptingGate();
}

public enum GateType : byte {
    None = 0,
    Cliffhanger = 1,
    VaseOff = 2,
    SkinchangeWeCanBelieveIn = 3,
    TheTimeOfMyLife = 4,
    AnyWayTheWindBlows = 5,
    LeapOfFaith = 6,
    AirForceOne = 7,
    SliceIsRight = 8,
}

public enum GatePositionType : byte {
    None = 0,
    WonderSquareEast = 1,
    EventSquare = 2,
    RoundSquare = 3,
    TheCactpotBoard = 4,
}

[Flags]
public enum GFateDirectorFlag : uint {
    IsJoined = 1 << 0,
    IsFinished = 1 << 1,
    Unk2 = 1 << 2,
    Unk3 = 1 << 3,
    Unk4 = 1 << 4,
    Unk5 = 1 << 5,
}
