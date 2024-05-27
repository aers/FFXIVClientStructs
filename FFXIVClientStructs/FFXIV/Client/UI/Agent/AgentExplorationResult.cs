using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.AirShipExplorationResult)]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
[GenerateInterop]
[Inherits<AgentExplorationResultInterface>]
public unsafe partial struct AgentAirshipExplorationResult {
    [FieldOffset(0x00)] public AgentExplorationResultInterface Interface;
}

[Agent(AgentId.SubmersibleExplorationResult)]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
[GenerateInterop]
[Inherits<AgentExplorationResultInterface>]
public unsafe partial struct AgentSubmersibleExplorationResult {
    [FieldOffset(0x00)] public AgentExplorationResultInterface Interface;
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
[GenerateInterop(isInherited: true)]
[Inherits<AgentInterface>]
public unsafe partial struct AgentExplorationResultInterface {
    [FieldOffset(0x28)] public uint ItemId; // fuel tank or something
    [FieldOffset(0x30)] public ExplorationResultData* Data;
}

[StructLayout(LayoutKind.Explicit, Size = 0x4F70)]
[GenerateInterop]
public unsafe partial struct ExplorationResultData {
    [FieldOffset(0x00)] [FixedSizeArray] internal FixedSizeArray151<AtkValue> _valueArray;

    [FieldOffset(0x988)] public Utf8String Rating;

    [FieldOffset(0xA00)] [FixedSizeArray] internal FixedSizeArray10<ExplorationResultDataItemReturn> _itemReturn;

    [FieldOffset(0x10E0)] public byte ItemReturnListCount;

    [FieldOffset(0x10E8)] [FixedSizeArray] internal FixedSizeArray100<Utf8String> _stringArray;

    [FieldOffset(0x3988)] [FixedSizeArray] internal FixedSizeArray100<Pointer<Utf8String>> _stringPointerArray;
    [FieldOffset(0x3CA8)] public byte StringPointerListCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct ExplorationResultDataItemReturn {
    [FieldOffset(0x00)] public uint ItemId;
    [FieldOffset(0x04)] public uint Quantity;
    [FieldOffset(0x08)] public fixed byte UnknownBytes[0xA8];
}
