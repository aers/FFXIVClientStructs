namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::LuaActorModule
//   Client::Game::Event::ModuleBase
[GenerateInterop]
[Inherits<ModuleBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public partial struct LuaActorModule {
    [FieldOffset(0x40)] public StdMap<ulong, Pointer<LuaActor>> ActorMap;
}
