namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x222)]
public partial struct AchievementsPacket {
    [FieldOffset(0x00), FixedSizeArray(isBitArray: true, bitCount: 4078)] internal FixedSizeArray510<byte> _completedAchievements;
    [FieldOffset(0x1FE), FixedSizeArray] internal FixedSizeArray5<ushort> _history; // last 5
    [FieldOffset(0x208), FixedSizeArray] internal FixedSizeArray16<byte> _unk208; // copied to 0x214
    [FieldOffset(0x218)] private ulong Unk218; // copied to 0x224
    [FieldOffset(0x220)] private ushort Unk220; // copied to 0x22C
}
