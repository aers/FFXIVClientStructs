namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentReconstructionBox
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ReconstructionBox)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x240)]
public unsafe partial struct AgentReconstructionBox {
    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray10<ReconstructionBoxItemDonation> _donatedItems;

    [FieldOffset(0x21C)] public int LimitedTotal; // Actual Donation amount if it exceeds weekly budget
    [FieldOffset(0x220)] public int UnlimitedTotal; // Total attempted donation amount, can exceed weekly budget
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct ReconstructionBoxItemDonation;
