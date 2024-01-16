using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_ActionBar01", "_ActionBar02", "_ActionBar03", "_ActionBar04", "_ActionBar05", "_ActionBar06", "_ActionBar07", "_ActionBar08", "_ActionBar09")]
[StructLayout(LayoutKind.Explicit, Size = 0x298)]
public unsafe partial struct AddonActionBarX {
    [FieldOffset(0x000)] public AddonActionBarBase AddonActionBarBase;

    [FieldOffset(0x248)] public AtkTextNode* HotbarNumIconTextNode;
    [FieldOffset(0x250)] public AtkCollisionNode* HotbarNumIconCollisionNode;
    [FieldOffset(0x258)] public AtkResNode* ContainerNode;
    [FieldOffset(0x260)] public AtkResNode* HotbarNumIconNode;
    [FieldOffset(0x268)] public AtkResNode* PadlockNode;

    /// <summary>
    /// The current layout (columns x rows) of this specific hotbar.
    /// </summary>
    [FieldOffset(0x270)] public ActionBarLayout ActionBarLayout;

    [FixedSizeArray<Dimensions>(6)]
    [FieldOffset(0x27C)] public fixed byte LayoutDimensions[6 * Dimensions.Size]; // every hotbar stores the same pre-baked dimensions for each of the 6 layout options

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct Dimensions {
        public const int Size = 0x4;
        [FieldOffset(0x0)] public short Width;
        [FieldOffset(0x2)] public short Height;
    }
}

public enum ActionBarLayout : byte {
    Layout12X1 = 0,
    Layout6X2 = 1,
    Layout4X3 = 2,
    Layout3X4 = 3,
    Layout2X6 = 4,
    Layout1X12 = 5
}
