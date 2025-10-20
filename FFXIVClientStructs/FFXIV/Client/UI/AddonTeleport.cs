using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonTeleport
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Teleport")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3D0)]
public unsafe partial struct AddonTeleport {
    [FieldOffset(0x238)] public AtkComponentRadioButton* TabHeaderAll;
    [FieldOffset(0x240)] public AtkComponentRadioButton* TabHeaderLaNoscea;
    [FieldOffset(0x248)] public AtkComponentRadioButton* TabHeaderBlackShroud;
    [FieldOffset(0x250)] public AtkComponentRadioButton* TabHeaderThanalan;
    [FieldOffset(0x258)] public AtkComponentRadioButton* TabHeaderIshgard;
    [FieldOffset(0x260)] public AtkComponentRadioButton* TabHeaderGyrAbania;
    [FieldOffset(0x268)] public AtkComponentRadioButton* TabHeaderFarEast;
    [FieldOffset(0x270)] public AtkComponentRadioButton* TabHeaderIlsabard;
    [FieldOffset(0x278)] public AtkComponentRadioButton* TabHeaderNorvandt;
    [FieldOffset(0x280)] public AtkComponentRadioButton* TabHeaderOther;
    [FieldOffset(0x288)] public AtkComponentRadioButton* TabHeaderHistory;
    [FieldOffset(0x290)] public AtkComponentRadioButton* TabHeaderFavourite;
    [FieldOffset(0x298)] public AtkTextNode* GilCountText;
    [FieldOffset(0x2A0)] public AtkComponentTreeList* TeleportTreeList;
    [FieldOffset(0x2A8)] public AtkComponentListItemRenderer* TeleportTreeListFirstHeader;
    [FieldOffset(0x2B0)] public AtkComponentListItemRenderer* TeleportTreeListFirstItem;

    // Inlined Class
    [FieldOffset(0x2C0)] public AddonTeleport* Addon;
    [FieldOffset(0x2C8)] public delegate*<void*, AddonTeleport*, void*> UnknownFunction;
    [FieldOffset(0x2D0)] public AtkComponentButton* SettingsButton;
    [FieldOffset(0x2D8)] public AtkTextNode* AetheryteTicketsText;
    [FieldOffset(0x2E0)] public uint SelectedTab;
    [FieldOffset(0x2E4)] public uint SelectedTabItemCount; // Includes Teleport Destinations and Headers
    [FieldOffset(0x2E8)] public uint ListTotalCount;
}
