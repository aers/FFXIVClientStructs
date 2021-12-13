using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character
{
    // Client::Game::Character::BattleChara
    //   Client::Game::Character::Character
    //     Client::Game::Object::GameObject
    //     Client::Graphics::Vfx::VfxDataListenner
    // characters that fight (players, monsters, etc)

    // size = 0x2C40
    // ctor E8 ? ? ? ? 48 8B F8 EB 02 33 FF 8B 86 ? ? ? ? 
    [StructLayout(LayoutKind.Explicit, Size = 0x2C40)]
    public unsafe partial struct BattleChara
    {
        [FieldOffset(0x0)] public Character Character;

        [FieldOffset(0x1A30)] public StatusManager StatusManager;

        [FieldOffset(0x1BC0)] public CastInfo SpellCastInfo;

        //[FieldOffset(0x1D30)] public fixed byte UnkBattleCharaStruct[0xF00];

        [FieldOffset(0x2C30)] public ForayInfo Foray;

        [VirtualFunction(80)]
        public partial StatusManager* GetStatusManager();

        [VirtualFunction(82)]
        public partial CastInfo* GetCastInfo();

        [VirtualFunction(86)]
        public partial ForayInfo* GetForayInfo();

        [StructLayout(LayoutKind.Explicit, Size = 0x170)]
        public struct CastInfo
        {
            [FieldOffset(0x00)] public byte IsCasting;
            [FieldOffset(0x01)] public byte Interruptible;
            [FieldOffset(0x02)] public ActionType ActionType;
            [FieldOffset(0x04)] public uint ActionID;
            [FieldOffset(0x08)] public uint Unk_08;
            [FieldOffset(0x10)] public uint CastTargetID;
            [FieldOffset(0x20)] public Vector3 CastLocation;
            [FieldOffset(0x30)] public uint Unk_30;
            [FieldOffset(0x34)] public float CurrentCastTime;
            [FieldOffset(0x38)] public float TotalCastTime;

            [FieldOffset(0x40)] public uint UsedActionId;
            [FieldOffset(0x44)] public ActionType UsedActionType;
            //[FieldOffset(0x4C)] public uint TotalActionCounter?;
            //[FieldOffset(0x50)] public uint OwnActionCounter?;

            [FieldOffset(0x58)] public fixed long ActionRecipientsObjectIdArray[32];
            [FieldOffset(0x158)] public int ActionRecipientsCount;
        }
        
        [StructLayout(LayoutKind.Explicit, Size = 2)]
        public struct ForayInfo {
            //bozja
            [FieldOffset(0x00)] public byte ResistanceRank;

            //eureka
            [FieldOffset(0x00)] public byte ElementalLevel;
            [FieldOffset(0x01)] public EurekaElement Element; //only on enemies
        }
    }
    
    public enum EurekaElement : byte {
      None = 0,
      Fire = 1,
      Ice = 2,
      Wind = 3,
      Earth = 4,
      Lightning = 5,
      Water = 6
    }
}
