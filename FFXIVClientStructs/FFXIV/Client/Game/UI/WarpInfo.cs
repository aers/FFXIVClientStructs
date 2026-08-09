using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;
using FFXIVClientStructs.FFXIV.Common.Component.BGCollision;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe partial struct WarpInfo {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 75 ?? 48 8B D7", 3)]
    public static partial WarpInfo* Instance();

    [FieldOffset(0x00)] private uint State;
    [FieldOffset(0x04)] private float Unk4;
    [FieldOffset(0x08)] private float Unk8;
    [FieldOffset(0x0C)] public WarpType WarpType;
    [FieldOffset(0x10)] private ExitRangeLayoutInstance* ExitRange;
    [FieldOffset(0x18)] private int Unk18;
    [FieldOffset(0x1C)] private int Unk1C;
    [FieldOffset(0x20)] public Vector3 ZoneLineLastHit;
    [FieldOffset(0x30)] public Vector3 WarpPos;
    [FieldOffset(0x40)] private byte Unk40;
    [FieldOffset(0x41)] private byte Unk41;
    [FieldOffset(0x42)] private byte Unk42;
    [FieldOffset(0x43)] private byte Unk43;
    [FieldOffset(0x44)] private int Unk44;
    [FieldOffset(0x48)] private byte Unk48;
    [FieldOffset(0x4C)] private uint PopRangeId;
    [FieldOffset(0x50)] private byte Unk50;
    [FieldOffset(0x51)] private byte Unk51;
    [FieldOffset(0x52)] private byte Unk52;
    [FieldOffset(0x53)] private byte Unk53;
    [FieldOffset(0x54)] private byte Unk54;
    [FieldOffset(0x55)] private byte Unk55;
    [FieldOffset(0x56)] private byte Unk56;
    [FieldOffset(0x57)] private byte Unk57;
    [FieldOffset(0x58)] private int Unk58;
    [FieldOffset(0x5C)] private byte Unk5C;
    [FieldOffset(0x5D)] private byte Unk5D;
    [FieldOffset(0x5E)] private byte Unk5E;
    [FieldOffset(0x5F)] private byte Unk5F;
    [FieldOffset(0x60)] private float Unk60;
    [FieldOffset(0x68)] public Collider* PrefetchCollider;
    [FieldOffset(0x70)] public PrefetchRangeLayoutInstance* PrefetchRange;
    [FieldOffset(0x78)] public uint PrefetchRangeBoundInstanceId;
    [FieldOffset(0x7C)] public short PrefetchRangePriority;
    [FieldOffset(0x80)] public uint PrefetchExitRangeId;
    [FieldOffset(0x88)] public ExitRangeLayoutInstance* PrefetchExitRange;
    [FieldOffset(0x90)] public Vector3 PrefetchExitRangePos;
    [FieldOffset(0xA0)] public ushort PrefetchExitRangeTerritoryType;
    [FieldOffset(0xA4)] public int PrefetchExitRangeDestInstanceId;
    [FieldOffset(0xA8)] private int UnkA8;
    [FieldOffset(0xB0)] public byte* TerritoryTypeBg;
    [FieldOffset(0xB8)] public InstanceType InstanceType;
    [FieldOffset(0xBC)] public uint DestInstanceId;
    [FieldOffset(0xC0)] public uint TerritoryTypeId;
    [FieldOffset(0xC4)] private byte UnkC4;
    [FieldOffset(0xC5)] private byte UnkC5;
    [FieldOffset(0xC6)] private byte UnkC6;
    [FieldOffset(0xC7)] private byte UnkC7;
    [FieldOffset(0xC8)] private DrawObject* LocalPlayerDrawObject;
    [FieldOffset(0xD0), FixedSizeArray] internal FixedSizeArray3<Pointer<Weapon>> _weapons;
}

public enum WarpType {
    None = 0,
    Normal = 1, // WARP_TYPE_NORMAL
    Unk2 = 2,
    Translate = 3, // name based on TownTranslate further down. seen when walking through ExitRange, changing wards in original housing zones
    Teleport = 4,
    Unk5 = 5,
    Unk6 = 6,
    Return = 7,
    Resurrection = 8,
    RentalChocobo = 9, // WARP_TYPE_RENTAL_CHOCOBO
    ChocoboTaxi = 10, // WARP_TYPE_CHOCOBO_TAXI
    Unk11 = 11,
    EnterInstanceContent = 12,
    LeaveInstanceContent = 13,
    Unk14 = 14,
    TownTranslate = 15, // WARP_TYPE_TOWN_TRANSLATE (Aethernet)
    Unk16 = 16,
    Login = 17, // lua function IsEnterTerritoryEventLogin
    Unk18 = 18,
    Unk19 = 19,
    HousingTeleport = 20,
    Unk21 = 21,
    Unk22 = 22,
    Unk23 = 23,
    Unk24 = 24,
    Event = 25, // anything InstanceContent and, so far discovered, at under water teleports in The Ruby Sea
    Dive = 26,
    WorldTransfer = 27,
    Unk28 = 28,
    Unk29 = 29,
    Unk30 = 30,
}
