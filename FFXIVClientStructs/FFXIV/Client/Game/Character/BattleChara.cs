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

        [FieldOffset(0x2C30)] public byte EurekaLevel;
        [FieldOffset(0x2C31)] public EurekaElement EurekaElement;

        [VirtualFunction(82)]
        public partial CastInfo* GetCastInfo();

        [StructLayout(LayoutKind.Explicit, Size = 0x40)]
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
