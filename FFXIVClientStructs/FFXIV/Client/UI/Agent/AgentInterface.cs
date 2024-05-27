using FFXIVClientStructs.FFXIV.Component.GUI;
using FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentInterface
//   Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "E8 ?? ?? ?? ?? 80 63 30 80"
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
[GenerateInterop(isInherited: true)]
[Inherits<AtkEventInterface>]
public unsafe partial struct AgentInterface {
    [FieldOffset(0x10)] public UIModule* UiModule;
    [FieldOffset(0x20)] public uint AddonId;

    [VirtualFunction(0)]
    public partial void* ReceiveEvent(void* eventData, AtkValue* values, uint valueCount, ulong eventKind); // TODO: return AtkValue* and change "void* eventData" to "AtkValue* returnValue"

    [VirtualFunction(3)]
    public partial void Show();

    [VirtualFunction(4)]
    public partial void Hide();

    [VirtualFunction(5)]
    public partial bool IsAgentActive();

    [VirtualFunction(8)]
    public partial uint GetAddonId();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 6E 20")]
    public partial AgentInterface* GetAgentByInternalId(AgentId agentId);

    [MemberFunction("E8 ?? ?? ?? ?? EB 5D 44 8B C5")]
    public partial bool IsAddonReady();
}
