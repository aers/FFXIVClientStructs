namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::LuaActorModule
//   Client::Game::Event::ModuleBase
// ctor "E8 ?? ?? ?? ?? 49 8D 8D ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 F6 49 8D 8D"
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
[GenerateInterop]
[Inherits<ModuleBase>]
public partial struct LuaActorModule {
    [FieldOffset(0x40)] public StdMap<long, LuaActor> ActorMap;
}
