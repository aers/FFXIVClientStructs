using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
public unsafe partial struct GatheringPointObject {
    [FieldOffset(0x1A0)] public GatheringPointObjectImplBase ObjectImplBase;
    [FieldOffset(0x1C0)] public GatheringPointObjectImpl ObjectImpl;
    [FieldOffset(0x1E0)] public GatheringPointObjectImplBase* Impl;

    /// <summary>This takes care of adding a child AVFX object and everything.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? 8B 57")]
    public partial void Setup();

    [GenerateInterop(isInherited: true)]
    [VirtualTable("48 8D 0D ?? ?? ?? ?? 48 8D 87", 3, 14)]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe partial struct GatheringPointObjectImplBase {
        [FieldOffset(0x08)] public GatheringPointEventHandler* EventHandler;
        [FieldOffset(0x10)] public byte RemainingCount;
        [FieldOffset(0x14)] private bool Unk14;
        [FieldOffset(0x15)] private bool Unk15;
        [FieldOffset(0x16)] private byte Unk16;

        [FieldOffset(0x18)] public GatheringPointObject* Object;

        [VirtualFunction(4)]
        public partial GatheringType GetGatheringType();

        [VirtualFunction(12)]
        public partial CStringPointer GetName();
    }

    [GenerateInterop]
    [Inherits<GatheringPointObjectImplBase>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe partial struct GatheringPointObjectImpl;
}
