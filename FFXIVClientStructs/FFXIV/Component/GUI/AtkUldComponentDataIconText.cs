namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public unsafe partial struct AtkUldComponentDataIconText {
    [FieldOffset(0x0C)] public fixed uint Nodes[2];
}
