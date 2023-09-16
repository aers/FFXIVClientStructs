namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public struct EnterContentInfo {
    [FieldOffset(0x00)] public byte NotifyType;

    /// <summary>
    /// The ID of the ContentFinderCondition EXD that has popped.
    /// </summary>
    [FieldOffset(0x1C)] public ushort ContentFinderConditionId;
}
