namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct TimeLineLayoutInstance {
    [FieldOffset(0x38)] public SharedGroupLayoutInstance* Child;
    [FieldOffset(0x40)] public uint Crc;
}
