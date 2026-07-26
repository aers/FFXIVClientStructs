namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct ActorSetPosPacket {
    [FieldOffset(0x00)] public ushort Rotation;
    [FieldOffset(0x02)] public byte WarpType; // TODO: Change to WarpInfo's WarpType (needs to be changed to a byte)
    [FieldOffset(0x03)] public byte Arg;
    [FieldOffset(0x04)] public uint TransitionTerritoryFilterKey;
    [FieldOffset(0x08)] public global::System.Numerics.Vector3 Position;
}
