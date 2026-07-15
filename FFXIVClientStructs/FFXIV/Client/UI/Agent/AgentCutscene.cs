using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentCutscene
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Cutscene)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x128)]
public unsafe partial struct AgentCutscene {
    [FieldOffset(0x30)] public uint SkipDialogAddonId;
    [FieldOffset(0x38)] public AtkModuleInterface.AtkEventInterface* SkipCallback;

    [MemberFunction("4C 8B DC 56 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 83 79 ?? 00 48 8B F1 0F 87")]
    public partial bool OpenSkipDialog(AtkModuleInterface.AtkEventInterface* callback);
}
