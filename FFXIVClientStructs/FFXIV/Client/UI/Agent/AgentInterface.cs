using static FFXIVClientStructs.FFXIV.Component.GUI.AtkUnitManager;
using AtkEventInterface = FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface.AtkEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentInterface
//   Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "E8 ?? ?? ?? ?? 80 63 30 80"
[GenerateInterop(isInherited: true)]
[Inherits<AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AgentInterface {
    [FieldOffset(0x08)] private bool Unk8; // seen in AtkModule.HandleAddonCallback
    [FieldOffset(0x10)] public UIModuleInterface* UIModuleInterface;
    [FieldOffset(0x20)] public uint AddonId;

    [VirtualFunction(2)]
    public partial void Dtor(bool free);

    [VirtualFunction(3)]
    public partial void Show();

    [VirtualFunction(5)]
    public partial void Hide();

    [VirtualFunction(6)]
    public partial bool IsAgentActive();

    [VirtualFunction(7)]
    public partial void Update(uint frameCount);

    /// <summary>
    /// Checks if the Agent can be activated.<br/>
    /// This may be based on conditions, unlock state, completed quests or simply if the corresponding main command is enabled.
    /// </summary>
    [VirtualFunction(8)]
    public partial bool IsActivatable();

    [VirtualFunction(9)]
    public partial uint GetAddonId();

    [VirtualFunction(10)]
    public partial void OnGameEvent(GameEvent gameEvent);

    [VirtualFunction(11)]
    public partial void OnLevelChange(byte classJobId, ushort level);

    [VirtualFunction(12)]
    public partial void OnClassJobChange(byte classJobId);

    [MemberFunction("E8 ?? ?? ?? ?? 44 85 FF")]
    public partial AgentInterface* GetAgentByInternalId(AgentId agentId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 7E 4B")]
    public partial bool IsAddonReady();

    [MemberFunction("E8 ?? ?? ?? ?? 45 84 ED 74 1A")]
    public partial void ShowAddon();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 7D 40")]
    public partial void HideAddon();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 05 41 B4 01")]
    public partial bool IsAddonShown();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 1A 49 8B CF")]
    public partial bool IsAddonHidden();

    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 04 74 40")]
    public partial AddonStatus GetAddonStatus();

    [MemberFunction("E8 ?? ?? ?? ?? EB 08 8B 55 97")]
    public partial bool FocusAddon();

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
