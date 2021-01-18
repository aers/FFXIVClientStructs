using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object
{
    // Client::Game::Object::GameObject
    // base class for game objects in the world

    // size = 0x1A0
    // ctor E8 ? ? ? ? 48 8D 8E ? ? ? ? 48 89 AE ? ? ? ? 48 8B D7 
    [StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
    public unsafe struct GameObject
    {
        [FieldOffset(0x30)] public fixed byte Name[30];
        [FieldOffset(0x74)] public uint ObjectID;
        [FieldOffset(0x8C)] public byte ObjectKind;
        [FieldOffset(0xF0)] public void* DrawObject;
        [FieldOffset(0x104)] public int RenderFlags;
    }
}
