namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x94)]
public unsafe struct AtkUldComponentDataJournalCanvas
{
    [FieldOffset(0x00)] public AtkUldComponentDataBase Base;
    [FieldOffset(0x0C)] public fixed uint Nodes[32];
    [FieldOffset(0x8C)] public ushort ItemMargin;
    [FieldOffset(0x8E)] public ushort BasicMargin;
    [FieldOffset(0x90)] public ushort AnotherMargin;
    [FieldOffset(0x92)] public ushort Padding;
}