using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonTeleport
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
// ctor "40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 33 D2 48 8D 8B ?? ?? ?? ?? 48 89 03 41 B8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 D2"
[Addon("Teleport")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3C8)]
public unsafe partial struct AddonTeleport {
    [FieldOffset(0x230)] public AtkComponentRadioButton* TabHeaderAll;
    [FieldOffset(0x238)] public AtkComponentRadioButton* TabHeaderLaNoscea;
    [FieldOffset(0x240)] public AtkComponentRadioButton* TabHeaderBlackShroud;
    [FieldOffset(0x248)] public AtkComponentRadioButton* TabHeaderThanalan;
    [FieldOffset(0x250)] public AtkComponentRadioButton* TabHeaderIshgard;
    [FieldOffset(0x258)] public AtkComponentRadioButton* TabHeaderGyrAbania;
    [FieldOffset(0x260)] public AtkComponentRadioButton* TabHeaderFarEast;
    [FieldOffset(0x268)] public AtkComponentRadioButton* TabHeaderIlsabard;
    [FieldOffset(0x270)] public AtkComponentRadioButton* TabHeaderNorvandt;
    [FieldOffset(0x278)] public AtkComponentRadioButton* TabHeaderOther;
    [FieldOffset(0x280)] public AtkComponentRadioButton* TabHeaderHistory;
    [FieldOffset(0x288)] public AtkComponentRadioButton* TabHeaderFavourite;
    [FieldOffset(0x290)] public AtkTextNode* GilCountText;
    [FieldOffset(0x298)] public AtkComponentTreeList* TeleportTreeList;
    [FieldOffset(0x2A0)] public AtkComponentListItemRenderer* TeleportTreeListFirstHeader;
    [FieldOffset(0x2A8)] public AtkComponentListItemRenderer* TeleportTreeListFirstItem;

    // Inlined Class
    [FieldOffset(0x2B8)] public AddonTeleport* Addon;
    [FieldOffset(0x2C0)] public delegate*<void*, AddonTeleport*, void*> UnknownFunction;
    [FieldOffset(0x2C8)] public AtkComponentButton* SettingsButton;
    [FieldOffset(0x2D0)] public AtkTextNode* AetheryteTicketsText;
    [FieldOffset(0x2D8)] public uint SelectedTab;
    [FieldOffset(0x2DC)] public uint SelectedTabItemCount; // Includes Teleport Destinations and Headers
    [FieldOffset(0x2E0)] public uint ListTotalCount;
}
