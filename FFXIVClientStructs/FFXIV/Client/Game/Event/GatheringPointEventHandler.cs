namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[GenerateInterop]
[Inherits<GatheringEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x448)]
public unsafe partial struct GatheringPointEventHandler {
    [FieldOffset(0x445)] public bool QuickGatheringEnabled;
}
