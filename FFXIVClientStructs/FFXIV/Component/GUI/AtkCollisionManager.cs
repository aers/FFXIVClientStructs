using FFXIVClientStructs.FFXIV.Client.UI;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct AtkCollisionManager {
    [FieldOffset(0x00)] public UIInputData* UIInputData;
    [FieldOffset(0x08)] public AtkUnitBase* IntersectingAddon;
    [FieldOffset(0x10)] public AtkCollisionNode* IntersectingCollisionNode;
}
