using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemSearchResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ItemSearchResult")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3E0)]
public unsafe partial struct AddonItemSearchResult {
    [FieldOffset(0x238)] public AtkTextNode* ItemName;
    [FieldOffset(0x230)] public AtkComponentIcon* ItemIcon;
    [FieldOffset(0x258)] public AtkComponentButton* History;
    [FieldOffset(0x260)] public AtkComponentButton* AdvancedSearch;
    [FieldOffset(0x270)] public AtkComponentList* Results;
    [FieldOffset(0x278)] public AtkTextNode* HitsMessage;
    [FieldOffset(0x280)] public AtkTextNode* ErrorMessage;
}
