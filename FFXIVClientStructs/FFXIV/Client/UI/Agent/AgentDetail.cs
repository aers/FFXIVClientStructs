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

    // Don't use these, as they are probably used for SocialDetail.
    // See functions in PlayerState if you want to check these.
    [FieldOffset(0x41)] internal bool IsBattleMentor;
    [FieldOffset(0x42)] internal bool IsTradeMentor;
    [FieldOffset(0x43)] internal bool IsReturner;

    /// <summary>
    /// Opens the SocialDetail addon.
    /// </summary>
    /// <param name="characterData">
    /// A pointer to the data of the character.
    /// </param>
    /// <param name="updateDataPacket">
    /// A pointer to <see cref="InfoProxySearchComment.UpdateData"/>.<br/>
    /// If set, used to open the editor version of the Social Info window as it will write to this on save.<br/>
    /// Pass <c>null</c> for other players, so it just opens the viewer.
    /// </param>
    /// <param name="ownerAddonId">
    /// The owner addon id, used to position the window.<br/>
    /// Can be 0, but will open slightly off-center.
    /// </param>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? BE ?? ?? ?? ??")]
    public partial void OpenForCharacterData(InfoProxyCommonList.CharacterData* characterData, InfoProxySearchComment.UpdateDataPacket* updateDataPacket = null, int ownerAddonId = 0);
}
