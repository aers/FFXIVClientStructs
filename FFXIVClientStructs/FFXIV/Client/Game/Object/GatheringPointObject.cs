using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x1E0)]
public unsafe partial struct GatheringPointObject {
    [FieldOffset(0x190)] public GatheringPointObjectImplBase ObjectImplBase;
    [FieldOffset(0x1B0)] public GatheringPointObjectImpl ObjectImpl;
    [FieldOffset(0x1D0)] public GatheringPointObjectImplBase* Impl;

    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe partial struct GatheringPointObjectImplBase {
        [FieldOffset(0x08)] public GatheringPointEventHandler* EventHandler;
        [FieldOffset(0x18)] public GatheringPointObject* Object;
    }

    [GenerateInterop]
    [Inherits<GatheringPointObjectImplBase>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe partial struct GatheringPointObjectImpl;
}
