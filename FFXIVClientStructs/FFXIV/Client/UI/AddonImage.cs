using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonImage
//   Component::GUI::AddonScreenInfoChild
//     Component::GUI::AtkUnitBase
//       Component::GUI::AtkEventListener
[Addon("_Image")]
[GenerateInterop(isInherited: true)]
[Inherits<AtkUnitBase>] // TODO: inherit from AddonScreenInfoChild
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe partial struct AddonImage {
    [FieldOffset(0x288)] public AtkResNode* ResNode1; // Both AtkResNode's appear to be the same node
    [FieldOffset(0x290)] public AtkResNode* ResNode2;
    [FieldOffset(0x298)] public AtkImageNode* ImageNode;

    [FieldOffset(0x2A4)] public ushort Width;
    [FieldOffset(0x2A8)] public ushort Height;
}
