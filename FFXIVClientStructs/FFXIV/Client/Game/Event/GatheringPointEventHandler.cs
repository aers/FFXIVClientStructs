namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[GenerateInterop]
[Inherits<GatheringEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x448)]
public unsafe partial struct GatheringPointEventHandler {
    [FieldOffset(0x4A5)] public bool QuickGatheringEnabled;
}
