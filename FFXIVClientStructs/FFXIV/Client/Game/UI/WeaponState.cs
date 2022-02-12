namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct WeaponState
{
    [FieldOffset(0x08)] public byte WeaponUnsheathed;
    [FieldOffset(0x0C)] public float SheatheTimer;
    [FieldOffset(0x10)] public float AutoSheathDelayTimer;
    [FieldOffset(0x14)] public byte AutoSheatheState;
    [FieldOffset(0x18)] public byte IsAutoAttacking;
}