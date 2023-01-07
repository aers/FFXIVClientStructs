namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public struct EventHandlerModule
{
    [FieldOffset(0x00)] public ModuleBase ModuleBase;
    [FieldOffset(0x40)] public StdMap<uint, Pointer<EventHandler>> EventHandlerMap;
    [FieldOffset(0x50)] public StdMap<ushort, StdPair<nint, nint>> EventHandlerFactories;
}