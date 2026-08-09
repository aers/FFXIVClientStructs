namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct MapEffectPacket {
    [FieldOffset(0x00)] public uint EventId;
    [FieldOffset(0x04)] public ushort State;
    [FieldOffset(0x06)] public ushort TimelineIndex;
    /// <remarks> Which map effect this applies to. </remarks>
    [FieldOffset(0x08)] public byte Index;
}
