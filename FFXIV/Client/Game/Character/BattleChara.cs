using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character
{
    // Client::Game::Character::BattleChara
    //   Client::Game::Character::Character
    //     Client::Game::Object::GameObject
    //     Client::Graphics::Vfx::VfxDataListenner
    // characters that fight (players, monsters, etc)

    // size = 0x2B60
    // ctor E8 ? ? ? ? 48 8B F8 EB 02 33 FF 8B 86 ? ? ? ? 
    [StructLayout(LayoutKind.Explicit, Size = 0x2B60)]
    public unsafe struct BattleChara
    {
        [FieldOffset(0x0)] public Character Character;
    }
}
