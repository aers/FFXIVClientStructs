using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.Graphics;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;
using FFXIVClientStructs.FFXIV.Client.UI.Arrays;
using FFXIVClientStructs.FFXIV.Common.Math;
using EventHandler = FFXIVClientStructs.FFXIV.Client.Game.Event.EventHandler;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::GameObject
// ctor "E8 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 48 89 AE ?? ?? ?? ?? 48 8B D3"
// base class for game objects in the world
[GenerateInterop(isInherited: true)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? C7 81 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 48 8B C1", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
public unsafe partial struct GameObject {
    [FieldOffset(0x10)] public Vector3 DefaultPosition;
    [FieldOffset(0x20)] public float DefaultRotation;
    [FieldOffset(0x30), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;
    [FieldOffset(0x70)] public byte EventState;
    [FieldOffset(0x78)] public uint EntityId;
    [FieldOffset(0x7C)] public uint LayoutId;
    [FieldOffset(0x84)] public uint BaseId;
    [FieldOffset(0x88)] public uint OwnerId;
    [FieldOffset(0x8C)] public ushort ObjectIndex; // index in object table
    [FieldOffset(0x90)] public ObjectKind ObjectKind;
    [FieldOffset(0x91), CExporterUnion("SubKind")] public byte SubKind;
    /// <remarks> Use only when <see cref="ObjectKind"/> is <see cref="ObjectKind.BattleNpc"/>. </remarks>
    [FieldOffset(0x91), CExporterUnion("SubKind")] public BattleNpcSubKind BattleNpcSubKind;
    [FieldOffset(0x92)] public byte Sex;
    [FieldOffset(0x94)] public byte YalmDistanceFromPlayerX;
    [FieldOffset(0x95)] public byte TargetStatus; // Goes from 6 to 2 when selecting a target and flashing a highlight
    [FieldOffset(0x96)] public byte YalmDistanceFromPlayerZ;
    [FieldOffset(0x9A)] public ObjectTargetableFlags TargetableStatus; // Determines whether the game object can be targeted by the user
    [FieldOffset(0xB0)] public Vector3 Position;
    [FieldOffset(0xC0)] public float Rotation;
    [FieldOffset(0xC4)] public float Scale;
    [FieldOffset(0xC8)] public float Height;
    [FieldOffset(0xCC)] public float VfxScale;
    [FieldOffset(0xD0)] public float HitboxRadius;
    [FieldOffset(0xE0)] public Vector3 DrawOffset;
    // [FieldOffset(0xF0)] public float RotationOffset; ?
    [FieldOffset(0xF4)] public EventId EventId;
    [FieldOffset(0xF8)] public ushort FateId;
    [FieldOffset(0x100)] public DrawObject* DrawObject;
    [FieldOffset(0x108)] public SharedGroupLayoutInstance* SharedGroupLayoutInstance;
    [FieldOffset(0x110)] public uint NamePlateIconId;
    /// <remarks>
    /// Controls what gets rendered or not some is hide some is show flags.
    /// </remarks>
    [FieldOffset(0x118)] public VisibilityFlags RenderFlags;
    /// <remarks>
    /// This value is interpolated and gets updated every frame.<br/>
    /// To set the target offset, use <see cref="NameplateOffsetTarget"/>.
    /// </remarks>
    [FieldOffset(0x120)] public Vector3 NameplateOffset;
    /// <remarks>
    /// This value is interpolated and gets updated every frame.<br/>
    /// To set the target offset, use <see cref="CameraOffsetTarget"/>.
    /// </remarks>
    [FieldOffset(0x130)] public Vector3 CameraOffset;
    // [FieldOffset(0x140)] private Vector3 Unk140; // something SharedGroupLayoutInstance related
    // [FieldOffset(0x150)] private uint Unk150; // something QuestRedo related
    [FieldOffset(0x158)] public LuaActor* LuaActor;
    [FieldOffset(0x160)] public EventHandler* EventHandler;
    // [FieldOffset(0x168)] private float Unk168; // ModelChara.Unknown3 * 0.1f
    [FieldOffset(0x16C)] public float NameplateOffsetScaleMultiplier; // ModelChara.Unknown6 * 0.1f
    [FieldOffset(0x170)] public Vector3 NameplateOffsetTarget;
    [FieldOffset(0x180)] public Vector3 CameraOffsetTarget;
    // [FieldOffset(0x190)] public byte AnimationFlags; // not sure, but & 1 = PapVariation

    [VirtualFunction(1)]
    public partial GameObjectId GetGameObjectId();

    [VirtualFunction(2)]
    public partial ObjectKind GetObjectKind();

    [VirtualFunction(4)]
    public partial bool GetIsTargetable();

    [VirtualFunction(6)]
    public partial CStringPointer GetName();

    [VirtualFunction(7)]
    public partial float GetRadius(bool adjustByTransformation = true);

    [VirtualFunction(8)]
    public partial float GetHeight();

    [VirtualFunction(11)]
    public partial byte GetSex();

    [VirtualFunction(12)]
    public partial void EnableDraw();

    [VirtualFunction(13)]
    public partial void DisableDraw();

    [VirtualFunction(23)]
    public partial DrawObject* GetDrawObject();

    [VirtualFunction(26)]
    public partial void Highlight(ObjectHighlightColor color);

    /// <param name="outHandlers">Should point to array that can fit up to 32 pointers.</param>
    /// <returns>Num elements filled.</returns>
    [VirtualFunction(30)]
    public partial int GetEventHandlersImpl(EventHandler** outHandlers);

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

    [VirtualFunction(59)]
    public partial void Terminate();

    [VirtualFunction(60)]
    public partial GameObject* Dtor(byte freeFlags);

    [VirtualFunction(61)]
    public partial bool IsCharacter();

    [VirtualFunction(68)]
    public partial void OnInitialize();

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

    [MemberFunction("E8 ?? ?? ?? ?? 83 FE 20")]
    public partial void SetRotation(float value);

    [MemberFunction("E8 ?? ?? ?? ?? 83 4B 70 01")]
    public partial void SetPosition(float x, float y, float z);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 48 8B 17 45 33 C9")]
    public partial bool IsReadyToDraw();

    [MemberFunction("E8 ?? ?? ?? ?? 49 63 F4")]
    public partial Vector3* GetPosition();

    [MemberFunction("E8 ?? ?? ?? ?? 89 85 ?? ?? ?? ?? 0F 57 C0")]
    public partial uint GetObjStrId();

    /// <summary>
    /// Gets the id of a saved nameplate color for this game object
    /// </summary>
    /// <remarks>
    /// The index refers to a hex-color array containing a mix of values from ConfigOptions and hardcoded values:<br/>
    /// [0] NamePlateEdgeObject, NamePlateColorObject<br/>
    /// [1] NamePlateEdgeSelf, NamePlateColorSelf<br/>
    /// [2] NamePlateEdgeParty, NamePlateColorParty<br/>
    /// [3] NamePlateEdgeOther, NamePlateColorOther<br/>
    /// [4] NamePlateColorLimEdge, NamePlateColorLim<br/>
    /// [5] NamePlateColorGriEdge, NamePlateColorGri<br/>
    /// [6] NamePlateColorUldEdge, NamePlateColorUld<br/>
    /// [7] NamePlateEdgeUnengagedEnemy, NamePlateColorUnengagedEnemy<br/>
    /// [8] 0xFF000000, 0xFFBFBFBF (Dead)<br/>
    /// [9] NamePlateEdgeEngagedEnemy, NamePlateColorEngagedEnemy<br/>
    /// [10] NamePlateEdgeClaimedEnemy, NamePlateColorClaimedEnemy<br/>
    /// [11] NamePlateEdgeUnclaimedEnemy, NamePlateColorUnclaimedEnemy<br/>
    /// [12] NamePlateEdgeNpc, NamePlateColorNpc<br/>
    /// [13] NamePlateEdgeNpc, NamePlateColorNpc<br/>
    /// [14] NamePlateEdgeMinion, NamePlateColorMinion<br/>
    /// [15] NamePlateEdgeSelfBuddy, NamePlateColorSelfBuddy<br/>
    /// [16] NamePlateEdgeSelfPet, NamePlateColorSelfPet<br/>
    /// [17] NamePlateEdgeOtherBuddy, NamePlateColorOtherBuddy<br/>
    /// [18] NamePlateEdgeOtherPet, NamePlateColorOtherPet<br/>
    /// [19] 0xFF985008, 0xFFFEFFE8<br/>
    /// [20] NamePlateEdgeAlliance, NamePlateColorAlliance<br/>
    /// [21] 0xFF000000, 0xFFBFBFBF<br/>
    /// [23] NamePlateColorHousingFieldEdge, NamePlateColorHousingField<br/>
    /// [24] NamePlateColorHousingFurnitureEdge, NamePlateColorHousingFurniture<br/>
    /// [25] 0xFF8C5900, 0xFFFEFFE8<br/>
    /// [26] 0xFF070F86, 0xFFBFBDFF<br/>
    /// [27] NamePlateEdgeTank, NamePlateColorTank<br/>
    /// [28] NamePlateEdgeHealer, NamePlateColorHealer<br/>
    /// [29] NamePlateEdgeDps, NamePlateColorDps<br/>
    /// [30] NamePlateEdgeOtherClass, NamePlateColorOtherClass
    /// </remarks>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B 35 ?? ?? ?? ?? 48 8B F9")]
    public partial byte GetNamePlateColorType();

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 43 FB")]
    public partial NamePlateColors GetNamePlateColors();

    /// <summary>Gets the world position where the base (bottom center) of the nameplate is to be placed.</summary>
    /// <param name="vector">A caller-supplied buffer (of one vector) to write the position into.</param>
    /// <returns><paramref name="vector" /></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 FF 0F 84 ?? ?? ?? ?? F3 0F 10 97")]
    public partial Vector3* GetNamePlateWorldPosition(Vector3* vector);

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct NamePlateColors {
        [FieldOffset(0x00), CExporterIgnore] public ulong Data;
        /// <seealso cref="Hud2NumberArray.TargetBarBackdropColor"/>
        [FieldOffset(0x00)] public ByteColor EdgeColor;
        /// <seealso cref="Hud2NumberArray.TargetBarFillColor"/>
        [FieldOffset(0x04)] public ByteColor Color;

        public static implicit operator ulong(NamePlateColors colors) => colors.Data;
        public static implicit operator NamePlateColors(ulong colors) => *(NamePlateColors*)&colors;
    }
}

// if (EntityId == 0xE0000000)
//   if (Companion && Companion.HasOwner && Companion.EntityId == 0xE0000000) ObjectId = Parent.EntityId, Type = 4
//   if (BaseId == 0 || (ObjectIndex >= 200 && ObjectIndex < 244)) ObjectId = ObjectIndex, Type = 2
//   if (BaseId != 0) ObjectId = BaseId, Type = 1
// else ObjectId = EntityId, Type = 0
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public struct GameObjectId : IEquatable<GameObjectId>, IComparable<GameObjectId> {
    [FieldOffset(0x00), CExporterIgnore] public ulong Id;
    [FieldOffset(0x00)] public uint ObjectId;
    [FieldOffset(0x04)] public byte Type;

    public static implicit operator ulong(GameObjectId id) => id.Id;
    public static unsafe implicit operator GameObjectId(ulong id) => *(GameObjectId*)&id;
    public bool Equals(GameObjectId other) => Id == other.Id;
    public override bool Equals(object? obj) => obj is GameObjectId other && Equals(other);
    public override int GetHashCode() => Id.GetHashCode();
    public static bool operator ==(GameObjectId left, GameObjectId right) => left.Id == right.Id;
    public static bool operator !=(GameObjectId left, GameObjectId right) => left.Id != right.Id;
    public int CompareTo(GameObjectId other) => Id.CompareTo(other);
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
    ReactionEventObject = 14,
    Ornament = 15,
    CardStand = 16
}

/// <summary>
/// Enum for <see cref="GameObject.SubKind"/> when <see cref="GameObject.ObjectKind"/> is <see cref="ObjectKind.BattleNpc"/>.
/// </summary>
public enum BattleNpcSubKind : byte {
    None = 0,
    /// <summary> Weak Spots </summary>
    BNpcPart = 1,
    /// <summary> Carbuncle, Eos/Selene, Machinists Rook Autoturret/Automaton Queen, Whitemages Lilybell, probably more. </summary>
    Pet = 2,
    /// <summary> Chocobo Companion </summary>
    Buddy = 3,

    /// <summary> Enemies, Guards </summary>
    Combatant = 5,
    /// <summary> Chocobos in Chocobo Racing </summary>
    RaceChocobo = 6,
    /// <summary> Minions in Lord of Verminion </summary>
    LovmMinion = 7,

    /// <summary> Squadron, Trust, Duty Support </summary>
    NpcPartyMember = 9,
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

[Flags]
public enum VisibilityFlags : ulong {
    None = 0,
    Model = 1ul << 1,
    Nameplate = 1ul << 11
}
