using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.AirShipExplorationResult)]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentAirshipExplorationResult {
    [FieldOffset(0x00)] public AgentExplorationResultInterface Interface;
}

[Agent(AgentId.SubmersibleExplorationResult)]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentSubmersibleExplorationResult {
    [FieldOffset(0x00)] public AgentExplorationResultInterface Interface;
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct AgentExplorationResultInterface {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public uint ItemId; // fuel tank or something
    [FieldOffset(0x30)] public ExplorationResultData* Data;
}

[StructLayout(LayoutKind.Explicit, Size = 0x4F70)]
public unsafe partial struct ExplorationResultData {
    [FixedSizeArray<AtkValue>(151)]
    [FieldOffset(0x00)] public fixed byte ValueArray[0x10 * 151];

    [FieldOffset(0x988)] public Utf8String Rating;

    [FixedSizeArray<ExplorationResultDataItemReturn>(10)]
    [FieldOffset(0xA00)] public fixed byte ItemReturn[0xB0 * 10];

    [FieldOffset(0x10E0)] public byte ItemReturnListCount;

    [FixedSizeArray<Utf8String>(100)]
    [FieldOffset(0x10E8)] public fixed byte StringArray[0x68 * 100];

    [FixedSizeArray<Pointer<Utf8String>>(100)]
    [FieldOffset(0x3988)] public fixed byte StringPointerArray[0x8 * 100];
    [FieldOffset(0x3CA8)] public byte StringPointerListCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct ExplorationResultDataItemReturn {
    [FieldOffset(0x00)] public uint ItemId;
    [FieldOffset(0x04)] public uint Quantity;
    [FieldOffset(0x08)] public fixed byte UnknownBytes[0xA8];
}
