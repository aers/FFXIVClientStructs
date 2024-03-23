namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventHandlerModule
//   Client::Game::Event::ModuleBase
// ctor "E8 ?? ?? ?? ?? 48 8B 15 ?? ?? ?? ?? 49 8D 8D ?? ?? ?? ?? 48 81 C2 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 15"
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe struct EventHandlerModule {
    [FieldOffset(0x00)] public ModuleBase ModuleBase;
    [FieldOffset(0x40)] public StdMap<uint, Pointer<EventHandler>> EventHandlerMap;
    [FieldOffset(0x50)] public StdMap<ushort, StdPair<nint, nint>> EventHandlerFactories;
    [FieldOffset(0x60)] public CraftEventHandler* CraftEventHandler; // 0xA0001
    [FieldOffset(0x68)] public EventHandler* CraftLeveEventHandler; // 0xE0000
    [FieldOffset(0x70)] public EventHandler* FishingEventHandler; // 0x150001
    [FieldOffset(0x78)] public EventHandler* ExitRangeEventHandler; // 0x140001
    [FieldOffset(0x80)] public EventHandler* TripleTriadEventHandler; // 0x230001
    [FieldOffset(0x88)] public EventHandler* GroupPoseEventHandler; // 0xB0129
    [FieldOffset(0x90)] public EventHandler* IdleCameraEventHandler; // 0xB0130
}
