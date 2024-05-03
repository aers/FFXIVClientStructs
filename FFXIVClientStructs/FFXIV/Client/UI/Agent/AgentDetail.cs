using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentDetail
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Detail)]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct AgentDetail {
    [FieldOffset(0)] public AgentInterface AgentInterface;

    [FieldOffset(0x30)] public InfoProxySearchComment* InfoProxySearchCommentPtr;

    [FieldOffset(0x41)] public bool IsBattleMentor;
    [FieldOffset(0x42)] public bool IsTradeMentor;
    [FieldOffset(0x43)] public bool IsReturner;

    /// <summary>
    /// Opens the SocialDetail addon.
    /// </summary>
    /// <param name="characterData">
    /// A pointer to the data of the character.
    /// </param>
    /// <param name="infoProxySearchComment28">
    /// A pointer to <see cref="InfoProxySearchComment"/>+0x28.<br/>
    /// Used open the editor version of the Social Info window as it will write to this on save.<br/>
    /// Pass 0 for other players, so it just opens the viewer.
    /// </param>
    /// <param name="ownerAddonId">
    /// The owner addon id, used to position the window.<br/>
    /// Can be 0, but will open slightly off-center.
    /// </param>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? BE ?? ?? ?? ??")]
    public partial void OpenForCharacterData(InfoProxyCommonList.CharacterData* characterData, nint infoProxySearchComment28 = 0, int ownerAddonId = 0);
}
