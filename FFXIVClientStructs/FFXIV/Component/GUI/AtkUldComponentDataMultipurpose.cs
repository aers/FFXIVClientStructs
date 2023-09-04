namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct AtkUldComponentDataMultipurpose {
    [FieldOffset(0x00)] public AtkUldComponentDataBase Base;
    [FieldOffset(0x0C)] public fixed uint Nodes[3];
}
