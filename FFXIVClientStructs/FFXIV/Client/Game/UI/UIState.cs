using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI
{
    // this is a large object holding most of the other objects in the Client::Game::UI namespace
    // all data in here is used for UI display

    // ctor E8 ? ? ? ? 48 8D 0D ? ? ? ? 48 83 C4 28 E9 ? ? ? ? 48 83 EC 28 33 D2 
    [StructLayout(LayoutKind.Explicit, Size=0x15D2A)] // its at least this big, may be a few bytes bigger
    public unsafe struct UIState
    {
        [FieldOffset(0x1388)] public Telepo Telepo;
        [FieldOffset(0x1960)] public Buddy Buddy;
    }
}
