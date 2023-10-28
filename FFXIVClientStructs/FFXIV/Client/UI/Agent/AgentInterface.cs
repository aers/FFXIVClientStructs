using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentInterface
//   Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "E8 ?? ?? ?? ?? 80 63 30 80"
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AgentInterface {
    [FieldOffset(0x0)] public AtkEventInterface AtkEventInterface;
    [FieldOffset(0x10)] public UIModule* UiModule;
    [FieldOffset(0x20)] public uint AddonId;


    [VirtualFunction(0)]
    public partial void* ReceiveEvent(void* eventData, AtkValue* values, uint valueCount, ulong eventKind);

    [VirtualFunction(3)]
    public partial void Show();

    [VirtualFunction(4)]
    public partial void Hide();

    [VirtualFunction(5)]
    public partial bool IsAgentActive();

    [VirtualFunction(8)]
    public partial uint GetAddonID();
}
