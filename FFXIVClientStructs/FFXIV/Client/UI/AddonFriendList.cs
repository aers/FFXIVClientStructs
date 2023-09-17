using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("FriendList")]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public unsafe partial struct AddonFriendList {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x2F0)] public AtkComponentList* FriendList;
    [FieldOffset(0x2F8)] public AtkComponentButton* AddButton;
    [FieldOffset(0x300)] public AtkComponentCheckBox* MoveOnlineToTopCheckBox;
    [FieldOffset(0x308)] public AtkTextNode* CurrentFriendCountTextNode; // current / limit, ie '13/200'
    [FieldOffset(0x310)] public AtkTextNode* ListIsEmptyTextNode;
    [FieldOffset(0x320)] public AtkComponentDropDownList* FilterDropDownList;
    [FieldOffset(0x328)] public AtkComponentDropDownList* SortDropDownList;

    // There is a a few fields after the ui nodes that contains various state data,
    // would need to actually have friends to figure out what they mean...
}
