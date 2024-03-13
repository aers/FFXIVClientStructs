namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

/// <summary>
/// A struct representing the UIState Achievement
/// </summary>
// Client::Game::UI::Achievement
[StructLayout(LayoutKind.Explicit, Size = 0x558)]
public unsafe partial struct Achievement {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 04 30", 3)]
    public static partial Achievement* Instance();

    [FieldOffset(0x00)] public void** vtbl;
    [FieldOffset(0x08)] public AchievementState State;
    [FieldOffset(0x0C)] public fixed byte CompletedAchievements[428];

    [FieldOffset(0x1DC)] public AchievementState ProgressRequestState;
    [FieldOffset(0x1E0)] public uint ProgressAchievementId;
    [FieldOffset(0x1E4)] public uint ProgressCurrent;
    [FieldOffset(0x1E8)] public uint ProgressMax;

    /// <summary> Requests Achievement Progress from the server. </summary>
    [MemberFunction("48 83 EC ?? C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 45 33 C9")]
    public partial void RequestAchievementProgress(uint id);

    /// <summary> Receives Achievement Progress requested with <see cref="RequestAchievementProgress"/>. </summary>
    [MemberFunction("C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 89 91 ?? ?? ?? ?? 44 89 81")]
    public partial void ReceiveAchievementProgress(uint id, uint current, uint max);

    /// <summary> Check if an achievement is complete. </summary>
    /// <param name="achievementId">Achievement ID to check against. This is the ID from the Achievement table. </param>
    /// <returns> Returns true if the achievement is complete. </returns>
    [MemberFunction("E8 ?? ?? ?? ?? 04 30")]
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
        Invalid = 0, // Achievement is initialized at this state
        Requested = 1, // This state is set between the client request and receiving the data from the server
        Loaded = 2, // Set upon data being received
    }
}
