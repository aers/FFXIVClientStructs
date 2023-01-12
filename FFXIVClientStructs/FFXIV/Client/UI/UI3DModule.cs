using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.UI;
// Client::UI::UI3DModule

// ctor E8 ?? ?? ?? ?? 48 8B 44 24 ?? 4C 8D BF ?? ?? ?? ?? 
[StructLayout(LayoutKind.Explicit, Size = 0x11BE0)]
public unsafe struct UI3DModule
{
    // Client::UI::UI3DModule::MapInfo
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct MapInfo
    {
        [FieldOffset(0x8)] public int MapId;

        [FieldOffset(0xC)] public int IconId;

        // theres some other unknowns in here
        [FieldOffset(0x12)] public byte Unk_12;
    }

    // ObjectKind => NamePlateObjectKind
    // 1 => 0
    // 2 => SubKind6 = 8, enemy = 3, friendly = 4
    // 3, 9 => 1
    // 4 => 6
    // 5, 7, 12, 16 => 5
    // 6 => 7
    // 10 => 2              
    // rest => 9

    // Client::UI::UI3DModule::ObjectInfo
    //   Client::UI::UI3DModule::MapInfo
    // ctor inlined
    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public struct ObjectInfo
    {
        [FieldOffset(0x0)] public MapInfo MapInfo;
        [FieldOffset(0x18)] public GameObject* GameObject;
        [FieldOffset(0x20)] public Vector3 NamePlatePos;
        [FieldOffset(0x30)] public Vector3 ObjectPosProjectedScreenSpace; // maybe
        [FieldOffset(0x40)] public float DistanceFromCamera;
        [FieldOffset(0x44)] public float DistanceFromPlayer; // 0 for player
        [FieldOffset(0x48)] public uint Unk_48;
        [FieldOffset(0x4C)] public byte NamePlateScale;
        [FieldOffset(0x4D)] public byte NamePlateObjectKind;
        [FieldOffset(0x4E)] public byte NamePlateObjectKindAdjusted;
        [FieldOffset(0x4F)] public byte NamePlateIndex;
        [FieldOffset(0x50)] public byte Unk_50;

        [FieldOffset(0x51)] public byte SortPriority;
        // rest unknown
    }

    // Client::UI::UI3DModule::MemberInfo
    //   Client::UI::UI3DModule::MapInfo
    // ctor inlined
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct MemberInfo
    {
        [FieldOffset(0x0)] public MapInfo MapInfo;
        [FieldOffset(0x18)] public BattleChara* BattleChara;

        [FieldOffset(0x20)] public byte Unk_20;
        // rest unknown
    }

    // new since 2.3
    // Client::UI::UI3DModule::UnkInfo
    //   Client::UI::UI3DModule::MapInfo
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public struct UnkInfo
    {
        [FieldOffset(0x0)] public MapInfo MapInfo;
        // rest unknown
    }

    [FieldOffset(0x10)] public UIModule* UIModule;
    [FieldOffset(0x20)] public fixed byte ObjectInfoArray[599 * 0x60]; // array of Client::UI::UI3DModule::ObjectInfo
    [FieldOffset(0xE0C0)] public fixed byte SortedObjectInfoPointerArray[599 * 0x8]; // array of Client::UI::UI3DModule::ObjectInfo*, distance sorted(?)
    [FieldOffset(0xF378)] public int SortedObjectInfoCount;
    [FieldOffset(0xF380)] public fixed byte NamePlateObjectInfoPointerArray[50 * 0x8]; // array of Client::UI::UI3DModule::ObjectInfo* for current nameplates
    [FieldOffset(0xF510)] public int NamePlateObjectInfoCount;
    // [FieldOffset(0xF518)] public Bit NamePlateBits; // Client::System::Data::Bit
    [FieldOffset(0xF538)] public fixed byte NamePlateObjectIdList[50 * 0x8]; // array of GameObjectID (see GameObject.cs), ObjectId = E0000000 means it is empty, matches the order of nameplate addon objects
    [FieldOffset(0xF6C8)] public fixed byte NamePlateObjectIdList_2[50 * 0x8]; // seems to contain same data as above, but may be for working data
    [FieldOffset(0xF858)] public fixed byte CharacterObjectInfoPointerArray[50 * 0x8]; // array of Client::UI::UI3DModule::ObjectInfo* for Characters on screen (players, attackable NPCs, etc)
    [FieldOffset(0xF9E8)] public int CharacterObjectInfoCount;
    [FieldOffset(0xF950)] public fixed byte MapObjectInfoPointerArray[68 * 0x8]; // array of Client::UI::UI3DModule::ObjectInfo* for objects displayed on minimap - summoning bells, mailboxes, etc
    [FieldOffset(0xFC10)] public int MapObjectInfoCount;
    [FieldOffset(0xFC18)] public ObjectInfo* TargetObjectInfo;
    [FieldOffset(0xFC20)] public fixed byte MemberInfoArray[48 * 0x28]; // array of Client::UI::UI3DModule::MemberInfo, size = max alliance size
    [FieldOffset(0x103A0)] public fixed byte MemberInfoPointerArray[48 * 0x8]; // array of Client::UI::UI3DModule::MemberInfo*
    [FieldOffset(0x10520)] public int MemberInfoCount;
    [FieldOffset(0x10530)] public fixed byte UnkInfoArray[30 * 0x40];
    [FieldOffset(0x10CB0)] public int UnkCount;
    // there's more after this
}
