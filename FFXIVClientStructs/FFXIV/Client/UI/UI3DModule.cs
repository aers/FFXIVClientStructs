using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::UI3DModule

    // ctor E8 ? ? ? ? 48 8B 44 24 ? 4C 8D BF ? ? ? ? 
    [StructLayout(LayoutKind.Explicit, Size=0xD4C0)]
    public unsafe partial struct UI3DModule
    {
        // Client::UI::UI3DModule::MapInfo
        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public unsafe partial struct MapInfo
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
        public unsafe partial struct ObjectInfo
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
        public unsafe partial struct MemberInfo
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
        public unsafe partial struct UnkInfo
        {
            [FieldOffset(0x0)] public MapInfo MapInfo;
            // rest unknown
        }

        [FieldOffset(0x10)] public UIModule* UIModule;
        [FieldOffset(0x20)] public fixed byte ObjectInfoArray[424 * 0x60]; // array of Client::UI::UI3DModule::ObjectInfo
        [FieldOffset(0x9F20)] public fixed byte SortedObjectInfoPointerArray[424 * 0x8]; // array of Client::UI::UI3DModule::ObjectInfo*, distance sorted(?)
        [FieldOffset(0xAC60)] public int SortedObjectInfoCount;
        [FieldOffset(0xAC68)] public fixed byte NamePlateObjectInfoPointerArray[50 * 0x8]; // array of Client::UI::UI3DModule::ObjectInfo* for current nameplates
        [FieldOffset(0xADF8)] public int NamePlateObjectInfoCount;
        // [FieldOffset(0xAE00)] public Bit NamePlateBits; // Client::System::Data::Bit
        [FieldOffset(0xAE20)] public fixed byte NamePlateObjectIdList[50 * 0x8]; // array of GameObjectID (see GameObject.cs), ObjectId = E0000000 means it is empty, matches the order of nameplate addon objects
        [FieldOffset(0xAFB0)] public fixed byte NamePlateObjectIdList_2[50 * 0x8]; // seems to contain same data as above, but may be for working data
        [FieldOffset(0xB140)] public fixed byte CharacterObjectInfoPointerArray[50 * 0x8]; // array of Client::UI::UI3DModule::ObjectInfo* for Characters on screen (players, attackable NPCs, etc)
        [FieldOffset(0xB2D0)] public int CharacterObjectInfoCount;
        [FieldOffset(0xB2D8)] public fixed byte MapObjectInfoPointerArray[68 * 0x8];  // array of Client::UI::UI3DModule::ObjectInfo* for objects displayed on minimap - summoning bells, mailboxes, etc
        [FieldOffset(0xB4F8)] public int MapObjectInfoCount;
        [FieldOffset(0xB500)] public ObjectInfo* TargetObjectInfo;
        [FieldOffset(0xB508)] public fixed byte MemberInfoArray[48 * 0x28]; // array of Client::UI::UI3DModule::MemberInfo, size = max alliance size
        [FieldOffset(0xBC88)] public fixed byte MemberInfoPointerArray[48 * 0x8]; // array of Client::UI::UI3DModule::MemberInfo*
        [FieldOffset(0xBE08)] public int MemberInfoCount;
        [FieldOffset(0xBE10)] public fixed byte UnkInfoArray[30 * 0x40];
        [FieldOffset(0xC590)] public int UnkCount;
        // there's more after this
    }
}
