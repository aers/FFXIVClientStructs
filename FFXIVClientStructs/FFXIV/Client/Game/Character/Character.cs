using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character
{
    // Client::Game::Character::Character
    //   Client::Game::Object::GameObject
    //   Client::Graphics::Vfx::VfxDataListenner

    // size = 0x1910
    // ctor E8 ? ? ? ? 0F B7 93 ? ? ? ? 45 33 C9 
    [StructLayout(LayoutKind.Explicit, Size = 0x19B0)]
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

        [FieldOffset(0x1E2)] public byte ClassJob;
        [FieldOffset(0x1E3)] public byte Level;

        [FieldOffset(0x1040)] public fixed byte EquipSlotData[4 * 10];
        //[FieldOffset(0x17B0)] public void* VfxObject;
        //[FieldOffset(0x17B8)] public void* VfxObject2;
        [FieldOffset(0x17E0)] public void* Omen;

        [FieldOffset(0x1878)] public Companion* CompanionObject; // minion
        [FieldOffset(0x1898)] public fixed byte CustomizeData[0x1A];

        [FieldOffset(0x18B2)] public fixed byte FreeCompanyTag[6];

        [FieldOffset(0x18D8)] public uint TargetObjectID;  // Whats the difference with GameObject.TargetObjectID?

        [FieldOffset(0x1940)] public uint NameID;

        [FieldOffset(0x1950)] public uint CompanionOwnerID;
        [FieldOffset(0x195C)] public ushort CurrentWorld;
        [FieldOffset(0x195E)] public ushort HomeWorld;
        [FieldOffset(0x197F)] public byte Icon;
        [FieldOffset(0x19A0)] public byte StatusFlags;
    }
}
