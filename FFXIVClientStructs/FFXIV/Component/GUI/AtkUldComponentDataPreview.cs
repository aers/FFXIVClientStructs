namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public unsafe partial struct AtkUldComponentDataPreview {
    // [0] TextNode
    // [1] ImageNode
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray2<uint> _nodes;
}
