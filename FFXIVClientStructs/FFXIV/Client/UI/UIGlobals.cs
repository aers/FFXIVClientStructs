namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// This struct is a collection of static functions from the Client::UI namespace.
/// </summary>
[GenerateInterop]
public unsafe partial struct UIGlobals {
    /// <summary>
    /// Determines whether the player can apply glamour plates in the current territory.
    /// </summary>
    /// <param name="checkCastGlamourUnlocked">
    /// If <c>false</c>, skips the check for whether the player has unlocked the general action "Cast Glamour".
    /// </param>
    /// <returns>
    /// <c>true</c> if the player can apply glamour plates in the current territory; otherwise, <c>false</c>.
    /// </returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 21 48 8B 4F 10")]
    public static partial bool CanApplyGlamourPlates(bool checkCastGlamourUnlocked = true);

    /// <summary>
    /// Determines whether the exported gathering point type is of a timed node or not.
    /// </summary>
    /// <param name="gatheringPointType">
    /// Value of field GatheringPointType of sheet ExportedGatheringPoint.
    /// </param>
    /// <returns>
    /// <c>true</c> if it is a timed node; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// If it is a timed node, the icon ID from the IconOff field in the GatheringType sheet should be used; otherwise, IconMain.
    /// </remarks>
    [MemberFunction("80 F9 07 77")]
    public static partial bool IsExportedGatheringPointTimed(byte gatheringPointType);

    /// <summary>
    /// Determines whether the given string is a valid player character name.
    /// </summary>
    /// <param name="characterName">The character name of the player to validate.</param>
    /// <returns>
    /// <c>true</c> if the character name is valid; otherwise, <c>false</c>.
    /// </returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 C7 4C 8B CB"), GenerateStringOverloads]
    public static partial bool IsValidPlayerCharacterName(byte* characterName);

    [MemberFunction("E8 ?? ?? ?? ?? 45 0F B7 C5")]
    public static partial void PlaySoundEffect(uint effectId, nint a2 = 0, nint a3 = 0, byte a4 = 0);

    public static void PlayChatSoundEffect(uint effectId) {
        if (effectId is < 1 or > 16)
            throw new ArgumentException("Valid chat sfx values are 1 through 16.");

        PlaySoundEffect(effectId + 36);
    }
}
