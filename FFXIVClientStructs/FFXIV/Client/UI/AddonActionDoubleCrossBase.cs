namespace FFXIVClientStructs.FFXIV.Client.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0x2F8)]
[Addon("_ActionDoubleCrossL", "_ActionDoubleCrossR")]
public struct AddonActionDoubleCrossBase {
    [FieldOffset(0x000)] public AddonActionBarBase ActionBarBase;
    [FieldOffset(0x2EC)] public byte UseLeftSide;
    [FieldOffset(0x2E8)] public byte BarTarget;
}