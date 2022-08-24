using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Client.UI;
// Client::UI::UI3DModule

// ctor E8 ? ? ? ? 48 8B 44 24 ? 4C 8D BF ? ? ? ? 
[StructLayout(LayoutKind.Explicit, Size = 0x11AA0)]
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
        [FieldOffset(0x4E)] public byte NamePlateIndex;
        [FieldOffset(0x4F)] public byte Unk_4F;

        [FieldOffset(0x50)] public byte SortPriority;
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
    [FieldOffset(0x20)] public fixed byte ObjectInfoArray[596 * 0x60]; // array of Client::UI::UI3DModule::ObjectInfo
    [FieldOffset(0xDFA0)] public fixed byte SortedObjectInfoPointerArray[596 * 0x8]; // array of Client::UI::UI3DModule::ObjectInfo*, distance sorted(?)
    [FieldOffset(0xF240)] public int SortedObjectInfoCount;
    [FieldOffset(0xF248)] public fixed byte NamePlateObjectInfoPointerArray[50 * 0x8]; // array of Client::UI::UI3DModule::ObjectInfo* for current nameplates
    [FieldOffset(0xF3D8)] public int NamePlateObjectInfoCount;
    // [FieldOffset(0xAED0)] public Bit NamePlateBits; // Client::System::Data::Bit
    [FieldOffset(0xF400)] public fixed byte NamePlateObjectIdList[50 * 0x8]; // array of GameObjectID (see GameObject.cs), ObjectId = E0000000 means it is empty, matches the order of nameplate addon objects
    [FieldOffset(0xF590)] public fixed byte NamePlateObjectIdList_2[50 * 0x8]; // seems to contain same data as above, but may be for working data
    [FieldOffset(0xF720)] public fixed byte CharacterObjectInfoPointerArray[50 * 0x8]; // array of Client::UI::UI3DModule::ObjectInfo* for Characters on screen (players, attackable NPCs, etc)
    [FieldOffset(0xF8B0)] public int CharacterObjectInfoCount;
    [FieldOffset(0xF8B8)] public fixed byte MapObjectInfoPointerArray[68 * 0x8]; // array of Client::UI::UI3DModule::ObjectInfo* for objects displayed on minimap - summoning bells, mailboxes, etc
    [FieldOffset(0xFAD8)] public int MapObjectInfoCount;
    [FieldOffset(0xFAE0)] public ObjectInfo* TargetObjectInfo;
    [FieldOffset(0xFAE8)] public fixed byte MemberInfoArray[48 * 0x28]; // array of Client::UI::UI3DModule::MemberInfo, size = max alliance size
    [FieldOffset(0x10268)] public fixed byte MemberInfoPointerArray[48 * 0x8]; // array of Client::UI::UI3DModule::MemberInfo*
    [FieldOffset(0x103E8)] public int MemberInfoCount;
    [FieldOffset(0x103F0)] public fixed byte UnkInfoArray[30 * 0x40];
    [FieldOffset(0x10B70)] public int UnkCount;
    // there's more after this
}