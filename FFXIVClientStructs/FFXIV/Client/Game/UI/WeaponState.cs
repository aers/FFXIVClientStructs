namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct WeaponState {
    [FieldOffset(0x00)] public bool IsUnsheathed;
    [FieldOffset(0x04)] public float SheatheCooldown;
    [FieldOffset(0x08)] public float AutoSheathTimer;
    [FieldOffset(0x0C)] public bool AutoSheatheState;
    [FieldOffset(0x10)] public bool IsAutoAttacking;
}
