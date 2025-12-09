namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Achievement
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x7E8)]
public unsafe partial struct Achievement {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 04 30 FF C3", 3)]
    public static partial Achievement* Instance();

    [FieldOffset(0x08)] public AchievementState State;
    [FieldOffset(0x0C), FixedSizeArray(false, true, 3825)] internal FixedSizeArray479<byte> _completedAchievements;

    /// <remarks> Last Five Achievement Ids </remarks>
    [FieldOffset(0x1F2), FixedSizeArray] internal FixedSizeArray5<ushort> _history;
    // [FieldOffset(0x1FC), FixedSizeArray] internal FixedSizeArray32<byte> _unk1FC; // BitArray, index is Achievement.Unknown1 or Unknown2
    [FieldOffset(0x218)] public AchievementState ProgressRequestState;
    [FieldOffset(0x21C)] public uint ProgressAchievementId;
    [FieldOffset(0x220)] public uint ProgressCurrent;
    [FieldOffset(0x224)] public uint ProgressMax;

    // Stuff for "Near Completion" tab and some other unimplemented tab, idk?
    // [FieldOffset(0x22A)] 2x byte for opened state?
    // [FieldOffset(0x22C)] 2x AchievementState
    // [FieldOffset(0x234)] 2x struct 0x1E5 length with each 3x struct of 0x80 that contains an array of 100 bytes???

    // [FieldOffset(0x5FE), FixedSizeArray] internal FixedSizeArray479<byte> _completedItemBarterWarningAchievements; // unsure, currently only for Phantom weapons?!

    /// <summary> Requests Achievement Progress from the server. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 41 C6 44 24 ?? ?? E9 ?? ?? ?? ?? 48 8D 4F ?? E8 ?? ?? ?? ?? 88 43")]
    public partial void RequestAchievementProgress(uint id);

    /// <summary> Receives Achievement Progress requested with <see cref="RequestAchievementProgress"/>. </summary>
    [MemberFunction("C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 89 91 ?? ?? ?? ?? 44 89 81")]
    public partial void ReceiveAchievementProgress(uint id, uint current, uint max);

    /// <summary> Check if an achievement is complete. </summary>
    /// <param name="achievementId">Achievement ID to check against. This is the ID from the Achievement table. </param>
    /// <returns> Returns true if the achievement is complete. </returns>
    [MemberFunction("E8 ?? ?? ?? ?? 04 30 FF C3")]
    public partial bool IsComplete(int achievementId);

    /// <summary> Check if the achievement data has been "loaded" from the server. </summary>
    /// <remarks>
    /// The achievement data will only load when requested (so, when a player goes into the achievements menu).
    /// As such, before any check can take place, a developer must first validate that the achievement data is
    /// loaded. Generally, this will be when State == AchievementState.Loaded
    /// </remarks>
    /// <returns> Returns true if the Achievement data has been retrieved. </returns>
    public bool IsLoaded()
        => State is AchievementState.Loaded;

    /// <summary> Represents the loaded state of Achievement </summary>
    public enum AchievementState : int {
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
