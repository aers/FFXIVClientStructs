using FFXIVClientStructs.FFXIV.Client.Enums;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct ContentsFinderNotificationPacket {
    [FieldOffset(0x00)] public ContentsFinderQueueState QueueState;

    /// <summary>
    /// The ID of the ContentFinderCondition EXD that has popped.
    /// </summary>
    [FieldOffset(0x1C)] public ushort ContentFinderConditionId;
}
