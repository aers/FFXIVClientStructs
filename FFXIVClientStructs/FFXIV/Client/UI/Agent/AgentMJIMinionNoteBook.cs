using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MJIMinionNoteBook)]
[StructLayout(LayoutKind.Explicit, Size = 0x208)]
public unsafe partial struct AgentMJIMinionNoteBook {
    [FieldOffset(0)] public AgentInterface AgentInterface;

    [FieldOffset(0x1DC)] public SelectedMinionInfo SelectedFavoriteMinion;
    [FieldOffset(0x1E0)] public SelectedMinionInfo SelectedNormalMinion;
    [FieldOffset(0x1E4)] public SelectedMinionInfo SelectedSearchMinion;
    [FieldOffset(0x1E8)] public SelectedMinionInfo* SelectedMinion;
    [FieldOffset(0x1F0)] public ViewType CurrentView;

    /// <param name="flags">
    /// Switch to ViewType.Favorites = <c>0x407</c><br/>
    /// Switch to ViewType.Normal = <c>0x40B</c><br/>
    /// Switch to ViewType.Search = <c>0x413</c><br/>
    /// </param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 86 ?? ?? ?? ?? 88 58 03")]
    public partial void HandleCommand(int* flags);

    /// <inheritdoc cref="HandleCommand(int*)"/>
    public void HandleCommand(int flags) => HandleCommand(&flags);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 D8 85 DB")]
    public partial ushort GetSelectedMinionId(byte* viewType, byte* currentTabIndex, byte* currentSlotIndex);

    public ushort GetSelectedMinionId() {
        if (SelectedMinion == null)
            return 0;

        var currentView = (byte)CurrentView;
        return GetSelectedMinionId(&currentView, &SelectedMinion->TabIndex, &SelectedMinion->SlotIndex);
    }

    public enum ViewType : byte {
        Favorites = 1,
        Normal,
        Search,
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x4)]
    public struct SelectedMinionInfo {
        [FieldOffset(0)] public ushort MinionId;
        [FieldOffset(2)] public byte TabIndex;
        [FieldOffset(3)] public byte SlotIndex;
    }
}
