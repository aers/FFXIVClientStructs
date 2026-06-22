namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct PrepareZoningPacket {
    [FieldOffset(0x00)] public uint LogMessageId;
    [FieldOffset(0x04)] public ushort TerritoryTypeId;
    [FieldOffset(0x06)] public ushort VfxId;
    [FieldOffset(0x08)] private ushort Unk8;
    /// <remarks> See <see cref="UI.WarpType"/> </remarks>
    [FieldOffset(0x0A)] public byte WarpType;
    [FieldOffset(0x0B)] private byte UnkB;
    [FieldOffset(0x0C)] private byte UnkC;
    [FieldOffset(0x0D)] public byte Flags;
    [FieldOffset(0x0E)] private byte UnkE;
    [FieldOffset(0x0F)] private byte UnkF;
}
