using AtkEventInterface = FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface.AtkEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentInterface
//   Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "E8 ?? ?? ?? ?? 80 63 30 80"
[GenerateInterop(isInherited: true)]
[Inherits<AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AgentInterface {
    [FieldOffset(0x10)] public UIModuleInterface* UIModuleInterface;
    [FieldOffset(0x20)] public uint AddonId;

    [VirtualFunction(2)]
    public partial void Dtor(bool free);

    [VirtualFunction(3)]
    public partial void Show();

    [VirtualFunction(4)]
    public partial void Hide();

    [VirtualFunction(5)]
    public partial bool IsAgentActive();

    [VirtualFunction(6)]
    public partial void Update(uint frameCount);

    /// <summary>
    /// Checks if the Agent can be activated.<br/>
    /// This may be based on conditions, unlock state, completed quests or simply if the corresponding main command is enabled.
    /// </summary>
    [VirtualFunction(7)]
    public partial bool IsActivatable();

    [VirtualFunction(8)]
    public partial uint GetAddonId();

    [VirtualFunction(9)]
    public partial void OnGameEvent(GameEvent gameEvent);

    [VirtualFunction(10)]
    public partial void OnLevelChange(byte classJobId, ushort level);

    [VirtualFunction(11)]
    public partial void OnClassJobChange(byte classJobId);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 6E 20")]
    public partial AgentInterface* GetAgentByInternalId(AgentId agentId);

    [MemberFunction("E8 ?? ?? ?? ?? EB 5D 44 8B C5")]
    public partial bool IsAddonReady();

    public enum GameEvent {
        LoggedIn,
        LoadingEnded, // UI shown
        LoadingStarted, // UI hidden
        LoggedOut,
        Unk4,
        Unk5, // Entering Duty?
        Unk6, // Entering Duty?
        Unk7, // Leaving Duty?
        Unk8
    }
}
