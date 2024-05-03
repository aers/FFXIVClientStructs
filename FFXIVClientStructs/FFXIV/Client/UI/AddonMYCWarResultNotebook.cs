using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("MYCWarResultNotebook")]
[StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
public unsafe struct AddonMYCWarResultNotebook {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x240)] public AtkCollisionNode* DescriptionCollisionNode;

    [FieldOffset(0x254)] public int MaxNoteIndex;
    [FieldOffset(0x258)] public int CurrentNoteIndex;
    [FieldOffset(0x25C)] public int CurrentPageIndex;
}
