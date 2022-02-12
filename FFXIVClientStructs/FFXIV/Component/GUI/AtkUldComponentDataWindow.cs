namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct AtkUldComponentDataWindow
{
    [FieldOffset(0x00)] public AtkUldComponentDataBase Base;
    [FieldOffset(0x0C)] public fixed uint Nodes[8];
    [FieldOffset(0x2C)] public uint TitleTextId;
    [FieldOffset(0x30)] public uint SubtitleTextId;
    [FieldOffset(0x34)] public byte ShowCloseButton;
    [FieldOffset(0x35)] public byte ShowConfigButton;
    [FieldOffset(0x36)] public byte ShowHelpButton;
    [FieldOffset(0x37)] public byte ShowHeader;
}