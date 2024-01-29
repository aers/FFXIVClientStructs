namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventHandlerModule
//   Client::Game::Event::ModuleBase
// ctor "E8 ?? ?? ?? ?? 48 8B 15 ?? ?? ?? ?? 49 8D 8D ?? ?? ?? ?? 48 81 C2 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 15"
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public struct EventHandlerModule {
    [FieldOffset(0x00)] public ModuleBase ModuleBase;
    [FieldOffset(0x40)] public StdMap<uint, Pointer<EventHandler>> EventHandlerMap;
    [FieldOffset(0x50)] public StdMap<ushort, StdPair<nint, nint>> EventHandlerFactories;
}
