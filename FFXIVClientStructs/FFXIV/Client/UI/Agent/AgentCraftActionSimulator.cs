namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentCraftActionSimulator
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.CraftActionSimulator)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AgentCraftActionSimulator {
    [FieldOffset(0x28)] public ProgressEfficiencyCalculations* Progress; // Progress tab of the Efficiency Calculations window.
    [FieldOffset(0x40)] public QualityEfficiencyCalculations* Quality; // Quality tab of the Efficiency Calculations window.
}

[StructLayout(LayoutKind.Explicit, Size = 0x00e0)]
public struct ProgressEfficiencyCalculations {
    [FieldOffset(0x00)] public ProgressEfficiencyCalculation BasicSynthesis;
    [FieldOffset(0x1C)] public ProgressEfficiencyCalculation RapidSynthesis;
    [FieldOffset(0x38)] public ProgressEfficiencyCalculation MuscleMemory;
    [FieldOffset(0x54)] public ProgressEfficiencyCalculation CarefulSynthesis;
    [FieldOffset(0x70)] public ProgressEfficiencyCalculation Groundwork;
    [FieldOffset(0x8C)] public ProgressEfficiencyCalculation DelicateSynthesis;
    [FieldOffset(0xA8)] public ProgressEfficiencyCalculation IntensiveSynthesis;
    [FieldOffset(0xC4)] public ProgressEfficiencyCalculation PrudentSynthesis;
}

[StructLayout(LayoutKind.Explicit, Size = 0x01a4)]
public struct QualityEfficiencyCalculations {
    [FieldOffset(0x000)] public QualityEfficiencyCalculation BasicTouch;
    [FieldOffset(0x01C)] public QualityEfficiencyCalculation HastyTouch;
    [FieldOffset(0x038)] public QualityEfficiencyCalculation StandardTouch;
    [FieldOffset(0x054)] public QualityEfficiencyCalculation ByregotsBlessing;
    [FieldOffset(0x070)] public QualityEfficiencyCalculation PreciseTouch;
    [FieldOffset(0x08C)] public QualityEfficiencyCalculation PrudentTouch;
    [FieldOffset(0x0A8)] public QualityEfficiencyCalculation AdvancedTouch;
    [FieldOffset(0x0C4)] public QualityEfficiencyCalculation Reflect;
    [FieldOffset(0x0E0)] public QualityEfficiencyCalculation PreparatoryTouch;
    [FieldOffset(0x0FC)] public QualityEfficiencyCalculation DelicateSynthesis;
    [FieldOffset(0x118)] public QualityEfficiencyCalculation TrainedEye;
    [FieldOffset(0x150)] public QualityEfficiencyCalculation TrainedFinesse;
    // [FieldOffset(0x16C)] public QualityEfficiencyCalculation RefinedTouch;
    // [FieldOffset(0x188)] public QualityEfficiencyCalculation DaringTouch;
}

// It looks like all efficiency calculations are represented by the same struct,
// but they each only use certain fields, so I broke it into 2 distinct structs.
// Left this here as a template.
[StructLayout(LayoutKind.Explicit, Size = 0x001C)]
public struct EfficiencyCalculation {
    [FieldOffset(0x04)] public uint ActionId;

    [FieldOffset(0x08)] public uint ProgressEfficiency;
    [FieldOffset(0x0C)] public uint ProgressIncrease;

    [FieldOffset(0x10)] public uint QualityEfficiencyPercentage;
    [FieldOffset(0x14)] public uint QualityIncrease;

    //[FieldOffset(0x14)] public byte ;
    //[FieldOffset(0x15)] public byte ;
    [FieldOffset(0x1A)] public ActionStatus Status;
    //[FieldOffset(0x17)] public byte ;
}

[StructLayout(LayoutKind.Explicit, Size = 0x001C)]
public struct ProgressEfficiencyCalculation {
    [FieldOffset(0x04)] public uint ActionId;
    [FieldOffset(0x08)] public uint ProgressEfficiency;
    [FieldOffset(0x0C)] public uint ProgressIncrease;
    [FieldOffset(0x1A)] public ActionStatus Status;
}

[StructLayout(LayoutKind.Explicit, Size = 0x001C)]
public struct QualityEfficiencyCalculation {
    [FieldOffset(0x04)] public uint ActionId;
    [FieldOffset(0x10)] public uint QualityEfficiencyPercentage;
    [FieldOffset(0x14)] public uint QualityIncrease;
    [FieldOffset(0x1A)] public ActionStatus Status;
}

public enum ActionStatus : byte {
    Available = 0x0,
    NotYetAvailable = 0x1, // You have not yet learned this action, such as when you haven't reached the required level or completed the class mission.
    NotCurrentlyAvailable = 0x3, // This action cannot be used at this time, such as MuscleMemory on any step but 1, PreciseTouch when quality isn't Good/Excellent.
}
