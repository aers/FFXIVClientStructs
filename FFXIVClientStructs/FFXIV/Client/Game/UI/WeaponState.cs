namespace FFXIVClientStructs.FFXIV.Client.Game.UI;
// Client::Game::UI::WeaponState
/// <summary>
/// Represents the in-memory layout of the WeaponState structure.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public partial struct WeaponState {
    // Offset 0x00: IsUnsheathed – a bool flag indicating whether the weapon is unsheathed.
    // Updated via SetUnsheathed/SetUnsheathed2.
    [FieldOffset(0x00)]
    public bool IsUnsheathed;

    // Offset 0x04: SheatheCooldown – a float representing the cooldown/timer value.
    // The SetUnsheathed functions write the bytes 00 00 80 3F here, which corresponds to 1.0f.
    [FieldOffset(0x04)]
    public float SheatheCooldown;

    // Offset 0x08: AutoSheathTimer – another float value, likely used for auto-sheath timing.
    // The Tick method updates this timer by subtracting a delta time.
    [FieldOffset(0x08)]
    public float AutoSheathTimer;

    // Offset 0x0C: AutoSheatheState – a bool flag used to control auto-sheath behavior.
    // Checked (e.g. param_1[0x0C] != 0) in various code paths.
    [FieldOffset(0x0C)]
    public bool AutoSheatheState;

    // Offset 0x10: Originally, this offset was used for AutoAttackState.
    // In older versions, a simple bool (IsAutoAttacking) resided here.
    // In the current patch, analysis shows auto-attack state is handled globally via DAT_142921510.
    [FieldOffset(0x10)]
    public AutoAttackState AutoAttackState;

    /// <summary>
    /// Checks whether auto-sheathing is enabled.
    /// Internally, this checks a config option and the current AutoSheatheState.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 85 ?? ?? ?? ?? 45 33 C0 48 8D 8B")]
    public partial bool CanAutoSheathe();

    /// <summary>
    /// Extends the auto-sheath timer based on configuration settings.
    /// Sets AutoSheatheState and resets AutoSheathTimer.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 84 C0 79")]
    public partial void ExtendAutoSheatheTimer();

    /// <summary>
    /// Called when the actor's weapon drawn state changes.
    /// Updates the provided flag and triggers additional behavior.
    /// </summary>
    /// <param name="newUnsheathedState">The new unsheathed state (true = unsheathed, false = sheathed).</param>
    /// <param name="isInstant">Whether the change should occur instantly.</param>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B 3D ?? ?? ?? ?? 41 0F B6 E8 0F B6 DA")]
    public partial void OnActorControlWeaponDrawn(bool newUnsheathedState, bool isInstant);

    /// <summary>
    /// Updates the state every frame.
    /// This method decrements timers, resets them if necessary, and triggers auto-attack
    /// disablement via the global auto-attack state.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 87 ?? ?? ?? ?? 48 8B 18")]
    public partial void Tick();

    /// <summary>
    /// Sets the unsheathed state using the first method.
    /// This method may trigger animations or effects as needed.
    /// </summary>
    /// <param name="newState">The new unsheathed state (true = unsheathed, false = sheathed).</param>
    /// <param name="sendPacket">Whether to send a network update.</param>
    /// <param name="isInstant">Whether the change should occur instantly.</param>
    [MemberFunction("E8 ?? ?? ?? ?? F6 44 24 ?? ?? 75")]
    public partial bool SetUnsheathed(bool newState, bool sendPacket, bool isInstant);

    /// <summary>
    /// Sets the unsheathed state using the alternative variant (SetUnsheathed2).
    /// This version may update state without sending network packets.
    /// </summary>
    /// <param name="newState">The new unsheathed state (true = unsheathed, false = sheathed).</param>
    [MemberFunction("E9 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 40 84 FF")]
    public partial bool SetUnsheathed2(bool newState);
}

/// <summary>
/// Represents the AutoAttackState structure.
/// Originally, this might have been embedded in WeaponState at offset 0x10,
/// but current analysis shows auto-attack is managed globally.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1)]
public partial struct AutoAttackState {

    // Offset 0x00: A single byte that indicates if auto-attack is active.
    [FieldOffset(0)]
    public bool IsAutoAttacking;

    /// <summary>
    /// Gets the current auto-attack state.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 38 1D")]
    public partial bool Get();

    /// <summary>
    /// Handles actor control updates related to AutoAttack state.
    /// Note: Internally accesses LocalPlayer at offset 0x9a0 in version 7.0 (previously 0x9b0).
    /// </summary>
    /// <param name="newState">The new state value.</param>
    /// [MemberFunction("88 11 80 FA")] shorter but risky
    [MemberFunction("88 11 80 FA 01 75 ?? 48 8B 0D ?? ?? ?? ?? 48 85 C9 74 ?? 38 15 ?? ?? ?? ?? 74 ?? 48 81 C1 ?? ?? ?? ??")]
    public partial void OnActorControl(bool newState);

    /// <summary>
    /// Sets the auto-attack state after performing configuration and validation checks.
    /// Wraps the SetImpl call after ensuring conditions are met.
    /// </summary>
    /// <param name="newState">The new auto-attack state.</param>
    [MemberFunction("E8 ?? ?? ?? ?? B0 ?? EB ?? 48 8D 0D")]
    public partial bool Set(bool newState);

    /// <summary>
    /// Sets the auto-attack state.
    /// </summary>
    /// <param name="newState">The new state value.</param>
    /// <param name="sendPacket">Whether to send a network update.</param>
    /// <param name="isInstant">Whether the change should be applied instantly.</param>
    [MemberFunction("E8 ?? ?? ?? ?? EB ?? F6 87 ?? ?? ?? ?? ?? 75")]
    public partial bool SetImpl(bool newState, bool sendPacket, bool isInstant);
}
