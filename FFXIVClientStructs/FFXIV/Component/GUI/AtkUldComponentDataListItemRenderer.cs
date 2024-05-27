namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct AtkUldComponentDataListItemRenderer {
    [FieldOffset(0x0C)] public fixed uint Nodes[4];
    [FieldOffset(0x1C)] public byte CanToggle;
}
