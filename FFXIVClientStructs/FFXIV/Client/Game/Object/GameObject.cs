using System.Runtime.InteropServices;
using FFXIVClientStructs.Common;
using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object
{
    // Client::Game::Object::GameObject
    // base class for game objects in the world

    // size = 0x1A0
    // ctor E8 ? ? ? ? 48 8D 8E ? ? ? ? 48 89 AE ? ? ? ? 48 8B D7 
    [StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
    public unsafe partial struct GameObject
    {
        [FieldOffset(0x30)] public fixed byte Name[30];
        [FieldOffset(0x74)] public uint ObjectID;
        [FieldOffset(0x80)] public uint DataID;
        [FieldOffset(0x84)] public uint OwnerID;
        [FieldOffset(0x8C)] public byte ObjectKind;
        [FieldOffset(0x8D)] public byte SubKind;
        [FieldOffset(0xA0)] public Vector3 Position;
        [FieldOffset(0xB0)] public float Rotation;
        [FieldOffset(0xC0)] public float HitboxRadius;
        [FieldOffset(0xF0)] public void* DrawObject;
        [FieldOffset(0x104)] public int RenderFlags;
        [FieldOffset(0x148)] public void* LuaObject;

        [VirtualFunction(2)]
        public partial uint GetObjectID();

        [VirtualFunction(3)]
        public partial byte GetObjectKind();

        [VirtualFunction(5)]
        public partial bool GetIsTargetable();

        [VirtualFunction(7)]
        public partial char* GetName();

        [VirtualFunction(50)]
        public partial uint GetNpcID();
    }
}