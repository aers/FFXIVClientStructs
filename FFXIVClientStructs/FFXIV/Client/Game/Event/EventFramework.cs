using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event {
    [StructLayout(LayoutKind.Explicit, Size = 0x3BA0)]
    public unsafe partial struct EventFramework {
        [FieldOffset(0x00)] public EventHandlerModule EventHandlerModule;
        [FieldOffset(0xC0)] public DirectorModule DirectorModule;
        [FieldOffset(0x160)] public LuaActorModule LuaActorModule;

        [StaticAddress("48 8B 35 ?? ?? ?? ?? 0F B6 EA 4C 8B F1", isPointer: true)]
        public static partial EventFramework* Instance();
    }
}
