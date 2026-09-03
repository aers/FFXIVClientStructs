using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[GenerateInterop]
public unsafe partial struct ScreenLog {
    [MemberFunction("C7 02 ?? ?? ?? ?? 81 F9 ?? ?? ?? ??")]
    public static partial int ConvertLogMessageIdToScreenLogKind(int logMessageId, int* unkOption);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 73 ?? 85 F6 74 ?? 8B C6")]
    public static partial void AddScreenLogMessage(Character* target, int screenLogKind, int value);

    [MemberFunction("E8 ?? ?? ?? ?? 66 85 FF 0F 84")]
    public static partial void AddLootedItemScreenLogMessage(uint itemId, uint quantity);

    [MemberFunction("E8 ?? ?? ?? ?? 45 85 E4 0F 84 ?? ?? ?? ?? 48 8B 0D")]
    public static partial void AddScreenLogEntry(StdDeque<ScreenLogEntry>* queue, ScreenLogEntry* entry);
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct ScreenLogEntry {
    [FieldOffset(0x00)] public int ScreenLogKind;
    [FieldOffset(0x04)] public ScreenLogRelationKind SourceRelation;
    [FieldOffset(0x05)] public ScreenLogRelationKind TargetRelation;
    [FieldOffset(0x06)] public byte Option;
    [FieldOffset(0x07)] public byte ActionKind;
    [FieldOffset(0x08)] public uint ActionId;
    [FieldOffset(0x0C)] public int Value1;
    [FieldOffset(0x10)] public int Value2;
    [FieldOffset(0x14)] public int Value3;
    [FieldOffset(0x18)] public ulong Timestamp;
}

public enum ScreenLogRelationKind : byte {
    LocalPlayer = 0,
    PartyMember = 1,
    Other = 2,
    Enemy = 3,
}
