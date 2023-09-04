namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_ActionBar01", "_ActionBar02", "_ActionBar03", "_ActionBar04", "_ActionBar05", "_ActionBar06", "_ActionBar07", "_ActionBar08", "_ActionBar09")]
[StructLayout(LayoutKind.Explicit, Size = 0x298)]
public unsafe partial struct AddonActionBarX {
    [FieldOffset(0x00)] public AddonActionBarBase AddonActionBarBase;

    /// <summary>
    /// The current layout (columns x rows) of this specific hotbar.
    /// </summary>
    [FieldOffset(0x270)] public ActionBarLayout ActionBarLayout;
}

public enum ActionBarLayout : byte {
    Layout12X1 = 0,
    Layout6X2 = 1,
    Layout4X3 = 2,
    Layout3X4 = 3,
    Layout2X6 = 4,
    Layout1X12 = 5
}
