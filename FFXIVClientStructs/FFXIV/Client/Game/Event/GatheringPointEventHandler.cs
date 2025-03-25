namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[GenerateInterop]
[Inherits<GatheringEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x4A8)]
public unsafe partial struct GatheringPointEventHandler {
    [FieldOffset(0x475)] public bool QuickGatheringEnabled;
}
