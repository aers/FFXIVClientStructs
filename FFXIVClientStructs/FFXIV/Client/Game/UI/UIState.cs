using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.Game.Fate;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI
{
    // this is a large object holding most of the other objects in the Client::Game::UI namespace
    // all data in here is used for UI display

    // ctor E8 ? ? ? ? 48 8D 0D ? ? ? ? 48 83 C4 28 E9 ? ? ? ? 48 83 EC 28 33 D2 
    [StructLayout(LayoutKind.Explicit, Size=0x15D2A)] // its at least this big, may be a few bytes bigger
    public unsafe partial struct UIState
    {
        [FieldOffset(0x00)] public Hotbar Hotbar;
        [FieldOffset(0xA38)] public PlayerState PlayerState;
        [FieldOffset(0x1120)] public Revive Revive;
        [FieldOffset(0x1388)] public Telepo Telepo;
        [FieldOffset(0x1960)] public Buddy Buddy;
        [FieldOffset(0x22E8)] public RelicNote RelicNote;
        [FieldOffset(0x9FE0)] public FateDirector* FateDirector;

        [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 48 8B 01")]
        public static partial UIState* Instance();
    }
}
