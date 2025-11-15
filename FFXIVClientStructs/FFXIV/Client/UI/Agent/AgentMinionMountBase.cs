namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMinionMountBase
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop(isInherited: true)]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public partial struct AgentMinionMountBase {
    [FieldOffset(0x40)] public AddonMinionMountBase.ViewType ViewType;

    /// <summary>
    /// RowId from Mount / Minion Excel Sheet for the currently selected item in MountNotebook or MinionNoteBook
    /// while in viewType == ViewType.Favorites.
    /// </summary>
    ///
    /// <remarks>
    /// Will still update its value while in Normal and Search view, but it will not be what the user is actually selecting.
    ///
    /// It is basically doing FavoriteIds[index], and the index is updating in both Normal and Favorite View.
    /// </remarks>
    [FieldOffset(0x50)] public ushort SelectedIdInFavoritesView;

    /// <summary>
    /// RowId from Mount / Minion Excel Sheet for the currently selected item in MountNotebook or MinionNoteBook
    /// while in viewType == ViewType.Normal.
    /// </summary>
    ///
    /// <remarks>
    /// Will still update its value while in Favorite and Search view, but it will not be what the user is actually selecting.
    ///
    /// It is basically doing NormalIds[index], and the index is updating in both Normal and Favorite View.
    /// </remarks>
    [FieldOffset(0x5c)] public ushort SelectedIdInNormalView;

    /// <summary>
    /// Currently selected item index of Mount / Minion Notebook during Favorites or Normal view.
    /// </summary>
    [FieldOffset(0x58)] public ushort SelectedIndexInFavoritesAndNormalView1;

    /// <summary>
    /// Currently selected item index of Mount / Minion Notebook during Favorites or Normal view.
    /// </summary>
    [FieldOffset(0x64)] public ushort SelectedIndexInFavoritesAndNormalView2;

    /// <summary>
    /// RowId from Mount / Minion Excel Sheet for the currently selected item in MountNotebook or MinionNoteBook
    /// while in viewType == ViewType.Search.
    /// </summary>
    ///
    /// <remarks>
    /// Updates completely independent of Favorites and Normal view.
    /// </remarks>
    [FieldOffset(0x68)] public ushort SelectedIdInSearchView;

    /// <summary>
    /// Currently selected item index of Mount / Minion Notebook during Search view.
    /// </summary>
    [FieldOffset(0x70)] public ushort SelectedIndexInSearchView;
}
