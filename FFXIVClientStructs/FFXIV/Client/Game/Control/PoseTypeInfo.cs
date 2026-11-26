using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::PoseTypeInfo
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct PoseTypeInfo {
    /// <remarks>
    /// A pointer to an array the size of <see cref="PoseCount"/> containing emote ids.
    /// </remarks>
    [FieldOffset(0x00)] public ushort* Emotes;
    /// <remarks>
    /// Timeline this PoseType uses when PoseState is 0 
    /// </remarks>
    [FieldOffset(0x08)] public ushort BaseTimelineId;
    /// <remarks>
    /// When the local player's timeline in slot 0 matches <see cref="BaseTimelineId"/> the game calls this method to see if this PoseType is applicable,
    /// if the method pointer is null then it's considered applicable by default.
    /// </remarks>
    [FieldOffset(0x10)] public delegate* unmanaged<BattleChara*, bool> ShouldApplyPoseType;
    [FieldOffset(0x18)] public byte PoseCount;
    [FieldOffset(0x19)] public bool CanBeRandom;

    /// <remarks>
    /// A span of emote ids the size of <see cref="PoseCount"/>.
    /// </remarks>
    public Span<ushort> EmotesSpan => new(Emotes, PoseCount);
}
