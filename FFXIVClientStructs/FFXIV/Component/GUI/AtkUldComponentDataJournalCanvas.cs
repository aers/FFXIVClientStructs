namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x94)]
public unsafe partial struct AtkUldComponentDataJournalCanvas {
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray32<uint> _nodes;
    [FieldOffset(0x8C)] public ushort ItemMargin;
    [FieldOffset(0x8E)] public ushort BasicMargin;
    [FieldOffset(0x90)] public ushort AnotherMargin;
    [FieldOffset(0x92)] public ushort Padding;
}
