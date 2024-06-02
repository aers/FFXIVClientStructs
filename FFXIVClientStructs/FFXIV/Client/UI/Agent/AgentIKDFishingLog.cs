namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentIKDFishingLog
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.IKDFishingLog)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x460)]
public unsafe partial struct AgentIKDFishingLog {
    [FieldOffset(0x28)] public uint RouteId;
    [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray3<uint> _spotIds;
    [FieldOffset(0x38)] public uint SpotIndex;
    [FieldOffset(0x3C)] public uint SelectedSpotIndex; // in the Potential Catch window
    [FieldOffset(0x40)] public uint Points;
    [FieldOffset(0x44)] public bool SpecialCurrent;

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray3<LogEntry> _logs;

    [FieldOffset(0x84), FixedSizeArray] internal FixedSizeArray3<PotentialCatchSpot> _potentialCatchSpots;
    [FieldOffset(0x45C)] public bool DisplayOnlyCaught;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct LogEntry {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x08)] public ushort Average;
        [FieldOffset(0x0A)] public ushort Large;
        [FieldOffset(0x0C)] public ushort Points;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x148)]
    public unsafe partial struct PotentialCatchSpot {
        [FieldOffset(0x00)] public uint SpotId;
        [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray10<LogEntry> _catchEntries;

        [FieldOffset(0xA4)] public uint SpecialSpotId;
        [FieldOffset(0xA8), FixedSizeArray] internal FixedSizeArray10<LogEntry> _specialCatchEntries;
    }
}
