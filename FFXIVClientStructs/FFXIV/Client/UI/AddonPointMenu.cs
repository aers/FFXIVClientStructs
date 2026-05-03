using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonPointMenu
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("PointMenu")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonPointMenu {
    [FieldOffset(0x238)] public StdVector<Pointer<Entry>> Entries;

    [FieldOffset(0x250)] public TooltipContext* TooltipContextData;

    [FieldOffset(0x258)] public int PendingFocusIndex; // Focus target index consumed in OnRefresh, then reset to -1

    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public struct Entry {
        [FieldOffset(0x18)] public AtkComponentBase* Checkbox;
        [FieldOffset(0x20)] public AtkResNode* TitleNode;
        [FieldOffset(0x28)] public AtkResNode* ClickAreaNode;
        [FieldOffset(0x30)] public Utf8String Title; // Entry title set by AgentPointMenu.SendEntryToAddon
        [FieldOffset(0x98)] public byte IsActive; // Whether this entry is active (State > 0)
        [FieldOffset(0x99)] public byte IsHovered; // Hover state flag, cleared each frame in Update
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct TooltipContext {
        [FieldOffset(0x08)] public AtkResNode* RootNode;
        [FieldOffset(0x10)] public AtkTextNode* TextNode;
        [FieldOffset(0x18)] public AtkResNode* BackgroundNode;
    }
}
