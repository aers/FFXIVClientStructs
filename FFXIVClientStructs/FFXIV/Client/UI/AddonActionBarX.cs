namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x298)]


[Addon("_ActionBar01", "_ActionBar02")]
public unsafe partial struct AddonActionBarX {
    [FieldOffset(0x00)] public AddonActionBarBase AddonActionBarBase;
}