using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Fate;

// Client::Game::Fate::FateContext
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 66 89 51 18"
[StructLayout(LayoutKind.Explicit, Size = 0x1040)]
public struct FateContext {
    [FieldOffset(0x18)] public ushort FateId;
    [FieldOffset(0x20)] public int StartTimeEpoch;
    [FieldOffset(0x28)] public short Duration;

    [FieldOffset(0xC0)] public Utf8String Name;
    [FieldOffset(0x128)] public Utf8String Description;
    [FieldOffset(0x190)] public Utf8String Objective;

    [FieldOffset(0x3AC)] public byte State;
    [FieldOffset(0x3AF)] public byte HandInCount;
    [FieldOffset(0x3B8)] public byte Progress;
    [FieldOffset(0x3C4)] public bool IsExpBonus;
    [FieldOffset(0x3D8)] public uint IconId;
    [FieldOffset(0x3F9)] public byte Level;
    [FieldOffset(0x3FA)] public byte MaxLevel;
    [FieldOffset(0x450)] public Vector3 Location;
    [FieldOffset(0x464)] public float Radius;

    [FieldOffset(0x760)] public uint MapIconId;
    [FieldOffset(0x78E)] public ushort TerritoryId;
}
