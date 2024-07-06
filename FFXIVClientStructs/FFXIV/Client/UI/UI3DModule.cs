using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UI3DModule
// ctor "E8 ?? ?? ?? ?? 48 8B 44 24 ?? 4C 8D B7"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x12810)]
public unsafe partial struct UI3DModule {
    [FieldOffset(0x10)] public UIModule* UIModule;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray629<ObjectInfo> _objectInfos; // array of Client::UI::UI3DModule::ObjectInfo
    [FieldOffset(0xEC00), FixedSizeArray] internal FixedSizeArray629<Pointer<ObjectInfo>> _sortedObjectInfoPointers; // array of Client::UI::UI3DModule::ObjectInfo*, distance sorted(?)
    [FieldOffset(0xFFA8)] public int SortedObjectInfoCount;
    [FieldOffset(0xFFB0), FixedSizeArray] internal FixedSizeArray50<Pointer<ObjectInfo>> _namePlateObjectInfoPointers; // array of Client::UI::UI3DModule::ObjectInfo* for current nameplates
    [FieldOffset(0x10140)] public int NamePlateObjectInfoCount;
    // [FieldOffset(0x10148)] public Bit NamePlateBits; // Client::System::Data::Bit
    [FieldOffset(0x10168), FixedSizeArray] internal FixedSizeArray50<GameObjectId> _namePlateObjectIds; // array of GameObjectID (see GameObject.cs), ObjectId = E0000000 means it is empty, matches the order of nameplate addon objects
    [FieldOffset(0x102F8), FixedSizeArray] internal FixedSizeArray50<GameObjectId> _namePlateObjectIds_2; // seems to contain same data as above, but may be for working data
    [FieldOffset(0x10488), FixedSizeArray] internal FixedSizeArray50<Pointer<ObjectInfo>> _characterObjectInfoPointers; // array of Client::UI::UI3DModule::ObjectInfo* for Characters on screen (players, attackable NPCs, etc)
    [FieldOffset(0x10618)] public int CharacterObjectInfoCount;
    [FieldOffset(0x10620), FixedSizeArray] internal FixedSizeArray68<Pointer<ObjectInfo>> _mapObjectInfoPointers; // array of Client::UI::UI3DModule::ObjectInfo* for objects displayed on minimap - summoning bells, mailboxes, etc
    [FieldOffset(0x10840)] public int MapObjectInfoCount;
    [FieldOffset(0x10848)] public ObjectInfo* TargetObjectInfo;
    [FieldOffset(0x10850), FixedSizeArray] internal FixedSizeArray48<MemberInfo> _memberInfos; // array of Client::UI::UI3DModule::MemberInfo, size = max alliance size
    [FieldOffset(0x10FD0), FixedSizeArray] internal FixedSizeArray48<Pointer<MemberInfo>> _memberInfoPointers; // array of Client::UI::UI3DModule::MemberInfo*
    [FieldOffset(0x11150)] public int MemberInfoCount;
    [FieldOffset(0x11160), FixedSizeArray] internal FixedSizeArray30<UnkInfo> _unkInfoArray;
    [FieldOffset(0x118E0)] public int UnkCount;
    // there's more after this

    // Client::UI::UI3DModule::MapInfo
    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct MapInfo {
        [FieldOffset(0x8)] public uint MapId;

        [FieldOffset(0xC)] public uint IconId;

        // theres some other unknowns in here
        [FieldOffset(0x12)] public byte Unk_12;
    }

    // Client::UI::UI3DModule::ObjectInfo
    //   Client::UI::UI3DModule::MapInfo
    // ctor inlined
    [GenerateInterop]
    [Inherits<MapInfo>]
    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct ObjectInfo {
        [FieldOffset(0x18)] public GameObject* GameObject;
        [FieldOffset(0x20)] public Vector3 NamePlatePos;
        [FieldOffset(0x30)] public Vector3 ObjectPosProjectedScreenSpace; // maybe
        [FieldOffset(0x40)] public float DistanceFromCamera;
        [FieldOffset(0x44)] public float DistanceFromPlayer; // 0 for player
        [FieldOffset(0x48)] public uint Unk_48;
        [FieldOffset(0x4C)] public byte NamePlateScale;
        [FieldOffset(0x4D)] public UIObjectKind NamePlateObjectKind;
        [FieldOffset(0x4E)] public UIObjectKind NamePlateObjectKindAdjusted; // identical to above except in one single case
        [FieldOffset(0x4F)] public byte NamePlateIndex;
        [FieldOffset(0x50)] public byte Unk_50;

        [FieldOffset(0x51)] public byte SortPriority;
        // rest unknown
    }

    // Client::UI::UI3DModule::MemberInfo
    //   Client::UI::UI3DModule::MapInfo
    // ctor inlined
    [GenerateInterop]
    [Inherits<MapInfo>]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct MemberInfo {
        [FieldOffset(0x18)] public BattleChara* BattleChara;

        [FieldOffset(0x20)] public byte Unk_20;
        // rest unknown
    }

    // new since 2.3
    // Client::UI::UI3DModule::UnkInfo
    //   Client::UI::UI3DModule::MapInfo
    [GenerateInterop]
    [Inherits<MapInfo>]
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct UnkInfo;
}

// this function was inlined in UI3DModule::UpdateGameObjects
// ObjectKind => UIObjectKind
// 1 => 0
// 2 => SubKind6 = 8, enemy = 3, friendly = 4
// 3, 9 => 1
// 4 => 6
// 5, 7, 12, 16 => 5
// 6 => 7
// 10 => 2              
// rest => 9

public enum UIObjectKind : byte {
    PlayerCharacter = 0,
    EventNpcCompanion = 1,
    Retainer = 2,
    BattleNpcEnemy = 3,
    BattleNpcFriendly = 4,
    EventObject = 5,
    Treasure = 6,
    GatheringPoint = 7,
    BattleNpcSubkind6 = 8,
    Other = 9
}
