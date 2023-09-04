using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_Image, _Image3")]
[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public unsafe struct AddonImage {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x260)] public AtkResNode* ResNode1; // Both AtkResNode's appear to be the same node
    [FieldOffset(0x268)] public AtkResNode* ResNode2;
    [FieldOffset(0x270)] public AtkImageNode* ImageNode;

    [FieldOffset(0x27C)] public ushort Width;
    [FieldOffset(0x280)] public ushort Height;
}
