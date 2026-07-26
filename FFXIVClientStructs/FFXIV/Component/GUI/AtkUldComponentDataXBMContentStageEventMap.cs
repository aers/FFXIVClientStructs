namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct AtkUldComponentDataXBMContentStageEventMap {
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray5<uint> _templateNodeIds;
}
