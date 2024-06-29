using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFriendList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("FriendList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public unsafe partial struct AddonFriendList {
    [FieldOffset(0x300)] public AtkComponentList* FriendList;
    [FieldOffset(0x308)] public AtkComponentButton* AddButton;
    [FieldOffset(0x310)] public AtkComponentCheckBox* MoveOnlineToTopCheckBox;
    [FieldOffset(0x318)] public AtkTextNode* CurrentFriendCountTextNode; // current / limit, ie '13/200'
    [FieldOffset(0x320)] public AtkTextNode* ListIsEmptyTextNode;
    [FieldOffset(0x330)] public AtkComponentDropDownList* FilterDropDownList;
    [FieldOffset(0x338)] public AtkComponentDropDownList* SortDropDownList;

    // There is a a few fields after the ui nodes that contains various state data,
    // would need to actually have friends to figure out what they mean...
}
