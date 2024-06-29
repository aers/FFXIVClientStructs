using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMYCWarResultNotebook
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MYCWarResultNotebook")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2E8)]
public unsafe partial struct AddonMYCWarResultNotebook {
    [FieldOffset(0x250)] public AtkCollisionNode* DescriptionCollisionNode;

    [FieldOffset(0x264)] public int MaxNoteIndex;
    [FieldOffset(0x268)] public int CurrentNoteIndex;
    [FieldOffset(0x26C)] public int CurrentPageIndex;
}
