using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

//Client::UI::Agent::AgentCraftActionSimulator
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.CraftActionSimulator)]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe struct AgentCraftActionSimulator
{
    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0x28)] public ProgressEfficiencyCalculations* Progress; // Progress tab of the Efficiency Calculations window.
    [FieldOffset(0x40)] public QualityEfficiencyCalculations* Quality; // Quality tab of the Efficiency Calculations window.

    public static AgentCraftActionSimulator* Instance() =>
        (AgentCraftActionSimulator*)Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.CraftActionSimulator);
}

[StructLayout(LayoutKind.Explicit, Size = 0x0108)]
public struct ProgressEfficiencyCalculations
{
    [FieldOffset(0x00)] public ProgressEfficiencyCalculation BasicSynthesis;
    [FieldOffset(0x18)] public ProgressEfficiencyCalculation RapidSynthesis;
    [FieldOffset(0x30)] public ProgressEfficiencyCalculation MuscleMemory;
    [FieldOffset(0x48)] public ProgressEfficiencyCalculation CarefulSynthesis;
    [FieldOffset(0x60)] public ProgressEfficiencyCalculation FocusedSynthesis;
    [FieldOffset(0x78)] public ProgressEfficiencyCalculation Groundwork;
    [FieldOffset(0x90)] public ProgressEfficiencyCalculation DelicateSynthesis;
    [FieldOffset(0xA8)] public ProgressEfficiencyCalculation IntensiveSynthesis;
    [FieldOffset(0xC0)] public ProgressEfficiencyCalculation PrudentSynthesis;
}

[StructLayout(LayoutKind.Explicit, Size = 0x0138)]
public struct QualityEfficiencyCalculations
{
    [FieldOffset(0x000)] public QualityEfficiencyCalculation BasicTouch;
    [FieldOffset(0x018)] public QualityEfficiencyCalculation HastyTouch;
    [FieldOffset(0x030)] public QualityEfficiencyCalculation StandardTouch;
    [FieldOffset(0x048)] public QualityEfficiencyCalculation ByregotsBlessing;
    [FieldOffset(0x060)] public QualityEfficiencyCalculation PreciseTouch;
    [FieldOffset(0x078)] public QualityEfficiencyCalculation PrudentTouch;
    [FieldOffset(0x090)] public QualityEfficiencyCalculation FocusedTouch;
    [FieldOffset(0x0A8)] public QualityEfficiencyCalculation Reflect;
    [FieldOffset(0x0C0)] public QualityEfficiencyCalculation PreparatoryTouch;
    [FieldOffset(0x0D8)] public QualityEfficiencyCalculation DelicateSynthesis;
    [FieldOffset(0x0F0)] public QualityEfficiencyCalculation TrainedEye;
    [FieldOffset(0x108)] public QualityEfficiencyCalculation AdvancedTouch;
    [FieldOffset(0x120)] public QualityEfficiencyCalculation TrainedFinesse;
}

// It looks like all efficiency calculations are represented by the same struct,
// but they each only use certain fields, so I broke it into 2 distinct structs.
// Left this here as a template.
[StructLayout(LayoutKind.Explicit, Size = 0x0018)]
public struct EfficiencyCalculation
{
    [FieldOffset(0x00)] public uint ActionId;

    [FieldOffset(0x04)] public uint ProgressEfficiency;
    [FieldOffset(0x08)] public uint ProgressIncrease;

    [FieldOffset(0x0C)] public uint QualityEfficiencyPercentage;
    [FieldOffset(0x10)] public uint QualityIncrease;

    //[FieldOffset(0x14)] public byte ;
    //[FieldOffset(0x15)] public byte ;
    [FieldOffset(0x16)] public ActionStatus Status;
    //[FieldOffset(0x17)] public byte ;
}

[StructLayout(LayoutKind.Explicit, Size = 0x0018)]
public struct ProgressEfficiencyCalculation
{
    [FieldOffset(0x00)] public uint ActionId;
    [FieldOffset(0x04)] public uint ProgressEfficiency;
    [FieldOffset(0x08)] public uint ProgressIncrease;
    [FieldOffset(0x16)] public ActionStatus Status;
}

[StructLayout(LayoutKind.Explicit, Size = 0x0018)]
public struct QualityEfficiencyCalculation
{
    [FieldOffset(0x00)] public uint ActionId;
    [FieldOffset(0x0C)] public uint QualityEfficiencyPercentage;
    [FieldOffset(0x10)] public uint QualityIncrease;
    [FieldOffset(0x16)] public ActionStatus Status;
}

public enum ActionStatus : byte
{
    Available = 0x0,
    NotYetAvailable = 0x1, // You have not yet learned this action, such as when you haven't reached the required level or completed the class mission.
    NotCurrentlyAvailable = 0x3, // This action cannot be used at this time, such as MuscleMemory on any step but 1, PreciseTouch when quality isn't Good/Excellent.
}