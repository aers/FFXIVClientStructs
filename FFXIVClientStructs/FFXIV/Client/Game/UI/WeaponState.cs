namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct WeaponState
{
    [FieldOffset(0x08), Obsolete("Use IsUnsheathed instead.", true)] public byte WeaponUnsheathed;
    [FieldOffset(0x08)] public bool IsUnsheathed;
    [FieldOffset(0x0C)] public float SheatheCooldown;
    [FieldOffset(0x10)] public float AutoSheathTimer;
    [FieldOffset(0x14)] public bool AutoSheatheState;
    [FieldOffset(0x18)] public bool IsAutoAttacking;
}