namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[GenerateInterop]
[Inherits<GatheringEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x470)]
public unsafe partial struct GatheringPointEventHandler {
    [FieldOffset(0x46D)] public bool QuickGatheringEnabled;
}
