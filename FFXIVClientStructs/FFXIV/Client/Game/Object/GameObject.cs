using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// if (ObjectID == 0xE0000000)
//   if (Companion && Companion.HasOwner && Companion.ObjectID == 0xE0000000) ObjectID = Parent.ObjectID, Type = 4
//   if (DataID == 0 || (ObjectIndex >= 200 && ObjectIndex < 244)) ObjectID = ObjectIndex, Type = 2
//   if (DataID != 0) ObjectID = DataID, Type = 1
// else ObjectID = ObjectID, Type = 0
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct GameObjectID
{
    [FieldOffset(0x0)] public uint ObjectID;
    [FieldOffset(0x4)] public byte Type;

    public static unsafe implicit operator long(GameObjectID id) {
        var objid = stackalloc GameObjectID[] {id};
        return *(long*)objid;
    }

    public static unsafe implicit operator GameObjectID(long id) {
        var objid = stackalloc long[] {id};
        return *(GameObjectID*)objid;
    }
}

// Client::Game::Object::GameObject
// base class for game objects in the world

// size = 0x1A0
// ctor E8 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 48 89 AE ?? ?? ?? ?? 48 8B D7 
[StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
public unsafe partial struct GameObject 
{
    [FieldOffset(0x10)] public Vector3 DefaultPosition;
    [FieldOffset(0x20)] public float DefaultRotation;
    [FieldOffset(0x30)] public fixed byte Name[64];
    [FieldOffset(0x74)] public uint ObjectID;
    [FieldOffset(0x80)] public uint DataID;
    [FieldOffset(0x84)] public uint OwnerID;
    [FieldOffset(0x88)] public ushort ObjectIndex; // index in object table
    [FieldOffset(0x8C)] public byte ObjectKind;
    [FieldOffset(0x8D)] public byte SubKind;
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
    [FieldOffset(0xF4)] public EventId EventId;
    [FieldOffset(0xF8)] public uint FateId;
    [FieldOffset(0x100)] public DrawObject* DrawObject;
    [FieldOffset(0x114)] public int RenderFlags;
    [FieldOffset(0x158)] public LuaActor* LuaActor;

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

    [VirtualFunction(47)]
    public partial uint GetNpcID();

    [VirtualFunction(56)]
    public partial bool IsDead();

    [VirtualFunction(57)]
    public partial bool IsNotMounted();
    
    [VirtualFunction(60)]
    public partial bool IsCharacter();
}

public enum ObjectKind : byte
{
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
    CardStand = 14,
    Ornament = 15
}

[Flags]
public enum ObjectTargetableFlags : byte
{
    IsTargetable = 2,
    Unk1 = 4, // This flag is used but purpose is unclear
}