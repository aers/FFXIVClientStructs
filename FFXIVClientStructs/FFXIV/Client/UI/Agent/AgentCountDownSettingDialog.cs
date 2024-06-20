namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentCountDownSettingDialog
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.CountDownSettingDialog)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct AgentCountDownSettingDialog {
    [FieldOffset(0x28)] public float TimeRemaining;
    [FieldOffset(0x2C)] public float PrevTimeRemaining;
    [FieldOffset(0x30)] public uint ConfirmAddonId;
    [FieldOffset(0x34)] public uint CountdownAddonId;
    [FieldOffset(0x38)] public bool Active;
    [FieldOffset(0x3C)] public uint InitiatorId;
    [FieldOffset(0x40)] public bool ShowingCountdown;
}
