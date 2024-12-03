namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyPartyMember
//   Client::UI::Info::InfoProxyCommonList
//     Client::UI::Info::InfoProxyPageInterface
//       Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.PartyMember)]
[GenerateInterop]
[Inherits<InfoProxyCommonList>]
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct InfoProxyPartyMember {
    /// <summary>
    /// Changes the order of the party members in the party list.
    /// </summary>
    /// <param name="selectedIndex">The person you want to change order of. Has to be lower than <paramref name="targetIndex"/></param>
    /// <param name="targetIndex">Where you want them to end up.</param>
    /// <param name="doUpdate">Runs some update function.</param>
    [MemberFunction("E8 ?? ?? ?? ?? B3 01 88 5C 24 60")]
    public partial void ChangeOrder(int selectedIndex, int targetIndex, bool doUpdate = true);
}
