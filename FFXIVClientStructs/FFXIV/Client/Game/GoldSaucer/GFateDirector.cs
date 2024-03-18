using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.GoldSaucer;

// Client::Game::GoldSaucer::GFateDirector
//   Client::Game::Event::GoldSaucerDirector
//     Client::Game::Event::Director
//       Client::Game::Event::LuaEventHandler
//         Client::Game::Event::EventHandler
[StructLayout(LayoutKind.Explicit, Size = 0x808)]
public unsafe struct GFateDirector {
    [FieldOffset(0)] public GoldSaucerDirector GoldSaucerDirector;
    [FieldOffset(0x678)] public Utf8String MapMarkerTitle;
    [FieldOffset(0x6E0)] public uint MapMarkerLevelId;

    [FieldOffset(0x6E8)] public uint MapMarkerIconId;

    [FieldOffset(0x760)] internal fixed uint ObjectIds[32]; // ?
    [FieldOffset(0x7E0)] public uint EndTimestamp;

    [FieldOffset(0x7EC)] internal uint BgmId; // ?

    [FieldOffset(0x7F0)] internal uint ScreenImageId; // for loading screen?

    [FieldOffset(0x7FC)] public uint UIntFlags; // named like this to avoid conflicts in the future when adding an enum

    public readonly bool IsCompleted => UIntFlags == 0x7; // no clue, only observed
}
