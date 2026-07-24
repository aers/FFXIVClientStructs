namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct AtkUldComponentDataXBMItem {
    [FieldOffset(0x0C)] public uint IconComponentNodeId;
    [FieldOffset(0x10)] public uint NameTextNodeId;
    [FieldOffset(0x14)] public uint TypeTextNodeId;
    [FieldOffset(0x18)] public uint DescriptionTextNodeId;
}
