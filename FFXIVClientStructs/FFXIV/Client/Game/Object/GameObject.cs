using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;
using FFXIVClientStructs.FFXIV.Common.Math;
using EventHandler = FFXIVClientStructs.FFXIV.Client.Game.Event.EventHandler;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::GameObject
// ctor "E8 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 48 89 AE ?? ?? ?? ?? 48 8B D3"
// base class for game objects in the world
[StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? c7 81 80 00 00 00 00 00 00 00", 3)]
public unsafe partial struct GameObject {
    [FieldOffset(0x10)] public Vector3 DefaultPosition;
    [FieldOffset(0x20)] public float DefaultRotation;
    [FieldOffset(0x30)] public fixed byte Name[64];
    [FieldOffset(0x74)] public uint ObjectID; //TODO: rename to EntityId
    [FieldOffset(0x78)] public uint LayoutID;
    [FieldOffset(0x80)] public uint DataID; //TODO: raname to BaseId
    [FieldOffset(0x84)] public uint OwnerID;
    [FieldOffset(0x88)] public ushort ObjectIndex; // index in object table
    [FieldOffset(0x8C)] public byte ObjectKind;
    [FieldOffset(0x8D)] public byte SubKind;
    [FieldOffset(0x8E)] public byte Sex;
    [Obsolete("Renamed to Sex")]
    [FieldOffset(0x8E)] public byte Gender;
    [FieldOffset(0x90)] public byte YalmDistanceFromPlayerX;
    [FieldOffset(0x91)] public byte TargetStatus; // Goes from 6 to 2 when selecting a target and flashing a highlight
    [FieldOffset(0x92)] public byte YalmDistanceFromPlayerZ;
    [FieldOffset(0x95)] public ObjectTargetableFlags TargetableStatus; // Determines whether the game object can be targeted by the user
    [FieldOffset(0xB0)] public Vector3 Position;
    [FieldOffset(0xC0)] public float Rotation;
    [FieldOffset(0xC4)] public float Scale;
    [FieldOffset(0xC8)] public float Height;
    [FieldOffset(0xCC)] public float VfxScale;
    [FieldOffset(0xD0)] public float HitboxRadius;
    [FieldOffset(0xE0)] public Vector3 DrawOffset;
    [FieldOffset(0xF4)] public EventId EventId;
    [FieldOffset(0xF8)] public uint FateId;
    [FieldOffset(0x100)] public DrawObject* DrawObject;
    [FieldOffset(0x110)] public uint NamePlateIconId;
    [FieldOffset(0x114)] public int RenderFlags;
    [FieldOffset(0x158)] public LuaActor* LuaActor;
    [FieldOffset(0x160)] public EventHandler* EventHandler;

    [VirtualFunction(1)]
    public partial GameObjectID GetObjectID();

    [VirtualFunction(2)]
    public partial byte GetObjectKind();

    [VirtualFunction(4)]
    public partial bool GetIsTargetable();

    [VirtualFunction(6)]
    public partial byte* GetName();

    [VirtualFunction(7)]
    public partial float GetRadius();

    [VirtualFunction(8)]
    public partial float GetHeight();

    [VirtualFunction(16)]
    public partial void EnableDraw();

    [VirtualFunction(17)]
    public partial void DisableDraw();

    [VirtualFunction(27)]
    public partial DrawObject* GetDrawObject();

    [VirtualFunction(30)]
    public partial void Highlight(ObjectHighlightColor color);

    [VirtualFunction(38)]
    public partial void SetReadyToDraw();

    [VirtualFunction(47)]
    public partial uint GetNpcID(); //TODO: rename to GetNameId

    [VirtualFunction(57)]
    public partial bool IsDead();

    [VirtualFunction(58)]
    public partial bool IsNotMounted();

    [VirtualFunction(61)]
    public partial bool IsCharacter();

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 74 24 ?? 80 3D")]
    public partial void SetDrawOffset(float x, float y, float z);

    [MemberFunction("E8 ?? ?? ?? ?? 83 FE 4F")]
    public partial void Rotate(float value);

    [MemberFunction("E8 ?? ?? ?? ?? 83 4B 70 01")]
    public partial void SetPosition(float x, float y, float z);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 48 8B 17 45 33 C9")]
    public partial bool IsReadyToDraw();
}

// if (ObjectID == 0xE0000000)
//   if (Companion && Companion.HasOwner && Companion.ObjectID == 0xE0000000) ObjectID = Parent.ObjectID, Type = 4
//   if (DataID == 0 || (ObjectIndex >= 200 && ObjectIndex < 244)) ObjectID = ObjectIndex, Type = 2
//   if (DataID != 0) ObjectID = DataID, Type = 1
// else ObjectID = ObjectID, Type = 0
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct GameObjectID {
    [FieldOffset(0x0)] public uint ObjectID;
    [FieldOffset(0x4)] public byte Type;

    public static unsafe implicit operator ulong(GameObjectID id) => *(ulong*)&id;
    public static unsafe implicit operator GameObjectID(ulong id) => *(GameObjectID*)&id;
}

public enum ObjectKind : byte {
    None = 0,
    Pc = 1,
    BattleNpc = 2,
    EventNpc = 3,
    Treasure = 4,
    Aetheryte = 5,
    GatheringPoint = 6,
    EventObj = 7,
    Mount = 8,
    Companion = 9,
    Retainer = 10,
    AreaObject = 11,
    HousingEventObject = 12,
    Cutscene = 13,
    MjiObject = 14,
    Ornament = 15,
    CardStand = 16
}

[Flags]
public enum ObjectTargetableFlags : byte {
    IsTargetable = 1 << 1,
    Unk1 = 1 << 2, // This flag is used but purpose is unclear
    ReadyToDraw = 1 << 6
}

public enum ObjectHighlightColor : byte {
    None = 0,
    Red = 1,
    Green = 2,
    Blue = 3,
    Yellow = 4,
    Orange = 5,
    Magenta = 6,
    Black = 7
}
