using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCursor
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("CursorAddon")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public unsafe partial struct AddonCursor {
    [FieldOffset(0x288)] public AtkResNode* CursorContainerNode; // Same as AtkUnitBase.RootNode
}
