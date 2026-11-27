using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x584)]
public partial struct EffectResultPacket {
    [FieldOffset(0x00)] public byte NumEntries;
    [FieldOffset(0x01)] private byte Unk1;
    [FieldOffset(0x02)] private ushort Unk2;
    [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray16<EffectResultEntry> _entries;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public partial struct EffectResultEntry {
    /// <remarks> Same as <see cref="ActionEffectHandler.EffectEntry.GlobalSequence"/>. </remarks>
    [FieldOffset(0x00)] public uint GlobalSequence;
    [FieldOffset(0x04)] public uint EntityId;
    [FieldOffset(0x08)] public uint CurrentHP;
    [FieldOffset(0x0C)] public uint MaxHP;
    /// <remarks> MP/GP/CP </remarks>
    [FieldOffset(0x10)] public ushort CurrentParameterValue;
    /// <remarks> Same as <see cref="ActionEffectHandler.EffectEntry.TargetIndex"/>. </remarks>
    [FieldOffset(0x12)] public byte TargetIndex;
    [FieldOffset(0x13)] public byte ClassJob;
    [FieldOffset(0x14)] public byte ShieldValue;
    [FieldOffset(0x15)] public byte EffectCount;
    [FieldOffset(0x16)] private ushort Unk16;
    [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray4<EffectResultEffect> _effects;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct EffectResultEffect {
    [FieldOffset(0x00)] public byte StatusIndex; // passed to StatusManager.SetStatus
    [FieldOffset(0x01)] private byte Unk1;
    [FieldOffset(0x02)] public ushort StatusId;
    [FieldOffset(0x04)] public ushort Param;
    [FieldOffset(0x06)] private ushort Unk6;
    [FieldOffset(0x08)] public float RemainingTime;
    [FieldOffset(0x0C)] public uint SourceEntityId;
}
