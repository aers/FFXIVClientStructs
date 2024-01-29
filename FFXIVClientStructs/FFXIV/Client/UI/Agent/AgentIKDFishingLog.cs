using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.IKDFishingLog)]
[StructLayout(LayoutKind.Explicit, Size = 0x460)]
public unsafe partial struct AgentIKDFishingLog {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x28)] public uint RouteId;
    [FieldOffset(0x2C)] public fixed uint SpotId[3];
    [FieldOffset(0x38)] public uint SpotIndex;
    [FieldOffset(0x3C)] public uint SelectedSpotIndex; // in the Potential Catch window
    [FieldOffset(0x40)] public uint Points;
    [FieldOffset(0x44)] public bool SpecialCurrent;

    [FixedSizeArray<LogEntry>(3)]
    [FieldOffset(0x48)] public fixed byte Log[3 * 0x10];

    [FixedSizeArray<PotentialCatchSpot>(3)]
    [FieldOffset(0x84)] public fixed byte PotentialCatchSpots[3 * 0x148];

    [FieldOffset(0x45C)] public bool DisplayOnlyCaught;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct LogEntry {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x08)] public ushort Average;
        [FieldOffset(0x0A)] public ushort Large;
        [FieldOffset(0x0C)] public ushort Points;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x148)]
    public unsafe partial struct PotentialCatchSpot {
        [FieldOffset(0x00)] public uint SpotId;
        [FixedSizeArray<LogEntry>(10)]
        [FieldOffset(0x04)] public fixed byte CatchEntries[10 * 0x10];

        [FieldOffset(0xA4)] public uint SpecialSpotId;
        [FixedSizeArray<LogEntry>(10)]
        [FieldOffset(0xA8)] public fixed byte SpecialCatchEntries[10 * 0x10];
    }
}
