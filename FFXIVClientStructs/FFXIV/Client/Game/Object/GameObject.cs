using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.Graphics;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;
using FFXIVClientStructs.FFXIV.Common.Math;
using EventHandler = FFXIVClientStructs.FFXIV.Client.Game.Event.EventHandler;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::GameObject
// ctor "E8 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 48 89 AE ?? ?? ?? ?? 48 8B D3"
// base class for game objects in the world
[GenerateInterop(isInherited: true)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? C7 81 80 00 00 00 00 00 00 00", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
public unsafe partial struct GameObject {
    [FieldOffset(0x10)] public Vector3 DefaultPosition;
    [FieldOffset(0x20)] public float DefaultRotation;
    [FieldOffset(0x30), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;
    [FieldOffset(0x70)] public byte EventState;
    [FieldOffset(0x74)] public uint EntityId;
    [FieldOffset(0x78)] public uint LayoutId;
    [FieldOffset(0x80)] public uint BaseId;
    [FieldOffset(0x84)] public uint OwnerId;
    [FieldOffset(0x88)] public ushort ObjectIndex; // index in object table
    [FieldOffset(0x8C)] public ObjectKind ObjectKind;
    [FieldOffset(0x8D)] public byte SubKind;
    [FieldOffset(0x8E)] public byte Sex;
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
    [Obsolete("Use SharedGroupLayoutInstance")]
    [FieldOffset(0x108)] public ILayoutInstance* LayoutInstance;
    [FieldOffset(0x108)] public SharedGroupLayoutInstance* SharedGroupLayoutInstance;
    [FieldOffset(0x110)] public uint NamePlateIconId;
    [FieldOffset(0x118)] public int RenderFlags;
    [FieldOffset(0x158)] public LuaActor* LuaActor;
    [FieldOffset(0x160)] public EventHandler* EventHandler;

    [VirtualFunction(1)]
    public partial GameObjectId GetGameObjectId();

    [VirtualFunction(2)]
    public partial ObjectKind GetObjectKind();

    [VirtualFunction(4)]
    public partial bool GetIsTargetable();

    [VirtualFunction(6)]
    public partial byte* GetName();

    [VirtualFunction(7)]
    public partial float GetRadius();

    [VirtualFunction(8)]
    public partial float GetHeight();

    [VirtualFunction(12)]
    public partial void EnableDraw();

    [VirtualFunction(13)]
    public partial void DisableDraw();

    [VirtualFunction(23)]
    public partial DrawObject* GetDrawObject();

    [VirtualFunction(26)]
    public partial void Highlight(ObjectHighlightColor color);

    [VirtualFunction(34)]
    public partial void SetReadyToDraw();

    [VirtualFunction(46)]
    public partial void GetCenterPosition(Vector3* outCenter);

    [VirtualFunction(47)]
    public partial uint GetNameId();

    [VirtualFunction(54)]
    public partial void PositionModified();

    [VirtualFunction(55)]
    public partial void RotationModified();

    [VirtualFunction(57)]
    public partial bool IsDead();

    [VirtualFunction(58)]
    public partial bool IsNotMounted();

    [VirtualFunction(61)]
    public partial bool IsCharacter();

    /// <summary>
    /// Determines whether a ray intersects with the game object, either by checking the model's geometry or the object's approximate center position.
    /// </summary>
    /// <param name="ray">The ray to test for intersection, containing both origin and direction.</param>
    /// <param name="outHitPosition">The output position where the intersection occurs, if any.</param>
    /// <param name="outModelChecked">A boolean output that indicates whether the intersection was checked against the model (<c>true</c>) or approximated via the object's center (<c>false</c>).</param>
    /// <returns><c>true</c> if the ray intersects with the game object; otherwise, <c>false</c>.</returns>
    [VirtualFunction(69)]
    public partial bool IntersectsRay(Ray* ray, Vector3* outHitPosition, bool* outModelChecked);

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 74 24 ?? 80 3D")]
    public partial void SetDrawOffset(float x, float y, float z);

    [MemberFunction("E8 ?? ?? ?? ?? 83 FE 4F")]
    public partial void SetRotation(float value);

    [MemberFunction("E8 ?? ?? ?? ?? 83 4B 70 01")]
    public partial void SetPosition(float x, float y, float z);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 48 8B 17 45 33 C9")]
    public partial bool IsReadyToDraw();

    [MemberFunction("E8 ?? ?? ?? ?? 0F 5A C7")]
    public partial Vector3* GetPosition();
}

// if (EntityId == 0xE0000000)
//   if (Companion && Companion.HasOwner && Companion.EntityId == 0xE0000000) ObjectId = Parent.EntityId, Type = 4
//   if (BaseId == 0 || (ObjectIndex >= 200 && ObjectIndex < 244)) ObjectId = ObjectIndex, Type = 2
//   if (BaseId != 0) ObjectId = BaseId, Type = 1
// else ObjectId = EntityId, Type = 0
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct GameObjectId {
    [FieldOffset(0x0)] public uint ObjectId;
    [FieldOffset(0x4)] public byte Type;

    public static unsafe implicit operator ulong(GameObjectId id) => *(ulong*)&id;
    public static unsafe implicit operator GameObjectId(ulong id) => *(GameObjectId*)&id;
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
