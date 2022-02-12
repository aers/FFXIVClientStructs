namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public struct LuaActorModule
{
    [FieldOffset(0x00)] public ModuleBase ModuleBase;
    [FieldOffset(0x40)] public StdMap<long, LuaActor> ActorMap;
}