using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Fate;

// Client::Game::Fate::FateContext
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 66 89 51 18"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10A0)]
public partial struct FateContext {
    [FieldOffset(0x18)] public ushort FateId;
    [FieldOffset(0x1A)] public byte EurekaFate;
    [FieldOffset(0x20)] public int StartTimeEpoch;
    [FieldOffset(0x28)] public short Duration;

    [FieldOffset(0xC0)] public Utf8String Name;
    [FieldOffset(0x128)] public Utf8String Description;
    [FieldOffset(0x190)] public Utf8String Objective;

    [FieldOffset(0x3AC)] public byte State;
    [FieldOffset(0x3AF)] public byte HandInCount;
    [FieldOffset(0x3B8)] public byte Progress;
    /// <summary>
    /// If true grants extra experience and bicolor gemstones (ShB and up)
    /// </summary>
    [FieldOffset(0x3C4)] public bool IsBonus;
    [FieldOffset(0x3C4), Obsolete("Use IsBonus instead")] public bool IsExpBonus; // Since Shadowbringers the bonus fates have granted extra gemstones when this was true
    [FieldOffset(0x3C6), FixedSizeArray] internal FixedSizeArray8<ushort> _objectiveIcons;
    [FieldOffset(0x3D8)] public uint IconId;
    [FieldOffset(0x3DC)] public uint MapIconId;
    [FieldOffset(0x3E0)] public uint InactiveMapIcon;
    [FieldOffset(0x3E4)] public uint EventItem;
    [FieldOffset(0x3EC)] public int Music;
    [FieldOffset(0x3F0)] public ushort GivenStatus;
    [FieldOffset(0x3F4)] public byte Rule;
    [FieldOffset(0x3F6)] public byte FateRuleEx;
    [FieldOffset(0x3F9)] public byte Level;
    [FieldOffset(0x3FA)] public byte MaxLevel;
    [FieldOffset(0x3FC)] public ushort ScreenImageAccept;
    [FieldOffset(0x3FE)] public ushort ScreenImageComplete;
    [FieldOffset(0x400)] public ushort ScreenImageFailed;
    [FieldOffset(0x40A)] public ushort FATEChain;
    [FieldOffset(0x430)] public uint RequiredQuest;
    [FieldOffset(0x450)] public Vector3 Location;
    [FieldOffset(0x464)] public float Radius;

    [FieldOffset(0x79A)] public ushort TerritoryId;
}
