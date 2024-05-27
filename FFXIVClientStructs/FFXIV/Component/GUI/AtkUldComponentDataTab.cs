namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x24)]
public unsafe partial struct AtkUldComponentDataTab {
    [FieldOffset(0x0C)] public fixed uint Nodes[4];
    [FieldOffset(0x1C)] public uint TextId;
    [FieldOffset(0x20)] public uint GroupId;
}
