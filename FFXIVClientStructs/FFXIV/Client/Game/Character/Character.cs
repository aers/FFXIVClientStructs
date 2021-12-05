using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character
{
    // Client::Game::Character::Character
    //   Client::Game::Object::GameObject
    //   Client::Graphics::Vfx::VfxDataListenner

    // size = 0x19F0
    // ctor E8 ? ? ? ? 0F B7 93 ? ? ? ? 45 33 C9 
    [StructLayout(LayoutKind.Explicit, Size = 0x19F0)]
    public unsafe partial struct Character
    {
        [FieldOffset(0x0)] public GameObject GameObject;
        
        [FieldOffset(0x1C4)] public uint Health;
        [FieldOffset(0x1C8)] public uint MaxHealth;
        [FieldOffset(0x1CC)] public uint Mana;
        [FieldOffset(0x1D0)] public uint MaxMana;
        [FieldOffset(0x1D4)] public ushort GatheringPoints;
        [FieldOffset(0x1D6)] public ushort MaxGatheringPoints;
        [FieldOffset(0x1D8)] public ushort CraftingPoints;
        [FieldOffset(0x1DA)] public ushort MaxCraftingPoints;

        [FieldOffset(0x1E0)] public byte ClassJob;
        [FieldOffset(0x1E1)] public byte Level;

        [FieldOffset(0x230)] public uint PlayerTargetObjectID;

        [FieldOffset(0x1040)] public fixed byte EquipSlotData[4 * 10];
        //[FieldOffset(0x1840)] public void* VfxObject;
        //[FieldOffset(0x1848)] public void* VfxObject2;
        [FieldOffset(0x1870)] public void* Omen;

        [FieldOffset(0x1900)] public Companion* CompanionObject; // minion

        [FieldOffset(0xDD8)] public fixed byte CustomizeData[0x1A];

        [FieldOffset(0x1918)] public fixed byte FreeCompanyTag[6];
        [FieldOffset(0x1940)] public uint TargetObjectID;

        [FieldOffset(0x1998)] public uint NameID;

        [FieldOffset(0x19B4)] public ushort CurrentWorld;
        [FieldOffset(0x19B6)] public ushort HomeWorld;
        [FieldOffset(0x19C2)] public byte Icon;
        [FieldOffset(0x19D9)] public byte ShieldValue;
        [FieldOffset(0x19DF)] public byte StatusFlags;
        [FieldOffset(0x19A8)] public uint CompanionOwnerID;

        [MemberFunction("E8 ?? ?? ?? ?? 3B C7 74 45")]
        public partial uint GetTargetId();
    }
}
