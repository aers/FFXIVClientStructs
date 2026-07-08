using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::Companion
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
//     Client::Game::Character::CharacterData
// companion = minion or FollowMount
[GenerateInterop]
[Inherits<Character>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 48 C7 83", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x2470)]
public unsafe partial struct Companion {
    [FieldOffset(0x2370)] public CompanionType CompanionType;
    [FieldOffset(0x2374)] public ushort Model;
    [FieldOffset(0x2376)] public ushort FollowMountId;
    [FieldOffset(0x2378)] public byte CompanionScale;
    [FieldOffset(0x2379), FixedSizeArray] internal FixedSizeArray2<byte> _companionInactiveIdle;
    [FieldOffset(0x237B)] private byte FollowMountUnknown12;
    [FieldOffset(0x237C)] private byte FollowMountUnknown13;
    [FieldOffset(0x237D)] private byte FollowMountUnknown14;
    [FieldOffset(0x237E)] public byte CompanionInactiveBattle;
    [FieldOffset(0x237F)] public byte CompanionInactiveWandering;
    [FieldOffset(0x2380)] private uint FollowMountUnknown0;
    [FieldOffset(0x2384)] private uint FollowMountUnknown1;
    [FieldOffset(0x2388)] private uint FollowMountUnknown2;
    [FieldOffset(0x238C)] private uint FollowMountUnknown3;
    [FieldOffset(0x2390)] private uint FollowMountUnknown4;
    [FieldOffset(0x2394)] public CompanionMove Behavior;
    [FieldOffset(0x2395)] public byte Special;
    [FieldOffset(0x2396)] private byte CompanionUnknown10;
    [FieldOffset(0x2397)] private byte CompanionUnknown11;
    [FieldOffset(0x2398)] public byte WanderingWait;
    // 1 byte padding?
    [FieldOffset(0x239A)] public ushort Priority;
    [FieldOffset(0x239C)] private bool IsCompanionUnknown5;
    [FieldOffset(0x239D)] private bool IsCompanionUnknown6;
    [FieldOffset(0x239E)] private bool IsCompanionUnknown7;
    [FieldOffset(0x239F)] private bool IsCompanionUnknown8;
    [FieldOffset(0x23A0)] private bool IsCompanionUnknown9;
    // 1 byte padding?
    [FieldOffset(0x23A2)] public ushort Enemy;
    [FieldOffset(0x23A4)] public bool IsBattle;

    [FieldOffset(0x23A8)] public VfxList VfxListListenner;
    [FieldOffset(0x23D0)] public Vector3 MoveDestination;
    [FieldOffset(0x23E0)] private Vector3 Unk23E0;
    [FieldOffset(0x23F0)] public Vector3 PlacePosition;// or moving there
    [FieldOffset(0x2400)] public BattleChara* Owner;
    // 0x2408: array of 2 pointers? not sure
    [FieldOffset(0x2418)] private float Unk2418;
    [FieldOffset(0x241C)] private float Unk241C;
    [FieldOffset(0x2420)] private float Unk2420;
    [FieldOffset(0x2424)] private float Unk2424;
    [FieldOffset(0x2428)] private float Unk2428;
    [FieldOffset(0x242C)] private float Unk242C;
    [FieldOffset(0x2430)] private float Unk2430;
    [FieldOffset(0x2434)] private float Unk2434;
    [FieldOffset(0x2438)] private float Unk2438; // some Rotation
    [FieldOffset(0x2440)] private float Unk2440; // some Radius
    [FieldOffset(0x2444)] public float MoveCooldown;
    [FieldOffset(0x2448)] private float Unk2448;
    [FieldOffset(0x244C)] private uint Unk244C;
    [FieldOffset(0x2450)] private ushort Unk2450;
    [FieldOffset(0x2452)] private ushort Unk2452; // flags
    [FieldOffset(0x2454)] public ushort EmoteOwnerObjectIndex; // index in CharacterManager.BattleCharas
    [FieldOffset(0x2456)] private byte Unk2456;
    [FieldOffset(0x2457)] public CompanionSpawnState SpawnState;
    [FieldOffset(0x2458)] public CompanionBehaviorState BehaviorState;
    [FieldOffset(0x2459)] private byte Unk2459;
    [FieldOffset(0x245A)] public byte BehaviorSpecial;
    [FieldOffset(0x245B)] private byte Unk245B;
    [FieldOffset(0x245C)] private byte Unk245C;
    [FieldOffset(0x245D)] private bool Unk245D;
    [FieldOffset(0x245E)] public bool IsEmoteFromOwner;
    [FieldOffset(0x245F)] private bool Unk245F;
    [FieldOffset(0x2460)] private bool Unk2460;
    [FieldOffset(0x2461)] private bool Unk2461;
    [FieldOffset(0x2462)] private bool Unk2462;
    [FieldOffset(0x2463)] private bool Unk2463;

    /// <summary> Used when the companion places itself on its owner's shoulder or head. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F B6 87")]
    public partial void PlaceCompanion();

    // Client::Game::Character::Companion::VfxList
    //   Client::Graphics::Vfx::VfxDataListenner
    [GenerateInterop]
    [Inherits<VfxDataListenner>]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct VfxList {
        [FieldOffset(0x08)] public GameObject* OwnerObject;
        // array of 3 VfxData* here
    }
}

public enum CompanionType {
    None,
    /// <summary> Uses the Companion sheet. </summary>
    Companion,
    /// <summary> Uses the FollowMount sheet. </summary>
    FollowMount
}

public enum CompanionMove : byte {
    None,
    Obedient,
    Independent,
    Stationary,
}

public enum CompanionSpawnState : byte {
    None,
    Spawning,
    Despawning,
    Active,
    Unk4
}

public enum CompanionBehaviorState : byte {
    Idle = 0,
    Follow = 1, // following the owner character
    Unk2 = 2,
    BeingFed = 3,
    Unk4 = 4, // same case as BeingFed
    Move = 5, // moving to MoveDestination
    Unk6 = 6,
    Unk7 = 7,
    Unk8 = 8,
    Place = 9, // sitting on characters shoulder or head, or moving there
    Unk10 = 10,
    Unk11 = 11,
    Unk12 = 12,
    Unk13 = 13,
    Unk14 = 14,
    Unk15 = 15,
    Unk16 = 16,
    Unk17 = 17,
}
