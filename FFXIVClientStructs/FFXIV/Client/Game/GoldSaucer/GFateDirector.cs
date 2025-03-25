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
[StructLayout(LayoutKind.Explicit, Size = 0x810)]
public unsafe partial struct GFateDirector {
    [FieldOffset(0x680)] public Utf8String MapMarkerTooltipText;
    [FieldOffset(0x6E8)] public uint MapMarkerLevelId;

    [FieldOffset(0x6F0)] public uint MapMarkerIconId;

    [FieldOffset(0x768), FixedSizeArray] internal FixedSizeArray32<uint> _objectIds;
    [FieldOffset(0x7E8)] public int EndTimestamp;

    [FieldOffset(0x7F4)] public ushort BgmId;

    [FieldOffset(0x7FE)] public byte GateType;
    [FieldOffset(0x7FF)] public byte GatePositionType;

    [FieldOffset(0x7F8)] public ushort ScreenImageId1;
    [FieldOffset(0x7FA)] public ushort ScreenImageId2;
    [FieldOffset(0x7FC)] public ushort ScreenImageId3;

    [FieldOffset(0x804)] public GFateDirectorFlag Flags;

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
