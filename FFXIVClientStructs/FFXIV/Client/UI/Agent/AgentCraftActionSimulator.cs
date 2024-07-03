namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentCraftActionSimulator
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.CraftActionSimulator)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct AgentCraftActionSimulator {
    [FieldOffset(0x28)] public StdVector<EfficiencyCalculation> Progress;
    [FieldOffset(0x40)] public StdVector<EfficiencyCalculation> Quality;
    [FieldOffset(0x58)] public int SelectedTabIndex;
    [FieldOffset(0x5C)] public int ContextSelectIndex;
    [FieldOffset(0x60)] public uint ContextSelectedActionId;

    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public unsafe partial struct EfficiencyCalculation {
        [FieldOffset(0x00)] public uint BaseActionId;
        [FieldOffset(0x04)] public uint ActionId;
        [FieldOffset(0x08)] public ushort ProgressEfficiency;
        [FieldOffset(0x0C)] public uint ProgressIncrease;
        [FieldOffset(0x10)] public ushort QualityEfficiency;
        [FieldOffset(0x14)] public uint QualityIncrease;
        // [FieldOffset(0x18)] public byte ;
        // [FieldOffset(0x19)] public byte ;
        [FieldOffset(0x1A)] public SimulatorActionStatus ActionStatus;
    }
}

public enum SimulatorActionStatus : byte {
    Available = 0x0,
    NotYetAvailable = 0x1, // You have not yet learned this action, such as when you haven't reached the required level or completed the class mission.
    NotCurrentlyAvailable = 0x3, // This action cannot be used at this time, such as MuscleMemory on any step but 1, PreciseTouch when quality isn't Good/Excellent.
}
