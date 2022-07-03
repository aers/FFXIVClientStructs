using FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit, Size = 0x3BA0)]
public unsafe partial struct EventFramework
{
    [FieldOffset(0x00)] public EventHandlerModule EventHandlerModule;
    [FieldOffset(0xC0)] public DirectorModule DirectorModule;
    [FieldOffset(0x160)] public LuaActorModule LuaActorModule;

    [StaticAddress("48 8B 35 ?? ?? ?? ?? 0F B6 EA 4C 8B F1", isPointer: true)]
    public static partial EventFramework* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 85 C0 74 ?? 8D 43")]
    public partial InstanceContentDirector* GetInstanceContentDirector();
}