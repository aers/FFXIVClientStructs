using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemSearchResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x3D0)]
[Addon("ItemSearchResult")]
public unsafe struct AddonItemSearchResult
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;


    [FieldOffset(0x228)] public AtkTextNode* ItemName;
    [FieldOffset(0x220)] public AtkComponentIcon* ItemIcon;
    [FieldOffset(0x248)] public AtkComponentButton* History;
    [FieldOffset(0x250)] public AtkComponentButton* AdvancedSearch;
    [FieldOffset(0x260)] public AtkComponentList* Results;
    [FieldOffset(0x268)] public AtkTextNode* HitsMessage;
    [FieldOffset(0x270)] public AtkTextNode* ErrorMessage;
}