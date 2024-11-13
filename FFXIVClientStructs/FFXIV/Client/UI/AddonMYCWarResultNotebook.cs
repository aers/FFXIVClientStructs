using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMYCWarResultNotebook
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MYCWarResultNotebook")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public unsafe partial struct AddonMYCWarResultNotebook {
    [FieldOffset(0x258)] public AtkCollisionNode* DescriptionCollisionNode;

    [FieldOffset(0x26C)] public int MaxNoteIndex;
    [FieldOffset(0x270)] public int CurrentNoteIndex;
    [FieldOffset(0x274)] public int CurrentPageIndex;
}
