using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.Game.Fate;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI
{
    // this is a large object holding most of the other objects in the Client::Game::UI namespace
    // all data in here is used for UI display

    // ctor E8 ? ? ? ? 48 8D 0D ? ? ? ? 48 83 C4 28 E9 ? ? ? ? 48 83 EC 28 33 D2 
    [StructLayout(LayoutKind.Explicit, Size=0x168D8)] // its at least this big, may be a few bytes bigger
    public unsafe partial struct UIState
    {
        [FieldOffset(0x00)] public Hotbar Hotbar;
        [FieldOffset(0xA38)] public PlayerState PlayerState;
        [FieldOffset(0x11B0)] public Revive Revive; //+B0
        [FieldOffset(0x1448)] public Telepo Telepo; //+C0
        [FieldOffset(0x19F0)] public Buddy Buddy; //+90
        [FieldOffset(0x29E8)] public RelicNote RelicNote; //+700

        [FieldOffset(0xA6C0)] public Director* ActiveDirector; //+828?
        [FieldOffset(0xA808)] public FateDirector* FateDirector; //+828
        [FieldOffset(0xA950)] public Map Map; //+828

        [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 48 8B 01")]
        public static partial UIState* Instance();
    }
}
