namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_ActionBar")]
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe partial struct AddonActionBar {
    [FieldOffset(0x00)] public AddonActionBarX AddonActionBarX;
}
