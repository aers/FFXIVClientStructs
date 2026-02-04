namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MKDLoreBook)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe partial struct AgentMKDLoreBook {
    [FieldOffset(0xC8)] public StdVector<LoreEntry> LoreEntries;
    [FieldOffset(0xE1)] public byte SelectedLoreId;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xF8)]
    public partial struct LoreEntry {
        [FieldOffset(0x00)] public byte Id;
        [FieldOffset(0x04 + 0x00), CExporterExcelBegin("MKDLore")] private uint NameOffset;
        [FieldOffset(0x04 + 0x04)] private uint DescriptionOffset;
        [FieldOffset(0x04 + 0x08)] public uint UnlockLink;
        [FieldOffset(0x04 + 0x0C)] public uint Icon;
        [FieldOffset(0x04 + 0x10)] public uint LayoutId; // InstanceType.EventObject
        [FieldOffset(0x04 + 0x14)] private byte Unknown5;
        [FieldOffset(0x04 + 0x15), CExporterExcelEnd] private byte Unknown6;
        [FieldOffset(0x20)] public Utf8String Name;
        [FieldOffset(0x88)] public Utf8String Description;
        [BitField<bool>(nameof(Unlocked), 0)]
        [FieldOffset(0xF0)] public byte Flags;
    }
}
