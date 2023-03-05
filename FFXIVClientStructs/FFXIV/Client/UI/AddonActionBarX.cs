namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_ActionBar01", "_ActionBar02", "_ActionBar03", "_ActionBar04", "_ActionBar05", "_ActionBar06", "_ActionBar07", "_ActionBar08", "_ActionBar09" )]
[StructLayout(LayoutKind.Explicit, Size = 0x298)]
public unsafe partial struct AddonActionBarX {
    [FieldOffset(0x00)] public AddonActionBarBase AddonActionBarBase;
}