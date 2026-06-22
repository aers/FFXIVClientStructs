namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

[GenerateInterop(isInherited: true)]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public partial struct RangeLayoutInstance {
    [FieldOffset(0x30)] public Transform Transform;
    [FieldOffset(0x60)] private uint Unk60;
}

[GenerateInterop]
[Inherits<RangeLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public partial struct DoorRangeLayoutInstance;
