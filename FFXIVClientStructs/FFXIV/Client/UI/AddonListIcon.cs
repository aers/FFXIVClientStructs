using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonListIcon
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ListIcon")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
public unsafe partial struct AddonListIcon {
    [FieldOffset(0x238)] public int TotalItemCount;
    [FieldOffset(0x23C)] public int CurrentPage;
    [FieldOffset(0x240)] public int LastPage;
    [FieldOffset(0x244)] private uint Flags;
    [FieldOffset(0x248)] private int Unk248;
    [FieldOffset(0x24C)] public int HoveredItemIndex;
    [FieldOffset(0x250)] public AtkComponentListItemRenderer* HoveredItemRenderer;
    [FieldOffset(0x258)] private short Unk258; // width
    [FieldOffset(0x25A)] private short Unk25A; // height?
    [FieldOffset(0x25C)] private short Unk25C; // y offset?
    [FieldOffset(0x260)] public AtkComponentList* List;
    [FieldOffset(0x268)] public ItemData* ListData;
    [FieldOffset(0x270), FixedSizeArray] internal FixedSizeArray10<Pointer<AtkComponentRadioButton>> _tabButtons;
    [FieldOffset(0x2C0)] private AtkTextNode* Unk2C0TextNode; // some optional text at the bottom of the window
    [FieldOffset(0x2C8)] public AtkComponentList.ColumnNodeInfo ColumnNodeInfo;

    [MemberFunction("E8 ?? ?? ?? ?? 85 DB 74 ?? 3B 9F")]
    public partial void SetPage(int page);

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct ItemData {
        [FieldOffset(0x00)] public uint IconId;
        [FieldOffset(0x04)] public uint Flags;
        [FieldOffset(0x08)] public CStringPointer TooltipText;
        [FieldOffset(0x10)] public uint ItemId;
        [FieldOffset(0x14)] private uint Unk14;
    }
}
