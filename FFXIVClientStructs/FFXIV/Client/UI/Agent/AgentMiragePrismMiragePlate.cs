namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MiragePrismMiragePlate)]
[StructLayout(LayoutKind.Explicit, Size = 0x350)]
public unsafe partial struct AgentMiragePrismMiragePlate {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FixedSizeArray<MiragePlateItem>(14)]
    [FieldOffset(0x148)] public unsafe fixed byte PlateItems[14 * 0x20]; // 14 * MiragePlateItem
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct MiragePlateItem {
    // 00: Main
    // 01: Offhand
    // 02: Head
    // 03: Body
    // 04: Hands
    // 05: Waist
    // 06: Legs
    // 07: Feet
    // 08: Ears
    // 09: Neck
    // 0A: Wrist
    // 0B: Right Ring
    // 0C: Left Ring
    // 0D: Undefined
    // 0E: Empty
    [FieldOffset(0x00)] public byte EquipType;
    [FieldOffset(0x01)] public byte EquipSlotCategory;
    // [FieldOffset(0x02)] public byte EquipSlotCategory2;
    [FieldOffset(0x03)] public byte Stain;
    // [FieldOffset(0x04)] public byte Stain2;
    [FieldOffset(0x08)] public uint ItemId;
    [FieldOffset(0x10)] public ulong ModelMain;
    [FieldOffset(0x18)] public ulong ModelSub;
}
