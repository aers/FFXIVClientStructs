namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct AtkUldComponentDataDragDrop
{
    [FieldOffset(0x00)] public AtkUldComponentDataBase Base;
    [FieldOffset(0x0C)] public fixed uint Nodes[1];
}