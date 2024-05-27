namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x34)]
public unsafe partial struct AtkUldComponentDataMap {
    [FieldOffset(0x0C)] public fixed uint Nodes[10];
}
