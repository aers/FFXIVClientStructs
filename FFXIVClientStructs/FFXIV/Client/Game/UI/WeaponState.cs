namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::WeaponState
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct WeaponState {
    [FieldOffset(0x00)] public bool IsUnsheathed;
    [FieldOffset(0x04)] public float SheatheCooldown;
    [FieldOffset(0x08)] public float AutoSheathTimer;
    [FieldOffset(0x0C)] public bool AutoSheatheState;
    [FieldOffset(0x10)] public AutoAttackState AutoAttackState; // note: not sure whether this is actually a part of this structure or next field of a parent
    [FieldOffset(0x10), Obsolete("Use AutoAttackState.IsAutoAttacking", true)] public bool IsAutoAttacking;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1)]
public partial struct AutoAttackState {
    [FieldOffset(0)] public bool IsAutoAttacking;

    [MemberFunction("E8 ?? ?? ?? ?? EB 15 41 B0 01")]
    public partial bool SetImpl(bool value, bool sendPacket, bool isInstant);
}
