namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Achievement
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x848)]
public unsafe partial struct Achievement {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 04 30 FF C3", 3)]
    public static partial Achievement* Instance();

    [FieldOffset(0x08)] public AchievementState State;

    /// <summary>
    /// Main completion bitmap
    /// This is distinct from the two near-completion result bitmaps and the ItemBarterWarning bitmap.
    /// </summary>
    [FieldOffset(0x0C), FixedSizeArray(isBitArray: true, bitCount: 4078)] internal FixedSizeArray510<byte> _completedAchievements;

    /// <remarks> Last Five Achievement IDs </remarks>
    [FieldOffset(0x20A), FixedSizeArray] internal FixedSizeArray5<ushort> _history;

    /// <summary>
    /// Server-maintained 208-bit condition map used while the AgentAchievement builds presentation state.
    /// </summary>
    /// <remarks>
    /// The full achievement packet replaces all 26 bytes, while ActorControl category 941 replaces a single byte.
    /// The agent then tests an individual bit against the expected set or clear state recorded by an achievement entry.
    /// </remarks>
    [FieldOffset(0x214), FixedSizeArray(isBitArray: true, bitCount: 26 * 8)] internal FixedSizeArray26<byte> _agentStateFlags;

    [FieldOffset(0x230)] public AchievementState ProgressRequestState;
    [FieldOffset(0x234)] public uint ProgressAchievementId;
    [FieldOffset(0x238)] public uint ProgressCurrent;
    [FieldOffset(0x23C)] public uint ProgressMax;

    /// <summary>
    /// Enables the two independently requested near-completion result slots.
    /// </summary>
    /// <remarks>
    /// These slots do not cache or partition <see cref="CompletedAchievements"/>. Each is a separate server-provided
    /// achievement-ID membership bitmap for a different UI lifecycle.
    /// </remarks>
    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray2<byte> _nearCompletionAchievementRequestFlags;

    /// <summary> Set after a near-completion slot has been received, suppressing subsequent first-receipt notifications. </summary>
    [FieldOffset(0x242), FixedSizeArray] internal FixedSizeArray2<byte> _nearCompletionAchievementReceivedFlags;

    /// <summary> Load state for near-completion slots 0 and 1. </summary>
    [FieldOffset(0x244), FixedSizeArray] internal FixedSizeArray2<AchievementState> _nearCompletionAchievementStates;

    /// <summary>
    /// Near-completion achievement membership bitmap for the login notification.
    /// </summary>
    /// <remarks>
    /// Controlled by AchievementAppealLoginDisp config.
    /// </remarks>
    [FieldOffset(0x24C), FixedSizeArray(isBitArray: true, bitCount: 4078)] internal FixedSizeArray510<byte> _loginNotificationNearCompletionAchievements;

    /// <summary>
    /// Near-completion achievement membership bitmap for the Achievement addon's Near Completion page.
    /// </summary>
    [FieldOffset(0x44A), FixedSizeArray(isBitArray: true, bitCount: 4078)] internal FixedSizeArray510<byte> _achievementAddonNearCompletionAchievements;

    /// <summary> Used only by ItemBarterWarning rows. </summary>
    /// <remarks>
    /// A dedicated server packet is ORed into this bitmap without modifying <see cref="CompletedAchievements"/>. When
    /// checking an ItemBarterWarning row, the game treats its referenced achievement as complete if either bitmap has
    /// the corresponding bit set.
    /// </remarks>
    [FieldOffset(0x648), FixedSizeArray(isBitArray: true, bitCount: 4080)] internal FixedSizeArray510<byte> _itemBarterWarningCompletedAchievements;

    /// <summary> Requests the main completed achievement bitmap </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 8B C3 48 8B 5C 24 ?? 48 8B 74 24 ?? 48 83 C4 ?? 5F C3 83 F8")]
    public partial bool RequestCompletedAchievements();

    /// <summary> Requests Achievement Progress from the server. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 41 C6 44 24 ?? ?? E9 ?? ?? ?? ?? 48 8D 4F ?? E8 ?? ?? ?? ?? 88 43")]
    public partial void RequestAchievementProgress(uint achievementID);

    /// <summary> Requests data for a FATE progress tab.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 54 24 ?? C6 86")]
    public partial bool RequestFateProgressTab(byte tabIndex);

    [MemberFunction("E9 ?? ?? ?? ?? CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC 80 39")]
    public partial void HandleFateProgressTabPacket(void* packet);

    /// <summary> Receives Achievement Progress requested with <see cref="RequestAchievementProgress"/>. </summary>
    [MemberFunction("C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 89 91 ?? ?? ?? ?? 44 89 81")]
    public partial void ReceiveAchievementProgress(uint achievementID, uint current, uint max);

    /// <summary> Checks whether an achievement is present in the main completion bitmap. </summary>
    /// <param name="achievementID">Achievement ID to check against</param>
    /// <returns> Returns true if the achievement is complete. </returns>
    /// <remarks> This does not inspect ItemBarterWarning data. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 04 30 FF C3")]
    public partial bool IsComplete(int achievementID);

    /// <summary> Marks an achievement complete and adds it to the recent completion history. </summary>
    /// <remarks> Any near-completion result slot containing this achievement is cleared and reset to Invalid. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B C8 ?? ?? ?? FF 52 ?? 8B 54 24 ?? 48 8B C8")]
    public partial void SetAchievementComplete(uint achievementID);

    /// <summary> Replaces one byte of the shared achievement agent state map. </summary>
    [MemberFunction("8B C2 44 88 84 08 ?? ?? ?? ?? C3 CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC 4C 8B D9")]
    public partial void SetAgentState(uint agentStateIndex, byte value);

    /// <summary> Checks whether a condition-map bit matches the expected state. </summary>
    /// <remarks> When <paramref name="expectedSet"/> is false, this returns true only when the bit is clear. </remarks>
    [MemberFunction("4C 8B C9 8B C2 48 C1 E8 ?? 8B CA 83 E1 ?? 41 BA ?? ?? ?? ?? 41 D3 E2 42 0F B6 8C 08")]
    public partial bool MatchesAgentState(uint agentStateIndex, bool expectedSet);

    [MemberFunction("83 FA ?? 77 ?? 48 63 C2 0F B7 84 41 ?? ?? ?? ?? C3 33 C0 C3 CC CC CC CC CC CC CC CC CC CC CC CC C7 81")]
    public partial ushort GetHistoryEntry(uint index);

    /// <summary> ORs a ItemBarterWarning packet into the bitmap. </summary>
    [MemberFunction("48 89 5C 24 ?? 48 89 7C 24 ?? 48 2B D1 48 8D 81")]
    public partial void MergeItemBarterWarningCompletedAchievements(byte* achievementBitmap);

    /// <summary> Checks the ItemBarterWarning completion bitmap for an achievement ID</summary>
    [MemberFunction("44 8B C2 4C 8B C9 81 FA ?? ?? ?? ?? 72")]
    public partial bool IsItemBarterWarningAchievementComplete(uint achievementID);

    /// <summary>
    /// Clears the login notification near-completion bitmap and resets only its state to <see cref="AchievementState.Invalid"/>.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? C6 45 ?? ?? 45 33 F6")]
    public partial void ResetLoginNearCompletionAchievements();

    /// <summary> Returns the load state for a near-completion result slot. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? FF C8 83 F8 ?? 76 ?? 41 8D 56")]
    public partial AchievementState GetNearCompletionAchievementState(NearCompletionAchievementSlot slot);

    /// <summary> Checks whether an achievement belongs to a loaded near-completion result slot. </summary>
    [MemberFunction("45 8B C8 83 FA ?? 73 ?? 44 8B C2")]
    public partial bool IsNearCompletionAchievement(NearCompletionAchievementSlot slot, uint achievementID);

    /// <summary> Receives near-completion result for a UI slot. </summary>
    [MemberFunction("83 FA ?? 0F 83 ?? ?? ?? ?? 48 89 5C 24 ?? 56 48 83 EC ?? 48 8B D9")]
    public partial void ReceiveNearCompletionAchievements(NearCompletionAchievementSlot slot, byte* achievementBitmap);

    /// <summary>
    /// Requests both near-completion result slots.
    /// </summary>
    /// <remarks> This is not a forced refresh of a slot that is already enabled and requested or loaded. </remarks>
    [MemberFunction("48 83 EC ?? 33 D2 38 91")]
    public partial void RequestAllNearCompletionAchievements();

    /// <summary> Requests one near-completion result slot. </summary>
    [MemberFunction("48 8B C1 83 FA ?? 73 ?? 8B CA BA")]
    public partial void RequestNearCompletionAchievementSlot(NearCompletionAchievementSlot slot);

    /// <summary>
    /// Requests selected near-completion result slots
    /// </summary>
    [MemberFunction("48 83 EC ?? F6 C2 ?? 74")]
    public partial void RequestNearCompletionAchievementSlots(NearCompletionAchievementSlotFlags slots);

    /// <summary> Check if the achievement data has been "loaded" from the server. </summary>
    /// <remarks>
    /// The achievement data will only load when requested (so, when a player goes into the achievements menu).
    /// As such, before any check can take place, a developer must first validate that the achievement data is
    /// loaded. Generally, this will be when State == AchievementState.Loaded
    /// </remarks>
    /// <returns> Returns true if the Achievement data has been retrieved. </returns>
    public bool IsLoaded()
        => State is AchievementState.Loaded;

    /// <summary> Identifies a near-completion result slot. </summary>
    public enum NearCompletionAchievementSlot : uint {
        /// <summary> Data used by the login notification. </summary>
        LoginNotification = 0,

        /// <summary> Data used by the Achievement addon's Near Completion page. </summary>
        AchievementAddon = 1,
    }

    /// <summary> Selects one or both near-completion result slots. </summary>
    [Flags]
    public enum NearCompletionAchievementSlotFlags : uint {
        None = 0,
        LoginNotification = 1 << 0,
        AchievementAddon = 1 << 1,
    }

    /// <summary> Represents the loaded state of Achievement </summary>
    public enum AchievementState {
        /// <summary> Achievement is initialized at this state. </summary>
        /// <remarks> Debug output calls it "invalide". </remarks>
        Invalid = 0,

        /// <summary> This state is set between the client request and receiving the data from the server. </summary>
        /// <remarks> Debug output calls it "waiting". </remarks>
        Requested = 1,

        /// <summary> Set upon data being received. </summary>
        /// <remarks> Debug output calls it "effective". </remarks>
        Loaded = 2,
    }
}
