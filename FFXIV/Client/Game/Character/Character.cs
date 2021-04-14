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
    public unsafe struct Character
    {
        [FieldOffset(0x0)] public GameObject GameObject;
        [FieldOffset(0x1040)] public fixed byte EquipSlotData[4 * 10];
        [FieldOffset(0x1878)] public Companion* CompanionObject; // minion
        [FieldOffset(0x1898)] public fixed byte CustomizeData[0x1A];
        [FieldOffset(0x1950)] public uint OwnerID;
    }
}
