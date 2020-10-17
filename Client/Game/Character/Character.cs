using System.Runtime.InteropServices;

using FFXIVClientStructs.Client.Game.Object;

namespace FFXIVClientStructs.Client.Game.Character
{
    // Client::Game::Character::Character
    //   Client::Game::Object::GameObject
    //   Client::Graphics::Vfx::VfxDataListenner
    
    // size = 0x1910
    // ctor E8 ? ? ? ? 0F B7 93 ? ? ? ? 45 33 C9 
    [StructLayout(LayoutKind.Explicit, Size = 0x1910)]
    public unsafe struct Character
    {
        [FieldOffset(0x0)] public GameObject GameObject;
        [FieldOffset(0x1708)] public fixed byte EquipSlotData[4 * 10];
        [FieldOffset(0x17B8)] public fixed byte CustomizeData[0x1A];
    }
}
