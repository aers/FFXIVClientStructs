using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonImage
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_Image, _Image3")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public unsafe partial struct AddonImage {
    [FieldOffset(0x270)] public AtkResNode* ResNode1; // Both AtkResNode's appear to be the same node
    [FieldOffset(0x278)] public AtkResNode* ResNode2;
    [FieldOffset(0x280)] public AtkImageNode* ImageNode;

    [FieldOffset(0x28C)] public ushort Width;
    [FieldOffset(0x290)] public ushort Height;
}
