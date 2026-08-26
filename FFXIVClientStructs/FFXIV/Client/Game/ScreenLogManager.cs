namespace FFXIVClientStructs.FFXIV.Client.Game;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ScreenLogManager {
    [FieldOffset(0)] StdDeque<Pointer<ScreenLogEntry>> ScreenLogEntries;
    
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct ScreenLogEntry
    {
        [FieldOffset(0)] public uint ScreenLogKind;
        [FieldOffset(1 * 4 + 0)] private byte Unk1;
        [FieldOffset(1 * 4 + 1)] private byte Unk2;
        [FieldOffset(1 * 4 + 2)] private byte Unk3;
        [FieldOffset(1 * 4 + 3)] public ActionType ActionType;
        [FieldOffset(2 * 4)] public int TextParam1;
        [FieldOffset(3 * 4)] public int TextParam2;
        [FieldOffset(4 * 4)] public int TextParam3;
        [FieldOffset(5 * 4)] public int TextParam4;
        [FieldOffset(6 * 4)] public long AtTime;
    }
    
    [MemberFunction("E8 ?? ?? ?? ?? 45 85 E4 0F 84 ?? ?? ?? ?? 48 8B 0D")]
    public partial void AddScreenLogEntry(ScreenLogEntry* screenLogEntry);
}
