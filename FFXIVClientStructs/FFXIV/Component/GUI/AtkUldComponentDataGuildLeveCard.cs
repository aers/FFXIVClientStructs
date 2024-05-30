namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public unsafe partial struct AtkUldComponentDataGuildLeveCard {
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray3<uint> _nodes;
}
