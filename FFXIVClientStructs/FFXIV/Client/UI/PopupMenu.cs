using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::PopupMenu
// Used in several addons as inlined derivations
[GenerateInterop]
[Inherits<AtkEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct PopupMenu {
    [FieldOffset(0x8)] public AtkStage* AtkStage;
    [FieldOffset(0x10)] public byte** EntryNames; // array of char* pointers
    [FieldOffset(0x30)] public AtkComponentWindow* Window;
    [FieldOffset(0x38)] public AtkComponentList* List;
    [FieldOffset(0x40)] public AtkUnitBase* Owner;
    [FieldOffset(0x4C)] public int EntryCount;
}
