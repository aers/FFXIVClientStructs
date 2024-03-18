using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.GoldSaucer;

// Client::Game::GoldSaucer::GFateDirector
//   Client::Game::Event::GoldSaucerDirector
//     Client::Game::Event::Director
//       Client::Game::Event::LuaEventHandler
//         Client::Game::Event::EventHandler
[StructLayout(LayoutKind.Explicit, Size = 0x808)]
public unsafe partial struct GFateDirector {
    [FieldOffset(0)] public GoldSaucerDirector GoldSaucerDirector;
    [FieldOffset(0x678)] public Utf8String MapMarkerTooltipText;
    [FieldOffset(0x6E0)] public uint MapMarkerLevelId;

    [FieldOffset(0x6E8)] public uint MapMarkerIconId;

    [FieldOffset(0x760)] public fixed uint ObjectIds[32]; // for what?
    [FieldOffset(0x7E0)] public uint EndTimestamp;

    [FieldOffset(0x7EC)] public ushort BgmId;

    [FieldOffset(0x7F6)] public byte GateType;
    [FieldOffset(0x7F7)] public byte GatePositionType;

    [FieldOffset(0x7F0)] public ushort ScreenImageId1;
    [FieldOffset(0x7F2)] public ushort ScreenImageId2;
    [FieldOffset(0x7F4)] public ushort ScreenImageId3;

    [FieldOffset(0x7FC)] public GFateDirectorFlag Flags;

    [VirtualFunction(3)]
    public partial bool IsRunningGate();

    [VirtualFunction(294)]
    public partial bool IsAcceptingGate();
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
